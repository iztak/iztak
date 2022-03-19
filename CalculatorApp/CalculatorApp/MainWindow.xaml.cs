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

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool func = false;
        string operation;
        double num1 = 0;
        double num2 = 0;

        public MainWindow()
        {
            InitializeComponent();



        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "0";
            func = false;
            num1 = 0;
            num2 = 0;
            operation = "";
        }

        private void PlusMinus_Button_Click(object sender, RoutedEventArgs e)
        {
            string s1 = "-";
            if(Display.Text.Contains(s1))
            {
                Display.Text = Display.Text.Remove(0,1);
            }
            else
            {
                Display.Text = s1 + Display.Text;
            }
        }

        private void Percent_Button_Click(object sender, RoutedEventArgs e)
        {
            double num = double.Parse(Display.Text);
            num *= 0.01;
            Display.Text = num.ToString();

        }

        private void Func_Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Content.ToString();
            if (!func)
            {
                func = true;
            }
            else
            {
                if(operation == "+")
                {
                    num1 = num1 + num2;
                    Display.Text = num1.ToString();
                }
                else if (operation == "-")
                {
                    num1 = num1 - num2;
                    Display.Text = num1.ToString();
                }
                else if (operation == "X")
                {
                    num1 = num1 * num2;
                    Display.Text = num1.ToString();
                }
                else
                {
                    num1 = num1 / num2;
                    Display.Text = num1.ToString();
                }
            }
            


        }


        private void Point_Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string s1 = b.Content.ToString();
            if (!(Display.Text.Contains(s1)))
            {
                Display.Text += b.Content.ToString();
            }
        }

        private void Equal_Button_Click(object sender, RoutedEventArgs e)
        {
            if(operation == "+")
            {
                Display.Text = (num1 + num2).ToString();
            }
            else if (operation == "-")
            {
                Display.Text = (num1 - num2).ToString();
            }
            else if (operation == "X")
            {
                Display.Text = (num1 * num2).ToString();
            }
            else
            {
                Display.Text = (num1 / num2).ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string s1 = b.Content.ToString();
            if (func == false)
            {

                if ((Display.Text == "0") && (s1 == "0")) ;
                else if (Display.Text == "0")
                {
                    Display.Text = b.Content.ToString();
                }
                else
                {
                    Display.Text += b.Content.ToString();
                }
                num1 = double.Parse(Display.Text);
            }
            else
            {
                Display.Text = "";
                if ((Display.Text == "") && (s1 == "0")) ;
                else if (Display.Text == "0")
                {
                    Display.Text = b.Content.ToString();
                }
                else
                {
                    Display.Text += b.Content.ToString();
                }

                num2 = int.Parse(Display.Text);
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "0";
        }
    }
}
