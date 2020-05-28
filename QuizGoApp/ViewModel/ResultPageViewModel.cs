using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizGoApp.Model;
using System.ComponentModel;
using QuizGoApp.Classes;
using QuizGoApp.Command;
using System.Windows.Input;
using Newtonsoft.Json;
using System.IO;
using QuizGoApp.View;

namespace QuizGoApp.ViewModel
{
    public class ResultPageViewModel :INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        ResultPageModel ResultPage;
        int count = 0;
        int multioptioncount = 0;
        RelayCommand _CloseQuizClick;
        RelayCommand _PreviousQuizClick;
        RelayCommand _PreviousQuizResultClick;
        #region Properties
        public string DateofExamination
        {
            get { return ResultPage.DateofExamination; }
            set { ResultPage.DateofExamination = value; OnPropertyChanged("DateofExamination"); }
        }
        public string ScoreInPercentage
        {
            get { return ResultPage.ScoreInPercentage; }
            set { ResultPage.ScoreInPercentage = value; OnPropertyChanged("ScoreInPercentage"); }
        }
        public string PassFail
        {
            get { return ResultPage.PassFail; }
            set { ResultPage.PassFail = value; OnPropertyChanged("PassFail"); }
        }
        #endregion Properties
        public ResultPageViewModel()
        {
            ResultPage = new ResultPageModel();
            CalculateResult();
        }
        public ICommand CloseQuizClick
        {
            get
            {
                if (_CloseQuizClick == null)
                    _CloseQuizClick = new RelayCommand(() => CloseClick());
                return _CloseQuizClick;
            }
        }
        public ICommand PreviousQuizClick
        {
            get
            {
                if (_PreviousQuizClick == null)
                    _PreviousQuizClick = new RelayCommand(() => PreviousClick());
                return _PreviousQuizClick;
            }
        }
        public ICommand PreviousQuizResultClick
        {
            get
            {
                if (_PreviousQuizResultClick == null)
                    _PreviousQuizResultClick = new RelayCommand(() => PreviousResultClick());
                return _PreviousQuizResultClick;
            }
        }
        private void CloseClick()
        {
            CloseAction();
        }
        private void CalculateResult()
        {
            try
            {
                for (int i = 0; i < CommonData.answerlist.Count; i++)
                {
                    if (CommonData.answerlist[i].TypeOfQuestion == "Subjective")
                    {
                        if (!string.IsNullOrEmpty(CommonData.answerlist[i].Answers[0]))
                            count++;
                    }
                    else if (CommonData.answerlist[i].TypeOfQuestion == "MultipleChoice")
                    {
                        for (int j = 0; j < CommonData.QuestionAnswerList[i].Answers.Count(); j++)
                        {
                            if (CommonData.QuestionAnswerList[i].Answers[j].StartsWith("*"))
                            {
                                if (CommonData.answerlist[i].Answers[0].Equals(CommonData.QuestionAnswerList[i].Answers[j].Trim('*')))
                                    count++;
                            }
                        }
                    }
                    else if (CommonData.answerlist[i].TypeOfQuestion == "MultipleOptionSelect")
                    {
                        for (int j = 0; j < CommonData.QuestionAnswerList[i].Answers.Count(); j++)
                        {
                            if (CommonData.QuestionAnswerList[i].Answers[j].StartsWith("*"))
                            {
                                if (CommonData.answerlist[i].Answers[0].Equals(CommonData.QuestionAnswerList[i].Answers[j].Trim('*')))
                                    multioptioncount++;
                            }
                        }
                        if (multioptioncount >= 1)
                        {
                            count++;
                            multioptioncount = 0;
                        }
                    }
                }

                DateofExamination = DateTime.Now.ToString();
                ScoreInPercentage = ((count * 100) / 10).ToString() + "%";
                if (count > 5)
                    PassFail = "Pass";
                else
                    PassFail = "Fail";
                CommonData.StoreResultData.Add("Date of Examination", DateofExamination);
                CommonData.StoreResultData.Add("Score In Percentagen", ScoreInPercentage);
                CommonData.StoreResultData.Add("Pass/Fail", PassFail);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private void PreviousClick()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string path = System.IO.Directory.GetCurrentDirectory() + "\\PreviousQuizzes\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            PreviousQuizDataView previousQuiz = new PreviousQuizDataView();
            if (File.Exists(path + CommonData.AddUserName.Select(p => p).FirstOrDefault() + ".txt"))
            {
                previousQuiz.ShowDialog();
            }
            else
            {
                for (int i = 0; i < CommonData.answerlist.Count; i++)
                {
                    keyValuePairs.Add(CommonData.answerlist[i].Questions, string.Join(",", CommonData.answerlist[i].Answers));
                }

                using (StreamWriter file = new StreamWriter(path + CommonData.AddUserName.Select(p => p).FirstOrDefault() + ".txt"))
                    foreach (var entry in keyValuePairs)
                        file.WriteLine("{0} - {1}", entry.Key, entry.Value);
            }
            
        }
        private void PreviousResultClick()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\PreviousQuizzes\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            PreviousQuizResultView previousQuiz = new PreviousQuizResultView();
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\PreviousQuizzes\\" + CommonData.AddUserName.Select(p => p).FirstOrDefault() + "Result.txt"))
            {
                previousQuiz.ShowDialog();
            }
            using (StreamWriter file = new StreamWriter(path + CommonData.AddUserName.Select(p => p).FirstOrDefault() + "Result.txt"))
                foreach (var entry in CommonData.StoreResultData)
                    file.WriteLine("{0} - {1}", entry.Key, entry.Value);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
