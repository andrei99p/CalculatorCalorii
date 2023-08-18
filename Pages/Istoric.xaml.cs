using CalculatorCalorii.Classes;

namespace CalculatorCalorii.Pages;

public partial class Istoric : ContentPage
{
	public Istoric()
	{
		InitializeComponent();
        MessagingCenter.Subscribe<object>(this, "IstoricAdded", (sender) => {
            InitializeData();
        });
        InitializeData();
    }

    private void InitializeData()
    {
        List<Calcule> calcul = Calcule.GetData();
        listAlimente.ItemsSource = calcul;
    }
}