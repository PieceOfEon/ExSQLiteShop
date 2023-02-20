using ControlzEx.Standard;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace ExSQLiteShop
{
    /// <summary>
    /// Interaction logic for DelSearchWindow.xaml
    /// </summary>
    public partial class DelSearchWindow : Window
    {
        public DelSearchWindow()
        {
            InitializeComponent();
        }
        int Radio;
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = "SELECT * FROM Books";
            if (RadioName.IsChecked == true)
            {
                Radio = 1;
            }
            else if (RadioFIO.IsChecked == true)
            {
                Radio = 2;
            }
            else if (RadioGenre.IsChecked == true)
            {
                Radio = 6;
            }
            else
            {
                Radio = 1;
            }
            try
            {
                if (SearchName.Text != "" || SearchFIO.Text != "" || SearchGenre.Text != "")
                {
                    using (var connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                    {
                        connection.Open();

                        SqliteCommand command = new SqliteCommand(str, connection);
                        command.Connection = connection;
                        SqliteDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            Searcher.Text = "";
                            while (reader.Read())
                            {
                                //MessageBox.Show(s2);
                                object id = reader.GetValue(0);
                                object id1 = reader.GetValue(Radio);
                                if (Radio == 1)
                                {
                                    if (SearchName.Text.ToLower() == id1.ToString().ToLower())
                                    {
                                        Searcher.Text += id + "\t" + id1 + "\n";
                                    }
                                }
                                else if (Radio == 2)
                                {
                                    if (SearchFIO.Text.ToLower() == id1.ToString().ToLower())
                                    {
                                        Searcher.Text += id + "\t" + id1 + "\n";
                                    }
                                }
                                else if (Radio == 6)
                                {
                                    if (SearchGenre.Text.ToLower() == id1.ToString().ToLower())
                                    {
                                        Searcher.Text += id + "\t" + id1 + "\n";
                                    }
                                }

                            }
                            //reader.Close();

                        }
                    }
                    //Console.Read();
                }
            }
            catch (Exception b) { Console.WriteLine(b.Message); };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                if (DelID.Text != "")
                {
                    string str = "DELETE from Books where id=" + DelID.Text;
                    using (SqliteConnection connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand(str, connection))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            //InfSearch.Text = "Successfully";
                            MessageBox.Show($"Deleted {rowsAffected} rows.");
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
            try
            {
                printbox.Text = "";
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
                                
                                printbox.Text += id + "\t" + id1 + "\t" + id2 + "\t" + id3 + "\t" + id4 + "\t" + id5 + "\t" + id6 + "\t" + id7 + "\n";
 
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
                // update Books set FIO='LOX' where id = 2;
                string str = "update Books set ";
                string str2="";
                int kol = 0;
                int kol2 = 0;
                if (nameedit.Text != "")
                {
                    kol2++;
                }
                if(fioedit.Text!="")
                {
                    kol2++;
                }
                if(nameizdaedit.Text!="")
                {
                    kol2++;
                }
                if(pagesedit.Text!="")
                {
                    kol2++;
                }
                if(yearsedit.Text!="")
                {
                    kol2++;
                }
                if(genreedit.Text!="")
                {
                    kol2++;
                }
                if(priceedit.Text!="")
                {
                    kol2++;
                }
                if (idedit.Text != "" && nameedit.Text != "" || fioedit.Text != "" && idedit.Text != "" || nameizdaedit.Text != "" && idedit.Text != "" || pagesedit.Text != "" && idedit.Text != "" || yearsedit.Text != "" && idedit.Text != "" || genreedit.Text != "" && idedit.Text != "" || priceedit.Text != "" && idedit.Text != "")
                {
                    using (SqliteConnection connection = new SqliteConnection("Data Source = D:\\ViStudio\\ExSQLiteShop\\ExSQLiteShop\\ExSQLiteShop.db"))
                    {
                        
                        if(nameedit.Text!="")
                        {
                            if(kol2>1)
                            {
                                str2 += "NameBook='" + nameedit.Text + "', ";
                            }
                            else
                            {
                                str2 += "NameBook='" + nameedit.Text + "' ";
                            }
                            
                            
                        }
                        if(fioedit.Text!="")
                        {
                            
                            if(kol2>1)
                            {
                                str2 += "FIO='" + fioedit.Text + "', ";
                            }
                            else
                            {
                                str2 += "FIO='" + fioedit.Text + "' ";
                            }
                            kol++;
                        }
                        if(nameizdaedit.Text!="")
                        {
                            if(kol2>1)
                            {
                                str2 += "NameIzda='" + nameizdaedit.Text + "', ";
                            }
                            else
                            {
                                str2 += "NameIzda='" + nameizdaedit.Text + "' ";
                            }
                            kol++;
                        }
                        if(pagesedit.Text!="")
                        {
                            if(kol2>1)
                            {
                                str2 += "Pages=" + pagesedit.Text + ", ";
                            }
                            else
                            {
                                str2 += "Pages=" + pagesedit.Text + " ";
                            }
                            
                        }
                        if(yearsedit.Text!="")
                        {
                            if(kol2>1)
                            {
                                str2 += "YearIzda=" + yearsedit.Text + ", ";
                            }
                            else
                            {
                                str2 += "YearIzda=" + yearsedit.Text + " ";
                            }
                            
                        }
                        if(genreedit.Text!="")
                        {
                            if(kol2>1)
                            {
                                str2 += "Genre='" + genreedit.Text + "', ";
                            }
                            else
                            {
                                str2 += "Genre='" + genreedit.Text + "' ";
                            }
                            
                        }
                        if(priceedit.Text!="")
                        {
                            if(kol2>1)
                            {
                                str2 += "Price=" + priceedit.Text + ", ";
                            }
                            else
                            {
                                str2 += "Price=" + priceedit.Text + " ";
                            }
                            
                        }
                        if(kol2>1)
                        {
                           
                            str2=str2.Remove(str2.Length-2);
                            MessageBox.Show(str2);
                        }
                        str += str2 + " where id="+idedit.Text;
                        MessageBox.Show(str);
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand(str, connection))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            //InfSearch.Text = "Successfully";
                            MessageBox.Show($"Upd successfully {rowsAffected} rows.");
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
