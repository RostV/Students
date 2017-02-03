using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Students.Classes
{
    public class ApplicationContext : DbContext, INotifyPropertyChanged
    {

        public ApplicationContext() : base("DefaultConnection")
        {
        }

        public DbSet<Student> StudentsDB { get; set; }

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                if (students != value)
                {
                    students = value;
                    OnPropertyChanged("Students");
                }
            }
        }

        private Student moreInfoSt;
        public Student MoreInfoSt
        {
            get
            {
                return moreInfoSt;
            }
            set
            {
                if (moreInfoSt != value)
                {
                    moreInfoSt = value;
                    OnPropertyChanged("MoreInfoSt");
                }
            }
        }

        public void LoadData()
        {
            Students = new ObservableCollection<Student>(StudentsDB.ToList());
            MoreInfoSt = new Student();
        }

        public void AddStudent(Student st)
        {
            StudentsDB.Add(st);
            Students.Add(st);
            SaveChanges();
        }

        public void ChangeStudent(Student st, Student changedST)
        {
            st = StudentsDB.Find(changedST.ID);
            if (st != null)
            {
                st.Name = changedST.Name;
                st.SurName = changedST.SurName;
                st.MiddleName = changedST.MiddleName;
                st.Gender = changedST.Gender;
                st.Birthday = changedST.Birthday;
                st.PhoneNumber = changedST.PhoneNumber;
                st.Email = changedST.Email;

                Entry(st).State = EntityState.Modified;
                SaveChanges();
            }
        }

        public void DeleteStudent(Student st)
        {
            StudentsDB.Remove(st);
            Students.Remove(st);
            SaveChanges();
        }

        public void Sorting()
        {
            for (int i = 0; i < Students.Count; i++) 
            {
                for (int j = 0; j < Students.Count - i - 1; j++) 
                {
                    int k = 0;
                    while (k < Students[j].SurName.Count() && k < Students[j + 1].SurName.Count())
                    {
                        if (Students[j].SurName[k] > Students[j + 1].SurName[k])
                        {
                            Student st = Students[j];
                            Students[j] = Students[j + 1];
                            Students[j + 1] = st;
                            break;
                        }
                        if (Students[j].SurName[k] == Students[j + 1].SurName[k])
                        {
                            k++;
                        }
                        else break;
                    }
                }
            }
        }

        public void makeInfoForStudent(Student st)
        {
            MoreInfoSt = st;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
