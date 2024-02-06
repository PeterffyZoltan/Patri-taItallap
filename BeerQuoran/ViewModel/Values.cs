using BeerQuoran.Model;
using BeerQuoran.ViewModel.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerQuoran.ViewModel
{
    public class Values : INotifyPropertyChanged
    {
        

        public async void MakeQuery()
        {
            string localQuery = "";
            if (NameQuery != null && NameQuery.Length > 0)
            {
                localQuery += "?per_page=1&beer_name=";
                localQuery += NameQuery;
            }
            else {
                localQuery += "/random";
            }
            var bqs = await ApiHelper.getBeerQuorans(localQuery);
            beerWithQuorans.Clear();
            
            foreach (var bq in bqs)
            {
                beerWithQuorans.Add(bq);
            }
            SelectedBeer = bqs[0];



        }

        private BeerWithQuoran? selectedBeer;
        public BeerWithQuoran SelectedBeer
        {
            get { return selectedBeer; }
            set
            {
                selectedBeer = value;
                OnPropertyChanged(nameof(SelectedBeer));
            }
        }

        private string? nameQuery;
        public string NameQuery
        {
            get { return nameQuery; }
            set
            {
                nameQuery = value;
                OnPropertyChanged(nameof(NameQuery));
            }
        }

        public ObservableCollection<BeerWithQuoran> beerWithQuorans { get; set; } = new();
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
