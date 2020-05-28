using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGoApp.Classes
{
    public interface ICommonQuestion
    {
        string Questions { get; set; }
        string TypeOfQuestion { get; set; }

        string[] Answers { get; set; }
    }
}
