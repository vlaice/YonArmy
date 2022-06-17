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
    /// Логика взаимодействия для YTable.xaml
    /// </summary>
    public partial class YTable : Page
    {
        public YTable()
        {
            InitializeComponent();
            ClassV.Class2.ent = new hosEntities3();
        }

        private void YonT_Loaded(object sender, RoutedEventArgs e)
        {
            YonT.ItemsSource = ClassV.Class2.ent.Yonman.ToList();
            YonT.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassV.Class1.one.Navigate(new YonPage.YNew(null));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClassV.Class1.one.Navigate(new YonPage.OsnP());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < YonT.SelectedItems.Count; i++)
            {
                Yonman deliv = YonT.SelectedItems[i] as Yonman;
                ClassV.Class2.ent.Yonman.Remove(deliv);
            }
            ClassV.Class2.ent.SaveChanges();
            MessageBox.Show("Юнармеец удалён из базы данных!!!");
            NavigationService.Refresh();
        }
    }
}
