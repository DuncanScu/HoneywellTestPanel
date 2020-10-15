using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace HoneywellTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	

	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			
		}
		public class Customer //This creates a Class called "Customer", which will be used for the input
		{
			public string customerFirstName { get; set; } //Get Set is used to return the value of the variable FirstName, and assign the value to the variable.
			public string customerLastName { get; set; }
			public string customerCountry { get; set; }
			public string customerStreet { get; set; }
			public string customerCounty { get; set; }
			public string customerPostCode { get; set; }
			public string customerUsername { get; set; }
			public string customerEmail { get; set; }
			public string customerPhoneNumber { get; set; }
		}


		private void ApplyButton_Click(object sender, RoutedEventArgs e) //Activates following event when APPLY button is clicked
		{
			MessageBox.Show($"Data has been saved with the username: {this.Username.Text}"); //Simple Message Box statment
			Customer customer = new Customer(); //Creates a new customer object, where the follwing code will construct the object with the data from the user
			customer.customerFirstName = this.FirstName.Text;
			customer.customerLastName = this.LastName.Text;
			customer.customerCountry = this.Country.Text;
			customer.customerStreet = this.StreetName.Text;
			customer.customerCounty = this.County.Text;
			customer.customerPostCode = this.PostCode.Text;
			customer.customerUsername = this.Username.Text;
			customer.customerEmail = this.Email.Text;
			customer.customerPhoneNumber = this.PhoneNumber.Text;
			CustomerDataGrid.Items.Add(customer); // This adds the items of the user (From the object) to the Data Grid through the use of bindings
			//The password is not displayed because of security. Showing a password would never be a good idea.
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e) //Simple feature, to reset all fields for the user
		{
			MessageBox.Show("All Data Entered Has Been Cleared"); //Displays a message
			Password.Clear(); //Clears Password, cannot clear the password through the following method.
			this.FirstName.Text = this.LastName.Text = this.Country.Text = this.StreetName.Text = this.County.Text = this.PostCode.Text = this.PhoneNumber.Text = this.Email.Text = this.Username.Text = "";
		}

		
    }
}
