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
    /// Логика взаимодействия для NewRyk.xaml
    /// </summary>
    public partial class NewRyk : Page
    {
        private Ryk cli = new Ryk();
        public static int gr1 { get; set; }
        public static DatePicker kl { get; set; }
        public static int id { get; set; }
        public static int gp2 { get; set; }
        public static string Ar { get; set; }
        public static string Na { get; set; }
        public static string Ns { get; set; }
        public static string Nq { get; set; }
        public NewRyk(Ryk selectRyk)
        {
            InitializeComponent();
            Cl.SelectedValuePath = "ID";
            Cl.DisplayMemberPath = "Shool";
            Cl.ItemsSource = ClassV.Class2.ent.Schoo.ToList();
            if (selectRyk != null)
            {
                cli = selectRyk;
                DataContext = cli;
                Ar = cli.FIO;
                Na = cli.Post;
                Ns = cli.Phone;
                Nq = cli.Email;
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
            ClassV.Class1.one.Navigate(new YonPage.RykP());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var bd = new hosEntities3())
            {
                if (string.IsNullOrEmpty(fio.Text) || string.IsNullOrEmpty(dol.Text) || string.IsNullOrEmpty(tele.Text) || string.IsNullOrEmpty(email.Text) || (string.IsNullOrEmpty(Cl.Text)))
                {
                    MessageBox.Show("Все поля должны быть заполнены!!!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                else
                {
                    if (cli == null)
                    {
                        var kr = bd.Ryk.Where(u => u.Phone == Nq).FirstOrDefault();
                        if (kr != null)
                        {
                            MessageBox.Show("Данный руководитель уже есть!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            return;
                        }
                        else
                        {

                            Ryk ord = new Ryk()
                            {

                                FIO = fio.Text,
                                Post = dol.Text,
                                Phone = tele.Text,                                
                                Email = email.Text,
                                Schoo = Cl.SelectedItem as Schoo,
                               




                            };
                            ClassV.Class2.ent.Ryk.Add(ord);
                            ClassV.Class2.ent.SaveChanges();
                            MessageBox.Show("Руководитель добавлен!");
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
    }
}
