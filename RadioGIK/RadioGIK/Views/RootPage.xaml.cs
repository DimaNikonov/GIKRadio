using RadioGIK.Models;
using RadioGIK.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RadioGIK.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RootPage : ContentPage
	{
		public RootPage (ContextPage contextPage)
		{
			InitializeComponent ();
            this.BindingContext = new InfoPageViewModel(contextPage);
		}
    }
}