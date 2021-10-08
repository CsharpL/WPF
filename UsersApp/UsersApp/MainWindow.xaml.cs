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

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass2 = passBox2.Password.Trim(); 
            string email = textBoxEmail.Text.Trim().ToLower();
            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "Логин должен быть больше 5 символов";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if(pass.Length < 5)
            { 
                passBox.ToolTip = "пароль должен быть больше 5 символов";
                passBox.Background = Brushes.DarkRed;
            }
            else if (pass != pass2)
            {
                passBox2.ToolTip = "пароли должны совпадать";
                passBox2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "некорректная почта";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox2.ToolTip = "";
                passBox2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;
                
                MessageBox.Show("Все ок!");
                
                User user = new User(login, email, pass);
                db.Users.Add(user);
                db.SaveChanges();
            }

        }
    }
}
