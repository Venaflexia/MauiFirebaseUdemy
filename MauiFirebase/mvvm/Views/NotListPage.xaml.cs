using MauiFirebase.FirebaseMaui;
using MauiFirebase.mvvm.Models;

namespace MauiFirebase.mvvm.Views;

public partial class NotListPage : ContentPage
{
	public NotListPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!FirebaseAuthMaui.GirisYapildimi())
        {
           await Navigation.PushAsync(new LoginRegisterPage());
        }
        else
        {
            IList<NotOzellikleri> mylist=await FirebaseFirestore.ReadNotList();
            mycollection.ItemsSource= mylist;
        }
      
       
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddNotPage());
    }

}