using System.Windows.Input;

namespace ViewModels
{
    public class CurrencyCalcViewModel : BaseViewModel
    {
        private string _ilsAmountText = string.Empty;
        private string _usdResult = "0.00";
        private string _eurResult = "0.00";
        private string _gbpResult = "0.00";
        private string _jpyResult = "0.00";
        private string _chfResult = "0.00";

        public string IlsAmountText
        {
            get => _ilsAmountText;
            set { _ilsAmountText = value; OnPropertyChanged(); }
        }

        public string UsdResult
        {
            get => _usdResult;
            set { _usdResult = value; OnPropertyChanged(); }
        }

        public string EurResult
        {
            get => _eurResult;
            set { _eurResult = value; OnPropertyChanged(); }
        }

        public string GbpResult
        {
            get => _gbpResult;
            set { _gbpResult = value; OnPropertyChanged(); }
        }

        public string JpyResult
        {
            get => _jpyResult;
            set { _jpyResult = value; OnPropertyChanged(); }
        }

        public string ChfResult
        {
            get => _chfResult;
            set { _chfResult = value; OnPropertyChanged(); }
        }

       
        private const double RateUsd = 0.27;
        private const double RateEur = 0.25;
        private const double RateGbp = 0.21;
        private const double RateJpy = 41.50;
        private const double RateChf = 0.24;

        public ICommand ConvertCommand { get; }
        public ICommand GoHomeCommand { get; }

        public CurrencyCalcViewModel()
        {
            Title = "מחשבון מטח";
            ConvertCommand = new Command(ConvertCurrency);
            GoHomeCommand = new Command(async () => await GoHomeAsync());
        }

        private void ConvertCurrency()
        {
            if (double.TryParse(IlsAmountText, out double ilsAmount) && ilsAmount >= 0)
            {
                UsdResult = (ilsAmount * RateUsd).ToString("N2");
                EurResult = (ilsAmount * RateEur).ToString("N2");
                GbpResult = (ilsAmount * RateGbp).ToString("N2");
                JpyResult = (ilsAmount * RateJpy).ToString("N2");
                ChfResult = (ilsAmount * RateChf).ToString("N2");
            }
            else
            {
                UsdResult = EurResult = GbpResult = JpyResult = ChfResult = "0.00";
            }
        }

        private async Task GoHomeAsync()
        {
            await Shell.Current.GoToAsync("//WelcomePage");
        }
    }
}