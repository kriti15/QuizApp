using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QuizGoApp.Model
{
    public class ResultPageModel : INotifyPropertyChanged
    {
        private string _DateofExamination;

        public string DateofExamination
        {
            get { return _DateofExamination; }
            set { _DateofExamination = value; OnPropertyChanged("DateofExamination"); }
        }
        private string _ScoreInPercentage;

        public string ScoreInPercentage
        {
            get { return _ScoreInPercentage; }
            set { _ScoreInPercentage = value; OnPropertyChanged("ScoreInPercentage"); }
        }

        private string _PassFail;

        public string PassFail
        {
            get { return _PassFail; }
            set { _PassFail = value; OnPropertyChanged("PassFail"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
