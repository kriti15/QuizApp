using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuizGoApp.Command;
using System.Windows.Input;
using QuizGoApp.View;

namespace QuizGoApp.ViewModel
{
    public class BasicInstructionPageViewModel : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }

        private string _InstructionText;

        public string InstructionText
        {
            get { return _InstructionText; }
            set { _InstructionText = value; OnPropertyChanged("InstructionText"); }
        }

        RelayCommand _StartQuizButtonClick;

        public BasicInstructionPageViewModel()
        {
            InstructionText = Properties.Resources.INSTRUCTION_TEXT + "\n" + Properties.Resources.INSTRUCTION_TEXT1;
        }

        public ICommand StartQuizButtonClick
        {
            get
            {
                if (_StartQuizButtonClick == null)
                    _StartQuizButtonClick = new RelayCommand(() => StartQuizClick());

                return _StartQuizButtonClick;
            }
        }
        private void StartQuizClick()
        {
            MultipleChoiceTestCycleViewxaml multiplechoice = new MultipleChoiceTestCycleViewxaml(true);
            CloseAction();
            multiplechoice.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
