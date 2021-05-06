using System;
using System.Collections.Generic;
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

namespace BeadandoBeseGabor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Invoice invoiceOne = new Invoice(1, "Balázs", 5000);
		Invoice invoiceTwo = new Invoice(2, "Patrik", 5000);

		public MainWindow()
		{
			InitializeComponent();			
		}

		private void Deposite(Invoice invoice, int amount)
		{
			try
			{
				if (amount > 0)
				{
					invoice.amount += amount;
					RefreshUI();
				}
				else
				{
					throw new ArgumentException();
				}
			}
			catch (ArgumentException)
			{

				MessageBox.Show("Csak pozitív egész szám adaható meg a tranzakció értékeként", "Hiba történt!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void Transfer(Invoice sender, Invoice destination, int amount)
		{
			try
			{
				if (sender.amount > amount)
				{
					sender.amount -= amount;
					destination.amount += amount;
					RefreshUI();
				}
				else
				{
					throw new ArgumentException();
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Az utaláshoz rendelkezni kell elegendő összeggel illetve csak pozitív egész szám adaható meg a tranzakció értékeként", "Hiba történt!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void Withdraw(Invoice invoice, int amount)
		{
			try
			{
				if (amount > 0 && invoice.amount >= amount)
				{
					invoice.amount -= amount;
					RefreshUI();
				}
				else
				{
					throw new ArgumentException();
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Csak pozitív egész szám adaható meg a tranzakció értékeként", "Hiba történt!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void RefreshUI()
		{
			FirstMoneyTextBox.Text = invoiceOne.amount.ToString();
			SecondMoneyTextBox.Text = invoiceTwo.amount.ToString();
		}
	}
}
