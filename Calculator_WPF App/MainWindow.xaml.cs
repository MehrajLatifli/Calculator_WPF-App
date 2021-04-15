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

namespace Calculator_WPF_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CloseButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));

            EqualsButton.IsEnabled = false;
            PercentButon.IsEnabled = false;
            Button_Div.IsEnabled = false;
            Button_Mult.IsEnabled = false;
            Button_Add.IsEnabled = false;
            Button_Minus.IsEnabled = false;
            Button_Point.IsEnabled = false;
            Button_1x.IsEnabled = false;
            Button_x2.IsEnabled = false;
            Button_root.IsEnabled = false;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CloseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            CloseButton.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            CloseButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        }

        private void CloseButton_MouseLeave(object sender, MouseEventArgs e)
        {
       

            CloseButton.Background = new SolidColorBrush(Color.FromArgb(255, 253, 253, 253));
            CloseButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

            Decimal result = 0.0M;
            string operation = "";
            bool isOperationprocess = false;

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            EqualsButton.IsEnabled = true;
            PercentButon.IsEnabled = true;
            Button_Div.IsEnabled = true;
            Button_Mult.IsEnabled = true;
            Button_Add.IsEnabled = true;
            Button_Minus.IsEnabled = true;
            Button_Point.IsEnabled = true;
            Button_1x.IsEnabled = true;
            Button_x2.IsEnabled = true;
            Button_root.IsEnabled = true;


            if (isOperationprocess)
            {
                ArenaofCaclulateTextBox.Clear();

            }

            if (sender is Button button)
            {
                if (button.Content == ".")
                {

                    if (!ArenaofCaclulateTextBox.Text.Contains("."))
                    {
                            ArenaofCaclulateTextBox.Text = ArenaofCaclulateTextBox.Text + button.Content;
                        
                    }

                }
                if (button.Content != ".")
                {
                    ArenaofCaclulateTextBox.Text = ArenaofCaclulateTextBox.Text + button.Content;
                }

                

                if (ArenaofCaclulateTextBox.Text.Length > 10)
                {
                    ArenaofCaclulateTextBox.Text = "Imposible";

                    EqualsButton.IsEnabled = false;
                    PercentButon.IsEnabled = false;
                    Button_Div.IsEnabled = false;
                    Button_Mult.IsEnabled = false;
                    Button_Add.IsEnabled = false;
                    Button_Minus.IsEnabled = false;
                    Button_Point.IsEnabled = false;
                    Button_1x.IsEnabled = false;
                    Button_x2.IsEnabled = false;
                    Button_root.IsEnabled = false;
                }

                int resultButton = ArenaofCaclulateTextBox.Text.ToCharArray().Count(c => c == '.');
                if(resultButton > 1)
                {
                    ArenaofCaclulateTextBox.Text = "Imposible";

                    EqualsButton.IsEnabled = false;
                    PercentButon.IsEnabled = false;
                    Button_Div.IsEnabled = false;
                    Button_Mult.IsEnabled = false;
                    Button_Add.IsEnabled = false;
                    Button_Minus.IsEnabled = false;
                    Button_Point.IsEnabled = false;
                    Button_1x.IsEnabled = false;
                    Button_x2.IsEnabled = false;
                    Button_root.IsEnabled = false;
                }


         
                isOperationprocess = false;
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button button)
            {

                isOperationprocess = true;



                switch (operation)
                {
                    case "-":

                        ArenaofCaclulateTextBox.Text = (result - Decimal.Parse(ArenaofCaclulateTextBox.Text)).ToString();

                        break;
                    case "÷":
                        if (Decimal.Parse(ArenaofCaclulateTextBox.Text) != 0)
                        {
                            ArenaofCaclulateTextBox.Text = (result / Decimal.Parse(ArenaofCaclulateTextBox.Text)).ToString();
                        }



                        break;
                    case "✕":
                        ArenaofCaclulateTextBox.Text = (result * Decimal.Parse(ArenaofCaclulateTextBox.Text)).ToString();

                        break;
                    case "+":
                        ArenaofCaclulateTextBox.Text = (result + Decimal.Parse(ArenaofCaclulateTextBox.Text)).ToString();

                        break;
                    case "%":

                        result = (Convert.ToDecimal(ArenaofCaclulateTextBox.Text) / Convert.ToDecimal(100));
                        ArenaofCaclulateTextBox.Text = result.ToString();

                        break;

                    case "²√x":

                        result = Convert.ToDecimal(ArenaofCaclulateTextBox.Text);
                        ArenaofCaclulateTextBox.Text = Math.Sqrt(Convert.ToDouble(result)).ToString();

                        break;
                    case "1/x":

                        result = Convert.ToDecimal(ArenaofCaclulateTextBox.Text);
                        ArenaofCaclulateTextBox.Text = (1 / result).ToString();

                        break;

                    case "x²":

                        result = Convert.ToDecimal(ArenaofCaclulateTextBox.Text);
                        ArenaofCaclulateTextBox.Text = (result * result).ToString();

                        break;

                    default:
                        break;

                }


                operation = button.Content.ToString();
                if (Decimal.Parse(ArenaofCaclulateTextBox.Text) != 0)
                {
                    result = Decimal.Parse(ArenaofCaclulateTextBox.Text);
                }

                if (Decimal.Parse(ArenaofCaclulateTextBox.Text) == 0)
                {
                    ArenaofCaclulateTextBox.Text = "Imposible";

                    EqualsButton.IsEnabled = false;
                    PercentButon.IsEnabled = false;
                    Button_Div.IsEnabled = false;
                    Button_Mult.IsEnabled = false;
                    Button_Add.IsEnabled = false;
                    Button_Minus.IsEnabled = false;
                    Button_Point.IsEnabled = false;
                    Button_1x.IsEnabled = false;
                    Button_x2.IsEnabled = false;
                    Button_root.IsEnabled = false;
                }


            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {

                isOperationprocess = true;



                switch (operation)
                {
                    case "-":

                        ArenaofCaclulateTextBox.Text = (result - Decimal.Parse(ArenaofCaclulateTextBox.Text)).ToString();

                        break;
                    case "÷":
                        if (Decimal.Parse(ArenaofCaclulateTextBox.Text) != 0)
                        {
                            ArenaofCaclulateTextBox.Text = (result / Decimal.Parse(ArenaofCaclulateTextBox.Text)).ToString();
                        }

               

                        break;
                    case "✕":
                        ArenaofCaclulateTextBox.Text = (result * Decimal.Parse(ArenaofCaclulateTextBox.Text)).ToString();

                        break;
                    case "+":
                        ArenaofCaclulateTextBox.Text = (result + Decimal.Parse(ArenaofCaclulateTextBox.Text)).ToString();

                        break;
                    case "%":

                        result = (Convert.ToDecimal(ArenaofCaclulateTextBox.Text) / Convert.ToDecimal(100));
                        ArenaofCaclulateTextBox.Text = result.ToString();

                        break;

                    case "²√x":

                        result = Convert.ToDecimal(ArenaofCaclulateTextBox.Text);
                        ArenaofCaclulateTextBox.Text = Math.Sqrt(Convert.ToDouble(result)).ToString();

                        break;
                    case "1/x":

                        result = Convert.ToDecimal(ArenaofCaclulateTextBox.Text);
                        ArenaofCaclulateTextBox.Text = (1 / result).ToString();

                        break;

                    case "x²":

                        result = Convert.ToDecimal(ArenaofCaclulateTextBox.Text);
                        ArenaofCaclulateTextBox.Text = (result * result).ToString();

                        break;

                    default:
                        break;

                }


                operation = button.Content.ToString();
                if (Decimal.Parse(ArenaofCaclulateTextBox.Text) != 0)
                {
                    result = Decimal.Parse(ArenaofCaclulateTextBox.Text);
                }

                if (Decimal.Parse(ArenaofCaclulateTextBox.Text) == 0)
                {
                    ArenaofCaclulateTextBox.Text = "Imposible";

                    EqualsButton.IsEnabled = false;
                    PercentButon.IsEnabled = false;
                    Button_Div.IsEnabled = false;
                    Button_Mult.IsEnabled = false;
                    Button_Add.IsEnabled = false;
                    Button_Minus.IsEnabled = false;
                    Button_Point.IsEnabled = false;
                    Button_1x.IsEnabled = false;
                    Button_x2.IsEnabled = false;
                    Button_root.IsEnabled = false;
                }


                }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            EqualsButton.IsEnabled = false;
            PercentButon.IsEnabled = false;
            Button_Div.IsEnabled = false;
            Button_Mult.IsEnabled = false;
            Button_Add.IsEnabled = false;
            Button_Minus.IsEnabled = false;
            Button_Point.IsEnabled = false;
            Button_1x.IsEnabled = false;
            Button_x2.IsEnabled = false;
            Button_root.IsEnabled = false;

            ArenaofCaclulateTextBox.Clear();

            ArenaofCaclulateTextBox.Text.Trim();
            result.Equals(null);
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (ArenaofCaclulateTextBox.Text.Length > 0)
            {
                ArenaofCaclulateTextBox.Text = ArenaofCaclulateTextBox.Text.Remove(ArenaofCaclulateTextBox.Text.Length - 1, 1);

                if(ArenaofCaclulateTextBox.Text=="")
                {
                    EqualsButton.IsEnabled = false;
                    PercentButon.IsEnabled = false;
                    Button_Div.IsEnabled = false;
                    Button_Mult.IsEnabled = false;
                    Button_Add.IsEnabled = false;
                    Button_Minus.IsEnabled = false;
                    Button_Point.IsEnabled = false;
                    Button_1x.IsEnabled = false;
                    Button_x2.IsEnabled = false;
                    Button_root.IsEnabled = false;
                }
            }
        }

   



        private void RadToggleSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            if (colorbutton.IsChecked == true)
            {
                this.Background = new SolidColorBrush(Color.FromArgb(255, 170, 0, 255));
                this.Opacity = .8;
                ArenaofCaclulateTextBox.Background = new SolidColorBrush(Color.FromArgb(255, 5, 5, 5));
                ArenaofCaclulateTextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                ArenaofCaclulateTextBox.Opacity = .5;

                CloseButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));

            }

            else
            {
                this.Background = new SolidColorBrush(Color.FromArgb(255, 70, 30, 55));
                this.Opacity = .8;
                ArenaofCaclulateTextBox.Background = new SolidColorBrush(Color.FromArgb(255, 25, 115, 25));
                ArenaofCaclulateTextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                ArenaofCaclulateTextBox.Opacity = .5;

                CloseButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));

            }
        }

      
    }
}
