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
        Alimente aliment = new();

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
            filteredItems = originalItems;
            listAlimente.ItemsSource = filteredItems;
        }

        private void listAlimente_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            aliment = (Alimente)e.SelectedItem;
            calorii=(double)(aliment.Calorii)/100;
        }

        #region buttons

        private void btnSuma_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtGrame.Text))
            {
                double suma = calorii * double.Parse(txtGrame.Text) + double.Parse(txtSuma.Text.Substring(0, txtSuma.Text.Length - 5));
                txtSuma2.Text = " + " + (calorii * double.Parse(txtGrame.Text)).ToString();
                txtSuma.Text = suma.ToString() + " kcal";

                Calcule calcul = new();
                calcul.Calcul = aliment.Name + " : " + (calorii * double.Parse(txtGrame.Text)).ToString("#.##") + " kcal";
                if(Calcule.Insert(calcul)==1);
                    MessagingCenter.Send<object>(this, "IstoricAdded");
            }
        }

        private void btnClear_Clicked_1(object sender, EventArgs e)
        {
            txtSuma.Text = "0 kcal";
            txtSuma2.Text = string.Empty;
            txtGrame.Text = string.Empty;
            InitializeData();
        }
        #endregion

        #region pages
        private void btnIstoric_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(Istoric));
        }
        private void btnAdaugare_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(Adaugare));
        }
        private void btnModificare_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(Modificare));
        }
        #endregion
    }
}