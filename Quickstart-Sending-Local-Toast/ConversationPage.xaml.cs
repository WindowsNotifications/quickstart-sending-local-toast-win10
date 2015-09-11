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
    public sealed partial class ConversationPage : BackButtonPage
    {
        public ConversationPage()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty ConversationIdProperty = DependencyProperty.Register("ConversationId", typeof(int), typeof(ConversationPage), null);

        public int ConversationId
        {
            get { return (int)GetValue(ConversationIdProperty); }
            private set { SetValue(ConversationIdProperty, value); }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Get the conversation ID
            ConversationId = (int)e.Parameter;

            // TODO: A real app would load the conversation and display it
        }
    }
}
