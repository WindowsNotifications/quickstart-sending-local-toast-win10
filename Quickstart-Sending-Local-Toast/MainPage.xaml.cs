using NotificationsExtensions.Toasts;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Notifications;
using Microsoft.QueryStringDotNET;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Quickstart_Sending_Local_Toast
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ButtonSendToast_Click(object sender, RoutedEventArgs e)
        {
            // In an actual app, these variables would be initialized with actual data
            string title = "Andrew sent you a picture";
            string content = "Check this out, Happy Canyon in Utah!";
            string image = "http://blogs.msdn.com/cfs-filesystemfile.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-01-71-81-permanent/2727.happycanyon1_5B00_1_5D00_.jpg";
            string logo = "ms-appdata:///local/Andrew.jpg";
            string conversationId = "384928";

            ToastVisual visual = new ToastVisual()
            {
                TitleText = new ToastText()
                {
                    Text = title
                },

                BodyTextLine1 = new ToastText()
                {
                    Text = content
                },

                InlineImages =
                {
                    new ToastImage()
                    {
                        Source = new ToastImageSource(image)
                    }
                },

                AppLogoOverride = new ToastAppLogo()
                {
                    Source = new ToastImageSource(logo),
                    Crop = ToastImageCrop.Circle
                }
            };

            ToastActionsCustom actions = new ToastActionsCustom()
            {
                Inputs =
                {
                    new ToastTextBox("tbReply")
                    {
                        PlaceholderContent = "Type a response"
                    }
                },

                Buttons =
                {
                    new ToastButton("Reply", new QueryString()
                    {
                        { "action", "reply" },
                        { "conversationId", conversationId }

                    }.ToString())
                    {
                        ActivationType = ToastActivationType.Background,
                        ImageUri = "Assets/Reply.png",

                        // Reference the text box's ID in order to
                        // place this button next to the text box
                        TextBoxId = "tbReply"
                    },

                    new ToastButton("Like", new QueryString()
                    {
                        { "action", "like" },
                        { "conversationId", conversationId }

                    }.ToString())
                    {
                        ActivationType = ToastActivationType.Background
                    },

                    new ToastButton("View", new QueryString()
                    {
                        { "action", "viewImage" },
                        { "imageUrl", image }

                    }.ToString())
                }
            };


            // Now we can construct the final toast content
            ToastContent toastContent = new ToastContent()
            {
                Visual = visual,
                Actions = actions,

                // Arguments when the user taps body of toast
                Launch = new QueryString()
                {
                    { "action", "viewConversation" },
                    { "conversationId", conversationId }

                }.ToString()
            };


            // And create the toast notification
            ToastNotification notification = new ToastNotification(toastContent.GetXml());


            // And then send the toast
            ToastNotificationManager.CreateToastNotifier().Show(notification);
        }
    }
}
