using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;

namespace SingleScreenApp
{
    [Activity(Label = "SingleScreenApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate {
                var notification = new NotificationCompat.Builder(this)
                            .SetContentTitle("Notifications")
                            .SetContentText("Clicked " + count++ + " times!")

                            .SetSmallIcon(Android.Resource.Drawable.DialogFrame)
                            .SetGroup("testGroup").Build();

                var manager = NotificationManagerCompat.From(this);
                manager.Notify(1, notification);
                button.Text = "Check Notification!";

            };
        }
    }
}

