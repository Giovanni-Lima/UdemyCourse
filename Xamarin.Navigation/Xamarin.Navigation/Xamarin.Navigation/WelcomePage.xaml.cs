using System;

namespace Xamarin.Navigation
{
    public partial class WelcomePage
    {
		public WelcomePage()
		{
			InitializeComponent();
		}

	    private async void Button_OnClicked(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new Presentation());
	    }
	}
}
