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

        while (calcul.Count > 3)
        {
            Calcule calculat = calcul[0];
            Calcule.Delete(calculat.ID);
            calcul = Calcule.GetData();
        }
    }
}