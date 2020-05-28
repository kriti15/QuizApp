using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace QuizGoApp.Model
{
    public class TestCyclePageModel : INotifyPropertyChanged
    {

        private string _Questions;

        public string Questions
        {
            get { return _Questions; }
            set { _Questions = value; OnPropertyChanged("Questions"); }
        }

        private string _Answer1;

        public string Answer1
        {
            get { return _Answer1; }
            set { _Answer1 = value; OnPropertyChanged("Answer1"); }
        }

        private string _Answer2;

        public string Answer2
        {
            get { return _Answer2; }
            set { _Answer2 = value; OnPropertyChanged("Answer2"); }
        }

        private string _Answer3;

        public string Answer3
        {
            get { return _Answer3; }
            set { _Answer3 = value; OnPropertyChanged("Answer3"); }
        }
        private string _Answer4;

        public string Answer4
        {
            get { return _Answer4; }
            set { _Answer4 = value; OnPropertyChanged("Answer4"); }
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
        private bool _Answer1IsChecked;

        public bool Answer1IsChecked
        {
            get { return _Answer1IsChecked; }
            set { _Answer1IsChecked = value; OnPropertyChanged("Answer1IsChecked"); }
        }
        private bool _Answer2IsChecked;

        public bool Answer2IsChecked
        {
            get { return _Answer2IsChecked; }
            set { _Answer2IsChecked = value; OnPropertyChanged("Answer2IsChecked"); }
        }
        private bool _Answer3IsChecked;

        public bool Answer3IsChecked
        {
            get { return _Answer3IsChecked; }
            set { _Answer3IsChecked = value; OnPropertyChanged("Answer3IsChecked"); }
        }
        private bool _Answer4IsChecked;

        public bool Answer4IsChecked
        {
            get { return _Answer4IsChecked; }
            set { _Answer4IsChecked = value; OnPropertyChanged("Answer4IsChecked"); }
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
