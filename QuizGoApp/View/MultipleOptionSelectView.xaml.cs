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
    /// Interaction logic for MultipleOptionSelectView.xaml
    /// </summary>
    public partial class MultipleOptionSelectView : Window
    {
        public MultipleOptionSelectView()
        {
            InitializeComponent();
            MultipleOptionSelectVM multipleOptionSelect = new MultipleOptionSelectVM();
            this.DataContext = multipleOptionSelect;
            if (multipleOptionSelect.CloseAction == null)
                multipleOptionSelect.CloseAction = new Action(() => this.Close());
        }
    }
}
