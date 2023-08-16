using CalculatorCalorii.Classes;

namespace CalculatorCalorii
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SQLiteCon.conexiune();
            MainPage = new AppShell();
        }
    }
}