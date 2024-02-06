using BeerQuoran.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


namespace BeerQuoran.ViewModel.Helpers
{
    static public class ApiHelper
    {
        public const string QuoranApiUrl = "https://api.alquran.cloud/v1/ayah/{0}/editions/quran-uthmani,en.pickthall";
        public const string BeerApiUrl = "https://api.punkapi.com/v2/beers";

         public static async Task<List<Beer>> getBeers(string query) {
            List<Beer>? beers = new();
            string url = BeerApiUrl + query;
            using (HttpClient client = new())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                beers = JsonConvert.DeserializeObject<List<Beer>>(json);
            }

            return beers;


        }
        public static async Task<Quoran> getQuoran(int id)
        {
            Quoran? quoran = new();
            string url = string.Format(QuoranApiUrl, id);
            using (HttpClient client = new())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                quoran = JsonConvert.DeserializeObject<Quoran>(json);
            }

            return quoran;


        }

        public static async Task<List<BeerWithQuoran>> getBeerQuorans(string query)
        {
            List<BeerWithQuoran>? beerWithQuorans = new();
            List<Beer> beers = await getBeers(query);
            foreach (Beer beer in beers)
            {
                Quoran quoran = await getQuoran(beer.id);
                BeerWithQuoran bq = new BeerWithQuoran();
                bq.quoran = quoran;
                bq.beer = beer;
                bq.QuoranText = quoran.data[1].text;
                beerWithQuorans.Add(bq);
            }
            return beerWithQuorans;

        }





    }
}
