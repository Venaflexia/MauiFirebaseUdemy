using MauiFirebase.FirebaseMaui;

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
       
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddNotPage());
    }

}