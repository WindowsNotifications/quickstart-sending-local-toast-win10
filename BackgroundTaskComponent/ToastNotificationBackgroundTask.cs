using Microsoft.QueryStringDotNET;
using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.UI.Notifications;

namespace BackgroundTaskComponent
{
    public sealed class ToastNotificationBackgroundTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            // Get a deferral since we're executing async code
            var deferral = taskInstance.GetDeferral();

            try
            {
                // If it's a toast notification action
                if (taskInstance.TriggerDetails is ToastNotificationActionTriggerDetail)
                {
                    // Get the toast activation details
                    var details = taskInstance.TriggerDetails as ToastNotificationActionTriggerDetail;

                    // Deserialize the arguments received from the toast activation
                    QueryString args = QueryString.Parse(details.Argument);

                    // Depending on what action was taken...
                    switch (args["action"])
                    {
                        // User clicked the reply button (doing a quick reply)
                        case "reply":
                            await HandleReply(details, args);
                            break;

                        // User clicked the like button
                        case "like":
                            await HandleLike(details, args);
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }

                // Otherwise handle other background activations
            }

            finally
            {
                // And finally release the deferral since we're done
                deferral.Complete();
            }
        }

        private async Task HandleReply(ToastNotificationActionTriggerDetail details, QueryString args)
        {
            // Get the conversation the toast is about
            int conversationId = int.Parse(args["conversationId"]);

            // Get the message that the user typed in the toast
            string message = (string)details.UserInput["tbReply"];

            // In a real app, this would be making a web request, sending the new message
            await Task.Delay(TimeSpan.FromSeconds(2.3));

            // In a real app, you most likely should NOT notify your user that the request completed (only notify them if there's an error)
            SendToast("Your message has been sent! Your message: " + message);
        }

        private async Task HandleLike(ToastNotificationActionTriggerDetail details, QueryString args)
        {
            // Get the conversation the toast is about
            int conversationId = int.Parse(args["conversationId"]);

            // In a real app, this would be making a web request, sending the like command
            await Task.Delay(TimeSpan.FromSeconds(1.1));

            // In a real app, you most likely should NOT notify your user that the request completed (only notify them if there's an error)
            SendToast("Your like has been sent!");
        }

        private void SendToast(string message)
        {
            ToastContent content = new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    TitleText = new ToastText()
                    {
                        Text = "Background Task Completed"
                    },

                    BodyTextLine1 = new ToastText()
                    {
                        Text = message
                    }
                }
            };

            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(content.GetXml()));
        }
    }
}
