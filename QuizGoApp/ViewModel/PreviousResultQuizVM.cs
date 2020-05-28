using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using QuizGoApp.Classes;
using System.Windows;

namespace QuizGoApp.ViewModel
{
    public class PreviousResultQuizVM : INotifyPropertyChanged
    {
        private string _PreviousQuizData;

        public string PreviousQuizData
        {
            get { return _PreviousQuizData; }
            set { _PreviousQuizData = value; OnPropertyChanged("PreviousQuizData"); }
        }

        public PreviousResultQuizVM()
        {
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\PreviousQuizzes\\" + CommonData.AddUserName.Select(p => p).FirstOrDefault() + "Result.txt"))
            {
                PreviousQuizData = File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "\\PreviousQuizzes\\" + CommonData.AddUserName.Select(p => p).FirstOrDefault() + "Result.txt");
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
