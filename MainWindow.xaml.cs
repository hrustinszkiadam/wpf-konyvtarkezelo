using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace konyvtarkezelo
{
	public partial class MainWindow : Window
	{
		public string filter = "";
		public MainWindow()
		{
			InitializeComponent();
			foreach (string mufaj in Konyv.mufajok)
			{
				Genre.Items.Add(mufaj);
			}
		}

		public void Refresh()
		{
			Title.Text = "";
			Genre.Text = "";
			Books.Items.Clear();
			foreach (Konyv k in Konyv.konyvek)
			{
				if (filter == "" || k.mufaj == filter)
				{
					Books.Items.Add(k);
				}
			}
		}

		private void AddBook(object sender, RoutedEventArgs e)
		{
			string cim = Title.Text;
			string mufaj = Genre.Text;

			if (cim == "" || mufaj == "")
			{
				MessageBox.Show("Nem adtál meg minden adatot!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			Konyv.konyvek.Add(new Konyv(cim, mufaj));
			Refresh();
		}

		private void RemoveBook(object sender, RoutedEventArgs e)
		{
			if (Books.SelectedItem == null)
			{
				return;
			}

			MessageBoxResult confirmed = MessageBox.Show("Biztosan törölni akarod a könyvet?", "Törlés", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (confirmed == MessageBoxResult.Yes)
			{
				Konyv.konyvek.Remove((Konyv)Books.SelectedItem);
				Refresh();
			}
			else
			{
				Books.SelectedItem = null;
				return;
			}
		}

		private void ListBooks(object sender, RoutedEventArgs e)
		{
			if (Konyv.konyvek.Count == 0)
			{
				MessageBox.Show("Nincs egy könyv sem!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}
			string message = "";
			foreach (Konyv k in Konyv.konyvek)
			{
				message += k + "\n";
			}
			MessageBox.Show(message, "Könyvek", MessageBoxButton.OK);
		}

		private void FilterByGenre(object sender, RoutedEventArgs e)
		{
			if (Konyv.konyvek.Count == 0)
			{
				MessageBox.Show("Nincs egy könyv sem!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}
			if (Genre.Text == "")
			{
				MessageBox.Show("Nem választottál műfajt!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			filter = Genre.Text;
			Refresh();
		}

		private void ResetFilter(object sender, RoutedEventArgs e)
		{
			filter = "";
			Refresh();
		}
	}
}