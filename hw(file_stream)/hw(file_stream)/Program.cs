using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace hw_file_stream_
{
    internal class Program
    {
        class AppSettingHelper
        {
            public ConsoleColor FGColor { get; set; }
            public ConsoleColor BGColor { get; set; }
            public string Title { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public void Writer(string fname)
            {
                try
                {

                using (BinaryWriter bw = new BinaryWriter(new FileStream(fname, FileMode.Create, FileAccess.Write)))
                {
                    bw.Write((int)FGColor);
                    bw.Write((int)BGColor);
                    bw.Write(Title);
                    bw.Write(Height);
                    bw.Write(Width);
                }
                }catch (Exception ex)
                {
                    Console.WriteLine($"Impossible to WRITE information: {ex}");
                }
            }
            public void Reader(string fname)
            {
                try
                {
                    using (BinaryReader br = new BinaryReader(new FileStream(fname, FileMode.Open, FileAccess.Read)))
                    {
                        FGColor = (ConsoleColor)br.ReadInt32();
                        BGColor = (ConsoleColor)br.ReadInt32();
                        Title = br.ReadString();
                        Width = br.ReadInt32();
                        Height = br.ReadInt32();

                        Console.WriteLine($"FG color: {FGColor}\nBG color: {BGColor}\nTitle: {Title}" +
                            $"\nWidth: {Width}\nHeight: {Height}");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Impossible to READ file: {ex}");
                }
            }
        }
        static void Main(string[] args)
        {
            string file = "hw.dat";
            AppSettingHelper app = new AppSettingHelper();
            app.BGColor = Console.BackgroundColor;
            app.FGColor = Console.ForegroundColor;
            app.Title = "titleee";
            app.Width = Console.WindowWidth;
            app.Height = Console.WindowHeight;

            app.Writer(file);
            app.Reader(file);
            Console.WriteLine();
        }
    }
}
