using CalculatorCalorii.Pages;

namespace CalculatorCalorii
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Adaugare), typeof(Adaugare));
            Routing.RegisterRoute(nameof(Modificare), typeof(Modificare));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(Istoric), typeof(Istoric));
        }
    }
}