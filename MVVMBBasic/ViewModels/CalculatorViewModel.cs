using System.Windows.Input;

namespace ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        private string _number1 = string.Empty;
        private string _number2 = string.Empty;
        private string _result = "0";

        public string Number1
        {
            get => _number1;
            set
            {
                if (_number1 != value)
                {
                    _number1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Number2
        {
            get => _number2;
            set
            {
                if (_number2 != value)
                {
                    _number2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }

      
        public ICommand GoHomeCommand { get; }

        public CalculatorViewModel()
        {
            Title = "מחשבון";
            AddCommand = new Command(async () => await Calculate("+"));
            SubtractCommand = new Command(async () => await Calculate("-"));
            MultiplyCommand = new Command(async () => await Calculate("*"));
            DivideCommand = new Command(async () => await Calculate("/"));

         
            GoHomeCommand = new Command(async () => await GoHomeAsync());
        }

        private async Task Calculate(string operation)
        {
            bool isNum1Valid = double.TryParse(Number1, out double num1);
            bool isNum2Valid = double.TryParse(Number2, out double num2);

            if (!isNum1Valid || !isNum2Valid)
            {
                await ShowAlertAsync("קלט לא תקין", "אנא הכנס מספרים תקינים בשתי התיבות", "אישור");
                return;
            }

            switch (operation)
            {
                case "+":
                    Result = (num1 + num2).ToString();
                    break;
                case "-":
                    Result = (num1 - num2).ToString(); 
                    break;
                case "*":
                    Result = (num1 * num2).ToString(); 
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        await ShowAlertAsync("שגיאה", "לא ניתן לחלק באפס!", "אישור");
                        Result = "שגיאה";
                        return;
                    }
                    Result = (num1 / num2).ToString();
                    break;
            }
        }

       
        private async Task GoHomeAsync()
        {
            await Shell.Current.GoToAsync("//WelcomePage");
        }
    }
}