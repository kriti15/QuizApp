using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace QuizGoApp.Model
{
    public class SubjectiveModel : INotifyPropertyChanged
    {
        private string _Questions;

        public string Questions
        {
            get { return _Questions; }
            set { _Questions = value; OnPropertyChanged("Questions"); }
        }

        private string _Answer;

        public string Answer
        {
            get { return _Answer; }
            set { _Answer = value; OnPropertyChanged("Answer"); }
        }
        private bool _PreviousClickEnabled;

        public bool PreviousClickEnabled
        {
            get { return _PreviousClickEnabled; }
            set { _PreviousClickEnabled = value; OnPropertyChanged("PreviousClickEnabled"); }
        }
        private bool _NextClickEnabled;

        public bool NextClickEnabled
        {
            get { return _NextClickEnabled; }
            set { _NextClickEnabled = value; OnPropertyChanged("NextClickEnabled"); }
        }
        private bool _SubmitClickEnabled;

        public bool SubmitClickEnabled
        {
            get { return _SubmitClickEnabled; }
            set { _SubmitClickEnabled = value; OnPropertyChanged("SubmitClickEnabled"); }
        }
        private string _TimerText;

        public string TimerText
        {
            get { return _TimerText; }
            set { _TimerText = value; OnPropertyChanged("TimerText"); }
        }
        private Visibility _SkipVisibility;

        public Visibility SkipVisibility
        {
            get { return _SkipVisibility; }
            set { _SkipVisibility = value; OnPropertyChanged("SkipVisibility"); }
        }
        private Visibility _PreviousVisibility;

        public Visibility PreviousVisibility
        {
            get { return _PreviousVisibility; }
            set { _PreviousVisibility = value; OnPropertyChanged("PreviousVisibility"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
