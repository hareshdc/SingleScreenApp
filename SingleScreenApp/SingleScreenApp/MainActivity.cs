using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Media;

namespace SingleScreenApp
{
    [Activity(Label = "Single Screen App", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        MediaPlayer mp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            base.SetContentView(Resource.Layout.Main);

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

            //Play Song logic.
            Button btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.Click += delegate
            {
                mp = MediaPlayer.Create(this, Resource.Raw.Animals);
                mp.Start();

                btn1.Text = "Enjoy the song.";
            };

            //stop song logic.
            Button btn2 = FindViewById<Button>(Resource.Id.button2);
            btn2.Click += delegate
            {
                if (mp != null)
                    if (mp.IsPlaying)
                    {
                        mp.Stop();
                        btn2.Text = "Song Stopped.";
                    }

            };
        }
    }
}

