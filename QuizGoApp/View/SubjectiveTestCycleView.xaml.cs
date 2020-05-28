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
using System.Windows.Shapes;
using QuizGoApp.ViewModel;

namespace QuizGoApp.View
{
    /// <summary>
    /// Interaction logic for SubjectiveTestCycleView.xaml
    /// </summary>
    public partial class SubjectiveTestCycleView : Window
    {
        public SubjectiveTestCycleView()
        {
            InitializeComponent();
            SubjectiveTestCyclePageViewModel subjectiveTestCyclePage = new SubjectiveTestCyclePageViewModel();
            this.DataContext = subjectiveTestCyclePage;
            if (subjectiveTestCyclePage.CloseAction == null)
                subjectiveTestCyclePage.CloseAction = new Action(() => this.Close());
        }
    }
}
