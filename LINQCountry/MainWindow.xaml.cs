using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LINQCountry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Country> countries = new List<Country>
            {
                new ("Russia", "Moscow", 146748590, 17098246, "Europe", 15558000, new List<string>{ "Moscow", "Novosibirsk", "Omsk" } ),
                new ("France", "Paris", 63928608, 547030, "Europe", 7777777, new List<string>{ "Paris", "Marcel" }),
                new ("Austria", "Vienna", 8935112, 83879, "Europe", 4467000, new List<string>{ "Vienna", "Graz" }),
                new ("USA", "Washington", 332278200, 9826675, "North America", 23334508, new List<string>{ "New York", "Chicago" }),
                new ("Japan", "Tokyo", 127000000, 377668, "Asia", 8888888, new List<string>{ "Tokyo", "Osaka" }),
                new ("Egypt", "Cairo", 87266562, 1001449, "Africa", 9945780, new List<string>{ "Сairo", "Alexandria" }),

            };
        public ObservableCollection<string> list;
        public MainWindow()
        {
            InitializeComponent();
            list = new ObservableCollection<string>();
            ListInfo.ItemsSource = list;
        }

        private void InfoCountryButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listInfo = from country in countries
                           from majorCitie in country.MajorCities
                           select (country.Name, country.Capital, country.Population, country.Territory, 
                        country.PartOfTheWorld, country.PopulationOfCapital, majorCitie);
            foreach (var item in listInfo)
            {
                list.Add(item.ToString());
            }
        }
        private void CountryNamesButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            /*var listName = from country in countries
                       select country.Name;*/
            var listName = countries.Select(с => с.Name); // с ипользованием расширения (лямбд)
            foreach (var item in listName)
            {
                list.Add(item);
            }
        }

        private void CapitalNamesButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listCap = from country in countries
                          select country.Capital;
            foreach (var item in listCap)
            {
                list.Add(item);
            }
        }

        private void MajorCitiesButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listCities = from country in countries
                             from majorCitie in country.MajorCities
                             where country.Name == Info.Text
                             select majorCitie;
            foreach (var item in listCities)
            {
                list.Add(item);
            }
        }
        private void PopulationOfCapitalButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listPopulat = from country in countries
                             where country.PopulationOfCapital > 5000000
                             select country.Capital;
            foreach (var item in listPopulat)
            {
                list.Add(item);
            }
        }
        private void EuropeButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            /*var listEu = from country in countries
                         where country.PartOfTheWorld == "Europe"
                         select country.Name;*/
            var listEu = countries.Where(с => с.PartOfTheWorld == "Europe").Select(с => с.Name); // с ипользованием расширения (лямбд)
            foreach (var item in listEu)
            {
                list.Add(item);
            }

        }
        private void TerritoryButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listTer = from country in countries
                          where country.Territory > 700000
                          select country.Name;
            foreach (var item in listTer)
            {
                list.Add(item);
            }
        }

        private void CapitalThelettersButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listCap = from country in countries
                          select country.Capital;
            foreach (var item in listCap)
            {
                list.Add(item);
            }
        }

        private void CapitalletterStartButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listCap = from country in countries
                          orderby country.Capital
                          select country.Capital;
            foreach (var item in listCap.TakeWhile(x => x.StartsWith("C")))
            {
                list.Add(item);
            }
        }

        private void TerritoryRangeButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listTer = from country in countries
                          where country.Territory < 10000000 && country.Territory > 500000 
                          select country.Name;
            foreach (var item in listTer)
            {
                list.Add(item);
            }
        }

        private void PopulationOfCountryButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listPopulat = from country in countries
                              where country.Population > 100000000
                              select country.Name;
            foreach (var item in listPopulat)
            {
                list.Add(item);
            }
        }
        private void Top5CountryButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listTop5 = (from country in countries
                           orderby country.Territory descending 
                           select country.Name).Take(5);
            foreach (var item in listTop5)
            {
                list.Add(item);
            }
        }
        private void Top5CapitalButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listTop5 = (from country in countries
                           orderby country.PopulationOfCapital descending
                           select country.Capital).Take(5);
            foreach (var item in listTop5)
                list.Add(item);
        }

        private void TerritoryMaxButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listTerMax_1 = from country in countries
                          where country.Territory == countries.Max(с => с.Territory) 
                          select country.Name;
            var listTerMax_2 = countries // с ипользованием расширения (лямбд)
                .Where(с => с.Territory == countries.Max(с => с.Territory))
                .Select(с => с.Name);
            foreach (var item in listTerMax_2)
            {
                list.Add(item);
            }
        }

        private void PopulationMaxButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listPopulMax_1 = from country in countries
                             where country.Population == countries.Max(с => с.Population)
                             select country.Name;
            var listPopulMax_2 = countries // с ипользованием расширения (лямбд)
                .Where(с => с.Population == countries.Max(с => с.Population))
                .Select(с => с.Name);
            foreach (var item in listPopulMax_2)
            {
                list.Add(item);
            }
        }

        private void TerritoryMinButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listPopulMax_1 = from country in countries
                                 where country.PartOfTheWorld == "Europe" where country.Population == countries.Min(с => с.Population)
                                 select country.Name;
            var listPopulMax_2 = countries // с ипользованием расширения (лямбд)
                .Where(с => с.PartOfTheWorld == "Europe")
                .Where(с => с.Population == countries.Min(с => с.Population))
                .Select(с => с.Name);
            foreach (var item in listPopulMax_2)
            {
                list.Add(item);
            }
        }

        private void TerritoryAverageButton_Click(object sender, RoutedEventArgs e) // до работать
        {
            list.Clear();
            var listPopulAve_1 = from country in countries
                                 where country.PartOfTheWorld == "Europe" 
                                 select country.Territory;
            var listPopulAve_2 = countries // с ипользованием расширения (лямбд)
                .Where(с => с.PartOfTheWorld == "Europe")
                .Select(с => с.Territory);
            //list.Add(listPopulAve_2.Average().ToString());
            //Info.Text = listPopulAve_2.Average().ToString();            
        }

        private void CountCountryButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listCount = from country in countries
                            select country;
            list.Add(listCount.Count().ToString());
        }

        private void PartOfTheWorldButton_Click(object sender, RoutedEventArgs e) // до работать
        {
            list.Clear();
            var listPart = from country in countries
                           //where country.PartOfTheWorld.Count().Max() 
                           select country.PartOfTheWorld;
            list.Add(listPart.Count().ToString());
            //Info.Text = listPart.ToString();
        }

        private void CountCountryPartOfTheWorldButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            var listCountEu = from country in countries
                            where country.PartOfTheWorld == "Europe"
                            select country;
            list.Add(listCountEu.Count().ToString());
            var listCountAsia = from country in countries
                            where country.PartOfTheWorld == "Asia"
                            select country;
            list.Add(listCountAsia.Count().ToString());
            var listCountAfrica = from country in countries
                                where country.PartOfTheWorld == "Africa"
                                select country;
            list.Add(listCountAfrica.Count().ToString());
            var listCountNA = from country in countries
                                  where country.PartOfTheWorld == "North America"
                                  select country;
            list.Add(listCountNA.Count().ToString());
        }
    }
}
