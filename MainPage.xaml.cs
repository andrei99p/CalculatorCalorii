using CalculatorCalorii.Classes;
using CalculatorCalorii.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace CalculatorCalorii
{
    public partial class MainPage : ContentPage
    {

        private ObservableCollection<Alimente> originalItems; // Replace with your actual item type
        private ObservableCollection<Alimente> filteredItems;

        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<object>(this, "DataAdded", (sender) => {
                List<Alimente> alimente = SQLiteCon.GetData();
                listAlimente.ItemsSource = alimente;
            });
            InitializeData();
            searchBar.TextChanged += OnSearchBarTextChanged;
                 
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
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
        }

        private void InitializeData()
        {
            List<Alimente> alimente = SQLiteCon.GetData();
            originalItems = new ObservableCollection<Alimente>(alimente.OrderBy(aliment => aliment.Name));
                filteredItems = originalItems;
                listAlimente.ItemsSource = filteredItems;
        }

    }
}