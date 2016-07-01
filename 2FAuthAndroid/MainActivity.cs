using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android.Views.InputMethods;
using Android.Views.Accessibility;
using Android.Hardware;
//using Android.Graphics;
using _2FAuthAndroidLibrary;
using System.IO;
using System.Timers;
using ZXing.QrCode.Internal;
using ApxLabs.FastAndroidCamera;

using System;
using System.Collections.Generic;
using System.Drawing; 
using Android.Util;


namespace _2FAuthAndroid
{
    [Activity(Label = "Steam Authenticator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ImageView imageViewLoading;
        TextView textViewStatus;

        LinearLayout layoutStart;
        Button buttonCreateNew;
        Button buttonLoadExisting;

        LinearLayout layoutLoadExisting;
        Preview previewCamera;
        TextView textViewCamera;

        LinearLayout layoutLogin;
        defEditText editTextUsername;
        defEditText editTextPassword;
        defEditText editTextEmailCode;
        ImageView imageViewCaptcha;
        defEditText editTextCaptchaText;
        Button buttonLogin;

        LinearLayout layoutLink;
        Button buttonLink;
        defEditText editTextSmsCode;
        defEditText editTextPhone;
        Button buttonFinalizeLink;

        LinearLayout layoutCodes;
        TextView textViewTwoFactorCode;
        ProgressBar progressBarTwoFactorCode;
        TextView textViewRevocationCode;
        ProgressBar progressBarRevocationCode;
        Button buttonDeleteAuthenticator;
        Button buttonShowRevocationCode;


        CSteamAuth cSteamAuth;
        const string steamGuardFile = "steamguard.json";
        bool keepRefreshCode;
        string sTwoFactorCode;
        int iTwoFactorCodeTime;
        Timer TimerTwoFactorTextBoxUpdate;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var root = FindViewById<LinearLayout>(Resource.Id.rootLayout);

            layoutStart = new LinearLayout(this.ApplicationContext);
            root.AddView(layoutStart);
            buttonCreateNew = new Button(this.ApplicationContext);
            buttonCreateNew.Click += ButtonCreateNew_Click;
            layoutStart.AddView(buttonCreateNew);
            buttonLoadExisting = new Button(this.ApplicationContext);
            buttonLoadExisting.Click += ButtonLoadExisting_Click;
            layoutStart.AddView(buttonLoadExisting);

            layoutLoadExisting = new LinearLayout(this.ApplicationContext) { Visibility = ViewStates.Invisible};
            root.AddView(layoutLoadExisting);
            previewCamera = new Preview(this);
            //layoutLoadExisting.AddView(previewCamera);
            textViewCamera = new TextView(this.ApplicationContext) { Text = "some text here" };
            layoutLoadExisting.AddView(textViewCamera);

            layoutLogin = new LinearLayout(this.ApplicationContext) { Visibility = ViewStates.Invisible};
            root.AddView(layoutLogin);
            editTextUsername = new defEditText(this.ApplicationContext,"Username");
            layoutLogin.AddView(editTextUsername);
            editTextPassword = new defEditText(this.ApplicationContext, "Password") { InputType = Android.Text.InputTypes.TextVariationPassword};
            layoutLogin.AddView(editTextPassword);
            editTextEmailCode = new defEditText(this.ApplicationContext, "Email code") { Visibility = ViewStates.Invisible};
            layoutLogin.AddView(editTextEmailCode);
            imageViewCaptcha = new ImageView(this.ApplicationContext) { Visibility = ViewStates.Invisible };
            layoutLogin.AddView(imageViewCaptcha);
            editTextCaptchaText = new defEditText(this.ApplicationContext, "Captcha") { Visibility = ViewStates.Invisible };
            layoutLogin.AddView(editTextCaptchaText);
            buttonLogin = new Button(this.ApplicationContext) { Text = "Login"};
            buttonLogin.Click += ButtonLogin_Click;
            layoutLogin.AddView(buttonLogin);

            layoutLink = new LinearLayout(this.ApplicationContext) { Visibility = ViewStates.Invisible };
            root.AddView(layoutLink);
            buttonLink = new Button(this.ApplicationContext);
            buttonLink.Click += ButtonLink_Click;
            layoutLink.AddView(buttonLink);
            editTextSmsCode = new defEditText(this.ApplicationContext, "SMS code") { Visibility = ViewStates.Invisible };
            layoutLink.AddView(editTextSmsCode);
            editTextPhone = new defEditText(this.ApplicationContext, "+12345678900") { Visibility = ViewStates.Invisible , InputType = Android.Text.InputTypes.ClassPhone};
            layoutLink.AddView(editTextPhone);
            buttonFinalizeLink = new Button(this.ApplicationContext) { Visibility = ViewStates.Invisible };
            buttonFinalizeLink.Click += ButtonFinalizeLink_Click;
            layoutLink.AddView(buttonFinalizeLink);

            layoutCodes = new LinearLayout(this.ApplicationContext) { Visibility = ViewStates.Invisible };
            root.AddView(layoutCodes);
            textViewTwoFactorCode = new TextView(this.ApplicationContext);
            layoutCodes.AddView(textViewTwoFactorCode);
            progressBarTwoFactorCode = new ProgressBar(this.ApplicationContext);
            layoutCodes.AddView(progressBarTwoFactorCode);
            textViewRevocationCode = new TextView(this.ApplicationContext) { Visibility = ViewStates.Invisible };
            layoutCodes.AddView(textViewRevocationCode);
            progressBarRevocationCode = new ProgressBar(this.ApplicationContext) { Visibility = ViewStates.Invisible };
            layoutCodes.AddView(progressBarRevocationCode);
            buttonDeleteAuthenticator = new Button(this.ApplicationContext);
            buttonDeleteAuthenticator.Click += ButtonDeleteAuthenticator_Click;
            layoutCodes.AddView(buttonDeleteAuthenticator);
            buttonShowRevocationCode = new Button(this.ApplicationContext);
            buttonShowRevocationCode.Click += ButtonShowRevocationCode_Click;
            layoutCodes.AddView(buttonShowRevocationCode);

            imageViewLoading = new ImageView(this.ApplicationContext) { Visibility = ViewStates.Invisible};
            imageViewLoading.SetImageResource(global::_2FAuthAndroid.Resource.Drawable.loading80);
            root.AddView(imageViewLoading);
            textViewStatus = new TextView(this.ApplicationContext);
            root.AddView(textViewStatus);

            cSteamAuth = new CSteamAuth();

            layoutStart.Visibility = ViewStates.Invisible;
            //layoutLoadExisting.Visibility = ViewStates.Visible;

            SetContentView(previewCamera);
            ResponseQR();

            //if (File.Exists(steamGuardFile))
            //  if (cSteamAuth.LoadAuthenticator())
            //    OpenCodesTab();

        }



        public async Task Login()
        {

            string username = editTextUsername.text;
            string password = editTextPassword.text;
            string emailcode = editTextEmailCode.text;
            string captcha = editTextCaptchaText.text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                buttonLogin.Enabled = true;
                return;
            }

            LoadingOn();

            var res = await cSteamAuth.Login(username, password, captcha, emailcode/*, twoFactorCode*/).ConfigureAwait(true);
            switch (res)
            {
                case SteamAuth.UserLogin.LoginResult.NeedEmail:
                    editTextEmailCode.Visibility = ViewStates.Visible;
                    break;
                case SteamAuth.UserLogin.LoginResult.BadCredentials:
                    break;
                case SteamAuth.UserLogin.LoginResult.NeedCaptcha:
                    captchaUpdate();
                    break;
                case SteamAuth.UserLogin.LoginResult.LoginOkay:
                    layoutLogin.Visibility = ViewStates.Invisible;
                    layoutLink.Visibility = ViewStates.Visible;
                    break;
                //case SteamAuth.UserLogin.LoginResult.Need2FA:
                  //  panelTwoFactorCode.Visible = true;
                    //break;
            }
            textViewStatus.Text = res.ToString();
            LoadingOff();
            
        }
        public async Task Link()
        {
            string phoneNumber = editTextPhone.text;

            LoadingOn();
            editTextPhone.Visibility = ViewStates.Invisible;
            editTextSmsCode.Visibility = ViewStates.Invisible;

            var res = await cSteamAuth.Link(phoneNumber).ConfigureAwait(true);

            switch (res)
            {
                case SteamAuth.AuthenticatorLinker.LinkResult.MustProvidePhoneNumber:
                    editTextPhone.Visibility = ViewStates.Visible;
                    break;
                case SteamAuth.AuthenticatorLinker.LinkResult.MustRemovePhoneNumber:
                    //panelSMS.Visible = true;
                    break;
                case SteamAuth.AuthenticatorLinker.LinkResult.AwaitingFinalization:
                    editTextSmsCode.Visibility = ViewStates.Visible;
                    buttonLink.Text = "Resend code";
                    buttonFinalizeLink.Visibility = ViewStates.Visible;
                    break;
            }
            textViewStatus.Text = res.ToString();
            LoadingOff();
        }
        public async Task FinalizeLink()
        {
            string smsCode = editTextSmsCode.text;

            LoadingOn();

            var res = await cSteamAuth.FinalizeLink(smsCode).ConfigureAwait(true);
            switch (res)
            {
                case SteamAuth.AuthenticatorLinker.FinalizeResult.BadSMSCode:
                    editTextSmsCode.Text = "";
                    break;
                case SteamAuth.AuthenticatorLinker.FinalizeResult.Success:
                    OpenCodesTab();
                    break;
            }
        }
        public async Task DeLink()
        {
            LoadingOn();

            await cSteamAuth.DeleteAuthenticator().ConfigureAwait(true);

            LoadingOff();
        }
        private void LoadingOn()
        {
            textViewStatus.Text = "";
            imageViewLoading.Visibility = ViewStates.Visible;

            editTextCaptchaText.Visibility = ViewStates.Invisible;
            imageViewCaptcha.Visibility = ViewStates.Invisible;
            editTextEmailCode.Visibility = ViewStates.Invisible;
        }
        private void LoadingOff()
        {
            imageViewLoading.Visibility = ViewStates.Invisible;

            if (buttonLink.Enabled == false)
                buttonLink.Enabled = true;
            if (buttonLogin.Enabled == false)
                buttonLogin.Enabled = true;
        }
        private void captchaUpdate()
        {
            editTextCaptchaText.Visibility = ViewStates.Visible;
            imageViewCaptcha.Visibility = ViewStates.Visible;
            editTextCaptchaText.Text = "";

            if (string.IsNullOrEmpty(cSteamAuth.captchaGID))
                return;

            string filepath = cSteamAuth.GetCaptchaFile(cSteamAuth.captchaGID);
            if (string.IsNullOrEmpty(filepath))
                return;
            using (FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                imageViewCaptcha.SetImageBitmap(Android.Graphics.BitmapFactory.DecodeStream(stream));
            }
        }
        private void OpenCodesTab()
        {
            layoutLogin.Visibility = ViewStates.Invisible;
            layoutLink.Visibility = ViewStates.Invisible;
            layoutCodes.Visibility = ViewStates.Visible;
            //TODO: Show username
            //this.Text = $"{Programmname} ({cSteamAuth.GetAccountName()})";
            RefreshCode().Forget();
        }
        private async Task ShowRevocationCode()
        {
            var code = cSteamAuth.GetRevocationCode();
            if (string.IsNullOrEmpty(code))
            {
                buttonShowRevocationCode.Enabled = true;
                return;
            }
            progressBarRevocationCode.Visibility = ViewStates.Visible;
            textViewRevocationCode.Visibility = ViewStates.Visible;
            textViewRevocationCode.Text = code;

            Timer TimerRevocationCode = new Timer() { Interval = 1000, Enabled = true};
            TimerRevocationCode.Elapsed += TimerRevocationCode_Elapsed;
            TimerRevocationCode_Elapsed(null, null);
            TimerRevocationCode.Enabled = true;
            await Task.Delay(TimeSpan.FromSeconds(10));
            TimerRevocationCode.Stop();
            progressBarRevocationCode.Progress = 0;

            progressBarRevocationCode.Visibility = ViewStates.Invisible;
            textViewRevocationCode.Visibility = ViewStates.Invisible;
            textViewRevocationCode.Text = "";
            buttonShowRevocationCode.Enabled = true;
        }
        
        private async Task RefreshCode()
        {
            if (keepRefreshCode == false) //Starting
                keepRefreshCode = true;
            if (TimerTwoFactorTextBoxUpdate.Enabled == false)
                TimerTwoFactorTextBoxUpdate.Start();

            while (keepRefreshCode)//Updating
            {
                string code = await cSteamAuth.Get2FACode().ConfigureAwait(true);
                sTwoFactorCode = code;
                iTwoFactorCodeTime = await cSteamAuth.Get2FACodeLeft().ConfigureAwait(true);
                await Task.Delay(200);
            }
            return;
        }
        private void ResponseQR()
        {
            
            bool searching = true;
            Camera camera = Camera.Open();
            previewCamera.PreviewCamera = camera;
            Toast.MakeText(this.ApplicationContext, "Camera compette", ToastLength.Short).Show();
        }
        private void ButtonLoadExisting_Click(object sender, EventArgs e)
        {
            layoutStart.Visibility = ViewStates.Invisible;
            layoutLoadExisting.Visibility = ViewStates.Visible;
            ResponseQR();
        }
        private void ButtonCreateNew_Click(object sender, EventArgs e)
        {

        }
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(editTextUsername.text))
            {
                editTextUsername.PerformClick(); 
                return;
            }
            if (string.IsNullOrEmpty(editTextPassword.text))
            {
                editTextPassword.PerformClick();
                return;
            }

            buttonLogin.Enabled = false;
            Login().Forget();
        }
        private void ButtonLink_Click(object sender, EventArgs e)
        {
            buttonLink.Enabled = false;
            Link().Forget();
        }
        private void ButtonFinalizeLink_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(editTextSmsCode.text))
            {
                editTextSmsCode.PerformClick(); 
                return;
            }
            buttonFinalizeLink.Enabled = false;
            FinalizeLink().Forget();
        }
        private void ButtonShowRevocationCode_Click(object sender, EventArgs e)
        {
            buttonShowRevocationCode.Enabled = false;
            ShowRevocationCode().Forget();
        }
        private void ButtonDeleteAuthenticator_Click(object sender, EventArgs e)
        {
            bool sure = false;
            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Are u sure?");
            dialog.SetPositiveButton("Yes", (alertSender, args) => { sure = true; });
            dialog.SetNegativeButton("Cancel", (alertSender, args) => { sure = false; });
            dialog.Show();

            if (sure == true)
                DeLink().Forget();
        }

        private void TimerRevocationCode_Elapsed(object sender, ElapsedEventArgs e)
        {
            progressBarRevocationCode.IncrementProgressBy(10);
        }
    }
    class Preview : ViewGroup, ISurfaceHolderCallback
    {
        string TAG = "Preview";

        SurfaceView mSurfaceView;
        ISurfaceHolder mHolder;
        Camera.Size mPreviewSize;
        IList<Camera.Size> mSupportedPreviewSizes;
        Camera _camera;

        public Camera PreviewCamera
        {
            get { return _camera; }
            set
            {
                _camera = value;
                if (_camera != null)
                {
                    mSupportedPreviewSizes = PreviewCamera.GetParameters().SupportedPreviewSizes;
                    RequestLayout();
                }
            }
        }

        public Preview(Context context) : base(context)
        {
            mSurfaceView = new SurfaceView(context);
            AddView(mSurfaceView);

            // Install a SurfaceHolder.Callback so we get notified when the
            // underlying surface is created and destroyed.
            mHolder = mSurfaceView.Holder;
            mHolder.AddCallback(this);
            mHolder.SetType(SurfaceType.PushBuffers);
        }

        public void SwitchCamera(Camera camera)
        {
            PreviewCamera = camera;

            try
            {
                camera.SetPreviewDisplay(mHolder);
            }
            catch (Java.IO.IOException exception)
            {
                Log.Error(TAG, "IOException caused by setPreviewDisplay()", exception);
            }

            Camera.Parameters parameters = camera.GetParameters();
            parameters.SetPreviewSize(mPreviewSize.Width, mPreviewSize.Height);
            RequestLayout();

            camera.SetParameters(parameters);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            // We purposely disregard child measurements because act as a
            // wrapper to a SurfaceView that centers the camera preview instead
            // of stretching it.
            int width = ResolveSize(SuggestedMinimumWidth, widthMeasureSpec);
            int height = ResolveSize(SuggestedMinimumHeight, heightMeasureSpec);
            SetMeasuredDimension(width, height);

            if (mSupportedPreviewSizes != null)
            {
                mPreviewSize = GetOptimalPreviewSize(mSupportedPreviewSizes, width, height);
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            if (changed && ChildCount > 0)
            {
                View child = GetChildAt(0);

                int width = r - l;
                int height = b - t;

                int previewWidth = width;
                int previewHeight = height;
                if (mPreviewSize != null)
                {
                    previewWidth = mPreviewSize.Width;
                    previewHeight = mPreviewSize.Height;
                }

                // Center the child SurfaceView within the parent.
                if (width * previewHeight > height * previewWidth)
                {
                    int scaledChildWidth = previewWidth * height / previewHeight;
                    child.Layout((width - scaledChildWidth) / 2, 0,
                                 (width + scaledChildWidth) / 2, height);
                }
                else
                {
                    int scaledChildHeight = previewHeight * width / previewWidth;
                    child.Layout(0, (height - scaledChildHeight) / 2,
                                 width, (height + scaledChildHeight) / 2);
                }
            }
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            // The Surface has been created, acquire the camera and tell it where
            // to draw.
            try
            {
                if (PreviewCamera != null)
                {
                    PreviewCamera.SetPreviewDisplay(holder);
                }
            }
            catch (Java.IO.IOException exception)
            {
                Log.Error(TAG, "IOException caused by setPreviewDisplay()", exception);
            }
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            // Surface will be destroyed when we return, so stop the preview.
            if (PreviewCamera != null)
            {
                PreviewCamera.StopPreview();
            }
        }

        private Camera.Size GetOptimalPreviewSize(IList<Camera.Size> sizes, int w, int h)
        {
            const double ASPECT_TOLERANCE = 0.1;
            double targetRatio = (double)w / h;

            if (sizes == null)
                return null;

            Camera.Size optimalSize = null;
            double minDiff = Double.MaxValue;

            int targetHeight = h;

            // Try to find an size match aspect ratio and size
            foreach (Camera.Size size in sizes)
            {
                double ratio = (double)size.Width / size.Height;

                if (Math.Abs(ratio - targetRatio) > ASPECT_TOLERANCE)
                    continue;

                if (Math.Abs(size.Height - targetHeight) < minDiff)
                {
                    optimalSize = size;
                    minDiff = Math.Abs(size.Height - targetHeight);
                }
            }

            // Cannot find the one match the aspect ratio, ignore the requirement
            if (optimalSize == null)
            {
                minDiff = Double.MaxValue;
                foreach (Camera.Size size in sizes)
                {
                    if (Math.Abs(size.Height - targetHeight) < minDiff)
                    {
                        optimalSize = size;
                        minDiff = Math.Abs(size.Height - targetHeight);
                    }
                }
            }

            return optimalSize;
        }

        public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
        {
            // Now that the size is known, set up the camera parameters and begin
            // the preview.
            Camera.Parameters parameters = PreviewCamera.GetParameters();
            parameters.SetPreviewSize(mPreviewSize.Width, mPreviewSize.Height);
            RequestLayout();

            PreviewCamera.SetParameters(parameters);
            PreviewCamera.StartPreview();
        }
    }

    public static class Extensions
    {
        public static void Forget(this Task task) { }
    }
    public class defEditText : EditText
    {
        private string defText;
        public string text { get { return isDef() ? null : Text; } }
        public defEditText(Context context,string text) : base(context)
        { this.Text = text;this.defText = text; }
        public bool isDef()
        {
            return this.Text == defText;
        }
        public string getText()
        {
            if (isDef())
                return null;
            return Text;
        }
    }
}

