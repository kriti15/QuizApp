using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using QuizGoApp.View;

namespace QuizGoApp.FacttoryClasses
{
    public class FactoryGetObjectName
    {
        public Window commonQuestion;

        public Window GetClassObject(string TypeofQuestion)
        {
            if (TypeofQuestion.Equals("Subjective"))
                commonQuestion = new SubjectiveTestCycleView();
            else if (TypeofQuestion.Equals("MultipleChoice"))
                commonQuestion = new MultipleChoiceTestCycleViewxaml(false);
            else if (TypeofQuestion.Equals("MultipleOptionSelect"))
                commonQuestion = new MultipleOptionSelectView();

            return commonQuestion;
        }
    }
}
