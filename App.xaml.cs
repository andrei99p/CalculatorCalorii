using CalculatorCalorii.Classes;

namespace CalculatorCalorii
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            UserAppTheme = AppTheme.Light;
            SQLiteCon.conexiune();
            MainPage = new AppShell();
        }
    }
}