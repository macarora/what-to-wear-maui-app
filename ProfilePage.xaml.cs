
using Microsoft.Maui.Controls;
using WTW.Models;

namespace WTW.Pages
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new UserModel();
            string localFilePath = Preferences.Default.Get("ProfilePicture", string.Empty);
            if (!string.IsNullOrEmpty(localFilePath))
            {
                ProfileImage.Source = ImageSource.FromFile(localFilePath);
            }




        }

        public async void ProfilePicture_Tapped(object sender, EventArgs e)
        {
            // Logic to change profile picture - Use of Media as only Image needs to be picked. Use of File will be chaotic as new file could be picked up
            var pphoto = await MediaPicker.PickPhotoAsync();

            if (pphoto != null)
            {
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, pphoto.FileName);
                using Stream sourceStream = await pphoto.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);


                Preferences.Default.Set("ProfilePicture", localFilePath);

                // Update the Image Source
                ProfileImage.Source = ImageSource.FromFile(localFilePath);
            }
        }
        // Commneting out the "Done" Button code as I it is causing issues with saving the profile picture.
        // My undertsadning is that it is stacking another page on top of the saved profile picture page.  
        //// Code for Update Button to provide Feedback to User 
        //private async void ProfileUpdate_Clicked(object sender, EventArgs e)
        //{
        //    await DisplayAlert("Profile Update", "Profile Updated Successfully", "OK");
        //    if (Parent is TabbedPage parent)
        //    {
        //        parent.CurrentPage = parent.Children[0];
        //    }


        //}

        
    }
    
}
