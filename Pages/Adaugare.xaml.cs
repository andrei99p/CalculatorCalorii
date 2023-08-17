using CalculatorCalorii.Classes;

namespace CalculatorCalorii.Pages;

public partial class Adaugare : ContentPage
{
	public Adaugare()
	{
		InitializeComponent();
	}

    private void Adauga_Clicked(object sender, EventArgs e)
    {	
		if (String.IsNullOrEmpty(txtNume.Text) || String.IsNullOrEmpty(txtCalorii.Text))
		{
            Adauga.TextColor = Color.FromArgb("#FF0000");
            return;
        }

        if (!String.IsNullOrEmpty(txtCalorii.Text))
			try
			{
				int a = int.Parse(txtCalorii.Text);
			}
			catch
			{ 
				return;
			}

		Alimente aliment = new();
		aliment.Name = txtNume.Text;
		aliment.Calorii = int.Parse(txtCalorii.Text);

		if (Alimente.Insert(aliment) == 1)
		{
			txtNume.Text = string.Empty;
			txtCalorii.Text = string.Empty;
			Adauga.TextColor = Color.FromArgb("#69BE28");
            MessagingCenter.Send<object>(this, "DataAdded");
        }
		else
		{
            Adauga.TextColor = Color.FromArgb("#FF0000");
        }
    }
}