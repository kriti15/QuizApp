using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using QuizGoApp.Classes;

namespace QuizGoApp.View
{
    /// <summary>
    /// Interaction logic for MultipleOptionUserControl.xaml
    /// </summary>
    public partial class MultipleOptionUserControl : UserControl
    {
        DispatcherTimer _timer;
        public MultipleOptionUserControl()
        {
            InitializeComponent();

            CommonData._timer.Stop();
            CommonData._timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                if (CommonData._time == TimeSpan.Zero)
                {
                    CommonData._timer.Stop();
                }
                else
                    timertextblock.Text = CommonData._time.ToString();
                CommonData._time = CommonData._time.Add(TimeSpan.FromSeconds(-1));
            }, App.Current.Dispatcher);

            CommonData._timer.Start();

            //DispatcherTimer messageTimer = new DispatcherTimer();
            //messageTimer.Tick += new EventHandler(messageTimer_Tick);
            //messageTimer.Interval = new TimeSpan(0, 0, 1);
            //messageTimer.Start();
        }
        //void messageTimer_Tick(object sender, EventArgs e)
        //{
        //    timertextblock.Text = DateTime.Now.ToString();
        //}
    }
}
