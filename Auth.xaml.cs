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

namespace RoomKovalevskaya
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var userModel = DB.entities.User.FirstOrDefault
                (i => i.Login == txbLogin.Text && i.Password == psbPassword.Password);

            if(psbPassword.Password == psbPasswordRepeat.Password)
            {
                if(userModel == null)
                {
                    MessageBox.Show("Пользватель не найден, повторите попытку", "Пользователь не найден", MessageBoxButton.OK);
                }

                else if(userModel.IDRole == 1)
                {
                    AdminMain adminMain = new AdminMain();
                    adminMain.Show();
                    Application.Current.MainWindow.Close();
                }

                else if(userModel.IDRole == 2)
                {
                    Application.Current.MainWindow.Close();
                }

                else if(userModel.IDRole == 3)
                {
                    int idUser = userModel.IDUser;
                    Application.Current.MainWindow.Close();
                }

                else
                {
                    MessageBox.Show("Пароль не совпадает, повторите попытку",
                        "Ошибка ввода пароля", MessageBoxButton.OK);
                }

            }
        }
    }
}
