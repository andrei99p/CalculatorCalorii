using CalculatorCalorii.Classes;
using CalculatorCalorii.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Platform;
using System.Collections.ObjectModel;

namespace CalculatorCalorii
{
    public partial class MainPage : ContentPage
    {
        double calorii = 0;
        
        private ObservableCollection<Alimente> originalItems; 
        private ObservableCollection<Alimente> filteredItems;

        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<object>(this, "DataAdded", (sender) => {
                InitializeData();
            });
            InitializeData();
                 
        }

        private void btnAdaugare_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(Adaugare));
        }

        private void btnModificare_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(Modificare));
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
            List<Alimente> alimente = SQLiteCon.GetData();
            originalItems = new ObservableCollection<Alimente>(alimente.OrderBy(aliment => aliment.Name));
            filteredItems = originalItems;
            listAlimente.ItemsSource = filteredItems;
        }

        private void btnSuma_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtGrame.Text))
            {
                double suma = calorii * double.Parse(txtGrame.Text) +double.Parse(txtSuma.Text.Substring(0,txtSuma.Text.Length-5));
                txtSuma.Text=suma.ToString()+" kcal";
            }   
        }

        private void listAlimente_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Alimente aliment = (Alimente)e.SelectedItem;
            calorii=(double)(aliment.Calorii)/100;
        }
    }
}