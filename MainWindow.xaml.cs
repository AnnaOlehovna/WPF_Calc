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

namespace Calc
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

        private string number = null;
        private string operation = null;

        private void onNumberClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button numberButton = (Button)sender;
                switch (numberButton.Content)
                {
                    case "0":
                        if (TextBoxCurrentNumber.Text != "0")
                            TextBoxCurrentNumber.Text += numberButton.Content;
                        break;
                    case ".":
                        if (TextBoxCurrentNumber.Text != "0")
                            TextBoxCurrentNumber.Text += numberButton.Content;
                        else
                            TextBoxCurrentNumber.Text = "0.";
                        break;
                    default:
                        if (TextBoxCurrentNumber.Text != "0")
                            TextBoxCurrentNumber.Text += numberButton.Content;
                        else
                            TextBoxCurrentNumber.Text = numberButton.Content.ToString();
                        break;
                }
            }

        }

        private void onOperationClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button operationButton = (Button)sender;
                number = TextBoxCurrentNumber.Text;
                operation = operationButton.Content.ToString();
                TextBoxHistory.Text = number + " " + operationButton.Content;
                TextBoxCurrentNumber.Text = "0";
            }

        }

        private void onEqualsClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                double result;
                switch (operation)
                {
                    case "+":
                        {
                            result = Convert.ToDouble(number) + Convert.ToDouble(TextBoxCurrentNumber.Text);
                            TextBoxHistory.Text += " " + TextBoxCurrentNumber.Text;
                            TextBoxCurrentNumber.Text = result.ToString();
                            break;
                        }
                    case "-":
                        {
                            result = Convert.ToDouble(number) - Convert.ToDouble(TextBoxCurrentNumber.Text);
                            TextBoxHistory.Text += " " + TextBoxCurrentNumber.Text;
                            TextBoxCurrentNumber.Text = result.ToString();
                            break;
                        }
                    case "x":
                        {
                            result = Convert.ToDouble(number) * Convert.ToDouble(TextBoxCurrentNumber.Text);
                            TextBoxHistory.Text += " " + TextBoxCurrentNumber.Text;
                            TextBoxCurrentNumber.Text = result.ToString();
                            break;
                        }
                    case "÷":
                        {
                            if (TextBoxCurrentNumber.Text != "0")
                            {
                                result = Convert.ToDouble(number) / Convert.ToDouble(TextBoxCurrentNumber.Text);
                                TextBoxHistory.Text += " " + TextBoxCurrentNumber.Text;
                                TextBoxCurrentNumber.Text = result.ToString();
                            }
                            else
                            {
                                TextBoxHistory.Text = "На ноль делить нельзя";
                                enableButtons(false);
                            }

                            break;
                        }

                }
            }
        }


        private void onResetClick(object sender, RoutedEventArgs e)
        {
            number = null;
            operation = null;
            TextBoxHistory.Text = "0";
            TextBoxCurrentNumber.Text = "0";
            enableButtons(true);
        }

        private void enableButtons(bool enable)
        {
            buttonZero.IsEnabled = enable;
            button1.IsEnabled = enable;
            button2.IsEnabled = enable;
            button3.IsEnabled = enable;
            button4.IsEnabled = enable;
            button5.IsEnabled = enable;
            button6.IsEnabled = enable;
            button7.IsEnabled = enable;
            button8.IsEnabled = enable;
            button9.IsEnabled = enable;

            buttonPlus.IsEnabled = enable;
            buttonMinus.IsEnabled = enable;
            buttonMutliply.IsEnabled = enable;
            button1DevX.IsEnabled = enable;
            buttonXin2.IsEnabled = enable;
            buttonSqrt.IsEnabled = enable;
            buttonDivision.IsEnabled = enable;

            buttonEquals.IsEnabled = enable;
            buttonDot.IsEnabled = enable;
            buttonPlusMinus.IsEnabled = enable;

            buttonSin.IsEnabled = enable;
            buttonCos.IsEnabled = enable;
            buttonTg.IsEnabled = enable;
            buttonBackSpace.IsEnabled = enable;
        }

        private void onPlusMinusClick(object sender, RoutedEventArgs e)
        {
            if (TextBoxCurrentNumber.Text != "0")
            {
                if (TextBoxCurrentNumber.Text.Contains("-"))
                {
                    TextBoxCurrentNumber.Text = TextBoxCurrentNumber.Text.Replace("-", "");
                }
                else
                {
                    TextBoxCurrentNumber.Text = "-" + TextBoxCurrentNumber.Text;
                }
            }
        }

        private void onMathClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button mathOperation = (Button)sender;
                double result;
                double angle;
                switch (mathOperation.Content)
                {
                    case "1/x":
                        {
                            if (TextBoxCurrentNumber.Text != "0")
                            {
                                result = 1 / Convert.ToDouble(TextBoxCurrentNumber.Text);
                                TextBoxHistory.Text = "1/" + TextBoxCurrentNumber.Text;
                                TextBoxCurrentNumber.Text = result.ToString();
                            }
                            else
                            {
                                TextBoxHistory.Text = "На ноль делить нельзя";
                                enableButtons(false);
                            }
                            break;
                        }
                    case "x^2":
                        {
                            result = Math.Pow(Convert.ToDouble(TextBoxCurrentNumber.Text), 2);
                            TextBoxHistory.Text = "Sqr (" + TextBoxCurrentNumber.Text + ")";
                            TextBoxCurrentNumber.Text = result.ToString();
                            break;
                        }

                    case "√":
                        {

                            if (Convert.ToDouble(TextBoxCurrentNumber.Text) > 0)
                            {
                                result = Math.Pow(Convert.ToDouble(TextBoxCurrentNumber.Text), 0.5);
                                TextBoxHistory.Text = "√(" + TextBoxCurrentNumber.Text + ")";
                                TextBoxCurrentNumber.Text = result.ToString();
                            }
                            else
                            {
                                TextBoxHistory.Text = "Нельзя извлечь корень из отрицательного числа";
                                enableButtons(false);
                            }
                            break;
                        }
                    case "sin":
                        {
                            if (buttonRad.IsChecked == true)
                                angle = Convert.ToDouble(TextBoxCurrentNumber.Text);
                            else
                                angle = Convert.ToDouble(TextBoxCurrentNumber.Text) * Math.PI / 180.0;

                            result = Math.Sin(angle);
                            TextBoxHistory.Text = "sin(" + TextBoxCurrentNumber.Text + ")";
                            TextBoxCurrentNumber.Text = result.ToString();
                            break;
                        }
                    case "cos":
                        {
                            if (buttonRad.IsChecked == true)
                                angle = Convert.ToDouble(TextBoxCurrentNumber.Text);
                            else
                                angle = Convert.ToDouble(TextBoxCurrentNumber.Text) * Math.PI / 180.0;

                            result = Math.Cos(angle);
                            TextBoxHistory.Text = "cos(" + TextBoxCurrentNumber.Text + ")";
                            TextBoxCurrentNumber.Text = result.ToString();

                            break;
                        }
                    case "tg":
                        {

                            if (buttonRad.IsChecked == true)
                                angle = Convert.ToDouble(TextBoxCurrentNumber.Text);
                            else
                                angle = Convert.ToDouble(TextBoxCurrentNumber.Text) * Math.PI / 180.0;

                            if (angle != 0 && angle % (Math.PI / 2.0) == 0 && angle / (Math.PI / 2.0) % 2 != 0)
                            {
                                TextBoxHistory.Text = "Нельзя посчитать тангенс такого угла";
                                enableButtons(false);
                            }
                            else
                            {
                                result = Math.Tan(angle);
                                TextBoxHistory.Text = "tg(" + TextBoxCurrentNumber.Text + ")";
                                TextBoxCurrentNumber.Text = result.ToString();
                            }
                            break;
                        }
                }
            }
        }

        private void onBackspaceClick(object sender, RoutedEventArgs e)
        {
            if (TextBoxCurrentNumber.Text.Length > 1)
            {
                TextBoxCurrentNumber.Text = TextBoxCurrentNumber.Text.Remove(TextBoxCurrentNumber.Text.Length - 1);
            }
            else
            {
                if (TextBoxCurrentNumber.Text != "0")
                {
                    TextBoxCurrentNumber.Text = "0";
                }
            }
        }
    }
}
