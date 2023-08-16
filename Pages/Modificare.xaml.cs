using CalculatorCalorii.Classes;
using System.Collections.ObjectModel;

namespace CalculatorCalorii.Pages;

public partial class Modificare : ContentPage
{
    private ObservableCollection<Alimente> originalItems; // Replace with your actual item type
    private ObservableCollection<Alimente> filteredItems;

    int id, calorii;
    string name= string.Empty;
	public Modificare()
	{
		InitializeComponent();
        InitializeData();
        MessagingCenter.Subscribe<object>(this, "DataAdded", (sender) => {
            List<Alimente> alimente = SQLiteCon.GetData();
            listAlimente.ItemsSource = alimente;
        });
    }

    private void Modifica_Clicked(object sender, EventArgs e)
    {
        Alimente aliment = new();
        aliment.Name = txtNume.Text;
        aliment.Calorii = int.Parse(txtCalorii.Text);
        aliment.ID = id;
        if (SQLiteCon.Update(aliment) == 1)
        {
            txtNume.Text = string.Empty;
            txtCalorii.Text = string.Empty;
            Modifica.TextColor = Color.FromArgb("#228B22");
            SQLiteCon.GetData();
            MessagingCenter.Send<object>(this, "DataAdded");
        }
        else
        {
            Modifica.TextColor = Microsoft.Maui.Graphics.Color.FromArgb("#FF0000");
        }
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        if(SQLiteCon.Delete(id)==1)
        {
            txtNume.Text = string.Empty;
            txtCalorii.Text = string.Empty;
            Delete.TextColor = Color.FromArgb("#228B22");
            SQLiteCon.GetData();
            MessagingCenter.Send<object>(this, "DataAdded");
        }
        else
            Delete.TextColor = Color.FromArgb("#FF0000");
    }

    private void listAlimente_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Alimente aliment = (Alimente)e.SelectedItem;
        txtNume.Text = aliment.Name;
        txtCalorii.Text = aliment.Calorii.ToString();
        id = aliment.ID;
        calorii = aliment.Calorii;
        name = aliment.Name;
    }

    private void InitializeData()
    {

    }
}