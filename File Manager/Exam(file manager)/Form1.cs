using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using TreeView = System.Windows.Forms.TreeView;
//using ListView = System.Windows.Forms.ListView;

namespace Exam_file_manager_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ShowDrivers()
        {
            treeView1.BeginUpdate();
            string[] drives = Directory.GetLogicalDrives();
            foreach (var drive in drives)
            {
                TreeNode tn = new TreeNode(drive);
                treeView1.Nodes.Add(tn);
                AddDirs(tn);
            }
            treeView1.EndUpdate();
        }
        public void ShowFiles()
        {
            if (treeView1.SelectedNode != null)
            {
                DirectoryInfo di = new DirectoryInfo(treeView1.SelectedNode.FullPath);
                FileInfo[] files = { };
                ListViewItem item;

                listView1.Items.Clear();
                listView1.SmallImageList = imageList1;
                if (di.Exists)
                    files = di.GetFiles();

                listView1.BeginUpdate();
                foreach (FileInfo file in files)
                {
                    Icon iconf;
                    item = new ListViewItem(file.Name);
                    listView1.Items.Add(item);
                    iconf = SystemIcons.WinLogo;

                    if (!imageList1.Images.ContainsKey(file.Extension))
                    {
                        iconf = Icon.ExtractAssociatedIcon(file.FullName);
                        imageList1.Images.Add(file.Extension, iconf);
                    }
                    item.ImageKey = file.Extension;
                    item.SubItems.Add(FileSize((ulong)file.Length));
                    item.SubItems.Add(file.LastWriteTime.ToShortDateString());
                    item.SubItems.Add(file.Extension);
                }
                listView1.EndUpdate();
            }
            else
            {
                MessageBox.Show("Selected directory is empty");
            }
        }
        private string FileSize(ulong bytes)
        {
            string[] sizes = { "bytes", "MB", "KB", "GB", "TB" };
            int converted = 0;

            while (bytes >= 1024 && converted < sizes.Length - 1)
            {
                converted++;
                bytes = bytes / 1024;
            }
            return $"{bytes} {sizes[converted]}";
        }

        public void AddDirs(TreeNode tn)
        {
            string path = tn.FullPath;
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] dirs = { };
            try
            {
                if (di.Exists)
                    dirs = di.GetDirectories();
            }
            catch { return; }

            foreach (DirectoryInfo dir in dirs)
            {
                TreeNode tnd = new TreeNode(dir.Name);
                tn.Nodes.Add(tnd);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowDrivers();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //textBox1.Text = e.Node.FullPath;
            //ShowFiles();
            var di = (DirectoryInfo)e.Node.Tag;

            MessageBox.Show(di.FullName);
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeView1.BeginUpdate();
            foreach (TreeNode tn in e.Node.Nodes)
            {
                AddDirs(tn);
            }
            treeView1.EndUpdate();
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var fdialog = new OpenFileDialog
                {
                    InitialDirectory = treeView1.SelectedNode?.FullPath,
                };

                if (fdialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        textBox1.Text = File.ReadAllText(fdialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening the file: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("No item to open");
            }
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Clipboard.SetText(listView1.SelectedItems[0].ToString());
                MessageBox.Show("Path copied to clipboard");
            }
            else
            {
                MessageBox.Show("No item to copy");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete this file?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(listView1.SelectedItems[0].Text);
                    //Delete(listView1);
                }
            }
            else
            {
                MessageBox.Show("Select one item");
            }
        }

        private static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destinationDir);
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
  

        private void AddDirectories(TreeNodeCollection nodes, string path)
        {
            try
            {
                string[] directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    TreeNode node = new TreeNode(Path.GetFileName(directory));
                    nodes.Add(node);
                    AddDirectories(node.Nodes, directory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding directories: {ex.Message}");
            }
        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNew("file");
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNew("folder");
        }


        private void CreateNew(string type)
        {
            string create = Interaction.InputBox($"Enter the {type} name:", $"Create {type}", "");

            if (!string.IsNullOrEmpty(create))
            {
                string newPath = Path.Combine(Directory.GetCurrentDirectory(), create);

                try
                {
                    if (type == "File")
                    {
                        File.Create(newPath).Close();
                    }
                    else if (type == "Folder")
                    {
                        Directory.CreateDirectory(newPath);
                    }

                    treeView1.Nodes.Clear();
                    ShowDrivers();
                    ShowFiles();
                    MessageBox.Show($"{type} '{create}' created successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating {type.ToLower()}: {ex.Message}");
                }
            }
        }
        /*
        private string FilePath;
        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    DialogResult result = folderBrowserDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string destinationFolder = folderBrowserDialog.SelectedPath;

                        foreach (ListViewItem selectedItem in listView1.SelectedItems)
                        {
                            string sourcePath = Path.Combine(FilePath, selectedItem.Text);
                            string destinationPath = Path.Combine(destinationFolder, selectedItem.Text);

                            try
                            {
                                Console.WriteLine($"Moving: {sourcePath} to {destinationPath}");
                                FileAttributes attr = File.GetAttributes(sourcePath);

                                if (attr.HasFlag(FileAttributes.Directory))
                                {
                                    Directory.Move(sourcePath, destinationPath);
                                }
                                else
                                {
                                    File.Move(sourcePath, destinationPath);
                                }
                                Console.WriteLine("Move operation successful");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error moving file/folder: {ex.Message}");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Files/folders wasn`t moved");
                    }
                }
            }
            else
            {
                MessageBox.Show("No item to move");
            }
        }
        */
    }
}
