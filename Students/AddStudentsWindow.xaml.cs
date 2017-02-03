using Students.Classes;
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
using System.Windows.Shapes;

namespace Students
{
    /// <summary>
    /// Логика взаимодействия для AddStudentsWindow.xaml
    /// </summary>
    public partial class AddStudentsWindow : Window
    {
        public Student Student { get; private set; }

        public AddStudentsWindow(Student st, string title)
        {
            InitializeComponent();
            Student = st;
            Title = title;
            DataContext = Student;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (surNameTBox.Text == "" || MiddleNameTBox.Text == "" || NameTBox.Text == "")
            {
                if (surNameTBox.Text == "")
                    surNameTB.Foreground = Brushes.Red;
                else
                    surNameTB.Foreground = Brushes.Black;
                if  (MiddleNameTBox.Text == "")
                    MiddleNameTB.Foreground = Brushes.Red;
                else
                    MiddleNameTB.Foreground = Brushes.Black;
                if  (NameTBox.Text == "")
                    NameTB.Foreground = Brushes.Red;
                else
                    NameTB.Foreground = Brushes.Black;
            }
            else
                DialogResult = true;
        }
    }
}
