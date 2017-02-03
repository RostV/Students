using Students.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace Students
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> FindStudents = new ObservableCollection<Student>();
        ApplicationContext db;
        bool selected = false;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.LoadData();
            DataContext = db;
        }

        private void StudentsList_Selected(object sender, RoutedEventArgs e)
        {
            if (!selected)
            {
                HelpingLabel.Text = "Дополнительная информация";
                MoreInfoSP.Visibility = Visibility.Visible;
                selected = true;
            }
            db.makeInfoForStudent(StudentsList.SelectedItem as Student);
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudentsWindow addStudentsWindow = new AddStudentsWindow(new Student(), "Добавление студента");
            if (addStudentsWindow.ShowDialog() == true)
            {
                Student student = addStudentsWindow.Student;
                db.AddStudent(student);
            }
        }

        private void ChangeStudent_Click(object sender, RoutedEventArgs e)
        {
            if (!selected) return;

            Student student = StudentsList.SelectedItem as Student;

            AddStudentsWindow addStudentWindow = new AddStudentsWindow(new Student
            {
                ID = student.ID,
                Name = student.Name,
                SurName = student.SurName,
                MiddleName = student.MiddleName,
                Gender = student.Gender,
                Birthday = student.Birthday,
                PhoneNumber = student.PhoneNumber,
                Email = student.Email
            }, "Изменение информации");

            if (addStudentWindow.ShowDialog() == true)
            {
                db.ChangeStudent(student, addStudentWindow.Student);
            }
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (!selected) return;
            db.DeleteStudent(StudentsList.SelectedItem as Student);
            if (StudentsList.Items.Count == 0)
            {
                selected = false;
                HelpingLabel.Text = "Выберите или создайте студента";
            }

        }

        private void Sorting_Click(object sender, RoutedEventArgs e)
        {
            db.Sorting();
        }

        private void FindTBChanged(object sender, TextChangedEventArgs e)
        {
           if (FindTB.Text.Count() < 3)
            {
                StudentsList.ItemsSource = db.Students;
            }
         
            if (FindTB.Text.Count() > 2)
            {
                List<Student> stList = db.Students.Where(st =>
                st.Name.ToLower().Contains(FindTB.Text.ToLower()) ||
                st.SurName.ToLower().Contains(FindTB.Text.ToLower()) ||
                st.MiddleName.ToLower().Contains(FindTB.Text.ToLower())
                ).ToList();

                StudentsList.ItemsSource = stList;            
            }
        }
    }
}