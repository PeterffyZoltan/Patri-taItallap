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
            string query = "/";
            var bqs = await ApiHelper.getBeerQuorans(query);
            beerWithQuorans.Clear();
            
            foreach (var bq in bqs)
            {
                beerWithQuorans.Add(bq);
            }




        }
        public ObservableCollection<BeerWithQuoran> beerWithQuorans { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
