using QuizGoApp.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuizGoApp.Model;
using QuizGoApp.Classes;
using QuizGoApp.View;
using System.Windows;
using System.Windows.Input;
using QuizGoApp.FacttoryClasses;

namespace QuizGoApp.ViewModel
{
    public class SkipMultipleChoiceVM : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        RelayCommand _PreviousClick;

        RelayCommand _NextClick;
        RelayCommand _SubmitClick;

        TestCyclePageModel TestCyclePage;

        Random random = new Random();
        int number = 0;
        string typeofquestion = string.Empty;
        #region Properties
        public string Questions
        {
            get { return TestCyclePage.Questions; }
            set { TestCyclePage.Questions = value; OnPropertyChanged("Questions"); }
        }
        public string Answer1
        {
            get { return TestCyclePage.Answer1; }
            set { TestCyclePage.Answer1 = value; OnPropertyChanged("Answer1"); }
        }
        public string Answer2
        {
            get { return TestCyclePage.Answer2; }
            set { TestCyclePage.Answer2 = value; OnPropertyChanged("Answer2"); }
        }
        public string Answer3
        {
            get { return TestCyclePage.Answer3; }
            set { TestCyclePage.Answer3 = value; OnPropertyChanged("Answer3"); }
        }
        public string Answer4
        {
            get { return TestCyclePage.Answer4; }
            set { TestCyclePage.Answer4 = value; OnPropertyChanged("Answer4"); }
        }
        public bool PreviousClickEnabled
        {
            get { return TestCyclePage.PreviousClickEnabled; }
            set { TestCyclePage.PreviousClickEnabled = value; OnPropertyChanged("PreviousClickEnabled"); }
        }
        public bool NextClickEnabled
        {
            get { return TestCyclePage.NextClickEnabled; }
            set { TestCyclePage.NextClickEnabled = value; OnPropertyChanged("NextClickEnabled"); }
        }
        public bool SubmitClickEnabled
        {
            get { return TestCyclePage.SubmitClickEnabled; }
            set { TestCyclePage.SubmitClickEnabled = value; OnPropertyChanged("SubmitClickEnabled"); }
        }
        public bool Answer1IsChecked
        {
            get { return TestCyclePage.Answer1IsChecked; }
            set { TestCyclePage.Answer1IsChecked = value; OnPropertyChanged("Answer1IsChecked"); }
        }
        public bool Answer2IsChecked
        {
            get { return TestCyclePage.Answer2IsChecked; }
            set { TestCyclePage.Answer2IsChecked = value; OnPropertyChanged("Answer2IsChecked"); }
        }
        public bool Answer3IsChecked
        {
            get { return TestCyclePage.Answer3IsChecked; }
            set { TestCyclePage.Answer3IsChecked = value; OnPropertyChanged("Answer3IsChecked"); }
        }
        public bool Answer4IsChecked
        {
            get { return TestCyclePage.Answer4IsChecked; }
            set { TestCyclePage.Answer4IsChecked = value; OnPropertyChanged("Answer4IsChecked"); }
        }
        public string TimerText
        {
            get { return TestCyclePage.TimerText; }
            set { TestCyclePage.TimerText = value; OnPropertyChanged("TimerText"); }
        }
        public Visibility SkipVisibility
        {
            get { return TestCyclePage.SkipVisibility; }
            set { TestCyclePage.SkipVisibility = value; OnPropertyChanged("SkipVisibility"); }
        }
        public Visibility PreviousVisibility
        {
            get { return TestCyclePage.PreviousVisibility; }
            set { TestCyclePage.PreviousVisibility = value; OnPropertyChanged("PreviousVisibility"); }
        }
        #endregion Properties

        public SkipMultipleChoiceVM(bool firstquestionflag)
        {
            try
            {
                TestCyclePage = new TestCyclePageModel();

                if (firstquestionflag)
                {
                    CommonData.QuestionAnswersSkipListItems.Add(CommonData.SkipListItems[0]);
                    Questions = CommonData.QuestionAnswersSkipListItems[CommonData.count].Questions;
                    Answer1 = CommonData.QuestionAnswersSkipListItems[CommonData.count].Answers[0].Trim('*');
                    Answer2 = CommonData.QuestionAnswersSkipListItems[CommonData.count].Answers[1].Trim('*');
                    Answer3 = CommonData.QuestionAnswersSkipListItems[CommonData.count].Answers[2].Trim('*');
                    Answer4 = CommonData.QuestionAnswersSkipListItems[CommonData.count].Answers[3].Trim('*');
                }
                else
                {
                    Questions = CommonData.QuestionAnswersSkipListItems[CommonData.count].Questions;
                    Answer1 = CommonData.QuestionAnswersSkipListItems[CommonData.count].Answers[0].Trim('*');
                    Answer2 = CommonData.QuestionAnswersSkipListItems[CommonData.count].Answers[1].Trim('*');
                    Answer3 = CommonData.QuestionAnswersSkipListItems[CommonData.count].Answers[2].Trim('*');
                    Answer4 = CommonData.QuestionAnswersSkipListItems[CommonData.count].Answers[3].Trim('*');
                }

                NextClickEnabled = true;
                SubmitClickEnabled = false;
                SkipVisibility = Visibility.Collapsed;
                PreviousVisibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                throw;
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

        private void NextButtonClick()
        {
            try
            {
                int index = 0;
                if (CommonData.count >= CommonData.SkipListItems.Count - 1)
                {
                    if (Answer1IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            index = CommonData.answerlist.FindIndex(p => p.Questions == Questions);
                            CommonData.answerlist[index] = new MultipleChoiceQuestionsClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.SkipListItems[CommonData.count].TypeOfQuestion,
                                Answers = new string[1] { Answer1 }
                            };
                        }

                    }
                    else if (Answer2IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            index = CommonData.answerlist.FindIndex(p => p.Questions == Questions);
                            CommonData.answerlist[index] = new MultipleChoiceQuestionsClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.SkipListItems[CommonData.count].TypeOfQuestion,
                                Answers = new string[1] { Answer2 }
                            };
                        }
                    }
                    else if (Answer3IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            index = CommonData.answerlist.FindIndex(p => p.Questions == Questions);
                            CommonData.answerlist[index] = new MultipleChoiceQuestionsClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.SkipListItems[CommonData.count].TypeOfQuestion,
                                Answers = new string[1] { Answer3 }
                            };
                        }
                    }
                    else
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            index = CommonData.answerlist.FindIndex(p => p.Questions == Questions);
                            CommonData.answerlist[index] = new MultipleChoiceQuestionsClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.SkipListItems[CommonData.count].TypeOfQuestion,
                                Answers = new string[1] { Answer4 }
                            };
                        }
                    }
                    NextClickEnabled = false;
                    SubmitClickEnabled = true;
                }
                else
                {
                    if (Answer1IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            index = CommonData.answerlist.FindIndex(p => p.Questions == Questions);
                            CommonData.answerlist[index] = new MultipleChoiceQuestionsClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.SkipListItems[CommonData.count].TypeOfQuestion,
                                Answers = new string[1] { Answer1 }
                            };
                        }
                        Answer1IsChecked = false;
                    }
                    else if (Answer2IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            index = CommonData.answerlist.FindIndex(p => p.Questions == Questions);
                            CommonData.answerlist[index] = new MultipleChoiceQuestionsClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.SkipListItems[CommonData.count].TypeOfQuestion,
                                Answers = new string[1] { Answer2 }
                            };
                        }
                        Answer2IsChecked = false;
                    }
                    else if (Answer3IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            index = CommonData.answerlist.FindIndex(p => p.Questions == Questions);
                            CommonData.answerlist[index] = new MultipleChoiceQuestionsClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.SkipListItems[CommonData.count].TypeOfQuestion,
                                Answers = new string[1] { Answer3 }
                            };
                        }
                        Answer3IsChecked = false;
                    }
                    else if (Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            index = CommonData.answerlist.FindIndex(p => p.Questions == Questions);
                            CommonData.answerlist[index] = new MultipleChoiceQuestionsClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.SkipListItems[CommonData.count].TypeOfQuestion,
                                Answers = new string[1] { Answer4 }
                            };
                        }
                        Answer4IsChecked = false;
                    }
                    else if (!Answer1IsChecked && !Answer2IsChecked && !Answer3IsChecked && !Answer4IsChecked)
                    {
                        MessageBox.Show(Properties.Resources.NO_OPTION_SELECTED_ERROR, Properties.Resources.APPLICATION_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    number = random.Next(1, CommonData.SkipListItems.Count);
                    number = CommonData.CheckNumberSkip(number);
                    CommonData.count++;
                    typeofquestion = CommonData.SkipListItems[number].TypeOfQuestion;
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
            catch (Exception ex)
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

            catch (Exception ex)
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
