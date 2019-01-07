using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.Services;
using Newtonsoft.Json.Linq;
using App2.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;
using App2.ViewModels;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewAccount : ContentPage
    {
      
        string _token { get; set; }
       
        public AddNewAccount(string token)
        {
            InitializeComponent();
            _token = token;
            BindingContext = new AddNewAccountViewModel(_token);     
        }     
    }
}
