using System.Windows.Input;

namespace ViewModels 
{
    public class CalcAgeViewModel : BaseViewModel
    {
        private string _birthYearText = string.Empty;
        private string _ageResult = "הכנס שנת לידה";

        public string BirthYearText
        {
            get => _birthYearText;
            set
            {
                if (_birthYearText != value)
                {
                    _birthYearText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string AgeResult
        {
            get => _ageResult;
            set
            {
                if (_ageResult != value)
                {
                    _ageResult = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CalculateAgeCommand { get; }
        public ICommand GoHomeCommand { get; }

        public CalcAgeViewModel()
        {
            Title = "מחשבון גיל";
            CalculateAgeCommand = new Command(CalculateAge);
            GoHomeCommand = new Command(async () => await GoHomeAsync());
        }

        private void CalculateAge()
        {
            if (int.TryParse(BirthYearText, out int birthYear))
            {
                int currentYear = DateTime.Now.Year;
                int age = currentYear - birthYear;

                if (age >= 0 && age <= 120)
                {
                    AgeResult = $"הגיל שלך הוא: {age}";
                }
                else
                {
                    AgeResult = "שנת לידה לא שולית או לא תקינה";
                }
            }
            else
            {
                AgeResult = "אנא הכנס מספר תקין";
            }
        }

        private async Task GoHomeAsync()
        {
            await Shell.Current.GoToAsync("//WelcomePage");
        }
    }
}