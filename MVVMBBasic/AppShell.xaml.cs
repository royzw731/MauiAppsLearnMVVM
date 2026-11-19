namespace MVVMBBasic
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.CurrencyCalcPage), typeof(Views.CurrencyCalcPage));
        }
    }
}
