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
    /// Логика взаимодействия для RegP.xaml
    /// </summary>
    public partial class RegP : Page
    {
        public RegP()
        {
            InitializeComponent();
            ClassV.ClassBD.end = new hosEntities3();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassV.Class1.one.Navigate(new YonPage.LoginP());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(box1.Text) || string.IsNullOrEmpty(box2.Password))
            {
                MessageBox.Show("Все поля должны быть заполнены!!!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                using (var BD = new hosEntities3())
                {
                    var user = BD.Login.AsNoTracking().FirstOrDefault(u => u.Login1 == box1.Text && u.Password == box2.Password);
                    if (user != null)
                    {
                        MessageBox.Show("Данный пользователь уже существует", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                    else
                    {

                        Login us = new Login()
                        {

                            Login1 = box1.Text,
                            Password = box2.Password



                        };
                        ClassV.ClassBD.end.Login.Add(us);
                        ClassV.ClassBD.end.SaveChanges();
                        MessageBox.Show("Вы добавлены!!!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    }

                }
            }
            ClassV.Class1.one.Navigate(new YonPage.LoginP());
        }

    }
}

