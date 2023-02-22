using ControlzEx.Standard;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace ExSQLiteShop
{
    /// <summary>
    /// Interaction logic for SellWindow.xaml
    /// </summary>
    public partial class SellWindow : Window
    {
        public SellWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintBaza.Text = "";
                string str = "select * from Books";
                using (SqliteConnection connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                {
                    connection.Open();
                    using (SqliteCommand command = new SqliteCommand(str, connection))
                    {
                        //command.Connection = connection;
                        SqliteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //MessageBox.Show(s2);
                            object id = reader.GetValue(0);
                            object id1 = reader.GetValue(1);
                            object id2 = reader.GetValue(2);
                            object id3 = reader.GetValue(3);
                            object id4 = reader.GetValue(4);
                            object id5 = reader.GetValue(5);
                            object id6 = reader.GetValue(6);
                            object id7 = reader.GetValue(7);

                            PrintBaza.Text += id + "\t" + id1 + "\t" + id2 + "\t" + id3 + "\t" + id4 + "\t" + id5 + "\t" + id6 + "\t" + id7 + "\n";

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
                if (IDSell.Text != "")
                {
                    using (var connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                    {
                        connection.Open();

                        SqliteCommand command = new SqliteCommand("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db");
                        command.Connection = connection;
                        //Доабвление значений
                        command.CommandText = "INSERT INTO Sells(idBooks) VALUES(" + IDSell.Text + ")";
                  
                        int number = command.ExecuteNonQuery();
                        MessageBox.Show("Successfully");

                    }
                    Console.Read();

                }
            }
            catch (Exception b) { MessageBox.Show(b.Message); };
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintSell.Text = "";
                string str = "select * from Books,Sells where Books.id=Sells.idBooks";
                using (SqliteConnection connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                {
                    connection.Open();
                    using (SqliteCommand command = new SqliteCommand(str, connection))
                    {
                        //command.Connection = connection;
                        SqliteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //MessageBox.Show(s2);
                            object id = reader.GetValue(0);
                            object id1 = reader.GetValue(1);
                            object id2 = reader.GetValue(2);
                            object id3 = reader.GetValue(3);
                            object id4 = reader.GetValue(4);
                            object id5 = reader.GetValue(5);
                            object id6 = reader.GetValue(6);
                            object id7 = reader.GetValue(7);

                            PrintSell.Text += id + "\t" + id1 + "\t" + id2 + "\t" + id3 + "\t" + id4 + "\t" + id5 + "\t" + id6 + "\t" + id7 + "\n";

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintPopularSell.Text = "";
                string str = "select * from Books,Sells\r\nwhere Books.id=Sells.idBooks\r\ngroup by Sells.idBooks\r\nhaving count(Books.id) =(select max(count_) as ma from(SELECT count(*) as count_ FROM Sells GROUP BY idBooks))";
                using (SqliteConnection connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                {
                    connection.Open();
                    using (SqliteCommand command = new SqliteCommand(str, connection))
                    {
                        //command.Connection = connection;
                        SqliteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //MessageBox.Show(s2);
                            object id = reader.GetValue(0);
                            object id1 = reader.GetValue(1);
                            object id2 = reader.GetValue(2);
                            object id3 = reader.GetValue(3);
                            object id4 = reader.GetValue(4);
                            object id5 = reader.GetValue(5);
                            object id6 = reader.GetValue(6);
                            object id7 = reader.GetValue(7);

                            PrintPopularSell.Text += id + "\t" + id1 + "\t" + id2 + "\t" + id3 + "\t" + id4 + "\t" + id5 + "\t" + id6 + "\t" + id7 + "\n";

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintMaxPrice.Text = "";
                string str = "select * from Books,Sells\r\nwhere Books.id=Sells.idBooks\r\ngroup by Books.Price\r\nhaving max(Books.Price) =(select max(Books.Price)from Books, Sells where Books.id=Sells.idBooks)";
                using (SqliteConnection connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                {
                    connection.Open();
                    using (SqliteCommand command = new SqliteCommand(str, connection))
                    {
                        //command.Connection = connection;
                        SqliteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //MessageBox.Show(s2);
                            object id = reader.GetValue(0);
                            object id1 = reader.GetValue(1);
                            object id2 = reader.GetValue(2);
                            object id3 = reader.GetValue(3);
                            object id4 = reader.GetValue(4);
                            object id5 = reader.GetValue(5);
                            object id6 = reader.GetValue(6);
                            object id7 = reader.GetValue(7);

                            PrintMaxPrice.Text += id + "\t" + id1 + "\t" + id2 + "\t" + id3 + "\t" + id4 + "\t" + id5 + "\t" + id6 + "\t" + id7 + "\n";

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
