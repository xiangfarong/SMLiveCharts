using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Mw.SimulationCore.ClientHC.Models;

namespace Mw.SimulationCore.ClientHC.ViewModel
{
    public class Mode
    {
        #region 柱形图
        public SeriesCollection FirstSeriesCollection { get; } 
        public string[] BarLabels { get; }
        #endregion

        #region 线性图
        public SeriesCollection LineChartSeriesCollection { get; }
        public Func<double, string> Formatter { get; set; }
        #endregion

        #region 分组柱状图
        public SeriesCollection Series { get; set; }

        // We can preset the labels ourselves
        public string[] LabelsX { get; set; }

        // We'll can also use a formatter to do it for us
        public Func<double, string> YFormatter { get; set; }
       
        public void PopulateChart()
        {
            var list = CreateL();// DatabaseOperations.GetImportData();

            var years = (from c in list select c.Year).Distinct();

            var tonnesPL = (from c in list where c.Country == "Poland" select c.Tonnes).ToList();
            var tonnesRU = (from c in list where c.Country == "Russia" select c.Tonnes).ToList();
            var tonnesGR = (from c in list where c.Country == "Greece" select c.Tonnes).ToList();

            Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="Poland",
                    Values=new ChartValues<int>(tonnesPL),
                    Fill=new SolidColorBrush(Color.FromRgb(255,0,0))
                },
                new ColumnSeries
                {
                    Title="Russia",
                    Values=new ChartValues<int>(tonnesRU),
                    Fill=new SolidColorBrush(Color.FromRgb(255,0,255))
                },
                new ColumnSeries
                {
                    Title="Greece",
                    Values=new ChartValues<int>(tonnesGR),
                    Fill=new SolidColorBrush(Color.FromRgb(0,0,255))
                }
            };

            LabelsX = years.Select(i => i.ToString()).ToArray();

            YFormatter = value => value.ToString() + "t";

            //DataContext = this;
        }

        private List<Import> CreateL()
        {
            List<Import> ls = new List<Import>();

            for (int i = 2015; i < 2020; i++)
            {
                ls.Add(new Import()
                {
                    Year = i,
                    Country = "Poland",
                    Tonnes = 50 + (2019 - i)
                });

                ls.Add(new Import()
                {
                    Year = i,
                    Country = "Russia",
                    Tonnes = 140 + i % 12
                });

                ls.Add(new Import()
                {
                    Year = i,
                    Country = "Greece",
                    Tonnes = 10 + i % 3
                });
            }
            return ls;
        }
        #endregion

        #region 饼状图
        public SeriesCollection PieChartData { get; set; }

        public void DisplayPieChart()
        {

            PieChartData = new SeriesCollection();

            //PieChartDemo.Series = PieChartData;
            int[] data = { 5, 10, 3, 7};

            foreach (int item in data)
            {
                PieChartData.Add(
                    new PieSeries
                    {
                        Title = "Item" + item.ToString(),
                        Values = new ChartValues<int> { item },
                    });
            }

        } // end of Display Pie Chart


        #endregion
        public Mode()
        {
            //初始化分组柱状图数据
            PopulateChart();

            //初始化柱形图数据
            FirstSeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Person 1",
                    Values = new ChartValues<double>{1,2,3,4,5,6},
                },
                new ColumnSeries
                {
                Title = "Person 2",
                Values = new ChartValues<double> { 2, 4, 5, 8, 6, 9 },
                }
            };
            //FirstSeriesCollection.Add(new ColumnSeries
            //{
            //    Title = "Person 2",
            //    Values = new ChartValues<double> { 2, 4, 5, 8, 6, 9 },
            //});

            BarLabels = new string[] { "value1", "value2", "another" };//, "next", "last", "actual last" };


            Formatter = value => value.ToString("N");

            //初始化线性图数据
            LineChartSeriesCollection = new SeriesCollection();
            LineChartSeriesCollection.Add(new LineSeries
            {
                Title = "hmmm",
                Values = new ChartValues<double> { 1, 5, 4, 8 }
            });
            LineChartSeriesCollection.Add(new LineSeries
            {
                Title = "asdf",
                Values = new ChartValues<double> { 5, 3, 7, 9 },
            });
            //初始化拼状图数据
            DisplayPieChart();
        }
    }
}
