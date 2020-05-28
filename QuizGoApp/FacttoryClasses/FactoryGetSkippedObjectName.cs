using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using QuizGoApp.View;

namespace QuizGoApp.FacttoryClasses
{
    public class FactoryGetSkippedObjectName
    {
        public Window commonQuestion;

        public Window GetClassObject(string TypeofQuestion,bool firstquestionflag)
        {
            if (TypeofQuestion.Equals("Subjective"))
                commonQuestion = new SkipSubjectiveTestCycleView(firstquestionflag);
            else if (TypeofQuestion.Equals("MultipleChoice"))
                commonQuestion = new SkipMultipleChoiceView(firstquestionflag);
            else if (TypeofQuestion.Equals("MultipleOptionSelect"))
                commonQuestion = new SkipMultipleOptionView(firstquestionflag);

            return commonQuestion;
        }
    }
}
