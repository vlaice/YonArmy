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

namespace Van_Dip.YonPage
{
    /// <summary>
    /// Логика взаимодействия для OsnP.xaml
    /// </summary>
    public partial class OsnP : Page
    {
        public OsnP()
        {
            InitializeComponent();
            ClassV.Class2.ent = new hosEntities3();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassV.Class1.one.Navigate(new YonPage.YTable());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClassV.Class1.one.Navigate(new YonPage.YNew(null));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ClassV.Class1.one.Navigate(new YonPage.RykP());
        }
    }
}
