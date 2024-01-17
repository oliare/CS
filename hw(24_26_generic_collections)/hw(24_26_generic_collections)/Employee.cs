using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hw_24_26_generic_collections_
{
    internal class Employee
    {
        private string fullName;
        private string position;
        private double salary;
        private string email;
        public string Email
        {
            get => email;
            set => email = string.IsNullOrEmpty(value)
                || !value.Contains('@') ? "no email" : value;
        }
        public string Name
        {
            get => fullName;
            set => fullName = string.IsNullOrEmpty(value) ? "no name" : value;
        }
        public string Position
        {
            get => position;
            set => position = string.IsNullOrEmpty(value) ? "no position" : value;
        }
        public double Salary
        {
            get => salary;
            set => salary = value > 0 ? value : 0;
        }
        public Employee(string name, string position,
            double salary, string email)
        {
            Name = name;
            Position = position;
            Salary = salary;
            Email = email;
        }
        public override string ToString()
        {
            return $"\tFull name: {fullName}\n\tPosition : {position}" +
                $"\n\tSalary: {salary}$ \n\te-mail: {email}";
        }
    }
    class Methods
    {
        List<Employee> employees = new List<Employee>();
        public Methods(List<Employee> emp)
        {
            employees = emp;
        }
        public void AddEmp(Employee employee)
        {
            employees.Add(employee);
            Console.WriteLine("* employee has been added");
        }
        public void RemoveEmp(string name)
        {
            var toRemove = employees.FirstOrDefault(x => x.Name == name);
            if (toRemove != null)
            {
                employees.Remove(toRemove);
                Console.WriteLine("* employee was removed >> " + name);
            }
            else
            {
                Console.WriteLine("! something went wrong");
            }
        }
        public void ChangeEmp(Employee e, string name, string pos,
            double salary, string email)
        {
            if (employees.IndexOf(e) != -1)
            {
                e.Name = name;
                e.Position = pos;
                e.Salary = salary;
                e.Email = email;
                Console.WriteLine($"* information about the employee has been changed >>\n" +
                    $"Full name: {name}\nPosition : {pos}\nSalary: {salary}$\ne-mail: {email}");
            }
            else { Console.WriteLine("! failed to change information"); }
        }
        public void SearchByName(string name)
        {            
            if (employees.Any(x => x.Name == name))
            {
                Console.WriteLine("* employee found >> " + name);
            }
            else
            {
                Console.WriteLine($"{name} not found");
            }
        }
        public void SortBySalary()
        {
            employees.Sort((e1, e2) => e1.Salary.CompareTo(e2.Salary));
            Console.WriteLine("* employees are sorted by salary");
        }
    }

}
