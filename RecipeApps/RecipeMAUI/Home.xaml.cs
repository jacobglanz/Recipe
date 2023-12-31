namespace RecipeMAUI;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
        this.Loaded += Home_Loaded;
    }

    private async void Home_Loaded(object sender, EventArgs e)
    {
        if (!App.LoggedIn)
        {
            await Navigation.PushModalAsync(new Login());
        }
    }
}