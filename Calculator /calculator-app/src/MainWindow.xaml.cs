using System.Windows;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        private double _result;
        private string _operation;
        private bool _isOperationPerformed;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (_isOperationPerformed)
                {
                    DisplayTextBox.Text = button.Content.ToString();
                    _isOperationPerformed = false;
                }
                else
                {
                    DisplayTextBox.Text += button.Content.ToString();
                }
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (_result != 0)
                {
                    EqualsButton_Click(this, null);
                }

                _operation = button.Content.ToString();
                _result = double.Parse(DisplayTextBox.Text);
                _isOperationPerformed = true;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            switch (_operation)
            {
                case "+":
                    DisplayTextBox.Text = (_result + double.Parse(DisplayTextBox.Text)).ToString();
                    break;
                case "-":
                    DisplayTextBox.Text = (_result - double.Parse(DisplayTextBox.Text)).ToString();
                    break;
                case "*":
                    DisplayTextBox.Text = (_result * double.Parse(DisplayTextBox.Text)).ToString();
                    break;
                case "/":
                    DisplayTextBox.Text = (_result / double.Parse(DisplayTextBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            _result = 0;
            _operation = string.Empty;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayTextBox.Text = string.Empty;
            _result = 0;
            _operation = string.Empty;
        }
    }
}