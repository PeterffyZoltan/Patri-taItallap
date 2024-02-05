using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerQuoran.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Datum
    {
        public int number { get; set; }
        public string text { get; set; }
        public Edition edition { get; set; }
        public Surah surah { get; set; }
        public int numberInSurah { get; set; }
        public int juz { get; set; }
        public int manzil { get; set; }
        public int page { get; set; }
        public int ruku { get; set; }
        public int hizbQuarter { get; set; }
        public bool sajda { get; set; }
    }

    public class Edition
    {
        public string identifier { get; set; }
        public string language { get; set; }
        public string name { get; set; }
        public string englishName { get; set; }
        public string format { get; set; }
        public string type { get; set; }
        public string direction { get; set; }
    }

    public class Quoran
    {
        public int code { get; set; }
        public string status { get; set; }
        public List<Datum> data { get; set; }
    }

    public class Surah
    {
        public int number { get; set; }
        public string name { get; set; }
        public string englishName { get; set; }
        public string englishNameTranslation { get; set; }
        public int numberOfAyahs { get; set; }
        public string revelationType { get; set; }
    }


}
