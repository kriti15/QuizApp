using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuizGoApp.Classes;
using System.IO;
using System.Windows;

namespace QuizGoApp.ViewModel
{
    public class PreviousQuizDataVM : INotifyPropertyChanged
    {
        private string _PreviousQuizData;

        public string PreviousQuizData
        {
            get { return _PreviousQuizData; }
            set { _PreviousQuizData = value; OnPropertyChanged("PreviousQuizData"); }
        }

        public PreviousQuizDataVM()
        {
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\PreviousQuizzes\\" + CommonData.AddUserName.Select(p => p).FirstOrDefault() + ".txt"))
            {
                PreviousQuizData = File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "\\PreviousQuizzes\\" + CommonData.AddUserName.Select(p => p).FirstOrDefault() + ".txt");
            }
            else
            {
                MessageBox.Show("There is no previous quiz for current user", Properties.Resources.APPLICATION_NAME, MessageBoxButton.OK, MessageBoxImage.Information);
               
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
