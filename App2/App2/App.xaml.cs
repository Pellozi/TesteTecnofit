using App2.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App2
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();
           MainPage = new NavigationPage(new LoginPage());
          
            //SetMainPage();
		}
      
  //      public static void SetMainPage()
		//{
  //          Current.MainPage = new TabbedPage
  //         {
  //          //   Children =
  //          //   {
  //          //        new NavigationPage(new LoginPage())
  //          //       {
  //          //          Title = "login",
  //          //         Icon = Device.OnPlatform<string>("tab_login.png",null,null)
  //          //        },
  //          //       //  new NavigationPage(new AccountPage())
  //          //       // {
  //          //       //     Title = "Accounts",
  //          //       //    Icon = Device.OnPlatform<string>("tab_Account.png",null,null)
  //          //       //},
  //          //       // new NavigationPage(new ItemsPage())
  //          //       // {
  //          //       //     Title = "Browse",
  //          //       //    Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
  //          //       //},
  //          //       // new NavigationPage(new AboutPage())
  //          //       // {
  //          //       //     Title = "About",
  //          //       //     Icon = Device.OnPlatform<string>("tab_about.png",null,null)
  //          //       // },
  //          //    }
  //          //};
  //      }
	}
}
