using QuizGoApp.Command;
using QuizGoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using QuizGoApp.Classes;
using QuizGoApp.View;
using QuizGoApp.FacttoryClasses;

namespace QuizGoApp.ViewModel
{
    public class MultipleOptionSelectVM : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        RelayCommand _PreviousClick;
        RelayCommand _SkipClick;
        RelayCommand _NextClick;
        RelayCommand _SubmitClick;
        int count = 0;

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
        public MultipleOptionSelectVM()
        {
            try
            {
                TestCyclePage = new TestCyclePageModel();

                Questions = CommonData.QuestionAnswerList[CommonData.i].Questions;
                Answer1 = CommonData.QuestionAnswerList[CommonData.i].Answers[0].Trim('*');
                Answer2 = CommonData.QuestionAnswerList[CommonData.i].Answers[1].Trim('*');
                Answer3 = CommonData.QuestionAnswerList[CommonData.i].Answers[2].Trim('*');
                Answer4 = CommonData.QuestionAnswerList[CommonData.i].Answers[3].Trim('*');
                if (CommonData.answerlist.Count > 0 && CommonData.previousclickflag == true)
                {
                    for (int j = 0; j < CommonData.answerlist[CommonData.i].Answers.Count(); j++)
                    {
                        if (CommonData.answerlist[CommonData.i].Answers[j].Equals(Answer1))
                            Answer1IsChecked = true;
                        else if (CommonData.answerlist[CommonData.i].Answers[j].Equals(Answer2))
                            Answer2IsChecked = true;
                        else if (CommonData.answerlist[CommonData.i].Answers[j].Equals(Answer3))
                            Answer3IsChecked = true;
                        else if (CommonData.answerlist[CommonData.i].Answers[j].Equals(Answer4))
                            Answer4IsChecked = true;
                    }
                    CommonData.previousclickflag = false;
                }
                if (CommonData.QuestionAnswerList[0].Questions.Equals(Questions))
                    PreviousClickEnabled = false;
                else
                    PreviousClickEnabled = true;
                NextClickEnabled = true;
                SubmitClickEnabled = false;
                PreviousVisibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
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
            catch (Exception)
            {

                throw;
            }
        }
        private void SkipButtonClick()
        {
            CommonData.SkipListItems.Add((MultipleOptionSelectClass)CommonData.QuestionAnswerList[CommonData.i]);
            NextButtonClick();
        }
        private void NextButtonClick()
        {
            try
            {
                if (CommonData.QuestionAnswerList.Count >= 10)
                {
                    if (Answer1IsChecked && Answer2IsChecked && Answer3IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[3] { Answer1, Answer2, Answer3 }
                            });
                        }
                    }
                    else if (Answer1IsChecked && Answer3IsChecked && Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[3] { Answer1, Answer3, Answer4 }
                            });
                        }
                    }
                    else if (Answer2IsChecked && Answer3IsChecked && Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[3] { Answer2, Answer3, Answer4 }
                            });
                        }
                    }
                    else if (Answer1IsChecked && Answer2IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer1, Answer2 }
                            });
                        }
                    }
                    else if (Answer1IsChecked && Answer3IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer1, Answer3 }
                            });
                        }
                    }
                    else if (Answer1IsChecked && Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer1, Answer4 }
                            });
                        }
                    }
                    else if (Answer2IsChecked && Answer3IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer2, Answer3 }
                            });
                        }
                    }
                    else if (Answer2IsChecked && Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer2, Answer4 }
                            });
                        }
                    }
                    else if (Answer3IsChecked && Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer3, Answer4 }
                            });
                        }
                    }
                    else if (Answer1IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[1] { Answer1 }
                            });
                        }
                    }
                    else if (Answer2IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[1] { Answer2 }
                            });
                        }
                    }
                    else if (Answer3IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[1] { Answer3 }
                            });
                        }
                    }
                    else if (Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[1] { Answer4 }
                            });
                        }
                    }
                    PreviousClickEnabled = false;
                    NextClickEnabled = false;
                    SubmitClickEnabled = true;
                }
                else
                {
                    if (Answer1IsChecked && Answer2IsChecked && Answer3IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[3] { Answer1, Answer2, Answer3 }
                            });
                        }
                    }
                    else if (Answer1IsChecked && Answer3IsChecked && Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[3] { Answer1, Answer3, Answer4 }
                            });
                        }
                    }
                    else if (Answer2IsChecked && Answer3IsChecked && Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[3] { Answer2, Answer3, Answer4 }
                            });
                        }
                    }
                    else if (Answer1IsChecked && Answer2IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer1, Answer2 }
                            });
                        }
                    }
                    else if (Answer1IsChecked && Answer3IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer1, Answer3 }
                            });
                        }
                    }
                    else if (Answer1IsChecked && Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer1, Answer4 }
                            });
                        }
                    }
                    else if (Answer2IsChecked && Answer3IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer2, Answer3 }
                            });
                        }
                    }
                    else if (Answer2IsChecked && Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer2, Answer4 }
                            });
                        }
                    }
                    else if (Answer3IsChecked && Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[2] { Answer3, Answer4 }
                            });
                        }
                    }
                    else if (Answer1IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[1] { Answer1 }
                            });
                        }
                    }
                    else if (Answer2IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[1] { Answer2 }
                            });
                        }
                    }
                    else if (Answer3IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[1] { Answer3 }
                            });
                        }
                    }
                    else if (Answer4IsChecked)
                    {
                        if (!CommonData.answerlist.Select(p => p.Questions).Contains(Questions))
                        {
                            CommonData.answerlist.Add(new MultipleOptionSelectClass
                            {
                                Questions = Questions,
                                TypeOfQuestion = CommonData.QuestionAnswerList[CommonData.i].TypeOfQuestion,
                                Answers = new string[1] { Answer4 }
                            });
                        }
                    }
                    else if (!Answer1IsChecked && !Answer2IsChecked && !Answer3IsChecked && !Answer4IsChecked)
                    {
                        MessageBox.Show(Properties.Resources.NO_OPTION_SELECTED_ERROR, Properties.Resources.APPLICATION_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    Answer4IsChecked = false;
                    Answer3IsChecked = false;
                    Answer2IsChecked = false;
                    Answer1IsChecked = false;

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
                throw;
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
            catch (Exception)
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
