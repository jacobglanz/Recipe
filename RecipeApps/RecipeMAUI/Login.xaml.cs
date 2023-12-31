using RecipeSystem;

namespace RecipeMAUI;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private void LoginBtn_Clicked(object sender, EventArgs e)
    {
        try
        {
            MessageLbl.Text = "";
            DBManager.SetConnectionString(App.ConnStringSetting, true, UsernameTxt.Text, PasswordTxt.Text);
            App.LoggedIn = true;
            Navigation.PopModalAsync();
        }
        catch(Exception ex)
        {
            MessageLbl.Text = ex.Message;
        }
    }

    private void CancelBtn_Clicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}