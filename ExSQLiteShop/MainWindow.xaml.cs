using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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

namespace ExSQLiteShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int kol = 0;
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            Visibility = Visibility.Hidden;
            adminWindow.ShowDialog();
            Visibility = Visibility.Visible;
        }

        private void Proverka()
        {
            try
            {
                if (UsernameH.Text != "" && PassH.Password.ToString() != "")
                {
                    string sqlExpression = "SELECT * FROM UserReg";
                    using (SqliteConnection connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand(sqlExpression, connection))
                        {
                            SqliteDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                            {
                                string s1 = reader.GetName(1);
                                //string s2 = reader.GetName(2);

                                while (reader.Read())
                                {
                                    object nik = reader.GetValue(1);
                                    //object pass = reader.GetValue(2);
                                    if (UsernameH.Text == nik.ToString())
                                    {
                                        kol = 0;
                                        MessageBox.Show("Этот ник занят. Попробуйте другой.");
                                    }
                                    else
                                    {
                                        kol = 1;
                                    }

                                }

                                //int rowsAffected = command.ExecuteNonQuery();
                                //InfSearch.Text = "Successfully";

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Proverka();
                if(kol==1)
                {
                    if (UsernameH.Text != "" && PassH.Password.ToString() != "")
                    {
                        string str = "insert into UserReg (Login, Password) values ('" + UsernameH.Text + "', '" + PassH.Password.ToString() + "')"; ;
                        using (SqliteConnection connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                        {
                            connection.Open();
                            using (SqliteCommand command = new SqliteCommand(str, connection))
                            {


                                int rowsAffected = command.ExecuteNonQuery();
                                //InfSearch.Text = "Successfully";
                                MessageBox.Show($"Successfully {UsernameH.Text} reg.");

                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ProverkaSignIn()
        {
            try
            {
                if (UsernameH.Text != "" && PassH.Password.ToString() != "")
                {
                    string sqlExpression = "SELECT * FROM UserReg";
                    using (SqliteConnection connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand(sqlExpression, connection))
                        {
                            SqliteDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                            {
                                //string s1 = reader.GetName(1);
                                //string s2 = reader.GetName(2);

                                while (reader.Read())
                                {
                                    object nik = reader.GetValue(1);
                                    object pass = reader.GetValue(2);
                                    if (UsernameH.Text == nik.ToString() && PassH.Password.ToString()==pass.ToString())
                                    {
                                        MessageBox.Show("Successfully");
                                        AdminWindow adminWindow = new AdminWindow();
                                        adminWindow.ShowDialog();
                                        break;
                                    }
                                 

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ProverkaSignIn();
        }
    }
}
