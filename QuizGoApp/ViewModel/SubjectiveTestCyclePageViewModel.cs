using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizGoApp.Classes;
using QuizGoApp.Model;
using System.ComponentModel;
using QuizGoApp.Command;
using System.Windows.Input;
using QuizGoApp.View;
using System.Timers;
using System.Windows.Threading;
using System.Windows;
using QuizGoApp.FacttoryClasses;

namespace QuizGoApp.ViewModel
{
    public class SubjectiveTestCyclePageViewModel : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }

        SubjectiveModel subjectiveModel;

        string typeofquestion = string.Empty;
        RelayCommand _PreviousClick;
        RelayCommand _SkipClick;
        RelayCommand _NextClick;
        RelayCommand _SubmitClick;

        int number = 0;
        int counter = 60;
        int count = 0;
        
        Random random = new Random();
        

        #region Properties
        public string Questions
        {
            get { return subjectiveModel.Questions; }
            set { subjectiveModel.Questions = value; OnPropertyChanged("Questions"); }
        }
       
        public string Answer
        {
            get { return subjectiveModel.Answer; }
            set { subjectiveModel.Answer = value; OnPropertyChanged("Answer"); }
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

       
        public ICommand PreviousClick
        {
            get
            {
                if (_PreviousClick == null)
                    _PreviousClick = new RelayCommand(() => PreviousButtonClick());
                return _PreviousClick;
            }
        }
        public ICommand SkipClick
        {
            get
            {
                if (_SkipClick == null)
                    _SkipClick = new RelayCommand(() => SkipButtonClick());
                return _SkipClick;
            }
        }
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
        public SubjectiveTestCyclePageViewModel()
        {
            try
            {
                subjectiveModel = new SubjectiveModel();

                if (CommonData.previousclickflag)
                {
                    Questions = CommonData.answerlist[CommonData.i].Questions;
                    Answer = CommonData.answerlist[CommonData.i].Answers[0];
                }
                else
                {
                    Questions = CommonData.QuestionAnswerList[CommonData.i].Questions;
                    Answer = string.Empty;
                }

                if (CommonData.QuestionAnswerList[0].Questions.Equals(Questions))
                    PreviousClickEnabled = false;
                else
                    PreviousClickEnabled = true;
                NextClickEnabled = true;
                SubmitClickEnabled = false;
                SkipVisibility = Visibility.Visible;
                PreviousVisibility = Visibility.Visible;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
      
        private void PreviousButtonClick()
        {
            try
            {
                CommonData.i--;
                CommonData.previousclickflag = true;
                FactoryGetObjectName factory = new FactoryGetObjectName();
                Window window = factory.GetClassObject(CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion);
                CloseAction();
                window.ShowDialog();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        private void SkipButtonClick()
        {
            CommonData.SkipListItems.Add((SubjectiveClass)CommonData.QuestionAnswerList[CommonData.i]);
            NextButtonClick();
        }
        private void NextButtonClick()
        {
            try
            {
                if (CommonData.QuestionAnswerList.Count >= 10)
                {
                    if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                    {
                        CommonData.answerlist.Add(new SubjectiveClass
                        {
                            Questions = Questions,
                            TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                            Answers = new string[1] { Answer }
                        });
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
                            CommonData.answerlist.Add(new SubjectiveClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[1] { Answer }
                            });
                        }

                    }
                    else
                    {
                        MessageBox.Show("The answer cannot be blank please enter something", Properties.Resources.APPLICATION_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    number = random.Next(1, 17);
                    number = CommonData.CheckNumber(number);
                    CommonData.i++;
                    typeofquestion = QuestionAnswerCollectionClass.commonQuestions[number].TypeOfQuestion;
                    typeofquestion = RecursiveMethod(typeofquestion);

                    FactoryGetObjectName factory = new FactoryGetObjectName();
                    Window window = factory.GetClassObject(typeofquestion);
                    CloseAction();
                    window.ShowDialog();
                }
            }
            catch(Exception ex)
            {

            }
        }
        private string RecursiveMethod(string typeofquestion)
        {
            try
            {
                if (typeofquestion.Equals("Subjective"))
                {
                    if (MultipleChoiceTestCycleVM.numberofsubjectivequestions != 2)
                    {
                        CommonData.QuestionAnswerList.Insert(CommonData.i, (SubjectiveClass)QuestionAnswerCollectionClass.commonQuestions[number]);
                        MultipleChoiceTestCycleVM.numberofsubjectivequestions++;
                        return typeofquestion;
                    }
                    else
                    {
                        number = CommonData.CheckNumber(number);
                        typeofquestion = QuestionAnswerCollectionClass.commonQuestions[number].TypeOfQuestion;
                        return RecursiveMethod(typeofquestion);
                    }
                }
                if (typeofquestion.Equals("MultipleChoice"))
                {
                    if (MultipleChoiceTestCycleVM.numberofmultichoicequestions != 5)
                    {
                        CommonData.QuestionAnswerList.Insert(CommonData.i, (MultipleChoiceQuestionsClass)QuestionAnswerCollectionClass.commonQuestions[number]);
                        MultipleChoiceTestCycleVM.numberofmultichoicequestions++;
                        return typeofquestion;
                    }
                    else
                    {
                        number = CommonData.CheckNumber(number);
                        typeofquestion = QuestionAnswerCollectionClass.commonQuestions[number].TypeOfQuestion;
                        return RecursiveMethod(typeofquestion);
                    }
                }
                if (typeofquestion.Equals("MultipleOptionSelect"))
                {
                    if (MultipleChoiceTestCycleVM.numberofmultioptionquestions != 3)
                    {
                        CommonData.QuestionAnswerList.Insert(CommonData.i, (MultipleOptionSelectClass)QuestionAnswerCollectionClass.commonQuestions[number]);
                        MultipleChoiceTestCycleVM.numberofmultioptionquestions++;
                        return typeofquestion;
                    }
                    else
                    {
                        number = CommonData.CheckNumber(number);
                        typeofquestion = QuestionAnswerCollectionClass.commonQuestions[number].TypeOfQuestion;
                        return RecursiveMethod(typeofquestion);
                    }

                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return typeofquestion;
        }
        private void SubmitButtonClick()
        {
            try
            {
                if (CommonData.SkipListItems.Count > 0 && !CommonData._time.ToString().Equals("-00:00:01"))
                {
                    typeofquestion = CommonData.SkipListItems[0].TypeOfQuestion;
                    FactoryGetSkippedObjectName factory1 = new FactoryGetSkippedObjectName();
                    Window window = factory1.GetClassObject(typeofquestion, true);
                    CloseAction();
                    window.ShowDialog();
                }
                else
                {
                    ResultPageView resultPage = new ResultPageView();
                    CloseAction();
                    resultPage.ShowDialog();
                }
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
