using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mw.SimulationCore.ClientHC.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //public virtual event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        ///// <summary>
        ///// 属性值变化时发生
        ///// </summary>
        ///// <param name="propertyName"></param>
        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    if (this.PropertyChanged != null)
        //        this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        //}

        ///// <summary>
        ///// 属性值变化时发生
        ///// </summary>
        ///// <param name="propertyName"></param>
        //protected virtual void OnPropertyChanged<T>(System.Linq.Expressions.Expression<Func<T>> propertyExpression)
        //{
        //    var propertyName = (propertyExpression.Body as System.Linq.Expressions.MemberExpression).Member.Name;
        //    this.OnPropertyChanged(propertyName);
        //}


        SeriesCollection series = new SeriesCollection();
        List<string> labels = new List<string>();
        SeriesCollection seriesBar = new SeriesCollection();
        SeriesCollection seriesPie = new SeriesCollection();
        SeriesCollection seriesRadar = new SeriesCollection();
        SeriesCollection seriesStackedBarChart = new SeriesCollection();

        public SeriesCollection Series
        {
            get
            {
                return series;
            }

            set
            {
                series = value;
                RaisePropertyChanged("Series");
            }
        }

        public List<string> Labels
        {
            get
            {
                return labels;
            }

            set
            {
                labels = value;
                RaisePropertyChanged("Labels");
            }
        }

        public SeriesCollection SeriesBar
        {
            get
            {
                return seriesBar;
            }

            set
            {
                seriesBar = value;
                RaisePropertyChanged("SeriesBar");
            }
        }

        public SeriesCollection SeriesPie
        {
            get
            {
                return seriesPie;
            }

            set
            {
                seriesPie = value;
                RaisePropertyChanged("SeriesPie");
            }
        }

        public SeriesCollection SeriesRadar
        {
            get
            {
                return seriesRadar;
            }

            set
            {
                seriesRadar = value;
                RaisePropertyChanged("SeriesRadar");
            }
        }

        public SeriesCollection SeriesStackedBarChart
        {
            get
            {
                return seriesStackedBarChart;
            }

            set
            {
                seriesStackedBarChart = value;
                RaisePropertyChanged("SeriesStackedBarChart");
            }
        }

        public ViewModelBase()
        {
            List<double> data = new List<double>();
            data.Add(5);
            data.Add(6);
            data.Add(7);
            data.Add(5);
            data.Add(4);
            data.Add(3);
            Labels = new List<string>();
            Labels.Add("Pedro");
            Labels.Add("Juan");
            Labels.Add("Diego");
            Labels.Add("Pablo");
            Labels.Add("Marcos");
            Labels.Add("Manuel");

            ChartValues<double> cv = new ChartValues<double>();
            cv.AddRange(data);

            var lineSerie = new LineSeries
            {
                Title = "Values",
                Values = cv,
            };

            Series.Clear();
            Series.Add(lineSerie);

            //var barSerie = new BarSeries
            //{
            //    Title = "Values",
            //    Values = cv,
            //};

            SeriesBar.Clear();
            //SeriesBar.Add(barSerie);

            var pieSerie = new PieSeries
            {
                Title = "Values",
                Values = cv,
            };

            SeriesPie.Clear();
            SeriesPie.Add(pieSerie);

            //var radarSerie = new RadarSeries
            //{
            //    Title = "Values",
            //    Values = cv,
            //};

            //SeriesRadar.Clear();
            //SeriesRadar.Add(radarSerie);

            //var StackedBarChartSerie = new StackedBarSeries
            //{
            //    Title = "Values1",
            //    Values = cv,
            //};
            //var StackedBarChartSerie2 = new StackedBarSeries
            //{
            //    Title = "Values2",
            //    Values = cv,
            //};

            SeriesStackedBarChart.Clear();
            //SeriesStackedBarChart.Add(StackedBarChartSerie);
            //SeriesStackedBarChart.Add(StackedBarChartSerie2);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
