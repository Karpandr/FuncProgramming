using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FuncProgramming
{
    public class DerivativeHelper
    {
		private Func<double, double> Derivative(Func<double, double> f)
		{
			var eps = 1e-10;
			return x => (f(x + eps) - f(x)) / eps;
		}

		private Series BuildGraph(Func<double, double> f)
		{
			var series = new Series() { ChartType = SeriesChartType.FastLine };
			for (double x = 0; x < 1; x += 0.01)
				series.Points.Add(new DataPoint(x, f(x)));
			return series;
		}

		public void BuildDerivative()
		{
			Func<double, double> function = x => x * x;
			var chart = new Chart();
			chart.ChartAreas.Add(new ChartArea());
			chart.Series.Add(BuildGraph(function));
			chart.Series.Add(BuildGraph(Derivative(function)));
			var form = new Form();
			chart.Dock = DockStyle.Fill;
			form.Controls.Add(chart);
			System.Windows.Forms.Application.Run(form);
		}
	}
}
