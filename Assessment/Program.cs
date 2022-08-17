using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assessment
{
    public class program
    {
        static void Main(String[] args)
        {
            string filepath = @"C:\Users\meet.popat\Program.txt";
            //List<string> lines = File.ReadAllLines(filepath).ToList();
            //foreach (string Lines in lines)
            //{
            //    Console.WriteLine(Lines);
            //}
            //lines.Add("05              John            10th A");
            //lines.Add("06              Soham           10th B");
            //File.WriteAllLines(filepath, lines);
            //Console.ReadLine();

            List<Teacher> teacher = new List<Teacher>();
            List<string> lines = File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                Teacher newTeacher = new Teacher();
                newTeacher.ID = entries[0];
                newTeacher.Name = entries[1];
                newTeacher.Class = entries[2];
                teacher.Add(newTeacher);
            }

            Read newread = new Read();
            Write newwrite = new Write();
            Update newupdate = new Update();
            int option = 1;
            while (option!=0)
            {
                Console.WriteLine("\n********************");
                Console.WriteLine(" 1. READ THE DATA \n 2. WRITE THE DATA \n 3. UPDATE THE DATA \n 4. EXIT");
                Console.WriteLine("********************");
                Console.WriteLine("\n ENTER YOUR CHOICE");
                option = Convert.ToInt32(Console.ReadLine());
                
                if (option!=4)
                {
                    if (option==1)
                    {
                        newread.readEntries(filepath, teacher);
                    }
                    else if (option==2)
                    {
                        newwrite.writeEntries(filepath, teacher);
                    }
                    else if (option==3)
                    {
                        newupdate.updateEntries(filepath, teacher);
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Choice");
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
                
            }
        }
    }
    public class Read
    {
        public void readEntries(string filepath, List<Teacher> teacher)
        {
            Console.WriteLine("\n ID \tName \tClass");
            foreach (var teacherdetail in teacher)
            {
                Console.WriteLine($"{teacherdetail.ID} \t{teacherdetail.Name} \t{teacherdetail.Class}");

            }
        }
    }

    public class Write
    {
        public void writeEntries(string filepath, List<Teacher> teacher)
        {
            Console.Write("\n Enter ID: ");
            string newID = Console.ReadLine();
            Console.Write("\n Enter Name: ");
            string newName = Console.ReadLine();
            Console.Write("\n Enter Class: ");
            string newClass = Console.ReadLine();

            teacher.Add(new Teacher { ID = newID, Name = newName, Class= newClass });
            List<string> output = new List<string>();
            foreach (var teacherdetail in teacher)
            {
                output.Add($"{teacherdetail.ID},{teacherdetail.Name},{teacherdetail.Class}");

            }
            File.WriteAllLines(filepath, output);
            Console.WriteLine();
        }
    }

    public class Update
    {
        public void updateEntries(string filepath, List<Teacher> teacher)
        {
            Console.Write(" Enter ID: ");
            string selectID = Console.ReadLine();
            Teacher editTeacher = teacher.Where(i => i.ID == selectID).FirstOrDefault();
            if (editTeacher == null)
            {
                Console.WriteLine("\n Enter correct ID");
            }
            else
            {
                Console.Write("\n Enter New Name: ");
                string editName = Console.ReadLine();
                Console.Write("\n Enter New Class: ");
                string editClass = Console.ReadLine();

                editTeacher.Name = editName;
                editTeacher.Class = editClass;

                File.Delete(filepath);
                List<string> output = new List<string>();
                foreach (var teacherdetail in teacher)
                {
                    output.Add($"{teacherdetail.ID},{teacherdetail.Name},{teacherdetail.Class}");

                }
                File.AppendAllLines(filepath, output);

            }
        }
    }
}
