using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

/* This is a test project, just using this to practise connecting to Azure etc.
* Will delete and replace with actual project when done. Basic app adapted from tutorial at
* http://www.c-sharpcorner.com/article/how-to-add-azure-mobile-app-to-an-uwp-app/ */

namespace TestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        IMobileServiceTable<testtable> userTableObj = App.MobileService.GetTable<testtable>();

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                testtable obj = new testtable();
                obj.firstname = txtFirstName.Text;
                obj.lastname = txtLastName.Text;
                obj.city = txtCity.Text;
                await userTableObj.InsertAsync(obj);
                MessageDialog msgDialog = new MessageDialog("Data Inserted!!");
                await msgDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                await msgDialogError.ShowAsync();
            }
        }
    }
}
