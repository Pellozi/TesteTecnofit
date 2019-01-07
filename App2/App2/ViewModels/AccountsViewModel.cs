using System;
using System.Collections.Generic;
using System.Text;
using App2.Helpers;
using App2.Models;
using App2.Views;
using Xamarin.Forms;

namespace App2.ViewModels
{
    class AccountsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Account> _accounts { get; set; }
        public Command LoadAccountsCommand { get; set; }
   
        public AccountsViewModel()
        {
            Title = "Accounts";
            SearchBar sb = new SearchBar
            {
                Placeholder = "Type here to search",
            };
            ListView lstView = new ListView();
            lstView.ItemsSource = _accounts;

            
        }
    }
}


