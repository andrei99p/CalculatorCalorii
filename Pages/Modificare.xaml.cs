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
            List<Alimente> alimente = Alimente.GetData();
            listAlimente.ItemsSource = alimente;
        });
    }

    private void Modifica_Clicked(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtCalorii.Text) || String.IsNullOrEmpty(txtNume.Text))
        {
            Modifica.TextColor = Color.FromArgb("#FF0000");
            return;
        }
        Alimente aliment = new();
        aliment.Name = txtNume.Text;
        aliment.Calorii = int.Parse(txtCalorii.Text);
        aliment.ID = id;

        if (Alimente.Update(aliment) == 1)
        {
            txtNume.Text = string.Empty;
            txtCalorii.Text = string.Empty;
            Modifica.TextColor = Color.FromArgb("#69BE28");
            Alimente.GetData();
            MessagingCenter.Send<object>(this, "DataAdded");
        }
        else
        {
            Modifica.TextColor = Color.FromArgb("#FF0000");
        }
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        if(Alimente.Delete(id)==1)
        {
            txtNume.Text = string.Empty;
            txtCalorii.Text = string.Empty;
            Delete.TextColor = Color.FromArgb("#69BE28");
            Alimente.GetData();
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

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue;
        if (string.IsNullOrWhiteSpace(searchText))
        {
            listAlimente.ItemsSource = originalItems;
        }
        else
        {
            listAlimente.ItemsSource = originalItems.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase));
        }
    }

    private void InitializeData()
    {
        List<Alimente> alimente = Alimente.GetData();
        originalItems = new ObservableCollection<Alimente>(alimente.OrderBy(aliment => aliment.Name));
        listAlimente.ItemsSource = originalItems;
    }
}