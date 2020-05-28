using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuizGoApp.Command;
using System.Windows.Input;
using QuizGoApp.View;
using System.Windows;
using QuizGoApp.Classes;

namespace QuizGoApp.ViewModel
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        RelayCommand _SubmitButtonClick;
        public Action CloseAction { get; set; }

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged("UserName"); }
        }
        public LoginPageViewModel()
        {

        }
        public ICommand SubmitButtonClick
        {
            get
            {
                if (_SubmitButtonClick == null)
                    _SubmitButtonClick = new RelayCommand(() => ButtonClick());

                return _SubmitButtonClick;
            }
        }
        private void ButtonClick()
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                CommonData.AddUserName.Add(UserName);
            }
            else
            {
                MessageBox.Show(Properties.Resources.USERNAME_NOT_ENTERED_ERROR, Properties.Resources.APPLICATION_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            BasicInstructionsView basicInstructionsView = new BasicInstructionsView();
            CloseAction();
            basicInstructionsView.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
