using Microsoft.Maui.Controls;

namespace WTW.Pages;

public partial class MyClothesTabPage : ContentPage
{
    

    public MyClothesTabPage()
    {
        InitializeComponent();
        ProductImage = new Image();

    }

    public async void AddClothes_Clicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);

                await Navigation.PushAsync(new ProductPage(localFilePath));
            }
        }

    }

    public Image ProductImage;

    public async void SelectClothes_Clicked(object sender, EventArgs e)
    {
        // Logic to change profile picture - Use of Media as only Image needs to be picked. Use of File will be chaotic as new file could be picked up
        var productphoto = await MediaPicker.PickPhotoAsync();

        if (productphoto != null)
        {
            string localFilePath = Path.Combine(FileSystem.CacheDirectory, productphoto.FileName);
            using Stream sourceStream = await productphoto.OpenReadAsync();
            using FileStream localFileStream = File.OpenWrite(localFilePath);

            await sourceStream.CopyToAsync(localFileStream);

            await Navigation.PushAsync(new ProductPage(localFilePath));


            Preferences.Default.Set("ProductPicture", localFilePath);

        
        }
    }

}
