using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace LJV7_DllSampleAll
{
    public partial class ResultWindow : Form
    {
        public ResultWindow()
        {
            InitializeComponent();
        }

        // Hàm setup dữ liệu chart + label
        public void SetData(
            string title,
            List<double> templX, List<double> templY,
            List<double> measX, List<double> measY,
            bool isOK)
        {
            Text = title;

            lblResult.Text = isOK ? "OK" : "NG";
            lblResult.ForeColor = isOK ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            cartesianChart1.Series.Clear();

            int nT = Math.Min(templX?.Count ?? 0, templY?.Count ?? 0);
            int nM = Math.Min(measX?.Count ?? 0, measY?.Count ?? 0);

            var templateSeries = new LiveCharts.Wpf.LineSeries
            {
                Title = "Template",
                Values = new ChartValues<LiveCharts.Defaults.ObservablePoint>(),
                Stroke = System.Windows.Media.Brushes.Blue,
                StrokeThickness = 2,
                PointGeometry = null
            };
            for (int i = 0; i < nT; i++)
                templateSeries.Values.Add(new LiveCharts.Defaults.ObservablePoint(templX[i], templY[i]));

            var measuredSeries = new LiveCharts.Wpf.LineSeries
            {
                Title = "Measured",
                Values = new ChartValues<LiveCharts.Defaults.ObservablePoint>(),
                Stroke = System.Windows.Media.Brushes.Red,
                StrokeThickness = 2,
                PointGeometry = null
            };
            for (int i = 0; i < nM; i++)
                measuredSeries.Values.Add(new LiveCharts.Defaults.ObservablePoint(measX[i], measY[i]));

            cartesianChart1.Series.Add(templateSeries);
            cartesianChart1.Series.Add(measuredSeries);

            // tuỳ chọn: mượt hơn, ít nhấp nháy
            cartesianChart1.DisableAnimations = true;
            cartesianChart1.DataTooltip = null;
        }
    }
}