using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.ExceptionServices;
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
	/// Notes:
	///		For this project, there is much more that I would have loved to do with it, if i was more experienced and had more time.
	///		Therefor, I assumed that certain conditions were met
	///		1) Password was secure (Upper,Lower,Number, and special characters)
	///		2)All details entered were valid
	///		3)Usernames could be used multiple times
	///		4)All data was entered in the lower case
	///		
	///		Given more time I would have liked to:
	///		1) implemented an autofill feature for the address
	///		2) fixed the Datagrid so that the infomation is updated with the data directly from the .txt file
	///		3) implemented password verification, with a strength setting (low/mid/high)
	///		4) More functionality in terms of editing submitted data
	

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
	
		public void WriteToFile(string first, string last, string country, string street, string county, string postcode, string user, string email, string phone)
        {
			var path = @"C:\Users\dunca\Documents\HoneywellTest\HoneywellTest\CustomerData.txt"; //Identifies where the file is
			string input = $"{first},{last},{country},{street},{county},{postcode},{phone},{email},{user}"; //Identifies the string input, that will be written to the file
			using (StreamWriter sw = File.AppendText(path)) //This is used to write the input to the file under a new line
            {
				sw.WriteLine(input);
            }
		}
		private void ApplyButton_Click(object sender, RoutedEventArgs e) //Activates following event when APPLY button is clicked
		{
			MessageBox.Show($"Data has been saved with the username: {this.Username.Text}"); //Simple Message Box statment
			Customer customer = new Customer(); //Creates a new customer object, where the following code will construct the object with the data from the user
				customer.customerFirstName = this.FirstName.Text;
				customer.customerLastName = this.LastName.Text;
				customer.customerCountry = this.Country.Text;
				customer.customerStreet = this.StreetName.Text;
				customer.customerCounty = this.County.Text;
				customer.customerPostCode = this.PostCode.Text;
				customer.customerUsername = this.Username.Text;
				customer.customerEmail = this.Email.Text;
				customer.customerPhoneNumber = this.PhoneNumber.Text;
			WriteToFile(customer.customerFirstName, customer.customerLastName, customer.customerCountry, customer.customerStreet, customer.customerCounty, customer.customerPostCode, customer.customerUsername, customer.customerEmail, customer.customerPhoneNumber);

			CustomerDataGrid.Items.Add(customer);
			// This adds the items of the user (From the object) to the Data Grid through the use of bindings
			//The password is not displayed because of security. Showing a password would never be a good idea.

			//I deally I would have liked to use the stored data to build the DataGrid, but ran into issues
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e) //Simple feature, to reset all fields for the user
		{
			MessageBox.Show("All Data Entered Has Been Cleared"); //Displays a message
			Password.Clear(); //Clears Password, cannot clear the password through the following method.
			this.FirstName.Text = this.LastName.Text = this.Country.Text = this.StreetName.Text = this.County.Text = this.PostCode.Text = this.PhoneNumber.Text = this.Email.Text = this.Username.Text = "";
		}

    }
}
