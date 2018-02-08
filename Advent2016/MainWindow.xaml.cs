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
        int day = 20;
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
                    case 13:
                        Day13 day13 = new Day13(input.Text);
                        output.Text = day13.Result();
                        break;
                    case 14:
                        Day14 day14 = new Day14(input.Text);
                        output.Text = day14.Result();
                        break;
                    case 15:
                        Day15 day15 = new Day15(input.Text);
                        output.Text = day15.Result();
                        break;
                    case 16:
                        Day16 day16 = new Day16(input.Text);
                        output.Text = day16.Result();
                        break;
                    case 17:
                        Day17 day17 = new Day17(input.Text);
                        output.Text = day17.Result();
                        break;
                    case 18:
                        Day18 day18 = new Day18(input.Text);
                        output.Text = day18.Result();
                        break;
                    case 19:
                        Day19 day19 = new Day19(input.Text);
                        output.Text = day19.Result();
                        break;
                    case 20:
                        Day20 day20 = new Day20(input.Text);
                        output.Text = day20.Result();
                        break;
                    case 21:
                        Day21 day21 = new Day21(input.Text);
                        output.Text = day21.Result();
                        break;
                    case 22:
                        Day22 day22 = new Day22(input.Text);
                        output.Text = day22.Result();
                        break;
                    case 23:
                        Day23 day23 = new Day23(input.Text);
                        output.Text = day23.Result();
                        break;
                    case 24:
                        Day24 day24 = new Day24(input.Text);
                        output.Text = day24.Result();
                        break;
                    case 25:
                        Day25 day25 = new Day25(input.Text);
                        output.Text = day25.Result();
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
