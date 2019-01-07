using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using App2.Models;
using System.Net.Http.Headers;
using App2.Views;
using App2.Services;
using App2.ViewModels;


namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        string _token { get; set; }
        bool isBusy { get; set; }
        public object ac;
        public AccountPage(string token)
        {
            InitializeComponent();
            _token = token;
            datePickerView.DateSelected += DateP_DateSelected;
        }

        private async void Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (isBusy)
                return;
            isBusy = true;
            await Navigation.PushAsync(new AccountsDetails(e.SelectedItem, _token));
            listView.SelectedItem = null;
            isBusy = false;

        }
        private void DateP_DateSelected(object sender, DateChangedEventArgs e)
        {
            getAccount();
        }
        private List<Account> _AccountsList { get; set; }
        private async Task getAccount()
        {
            RestApi rest = new RestApi();
            string dateTime = datePickerView.Date.ToString("yyyy'-'MM'-'dd");
            var asd = await rest.Get<RootObject>($"http://api.tecnofit.com.br/financeiro/extrato/dia/1036/" + dateTime, _token);

          
            if (asd == null)
                await DisplayAlert("error,", "cancel", "ok");
            else
                listView.ItemsSource = asd.accountStatement.accounts;

        }
        private async void Add_Clicked(object sender, EventArgs e)
        {
            if (isBusy)
                return;
            isBusy = true;
            await Navigation.PushAsync(new AddNewAccount(_token));
            isBusy = false;
        }

    }
}