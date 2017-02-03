using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Students.Classes
{
    public class Student : INotifyPropertyChanged
    {
        public int ID { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string surName;
        public string SurName
        {
            get
            {
                return surName;
            }

            set
            {
                surName = value;
                OnPropertyChanged("SurName");
            }
        }

        private string middleName;
        public string MiddleName
        {
            get
            {
                return middleName;
            }

            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        private string gender;
        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private string birthday;
        public string Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
