using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGoApp.Classes
{
    public class QuestionAnswerCollectionClass
    {
        public static List<ICommonQuestion> commonQuestions = new List<ICommonQuestion>();

        static QuestionAnswerCollectionClass()
        {
            commonQuestions.Add(
                new MultipleChoiceQuestionsClass
                {
                    Questions = "Who is the owner of Marvel Studios",
                    TypeOfQuestion = "MultipleChoice",
                    Answers = new string[4] { "Warner Bros", "*Walt Disney", "21st Century Fox", "Universal Studios" }
                });

            commonQuestions.Add(
               new MultipleOptionSelectClass
               {
                   Questions = "Which of the follow are fruits?",
                   TypeOfQuestion = "MultipleOptionSelect",
                   Answers = new string[4] { "*Apples", "*Oranges", "Potato", "None" }
               });

            commonQuestions.Add(
               new SubjectiveClass
               {
                   Questions = "What is used in pencils?",
                   TypeOfQuestion = "Subjective",
                   Answers = new string[1] { "" }
               });

            commonQuestions.Add(
               new MultipleChoiceQuestionsClass
               {
                   Questions = "Pythagoras was first to ____ the universal validity of geometrical theorem.",
                   TypeOfQuestion = "MultipleChoice",
                   Answers = new string[4] { "give", "*prove", "both", "None of the above" }
               });

            commonQuestions.Add(
               new MultipleOptionSelectClass
               {
                   Questions = "Which of the follow are Shahid Kapoor Movies?",
                   TypeOfQuestion = "MultipleOptionSelect",
                   Answers = new string[4] { "*Kabir Singh", "Ishq", "*Kismat Konnection", "All" }
               });

            commonQuestions.Add(
                new SubjectiveClass
                {
                    Questions = "Entomology is the science that studies",
                    TypeOfQuestion = "Subjective",
                    Answers = new string[1] { "" }
                });

            commonQuestions.Add(
               new MultipleChoiceQuestionsClass
               {
                   Questions = "FFC stands for",
                   TypeOfQuestion = "MultipleChoice",
                   Answers = new string[4] { "Foreign Finance Corporation", "*Film Finance Corporation", "Federation of Football Council", "None of the above" }
               });

            commonQuestions.Add(
               new MultipleChoiceQuestionsClass
               {
                   Questions = "The ozone layer restricts",
                   TypeOfQuestion = "MultipleChoice",
                   Answers = new string[4] { "Visible light", "Infrared radiation", "X-rays and gamma rays", "*Ultraviolet radiation" }
               });

            commonQuestions.Add(
               new MultipleOptionSelectClass
               {
                   Questions = "Which of the following are Companies?",
                   TypeOfQuestion = "MultipleOptionSelect",
                   Answers = new string[4] { "*Google", "Chair", "*Microsoft", "*TCS" }
               });

            commonQuestions.Add( new MultipleChoiceQuestionsClass
               {
                   Questions = "Golden Temple, Amritsar is India's",
                   TypeOfQuestion = "MultipleChoice",
                   Answers = new string[4] { "*largest Gurdwara", "oldest Gurudwara", "Both option A and B are correct", "None of the above" }
               });

            commonQuestions.Add(new MultipleChoiceQuestionsClass
               {
                   Questions = "Brass gets discoloured in air because of the presence of which of the following gases in air?",
                   TypeOfQuestion = "MultipleChoice",
                   Answers = new string[4] { "Oxygen", "*Hydrogen sulphide", "Carbon dioxide", "Nitrogen" }
               });

            commonQuestions.Add(new MultipleOptionSelectClass
            {
                Questions = "Look at this series: 7, 10, 8, 11, 9, 12, ... What number should come next?",
                TypeOfQuestion = "MultipleOptionSelect",
                Answers = new string[4] { "7", "*10", "12", "13" }
            });

            commonQuestions.Add(new MultipleChoiceQuestionsClass
            {
                Questions = "Which of the following metals forms an amalgam with other metals?",
                TypeOfQuestion = "MultipleChoice",
                Answers = new string[4] { "Tin", "*Mercury", "Lead", "Zinc" }
            });

            commonQuestions.Add(new MultipleOptionSelectClass
            {
                Questions = "Look at this series: 36, 34, 30, 28, 24, ... What number should come next?",
                TypeOfQuestion = "MultipleOptionSelect",
                Answers = new string[4] { "20", "*22", "23", "26" }
            });

            //commonQuestions.Add(new MultipleChoiceQuestionsClass
            //{
            //    Questions = "Garampani sanctuary is located at",
            //    TypeOfQuestion = "MultipleChoice",
            //    Answers = new string[4] { "Junagarh, Gujarat", "*Diphu, Assam", "Kohima, Nagaland", "Gangtok, Sikkim" }
            //});

            //commonQuestions.Add(new MultipleOptionSelectClass
            //{
            //    Questions = "An accurate clock shows 8 o'clock in the morning. Through how may degrees will the hour hand rotate when the clock shows 2 o'clock in the afternoon?",
            //    TypeOfQuestion = "MultipleOptionSelect",
            //    Answers = new string[4] { "144°", "150°", "168°", "*180°" }
            //});

            commonQuestions.Add(new MultipleChoiceQuestionsClass
            {
                Questions = "For which of the following disciplines is Nobel Prize awarded?",
                TypeOfQuestion = "MultipleChoice",
                Answers = new string[4] { "Physics and Chemistry", "Physiology or Medicine", "Literature, Peace and Economics", "*All of the above" }
            });

            commonQuestions.Add(new MultipleOptionSelectClass
            {
                Questions = "Odometer is to mileage as compass is to",
                TypeOfQuestion = "MultipleOptionSelect",
                Answers = new string[4] { "speed", "hiking", "needle", "*direction" }
            });


            commonQuestions.Add(new MultipleChoiceQuestionsClass
            {
                Questions = "Hitler party which came into power in 1933 is known as",
                TypeOfQuestion = "MultipleChoice",
                Answers = new string[4] { "Labour Party", "*Nazi Party", "Ku-Klux-Klan", "Democratic Party" }
            });

            commonQuestions.Add(new MultipleOptionSelectClass
            {
                Questions = "Window is to pane as book is to",
                TypeOfQuestion = "MultipleOptionSelect",
                Answers = new string[4] { "novel", "glass", "cover", "*page" }
            });
        }
    }
}
