using System;
using System.Collections;
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

namespace HW_Lecture85_HashTable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Hashtable CustInfo;
      
        public MainWindow()
        {
            InitializeComponent();
            tb_IdKey.Focus();
            CustInfo = new Hashtable();
        }

        private void initialLoad()
        {
            tb_IdKey.Text = string.Empty;
            tb_NameInput.Text = string.Empty;
            tb_IdKey.Focus();
        }

        private void bt_Add_Click(object sender, RoutedEventArgs e)
        {
            if (tb_IdKey.Text.Length <= 0 || tb_NameInput.Text.Length <= 0)
            {
                if(tb_IdKey.Text.Length <= 0 && tb_NameInput.Text.Length > 0)
                {
                    MessageBox.Show("Input Cust ID !!");
                    tb_IdKey.Focus();
                }
                else if(tb_NameInput.Text.Length <= 0 && tb_IdKey.Text.Length > 0)
                {
                    MessageBox.Show("Input Cust Name !!");
                    tb_NameInput.Focus();
                }
                else
                {
                    MessageBox.Show("Please Input Data.");
                    initialLoad();

                }
                
            }
            else
            {
                //add
                CustInfo.Add(tb_IdKey.Text, tb_NameInput.Text);
                MessageBox.Show("Add Complete");
                initialLoad();
            }
        }
            
        

        private void bt_ShowAll_Click(object sender, RoutedEventArgs e)
        {
            ICollection icollection = CustInfo.Keys;

            StringBuilder builder = new StringBuilder();

            foreach (string data in icollection)
            {
                builder = builder.AppendLine(CustInfo[data].ToString());
                tb_NameShow.Text = builder.ToString();
            }
        }

        private void bt_Remove_Click(object sender, RoutedEventArgs e)
        {
            if(tb_IdKey.Text.Length <= 0)
            {
                MessageBox.Show("Input Cust ID !!");
            }
            else
            {
         
                try
                {
                    string exists = CustInfo[tb_IdKey.Text].ToString();
                    CustInfo.Remove(tb_IdKey.Text);
                    MessageBox.Show("Remove Complete");
                    initialLoad();
                }
                catch(Exception a)
                {
                    MessageBox.Show("No have id.");
                    initialLoad();
                }
            }
            
        }
    }
}
