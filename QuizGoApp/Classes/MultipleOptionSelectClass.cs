using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGoApp.Classes
{
    public class MultipleOptionSelectClass : ICommonQuestion
    {
        public string Questions { get; set; }
        public string TypeOfQuestion { get; set; }
        public string[] Answers { get; set; }
    }
}
