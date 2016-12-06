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

namespace Advent2016
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int day = 3;
        public MainWindow()
        {
            InitializeComponent();
            input.Focus();
            input.SelectAll();
            ValdDag.Content = day.ToString();
        }
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                switch (day)
                {
                    case 1:
                        Day1 day1 = new Day1(input.Text);
                        output.Text = day1.Result();
                        break;
                    case 2:
                        Day2 day2 = new Day2(input.Text);
                        output.Text = day2.Result();
                        break;
                    case 3:
                        Day3 day3 = new Day3(input.Text);
                        output.Text = day3.Result();
                        break;
                    default:
                        output.Text = "oops, no day choosen";
                        break;
                }

            }

        }
        private void onClick1(object sender, RoutedEventArgs e)
        {
            day = 1;
            ValdDag.Content = day.ToString();
        }

        private void onClick2(object sender, RoutedEventArgs e)
        {
            day = 2;
            ValdDag.Content = day.ToString();
        }
        private void onClick3(object sender, RoutedEventArgs e)
        {
            day = 3;
            ValdDag.Content = day.ToString();
        }
    }



}
