using System;
using Xamarin.Forms.Xaml;

namespace Xamarin.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Presentation
    {
        public Presentation()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        protected override bool OnBackButtonPressed() => true;
    }
}