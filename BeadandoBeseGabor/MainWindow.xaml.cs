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
		Invoice invoiceOne;
		Invoice invoiceTwo;

		public MainWindow()
		{
			InitializeComponent();

			invoiceOne = new Invoice(1, "Balázs", 5000);
			invoiceTwo = new Invoice(2, "Patrik", 5000);

			RefreshUI();
		}
		/// <summary>
		/// Definition of the deposition function, responsible for increasing the subject invoce available money with the given ammount
		/// </summary>
		private void Deposite(Invoice invoice, string amount)
		{
			try
			{
				if (int.Parse(amount) > 0)
				{
					invoice.amount += int.Parse(amount);
					RefreshUI();
				}
				else
				{
					throw new ArgumentException();
				}
			}
			catch (Exception)
			{

				MessageBox.Show("Csak pozitív egész szám adaható meg a tranzakció értékeként", "Hiba történt!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		/// <summary>
		/// Definition of the transfer function, responsible for transfering the given ammount from the subject invocie to the another invoice
		/// </summary>
		private void Transfer(Invoice sender, Invoice destination, string amount)
		{
			try
			{
				if (sender.amount > int.Parse(amount))
				{
					sender.amount -= int.Parse(amount);
					destination.amount += int.Parse(amount);
					RefreshUI();
				}
				else
				{
					throw new ArgumentException();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Az utaláshoz rendelkezni kell elegendő összeggel illetve csak pozitív egész szám adaható meg a tranzakció értékeként", "Hiba történt!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		/// <summary>
		/// Definition of the withdraw function, responsible for decreasing the subject invoce available money with the given ammount
		/// </summary>
		private void Withdraw(Invoice invoice, string amount)
		{
			try
			{
				if (int.Parse(amount) > 0 && invoice.amount >= int.Parse(amount))
				{
					invoice.amount -= int.Parse(amount);
					RefreshUI();
				}
				else
				{
					throw new ArgumentException();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Csak pozitív egész szám adaható meg a tranzakció értékeként", "Hiba történt!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		/// <summary>
		/// Definition of the swap owners name function, responsible for swapping the subject invoce current owners name with the given name
		/// </summary>
		private void SwapOwnersName(Invoice invoice, string name)
		{
			try
			{
				invoice.owner = name;
				RefreshUI();
			}
			catch (Exception)
			{
				MessageBox.Show("Csak pozitív egész szám adaható meg a tranzakció értékeként", "Hiba történt!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		/// <summary>
		/// Definition of the refresh function, responsible for fetching invoice objects current state with the UI
		/// </summary>
		private void RefreshUI()
		{
			FirstOwnerTextBox.Text = invoiceOne.owner;
			SecondOwnerTextBox.Text = invoiceTwo.owner;
			FirstMoneyTextBox.Text = invoiceOne.amount.ToString();
			SecondMoneyTextBox.Text = invoiceTwo.amount.ToString();
		}

		private void DepositButtonOne_Click(object sender, RoutedEventArgs e)
		{
			Deposite(invoiceOne, FirstAmountTextBox.Text);
		}

		private void TransferButtonOne_Click(object sender, RoutedEventArgs e)
		{
			Transfer(invoiceOne, invoiceTwo, FirstAmountTextBox.Text);
		}

		private void WithdrawButtonOne_Click(object sender, RoutedEventArgs e)
		{
			Withdraw(invoiceOne, FirstAmountTextBox.Text);
		}

		private void DepositButtonTwo_Click(object sender, RoutedEventArgs e)
		{
			Deposite(invoiceTwo, SecondAmountTextBox.Text);
		}

		private void TransferButtonTwo_Click(object sender, RoutedEventArgs e)
		{
			Transfer(invoiceTwo, invoiceOne, SecondAmountTextBox.Text);
		}

		private void WithdrawButtonTwo_Click(object sender, RoutedEventArgs e)
		{
			Withdraw(invoiceTwo, SecondAmountTextBox.Text);
		}

		private void SwapOwnersNameButtonOne_Click(object sender, RoutedEventArgs e)
		{
			SwapOwnersName(invoiceOne, FirstAmountTextBox.Text);
		}
		
		private void SwapOwnersNameButtonTwo_Click(object sender, RoutedEventArgs e)
		{
			SwapOwnersName(invoiceTwo, SecondAmountTextBox.Text);
		}
	}
}
