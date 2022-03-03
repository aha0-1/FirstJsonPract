using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> studentlist;
        public MainWindow()
        {
            
            InitializeComponent();
            string filename = "students.json";//automatically loads list
            if (File.Exists(filename))
            {
                string studentLongStr=File.ReadAllText(filename);
                this.studentlist = JsonSerializer.Deserialize<List<Student>>(studentLongStr);

                for(int i = 0; i < this.studentlist.Count; i++)//continuous count of variables
                {
                    Student.totalGrade += studentlist[i].grade;
                    Student.totalWeight+=studentlist[i].weight;
                }
                double averageWeight=Student.totalWeight/this.studentlist.Count;
                double avergeGrade = Student.totalWeight / this.studentlist.Count;

                this.AvgGrTB.Text=avergeGrade.ToString("F2");
                this.AvgWeightTB.Text = averageWeight.ToString("F2");
            }
            else
            {
                this.studentlist = new List<Student>();
            }
            this.studentlist = new List<Student>();
            this.StudentRosterLB.ItemsSource=studentlist;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id=this.IDTB.Text;
            string n = this.NameTB.Text;
            double w = Convert.ToDouble(this.WeightTB.Text);
            double g = Convert.ToDouble(this.Exam1TB.Text);


            Student student = new Student(id, n, w, g);
            this.studentlist.Add(student);
            this.StudentRosterLB.Items.Refresh();

            Student.totalWeight += w;
            Student.totalGrade += g;

            double averageWeight = Student.totalWeight / this.studentlist.Count;//defines
            double averageGrade = Student.totalGrade / this.studentlist.Count;

            this.AvgGrTB.Text = averageGrade.ToString("F2");
            this.AvgWeightTB.Text = averageWeight.ToString("F2");

           

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializerOptions opt = new JsonSerializerOptions();
            opt.WriteIndented = true;
            string stuLongStr = JsonSerializer.Serialize(this.studentlist, opt);
            string filename = "students.json";
            File.WriteAllText(filename, stuLongStr);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string filename = "students.json";
            string stuLongStr=File.ReadAllText(filename);//read from json
            this.studentlist=JsonSerializer.Deserialize<List<Student>>(stuLongStr);
            this.StudentRosterLB.ItemsSource = this.studentlist;
            Student.totalWeight = 0;
            Student.totalGrade = 0;

            for (int i = 0; i < this.studentlist.Count; i++)//continuous count of variables
            {
                Student.totalGrade += studentlist[i].grade;
                Student.totalWeight += studentlist[i].weight;
            }
            double averageWeight = Student.totalWeight / this.studentlist.Count;
            double avergeGrade = Student.totalWeight / this.studentlist.Count;

            this.AvgGrTB.Text = avergeGrade.ToString("F2");
            this.AvgWeightTB.Text = averageWeight.ToString("F2");
        }
    }
}
