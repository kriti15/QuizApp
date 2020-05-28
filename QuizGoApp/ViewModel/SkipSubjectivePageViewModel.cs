using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuizGoApp.Classes;
using QuizGoApp.Command;
using QuizGoApp.Model;
using System.ComponentModel;
using QuizGoApp.View;
using System.Windows;
using QuizGoApp.FacttoryClasses;

namespace QuizGoApp.ViewModel
{
    public class SkipSubjectivePageViewModel : INotifyPropertyChanged
    {
        RelayCommand _NextClick;
        RelayCommand _SubmitClick;
        SubjectiveModel subjectiveModel;
        public Action CloseAction { get; set; }
       
        int number = 0;
        Random random = new Random();

        #region Properties
        public string Questions
        {
            get { return subjectiveModel.Questions; }
            set { subjectiveModel.Questions = value; OnPropertyChanged("Questions"); }
        }
        public bool PreviousClickEnabled
        {
            get { return subjectiveModel.PreviousClickEnabled; }
            set { subjectiveModel.PreviousClickEnabled = value; OnPropertyChanged("PreviousClickEnabled"); }
        }
        public bool NextClickEnabled
        {
            get { return subjectiveModel.NextClickEnabled; }
            set { subjectiveModel.NextClickEnabled = value; OnPropertyChanged("NextClickEnabled"); }
        }
        public bool SubmitClickEnabled
        {
            get { return subjectiveModel.SubmitClickEnabled; }
            set { subjectiveModel.SubmitClickEnabled = value; OnPropertyChanged("SubmitClickEnabled"); }
        }
        public string TimerText
        {
            get { return subjectiveModel.TimerText; }
            set { subjectiveModel.TimerText = value; OnPropertyChanged("TimerText"); }
        }
        public string Answer
        {
            get { return subjectiveModel.Answer; }
            set { subjectiveModel.Answer = value; OnPropertyChanged("Answer"); }
        }

        public Visibility SkipVisibility
        {
            get { return subjectiveModel.SkipVisibility; }
            set { subjectiveModel.SkipVisibility = value; OnPropertyChanged("SkipVisibility"); }
        }
        public Visibility PreviousVisibility
        {
            get { return subjectiveModel.PreviousVisibility; }
            set { subjectiveModel.PreviousVisibility = value; OnPropertyChanged("PreviousVisibility"); }
        }
        #endregion Properties

        public ICommand NextClick
        {
            get
            {
                if (_NextClick == null)
                    _NextClick = new RelayCommand(() => NextButtonClick());
                return _NextClick;
            }
        }
        public ICommand SubmitClick
        {
            get
            {
                if (_SubmitClick == null)
                    _SubmitClick = new RelayCommand(() => SubmitButtonClick());
                return _SubmitClick;
            }
        }
        public SkipSubjectivePageViewModel(bool firstquestionflag)
        {
            try
            {
                subjectiveModel = new SubjectiveModel();

                if (firstquestionflag)
                {
                    CommonData.QuestionAnswersSkipListItems.Add(CommonData.SkipListItems[0]);
                    Questions = CommonData.QuestionAnswersSkipListItems[CommonData.count].Questions;
                    Answer = string.Empty;
                }
                else
                {
                    Questions = CommonData.QuestionAnswersSkipListItems[CommonData.count].Questions;
                    Answer = string.Empty;
                }
                NextClickEnabled = true;
                SubmitClickEnabled = false;
                SkipVisibility = Visibility.Collapsed;
                PreviousVisibility = Visibility.Collapsed;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private void NextButtonClick()
        {
            try
            {
                int index = 0;
                if (CommonData.count >= CommonData.SkipListItems.Count - 1)
                {
                    if (CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                    {
                        index = CommonData.answerlist.FindIndex(p => p.Questions == Questions);
                        CommonData.answerlist[index] = new SubjectiveClass
                        {
                            Questions = Questions,
                            TypeOfQuestion = CommonData.SkipListItems[CommonData.count].TypeOfQuestion,
                            Answers = new string[1] { Answer }
                        };
                    }
                    PreviousClickEnabled = false;
                    NextClickEnabled = false;
                    SubmitClickEnabled = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(Answer))
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            index = CommonData.answerlist.FindIndex(p => p.Questions == Questions);
                            CommonData.answerlist[index] = new SubjectiveClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.SkipListItems[CommonData.count].TypeOfQuestion,
                                Answers = new string[1] { Answer }
                            };
                        }
                    }
                    else
                    {
                        MessageBox.Show("The answer cannot be blank please enter something", QuizGoApp.Properties.Resources.APPLICATION_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    int number = random.Next(1, CommonData.SkipListItems.Count);
                    number = CommonData.CheckNumberSkip(number);
                    CommonData.count++;
                    string typeofquestion = CommonData.SkipListItems[number].TypeOfQuestion;
                    if (typeofquestion.Equals("Subjective"))
                        CommonData.QuestionAnswersSkipListItems.Insert(CommonData.count, (SubjectiveClass)CommonData.SkipListItems[number]);
                    else if (typeofquestion.Equals("MultipleChoice"))
                        CommonData.QuestionAnswersSkipListItems.Insert(CommonData.count, (MultipleChoiceQuestionsClass)CommonData.SkipListItems[number]);
                    else
                        CommonData.QuestionAnswersSkipListItems.Insert(CommonData.count, (MultipleOptionSelectClass)CommonData.SkipListItems[number]);
                    FactoryGetSkippedObjectName factory1 = new FactoryGetSkippedObjectName();
                    Window window = factory1.GetClassObject(typeofquestion, false);
                    CloseAction();
                    window.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
       
        private void SubmitButtonClick()
        {
            try
            {
                ResultPageView resultPage = new ResultPageView();
                CloseAction();
                resultPage.ShowDialog();
            }
            catch(Exception ex)
            {
                throw;
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

