using Microsoft.Data.Sqlite;
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
using System.Windows.Shapes;

namespace ExSQLiteShop
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db";
        string addnow;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addnow = "";
            AddNow.Text = "";
            addnow = "Название книги    Ф И О   Страницы    Год издания      Жанр   Цена\n";
            try
            {
                if (NamesBook.Text != "" && FIO.Text != "" && NamesIzda.Text != "" && Pages.Text != "" && YearsIzda.Text!="" && Genre.Text!="" && Price.Text!="")
                {
                    using (var connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                    {
                        connection.Open();

                        SqliteCommand command = new SqliteCommand(connectionString);
                        command.Connection = connection;
                        //Доабвление значений
                        command.CommandText = "INSERT INTO Books(NameBook,FIO, NameIzda, Pages, YearIzda, Genre, Price) VALUES('" + NamesBook.Text + "' ,'" + FIO.Text + "', '" + NamesIzda.Text + "', " + Pages.Text + ", " + YearsIzda.Text + ",'" + Genre.Text + "', " + Pages.Text+")";
                        //int number = command.ExecuteNonQuery();
                        //a += Convert.ToDouble(PriceProduct.Text) * Convert.ToDouble(CountProduct.Text);
                        //TotalPrice.Text = a.ToString();
                        MessageBox.Show(command.CommandText.ToString());
                        
                        addnow += NamesBook.Text+"\t" + FIO.Text+"\t"  + NamesIzda.Text+"\t" + Pages.Text+"\t" + YearsIzda.Text+"\t" + Genre.Text+"\t" + Pages.Text;

                        AddNow.Text = addnow;
                        int number = command.ExecuteNonQuery();
                        MessageBox.Show($"В таблицу Books добавлено объектов:{number}");
                        
                    }
                    Console.Read();
                    
                }
            }
            catch (Exception b) { MessageBox.Show(b.Message); };



        }
    }
    
}
