using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Quickstart_Sending_Local_Toast
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ImagePage : BackButtonPage
    {
        public ImagePage()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(string), typeof(ImagePage), null);

        public string ImageUrl
        {
            get { return GetValue(ImageProperty) as string; }
            set { SetValue(ImageProperty, value); }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // The parameter passed is an image URL that should be displayed
            ImageUrl = (string)e.Parameter;
        }
    }
}
