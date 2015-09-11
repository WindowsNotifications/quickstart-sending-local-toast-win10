using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Quickstart_Sending_Local_Toast
{
    public class BackButtonPage : Page
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.BackButtonVisibility = AppViewBackButtonVisibility.Visible;

            SystemNavigationManager.GetForCurrentView().BackRequested += BackButtonPage_BackRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.BackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            base.OnNavigatedFrom(e);

            SystemNavigationManager.GetForCurrentView().BackRequested -= BackButtonPage_BackRequested;
        }

        private void BackButtonPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            OnBackRequested(sender, e);
        }

        protected virtual void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (base.Frame.CanGoBack)
            {
                e.Handled = true;
                base.Frame.GoBack();
            }
        }

        public AppViewBackButtonVisibility BackButtonVisibility
        {
            get { return SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility; }
            set { SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = value; }
        }
    }
}
