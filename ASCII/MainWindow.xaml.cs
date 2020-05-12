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
using System.Text.RegularExpressions;

namespace ASCII
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected internal class ASCII
        {
            private int number;
            public int Number
            { 
                set
                {
                    number = value;
                }
                get
                {
                    return number;
                }
            }
        }

        protected void Decode()
        {
            ASCII ascii = new ASCII
            {
                Number = int.Parse(TxtCode.Text)
            };
            if (ascii.Number >= 'A' && ascii.Number <= 'Z' || ascii.Number >= 'a' && ascii.Number <= 'z')
            {
                LblResult.Text = ("Это буква ") + ($"{(char)ascii.Number}");
            }
            else
            {
                LblResult.Text = ("Это не буква, а символ ") + ($"{(char)ascii.Number}");
            }
        }

        private void BtnIdentify_Click(object sender, RoutedEventArgs e)
        {
            Decode();
        }

        private void TxtCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtCode.Text.Length == 0)
            {
                BtnIdentify.IsEnabled = false;
            }
            else
            {
                BtnIdentify.IsEnabled = true;
            }
            TxtCode.Text = TxtCode.Text.Replace(" ", string.Empty);
            TxtCode.SelectionStart = TxtCode.Text.Length;
        }

        private void TxtCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }
    }
}
