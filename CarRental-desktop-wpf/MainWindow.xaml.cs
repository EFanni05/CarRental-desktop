using CarRental_desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRental_desktop_wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		class DataItem
		{
			public int Id { get; set; }

			public string License_plate_number { get; set; }

			public string Brand { get; set; }

			public string Model { get; set; }

			public int Daily_cost { get; set; }
		}
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Onload(object sender, RoutedEventArgs e)
		{
			try
			{
				Statisztika stat = new Statisztika();
				var cars = stat.GetCar();
				if (cars == null || cars.Count == 0)
				{
					throw new Exception("something gone wrong!");
				}
				else
				{
					gridData.ItemsSource = cars.Select(r => new DataItem
					{
						License_plate_number = r.License_plate_number,
						Brand = r.Brand,
						Model = r.Model,
						Daily_cost = r.Daily_cost,
					});
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
