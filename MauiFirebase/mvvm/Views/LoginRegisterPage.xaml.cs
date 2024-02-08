using MauiFirebase.FirebaseMaui;

namespace MauiFirebase.mvvm.Views;

public partial class LoginRegisterPage : ContentPage
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public LoginRegisterPage()
	{
		InitializeComponent();
        this.BindingContext = this;
	}
    private void Button_ClickedKayitGiris(object sender, EventArgs e)
    {
        if (stacklGiris.IsVisible)
        {
            stacklGiris.IsVisible = false;
            stacklKayit.IsVisible = true;
        }
        else
        {
            stacklGiris.IsVisible = true;
            stacklKayit.IsVisible = false;
        }
    }

    private async void Button_ClickedGirisYap(object sender, EventArgs e)
    {
        bool result = await FirebaseAuthMaui.GirisYap(Email, Password);
        if (result)
        {
            // await DisplayAlert("Bilgi", "Test baþarýlý", "ok");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Bilgi", "Hatalý Giriþ", "ok");
        }
    }

    private async void Button_ClickedKayitOl(object sender, EventArgs e)
    {
        bool result = await FirebaseAuthMaui.KayitOl(UserName, Email, Password);
        if (result)
        {
            await DisplayAlert("Bilgi", "Test baþarýlý", "ok");
        }
    }
}