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
    /// Логика взаимодействия для RykP.xaml
    /// </summary>
    public partial class RykP : Page
    {

        public RykP()
        {
            InitializeComponent();
            ClassV.Class2.ent = new hosEntities3();
        }

        private void RykT_Loaded(object sender, RoutedEventArgs e)
        {
            RykT.ItemsSource = ClassV.Class2.ent.Ryk.ToList();
            RykT.SelectedIndex = 0;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassV.Class1.one.Navigate(new YonPage.OsnP());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClassV.Class1.one.Navigate(new YonPage.NewRyk(null));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < RykT.SelectedItems.Count; i++)
            {
                Ryk deliv = RykT.SelectedItems[i] as Ryk;
                ClassV.Class2.ent.Ryk.Remove(deliv);
            }
            ClassV.Class2.ent.SaveChanges();
            MessageBox.Show("Преподаватель удалён из базы данных!!!");
            NavigationService.Refresh();
        }
    }
}
