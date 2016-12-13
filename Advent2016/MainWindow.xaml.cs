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
        int day = 8;
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
                    case 4:
                        Day4 day4 = new Day4(input.Text);
                        output.Text = day4.Result();
                        break;
                    case 5:
                        Day5 day5 = new Day5(input.Text);
                        output.Text = day5.Result();
                        break;
                    case 6:
                        Day6 day6 = new Day6(input.Text);
                        output.Text = day6.Result();
                        break;
                    case 7:
                        Day7 day7 = new Day7(input.Text);
                        output.Text = day7.Result();
                        break;
                    case 8:
                        Day8 day8 = new Day8(input.Text);
                        output.Text = day8.Result();
                        break;
                    case 9:
                        Day9 day9 = new Day9(input.Text);
                        output.Text = day9.Result();
                        break;
                    case 10:
                        Day10 day10 = new Day10(input.Text);
                        output.Text = day10.Result();
                        break;
                    case 11:
                        Day11 day11 = new Day11(input.Text);
                        output.Text = day11.Result();
                        break;
                    case 12:
                        Day12 day12 = new Day12(input.Text);
                        output.Text = day12.Result();
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
        private void onClick4(object sender, RoutedEventArgs e)
        {
            day = 4;
            ValdDag.Content = day.ToString();
        }
        private void onClick5(object sender, RoutedEventArgs e)
        {
            day = 5;
            ValdDag.Content = day.ToString();
        }
        private void onClick6(object sender, RoutedEventArgs e)
        {
            day = 6;
            ValdDag.Content = day.ToString();
        }
        private void onClick7(object sender, RoutedEventArgs e)
        {
            day = 7;
            ValdDag.Content = day.ToString();
        }
        private void onClick8(object sender, RoutedEventArgs e)
        {
            day = 8;
            ValdDag.Content = day.ToString();
        }
        private void onClick9(object sender, RoutedEventArgs e)
        {
            day = 9;
            ValdDag.Content = day.ToString();
        }
        private void onClick10(object sender, RoutedEventArgs e)
        {
            day = 10;
            ValdDag.Content = day.ToString();
        }
        private void onClick11(object sender, RoutedEventArgs e)
        {
            day = 11;
            ValdDag.Content = day.ToString();
        }
        private void onClick12(object sender, RoutedEventArgs e)
        {
            day = 12;
            ValdDag.Content = day.ToString();
        }
    }



}
