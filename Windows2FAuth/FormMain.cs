using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2FAuthAndroidLibrary;
using System.IO;

namespace Windows2FAuth
{
    public partial class FormMain : Form
    {
        CSteamAuth cSteamAuth;
        bool keepRefreshCode;
        string sTwoFactorCode;
        int iTwoFactorCodeTime;
        Timer TimerTwoFactorTextBoxUpdate;
        const string Programmname = "Steam authenticator";
        public FormMain()
        {
            InitializeComponent();
            this.Width = 320;
            flowLayoutPanelLinker.Location = new Point(0, 0);
            flowLayoutPanelTwoFactorCodes.Location = new Point(0, 0);
            cSteamAuth = new CSteamAuth();

            TimerTwoFactorTextBoxUpdate = new Timer(){ Interval = 100 };//Timer to update two factor code from string to textbox
            TimerTwoFactorTextBoxUpdate.Tick += TimerTwoFactorTextBoxUpdate_Tick;

            if (File.Exists(CSteamAuth.SGAccountFile))
            {
                if (!cSteamAuth.LoadAuthenticator())
                    return;
                OpenCodesTab();
            }
        }

        

        
        public async Task Login()
        {

            string username = defTextBoxUsername.isDef() ? null : defTextBoxUsername.Text;
            string password = defTextBoxPassword.isDef() ? null : defTextBoxPassword.Text;
            string emailcode = defTextBoxEmailCode.isDef() ? null : defTextBoxEmailCode.Text;
            string captcha = defTextBoxCaptcha.isDef() ? null : defTextBoxCaptcha.Text;
            string twoFactorCode = defTextBoxTwoFactorCode.isDef() ? null : defTextBoxTwoFactorCode.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                buttonLogin.Enabled = true;
                return;
            }

            LoadingOn();

            var res = await cSteamAuth.Login(username,password,captcha,emailcode,twoFactorCode).ConfigureAwait(true);
            switch (res)
            {
                case SteamAuth.UserLogin.LoginResult.NeedEmail:
                    panelEmailCode.Visible = true;
                    break;
                case SteamAuth.UserLogin.LoginResult.BadCredentials:
                    break;
                case SteamAuth.UserLogin.LoginResult.NeedCaptcha:
                    captchaUpdate();
                    break;
                case SteamAuth.UserLogin.LoginResult.LoginOkay:
                    flowLayoutPanelLogin.Visible = false;
                    flowLayoutPanelLinker.Visible = true;
                    break;
                case SteamAuth.UserLogin.LoginResult.Need2FA:
                    panelTwoFactorCode.Visible = true;
                    break;
            }
            labelStatus.Text = res.ToString();
            LoadingOff();
        }
        public async Task Link()
        {
            string phoneNumber = defTextBoxPhone.isDef() ? null : defTextBoxPhone.Text;

            LoadingOn();
            panelPhone.Visible = false;
            panelSMS.Visible = false;

            var res = await cSteamAuth.Link(phoneNumber).ConfigureAwait(true);
            
            switch(res)
            {
                case SteamAuth.AuthenticatorLinker.LinkResult.MustProvidePhoneNumber:
                    panelPhone.Visible = true;
                    break;
                case SteamAuth.AuthenticatorLinker.LinkResult.MustRemovePhoneNumber:
                    //panelSMS.Visible = true;
                    break;
                case SteamAuth.AuthenticatorLinker.LinkResult.AwaitingFinalization:
                    panelSMS.Visible = true;
                    panelFinalizeLink.Visible = true;
                    break;
            }
            labelStatus.Text = res.ToString();
            LoadingOff();
        }
        public async Task FinalizeLink()
        {
            string smsCode = defTextBoxSMS.isDef() ? null : defTextBoxSMS.Text;

            LoadingOn();

            var res  = await cSteamAuth.FinalizeLink(smsCode).ConfigureAwait(true);
            switch(res)
            {
                case SteamAuth.AuthenticatorLinker.FinalizeResult.BadSMSCode:
                    defTextBoxSMS.Text = "";
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
        private void captchaUpdate()
        {
            panelCaptcha.Visible = true;
            defTextBoxCaptcha.Text = "";

            if (string.IsNullOrEmpty(cSteamAuth.captchaGID))
                return;

            string filepath = cSteamAuth.GetCaptchaFile(cSteamAuth.captchaGID);
            if (string.IsNullOrEmpty(filepath))
                return;
            using (FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                pictureBoxCaptcha.Image = Image.FromStream(stream);
            }
        }
        private void LoadingOn()
        {
            labelStatus.Text = "";
            panelLoadingLogin.Visible = true;
            panelLoadingLink.Visible = true;

            panelCaptcha.Visible = false;
            panelEmailCode.Visible = false;
            panelTwoFactorCode.Visible = false;
        }
        private void LoadingOff()
        {
            panelLoadingLogin.Visible = false;
            panelLoadingLink.Visible = false;
            if (buttonLink.Enabled == false)
                buttonLink.Enabled = true;
            if (buttonLogin.Enabled == false)
                buttonLogin.Enabled = true;
        }
        private void OpenCodesTab()
        {
            flowLayoutPanelLogin.Visible = false;
            flowLayoutPanelLinker.Visible = false;
            flowLayoutPanelTwoFactorCodes.Visible = true;
            this.Text = $"{Programmname} ({cSteamAuth.GetAccountName()})";
            RefreshCode().Forget();
        }
        private async Task ShowRevocationCode()
        {
            var code = cSteamAuth.getRevocationCode();
            if (string.IsNullOrEmpty(code))
            {
                buttonShowRevocationCode.Enabled = true;
                return;
            }
            panelRevocationCode.Visible = true;
            textBoxRevocationCode.Text = code;

            Timer TimerRevocationCode = new Timer() { Interval = 1000,Enabled = true};
            TimerRevocationCode.Tick += TimerRevocationCode_Tick;
            TimerRevocationCode_Tick(null,null);
            await Task.Delay(TimeSpan.FromSeconds(10));
            TimerRevocationCode.Stop();
            progressBarRevocationCode.Value = 0;

            panelRevocationCode.Visible = false;
            textBoxRevocationCode.Text = "";
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

        private void buttonLogin_Click(object sender, EventArgs e){
            ((Button)sender).Enabled = false;
            Login().Forget();
        } //Login button
        private void textBox_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter) return;
            buttonLogin.Enabled = false;
            Login().Forget();
        } //Username, password, captcha, email textboxes
        private void buttonLink_Click(object sender, EventArgs e){
            ((Button)sender).Enabled = false;
            Link().Forget();
        } // LinkButton
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            cSteamAuth.SaveSGAccount();
        }
        private void defTextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 43)
                e.Handled = true;
        } // Phone textBox filter
        private void buttonDeLink_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are u sure?","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;

            ((Button)sender).Enabled = false;
            DeLink().Forget();
        } // Delete authenticator button
        private void buttonShowRevocationCode_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            ShowRevocationCode().Forget();
        } // Show revocation code button
        private void buttonFinalize_Click(object sender, EventArgs e)
        {
            buttonFinalize.Enabled = false;
            FinalizeLink().Forget();
        } // Finalize link button

        private void TimerRevocationCode_Tick(object sender, EventArgs e)
        {
            progressBarRevocationCode.Increment(10);
        } // Revocation code showing timer
        private void TimerTwoFactorTextBoxUpdate_Tick(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(sTwoFactorCode) || textBoxTwoFactorCode.Text == sTwoFactorCode))
                textBoxTwoFactorCode.Text = sTwoFactorCode;

            progressBarTwoFactorCode.Value = iTwoFactorCodeTime;

            if (!keepRefreshCode)
            {
                textBoxTwoFactorCode.Text = "";
                (sender as Timer).Stop();
            }
        } // Two factor code updating from string (UI)
    }
    public static class Extensions
    {
        public static void Forget(this Task task){ }
    }
    public class defTextBox : TextBox
    {
        private string defText;
        public bool isDef()
        {
            if (!this.Created)
                return true;
            return this.Text == defText;
        }
        public defTextBox()
        {

        }
        protected override void OnCreateControl()
        {
            defText = this.Text;
            base.OnCreateControl();
        }
        protected override void OnLeave(EventArgs e)
        {
            if(this.Text == "")
            {
                this.Text = defText;
                this.ForeColor = Color.Gray;
            }
            base.OnLeave(e);
        }
        protected override void OnEnter(EventArgs e)
        {
            if (this.Text == defText)
            {
                this.Text = "";
                this.ForeColor = Color.Black;
            }
            base.OnEnter(e);
        }
    }
}
