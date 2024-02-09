using MauiFirebase.FirebaseMaui;
using MauiFirebase.mvvm.Models;

namespace MauiFirebase.mvvm.Views;

public partial class SelectedItemPage : ContentPage
{
	public SelectedItemPage()
	{
		InitializeComponent();
	}

    private void Button_ClickedSave(object sender, EventArgs e)
    {
        NotOzellikleri result=(NotOzellikleri)this.BindingContext;
        result.Icerik = editor_content.Text;
        result.PaylasanKisi = entry_name.Text;
        FirebaseFirestore.notguncelle(result);
    }

    private void Button_ClickedDelete(object sender, EventArgs e)
    {
        NotOzellikleri result = (NotOzellikleri)this.BindingContext;
        FirebaseFirestore.notusil(result);
    }
}