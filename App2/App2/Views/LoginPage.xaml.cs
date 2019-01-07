using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.Models;
using System.Net.Http;
using Newtonsoft.Json;
using App2.Views;
using App2.Services;
using System.Threading;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        

        public LoginPage()
        {
           
            InitializeComponent();
          
            Init();
            
        }
        void Init()
        {
            LoginIcon.HeightRequest = Constants.LoginIconHeigh;
             //BackgroundColor = Constants.BackgroundColor;
            //lbl_username.TextColor = Constants.MainTextColor;
            //lbl_password.TextColor = Constants.MainTextColor;
        }
        public async void SignInProcedure(object sender, EventArgs e)
        { 
                await Teste();            
        }
         public async Task Teste()
         {
            user user = new user()
          {
              UserName = entry_username.Text,
              Password = entry_password.Text
              
         };
            RestApi rest = new RestApi();

            var asd = await rest.Post(user, "http://api.tecnofit.com.br/auth");
           
            if (asd !=null)
            {
                
                
                var qualquercoisa = asd as Token;
                await Navigation.PushAsync(new AccountPage(qualquercoisa.token),true);
            }
            else
            {
                await DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }
        }
    }
}
