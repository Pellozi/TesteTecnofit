using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountsDetails : ContentPage
	{
        public string _token;
        bool isBusy { get; set; }
        public object Ac;
        public AccountsDetails (object accounts, string tk)
		{          
            InitializeComponent();
            Ac = accounts;
            _token = tk;
            gridDetails.BindingContext = Ac;
            gridDetailsAccounts.BindingContext = Ac;           
        }
        private async void AddOn_Clicked(object sender, EventArgs e)
        {
            if (isBusy)
                return;
            isBusy = true;
            await Navigation.PushAsync(new AddNewAccount(_token));
            isBusy = false;
        }
    }
}