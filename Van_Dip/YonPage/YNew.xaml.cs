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
    /// Логика взаимодействия для YNew.xaml
    /// </summary>
    public partial class YNew : Page
    {
        private Yonman cli = new Yonman();
        public static int gr1 { get; set; }
        public static DatePicker kl { get; set; }
        public static int id { get; set; }
        public static int gp2 { get; set; }
        public static string Ar { get; set; }
        public static string Na { get; set; }
        public static string Ns { get; set; }
        public static string Nq { get; set; }
        public YNew(Yonman selectYonman)
        {
            InitializeComponent();

            Cl.SelectedValuePath = "ID";
            Cl.DisplayMemberPath = "Shool";
            Cl.ItemsSource = ClassV.Class2.ent.Schoo.ToList();
            if (selectYonman != null)
            {
                cli = selectYonman;
                DataContext = cli;
                Ar = cli.Firstna;
                Na = cli.Firstnam;
                Ns = cli.Firstname;
                Nq = cli.Phone;
                id = cli.ID;
                 
                gr1 = Convert.ToInt32(cli.School);
                using (var bd = new hosEntities3())
                {
                    var krv = bd.Schoo.AsNoTracking().FirstOrDefault(u => u.ID == cli.ID);
                    Ar = krv.Shool;                  
                }
            }
            else
            {
                cli = null;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassV.Class1.one.Navigate(new YonPage.OsnP());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var bd = new hosEntities3())
            {
                if (string.IsNullOrEmpty(surname.Text) || string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(patronymic.Text) || string.IsNullOrEmpty(phon_Copy.Text) || (string.IsNullOrEmpty(Cl.Text)))
                {
                    MessageBox.Show("Все поля должны быть заполнены!!!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                else
                {
                    if (cli == null)
                    {
                        var kr = bd.Yonman.Where(u => u.Phone == Nq).FirstOrDefault();
                        if (kr != null)
                        {
                            MessageBox.Show("Данный юнармеец уже есть!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            return;
                        }
                        else
                        {

                            Yonman ord = new Yonman()
                            {

                                Firstna = surname.Text,
                                Firstnam = name.Text,
                                Firstname = patronymic.Text,
                                Date_of_Birth = (DateTime)dt.SelectedDate,
                                Phone = phon_Copy.Text,
                                Schoo = Cl.SelectedItem as Schoo,
                                Characteristic = Xar.Text,
                                Rodd = Xar_Copy.Text




                            };
                            ClassV.Class2.ent.Yonman.Add(ord);
                            ClassV.Class2.ent.SaveChanges();
                            MessageBox.Show("Юнармеец добавлен!");
                            //ClassV.Class1.one.Navigate(new ());
                        }
                    }
                    //else

                    //{
                    //    if (cli != null)
                    //    {
                    //        var krv = bd.Record.Where(u => u.ID_Pacient == gr1 && u.ID_Doctor == gp2).FirstOrDefault();
                    //        var grp = bd.Pacient.AsNoTracking().FirstOrDefault(g => g.FIO == Cl.Text);
                    //        var gr = bd.Doctor.AsNoTracking().FirstOrDefault(g => g.FIO == doc.Text);
                    //        Cl.Text = Na;
                    //        doc.Text = Ar;
                    //        krv.ID_Pacient = grp.ID;
                    //        krv.ID_Doctor = grp.ID;
                    //        bd.SaveChanges();
                    //        MessageBox.Show("Изменения сохранены!");
                    //        ClassPage.Class1.one.Navigate(new TZapi());
                    //    }

                    //}



                }


            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Xar_Copy.Clear();
            Xar_Copy.Text += "м";
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Xar_Copy.Clear();
            Xar_Copy.Text += "ж";
            
        }
    }
}
