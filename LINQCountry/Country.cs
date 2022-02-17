using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQCountry
{
    public class Country
    {
        public string Name { get; init; }
        public string Capital { get; private set; }
        public ulong Population { get; private set; }
        public uint Territory { get; private set; }
        public string PartOfTheWorld { get; private set; }
        public ulong PopulationOfCapital { get; private set; }
        public List<string> MajorCities { get; init; }

        public Country(string name, string capital, ulong population, uint territory, string partOfTheWorld, ulong populationOfCapital, List<string> majorCities)
        {
            Name = name;
            Capital = capital;
            Population = population;
            Territory = territory;
            PartOfTheWorld = partOfTheWorld;
            PopulationOfCapital = populationOfCapital;
            MajorCities = majorCities;
            //MajorCities = new List<string>();
        }

        public Country()
        {
            //MajorCities = new List<string>();
        }
    }
}
