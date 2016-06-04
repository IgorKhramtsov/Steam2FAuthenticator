using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using _2FAuthApp;

namespace _2FAuthApp.Droid
{
	[Activity (Label = "_2FAuthApp.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Login);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.buttonLogin);

            button.Click += LoginClick;
		}

        private void LoginClick(object sender, EventArgs e)
        {
            string username, password;
            username = FindViewById<EditText>(Resource.Id.editTextUsername).Text;
            password = FindViewById<EditText>(Resource.Id.editTextPassword).Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return;
            var result = CSteamAuth.Login(username, password);
        }
    }
}


