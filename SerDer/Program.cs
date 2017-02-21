using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerDer
{
    [Serializable]
    class Student
    {
        public string name;
        public int age;
        public double gpa;

        public Student(string n, int a, double num)
        {
            name = n;
            age = a;
            gpa = num;
        }
        public Student()
        {

        }
        public void setInfo()
        {
            name = "BATS";
            age = 54;
            gpa = 4.0;
        }
        public override string ToString()
        {
            return " Who?C--- " + name + " Years --- " + age + " ---  GPA:" + gpa; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            serialize();
            deserialize();
           
            Console.ReadKey();
        }
        static void serialize()
        {
            
            /*Student[] student = new Student[3];
            students[0] = new Student("Batman", 19, 4.0);
            students[1] = new Student("Sups", 18, 3.5);
            students[2] = new Student("Wonderwoman", 20, 3.7);

             */
            BinaryFormatter binF = new BinaryFormatter();
            FileStream fs = new FileStream("test.ser", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Student s = new Student();
            s.setInfo();

            try
            {    
                binF.Serialize(fs, s);
            }
            catch
            {
                Console.Write("Error");
            }
                fs.Close();
            
        }
        static void deserialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("test.ser", FileMode.Open, FileAccess.Read);

            try
            {
                Student s = bf.Deserialize(fs) as Student;
                Console.Write(s);
                Console.ReadKey();
            }
            catch
            {
                Console.Write("Error again");
            }
            
               fs.Close();
               
        }
    }
}
