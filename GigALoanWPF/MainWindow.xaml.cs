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
using GigALoanModel;
using System.Collections.ObjectModel;

namespace GigALoanWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<DTO_College> Colleges { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
            DataContext = this;
            Colleges = new ObservableCollection<DTO_College>(svc.GetColleges().ToList());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DTO_GigTypes obj = new DTO_GigTypes();
            obj.GigType = "Programming";
            MessageBox.Show(obj.GigType);
        }
    }
}
