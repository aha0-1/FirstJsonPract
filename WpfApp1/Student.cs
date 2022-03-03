using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Student
    {
        public static double totalWeight = 0;//shared by all Student object
        public static double totalGrade = 0;
        public string id { get; set; }
        public string name { get; set; }
        public double weight { get; set; }
        public double grade { get; set; }

        public Student()
        {

        }

        public Student(string id, string n, double w, double g)
        {
            this.id = id;
            this.name = n;
            this.weight = w;
            this.grade = g;
        }
        public override string ToString()
        {
            string message = string.Format("ID:{0}\nName:{1}", this.id, this.name);
            return message;
        }
    }
}
