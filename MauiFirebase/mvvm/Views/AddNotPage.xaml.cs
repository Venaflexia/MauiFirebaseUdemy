using MauiFirebase.FirebaseMaui;

namespace MauiFirebase.mvvm.Views;

public partial class AddNotPage : ContentPage
{
	public AddNotPage()
	{
		InitializeComponent();
	}
    private void Button_ClickedKaydet(object sender, EventArgs e)
    {
        FirebaseFirestore.notekle(new mvvm.Models.NotOzellikleri { Icerik = editor_content.Text, PaylasanKisi = entry_name.Text, OlusturulmaTarihi = DateTime.Now });
    }
}