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
    /// Логика взаимодействия для LoginP.xaml
    /// </summary>
    public partial class LoginP : Page
    {
        public static string Login { get; set; }
        public static string Passwrd { get; set; }
        public LoginP()
        {

            InitializeComponent();
            ClassV.ClassBD.end = new hosEntities3();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassV.Class1.one.Navigate(new YonPage.RegP());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(box1.Text) || string.IsNullOrEmpty(box2.Password))
            {
                MessageBox.Show("Введите логин и пароль!!!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                using (var bd = new hosEntities3())
                {
                    var user = bd.Login.AsNoTracking().FirstOrDefault(u => u.Login1 == box1.Text && u.Password == box2.Password);
                    if (user == null)
                    {
                        MessageBox.Show("Возможно вы ввели неверно логин или пароль. Пожалуйста повторите попытку или зарегестрируйтесь", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                    else
                    {
                        Login = box1.Text;

                        Passwrd = box2.Password;

                    }
                }
            }


            ClassV.Class1.one.Navigate(new YonPage.OsnP());
        }
    }
}
