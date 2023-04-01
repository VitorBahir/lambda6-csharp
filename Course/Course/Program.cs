using System.IO;
using System.Linq;
using System.Globalization;
using Course.Entities;
using System.Xml.Linq;


namespace Course
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            Console.Write("Enter full file path:");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double salaryComp = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(",");
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                        list.Add(new Employee(name, email, salary));
                    }
                }
                Console.WriteLine($"Email of people whose salary is more than {salaryComp}:");

                var emails = list.Where(e => e.Salary > salaryComp).Select(e => e.Email);
                foreach (string email in emails)
                {
                    Console.WriteLine(email);
                }

                var salarySum = list.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + salarySum);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}