using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace QuizGoApp.Classes
{
    public class CommonData
    {
        public static List<ICommonQuestion> QuestionAnswerList = new List<ICommonQuestion>();
        public static List<ICommonQuestion> answerlist = new List<ICommonQuestion>();
        public static List<ICommonQuestion> SkipListItems = new List<ICommonQuestion>();
        public static List<ICommonQuestion> QuestionAnswersSkipListItems = new List<ICommonQuestion>();
        public static List<string> AddUserName = new List<string>();
        public static List<int> listofrandomnumbers = new List<int>();
        public static List<int> Skiplistofrandomnumbers = new List<int>();
        public static Dictionary<string,string> StoreResultData = new Dictionary<string, string>();
        public static int i = 0;
        public static bool previousclickflag = false;
        public static int count = 0;

        public static TimeSpan _time = TimeSpan.FromMinutes(10);
        public static DispatcherTimer _timer;

        //public static string GetTimer()
        //{
        //    _time = TimeSpan.FromMinutes(10);

        //    _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
        //    {
        //        if (_time == TimeSpan.Zero)
        //        {
        //            _timer.Stop();
        //        }
        //        _time = _time.Add(TimeSpan.FromSeconds(-1));
        //    }, App.Current.Dispatcher);

        //    _timer.Start();
        //    return _time.ToString();
        //}

        static Random  random = new Random();
        public static int CheckNumber(int num)
        {
            if (!listofrandomnumbers.Contains(num))
            {
                listofrandomnumbers.Add(num);
                return num;
            }
            else
            {
                num = random.Next(1, 18);
                return CheckNumber(num);
            }

        }

        public static int CheckNumberSkip(int num)
        {
            if (!Skiplistofrandomnumbers.Contains(num))
            {
                Skiplistofrandomnumbers.Add(num);
                return num;
            }
            else
            {
                num = random.Next(1, SkipListItems.Count);
                return CheckNumberSkip(num);
            }

        }

    }
}
