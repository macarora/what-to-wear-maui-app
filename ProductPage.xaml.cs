using Microsoft.Maui.Controls;
using WTW.Models;

namespace WTW.Pages;

public partial class ProductPage : ContentPage
{
    ProductModel model;

	public ProductPage(string localFilePath)
	{
        model = new ProductModel();
        model.ImageSource = localFilePath;
        //ProductImage.Source = ImageSource.FromFile(localFilePath);
        BindingContext = model;

		InitializeComponent();
    }


    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save logic here
  
    }

}
