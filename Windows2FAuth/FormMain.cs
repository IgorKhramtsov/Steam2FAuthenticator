﻿using System;
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
using Microsoft.Win32;

namespace Windows2FAuth
{
    public partial class FormMain : Form
    {
        CSteamAuth cSteamAuth;
        bool keepRefreshCode;
        bool keepRefreshPendings;
        private bool WantClose = false;
        const string Programmname = "Steam authenticator";
        private string _secret = "";
        private string sgaPath = "";
        public FormMain()
        {
            InitializeComponent();
            notifyIconMain.Icon = global::Windows2FAuth.Properties.Resources.icon_closed;
            this.Width = 320; // Change width
            this.Height = 420; // and height
            labelStatus.Location = new Point(0, this.Height - labelStatus.Height - 40 /*Magick number*/ );
            foreach (var contr in this.Controls) { // Center all ours controls
                if (contr is FlowLayoutPanel && contr != flowLayoutPanelCrypto)
                {
                    (contr as Control).Location = new Point(0, 26);
                    (contr as Control).Width = 305;
                    (contr as Control).Height = 410;
                }
                if (contr == flowLayoutPanelCrypto)
                    (contr as Control).Location = new Point(0, 0);
                if (contr is defTextBox || (contr is Button) || contr is TextBox || contr is PictureBox || (contr is Label && contr != labelStatus))
                    (contr as Control).Center();
            }

            cSteamAuth = new CSteamAuth();

            flowLayoutPanelLinker.Visible = false;
            flowLayoutPanelPendingConfirmation.Visible = false;
            flowLayoutPanelTwoFactorCodes.Visible = false;
            flowLayoutPanelLogin.Visible = false;
            flowLayoutPanelCrypto.Visible = false;

        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Logging.LogInfo("==============Program start==============");
            if (File.Exists(CSteamAuth.SGAccountFile))
            {
                var fileInfo = new FileInfo(CSteamAuth.SGAccountFile);
                if (fileInfo.Length > 0)
                {
                    flowLayoutPanelCrypto.Visible = true;
                    defTextBoxCryptoCode.Focus();
                    return;
                }
                else
                    File.Delete(CSteamAuth.SGAccountFile);
            }

            toolStripMain.Visible = true;
            importToolStripMenuItem.Visible = true;
            flowLayoutPanelLogin.Visible = true;
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logging.LogInfo("==============Program close==============");
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = !WantClose; // Hide if user dont wanna close
                this.Hide();
            }
        }

        public async Task Login()
        {
            string username = defTextBoxUsername.text;
            string password = defTextBoxPassword.text;
            string emailcode = defTextBoxEmailCode.text;
            string captcha = defTextBoxCaptcha.text;
            string twoFactorCode = defTextBoxTwoFactorCode.text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                buttonLogin.Enabled = true;
                return;
            }
            
            LoadingOn();
            panelCaptcha.Visible = false;
            panelEmailCode.Visible = false;

            var res = await cSteamAuth.Login(username,password,captcha,emailcode,twoFactorCode).ConfigureAwait(true);
            switch (res)
            {
                case SteamAuth.UserLogin.LoginResult.NeedEmail:
                    panelEmailCode.Visible = true;
                    defTextBoxEmailCode.Focus();
                    break;
                case SteamAuth.UserLogin.LoginResult.BadCredentials:
                    break;
                case SteamAuth.UserLogin.LoginResult.NeedCaptcha:
                    captchaUpdate();
                    defTextBoxCaptcha.Focus();
                    break;
                case SteamAuth.UserLogin.LoginResult.LoginOkay:
                    flowLayoutPanelLogin.Visible = false;
                    flowLayoutPanelLinker.Visible = true;
                    buttonLink.Focus();

                    defTextBoxUsername.Reset();
                    defTextBoxPassword.Reset();
                    defTextBoxEmailCode.Reset();
                    defTextBoxCaptcha.Reset();
                    defTextBoxTwoFactorCode.Reset();
                    
                    toolStripMain.Visible = false;
                    importToolStripMenuItem.Visible = false;
                    break;
                case SteamAuth.UserLogin.LoginResult.Need2FA:
                    MessageBox.Show("This account already have authenticator. You must delete him.", "Authenticator already exist", MessageBoxButtons.OK);
                    this.Close();
                    break;
            }
            labelStatus.Text = res.ToString();
            LoadingOff();
            buttonLogin.Enabled = true;
        }
        public async Task Link()
        {
            string phoneNumber = defTextBoxPhone.text;

            LoadingOn();
            panelSMS.Visible = false;
            panelPhone.Visible = false;
            panelSecret.Visible = false;

            var res = await cSteamAuth.Link(phoneNumber).ConfigureAwait(true);
            switch(res)
            {
                case LinkResult.MustProvidePhoneNumber:
                    panelPhone.Visible = true;
                    defTextBoxPhone.Focus();
                    break;
                case LinkResult.AuthenticatorPresent:
                    MessageBox.Show("This account already have authenticator. You must delete him.", "Authenticator already exist", MessageBoxButtons.OK);
                    this.Close();
                    break;
                case LinkResult.MustRemovePhoneNumber:
                    MessageBox.Show("This account already have phone number. You must remove him to use other number.", "Phone number already provided", MessageBoxButtons.OK);
                    this.Close();
                    break;
                case LinkResult.AwaitingFinalization:
                    panelPhone.Visible = false;
                    panelSMS.Visible = true;
                    panelSecret.Visible = true;
                    panelFinalizeLink.Visible = true;
                    buttonLink.Text = "Resend code";
                    defTextBoxSMS.Focus();
                    break;
            }
            labelStatus.Text = res.ToString();
            LoadingOff();
            buttonLink.Enabled = true;
        }
        public async Task FinalizeLink()
        {
            string smsCode = defTextBoxSMS.text;
            string sSecret = defTextBoxSecret.text;

            panelSecret.Visible = false;
            panelSMS.Visible = false;

            LoadingOn();

            var res  = await cSteamAuth.FinalizeLink(smsCode,sSecret).ConfigureAwait(true);
            switch (res)
            {
                case FinalizeResult.BadSMSCode:
                    defTextBoxSMS.Visible = true;
                    defTextBoxSMS.Reset();
                    defTextBoxSMS.Focus();
                    break;
                case FinalizeResult.IncorrectSecretCode:
                    defTextBoxSecret.Visible = true;
                    defTextBoxSecret.Reset();
                    defTextBoxSecret.Focus();
                    break;
                case FinalizeResult.CantSaveAccountData:
                    MessageBox.Show("Cant save steamguard file, please do it manualy.", "Steamguard saving error.", MessageBoxButtons.OK);
                    defTextBoxSMS.Reset();
                    defTextBoxPhone.Reset();
                    defTextBoxSecret.Reset();
                    OpenCodesTab();
                    toolStripMain.Visible = true;
                    exportToolStripMenuItem.Visible = true;
                    break;
                case FinalizeResult.Success:
                    defTextBoxSMS.Reset();
                    defTextBoxPhone.Reset();
                    defTextBoxSecret.Reset();
                    OpenCodesTab();
                    toolStripMain.Visible = true;
                    exportToolStripMenuItem.Visible = true;
                    break;
            }
            buttonFinalize.Enabled = true;
            labelStatus.Text = res.ToString();
            LoadingOff();
        }
        public async Task DeLink()
        {
            LoadingOn();

            if (await cSteamAuth.DeleteAuthenticator().ConfigureAwait(true))
            { 
                flowLayoutPanelTwoFactorCodes.Visible = false;
                flowLayoutPanelLogin.Visible = true;
                keepRefreshCode = false;
                keepRefreshPendings = false;
            }


            LoadingOff();
        }
        private async Task ShowRevocationCode()
        {
            var code = cSteamAuth.GetRevocationCode();
            if (string.IsNullOrEmpty(code))
            {
                buttonShowRevocationCode.Enabled = true;
                return;
            }
            panelRevocationCode.Visible = true;
            textBoxRevocationCode.Text = code;

            Timer TimerRevocationCode = new Timer() { Interval = 1000, Enabled = true };
            TimerRevocationCode.Tick += TimerRevocationCode_Tick;
            TimerRevocationCode_Tick(null, null);
            await Task.Delay(TimeSpan.FromSeconds(10));
            TimerRevocationCode.Stop();
            progressBarRevocationCode.Value = 0;

            panelRevocationCode.Visible = false;
            textBoxRevocationCode.Text = "";
            buttonShowRevocationCode.Enabled = true;
        }
        private void LoadSGAccount(string secret)
        {
            defTextBoxCryptoCode.Reset(); // Reset text box
            if (secret.Length < 4)
                return;
            _secret = secret;

            if (cSteamAuth.LoadAuthenticator(secret,sgaPath))
            {
                OpenCodesTab();
                toolStripMain.Visible = true;
                exportToolStripMenuItem.Visible = true;
                importToolStripMenuItem.Visible = false;
                RefreshPendings().Forget();
                this.Focus();
                notifyIconMain.Icon = Properties.Resources.icon_opened;
                this.Icon = Properties.Resources.icon_opened;
                return;
            }
            labelStatus.Text = "Cant load steam guard file!";
        }
        private void OpenCodesTab()
        {
            flowLayoutPanelLogin.Visible = false;
            flowLayoutPanelLinker.Visible = false;
            flowLayoutPanelPendingConfirmation.Visible = false;
            flowLayoutPanelCrypto.Visible = false;
            flowLayoutPanelTwoFactorCodes.Visible = true;
            this.Text = $"{Programmname} ({cSteamAuth.GetAccountName()})";
            RefreshCode().Forget();
        }
        private void OpenPendingsTab()
        {
            flowLayoutPanelLinker.Visible = false;
            flowLayoutPanelLogin.Visible = false;
            flowLayoutPanelCrypto.Visible = false;
            flowLayoutPanelTwoFactorCodes.Visible = false;
            flowLayoutPanelPendingConfirmation.Visible = true;
        }
        private async Task RefreshCode()
        {
            if (keepRefreshCode == false) //Starting
                keepRefreshCode = true;
            toolStripTextBox2FACodes.Visible = true;

            while (keepRefreshCode)//Updating
            {
                string sTwoFactorCode = await cSteamAuth.Get2FACode().ConfigureAwait(true);
                int iTwoFactorCodeTime = await cSteamAuth.Get2FACodeLeft().ConfigureAwait(true);
                try
                {
                    this.BeginInvoke(new MethodInvoker(delegate
                    {
                        progressBarTwoFactorCode.Value = iTwoFactorCodeTime;
                        if (!keepRefreshCode)
                            progressBarTwoFactorCode.Value = 0;

                        if (!(string.IsNullOrEmpty(sTwoFactorCode) || textBoxTwoFactorCode.Text == sTwoFactorCode))
                            textBoxTwoFactorCode.Text = sTwoFactorCode;
                        if (toolStripTextBox2FACodes.Text != sTwoFactorCode)
                            toolStripTextBox2FACodes.Text = sTwoFactorCode;

                        if (!keepRefreshCode)
                            textBoxTwoFactorCode.Text = "";
                    }));
                }
                catch (Exception e) { Logging.LogError("Cant invoke to UI: " + e.Message); }
                await Task.Delay(1000);
            }
            return;
        }
        private async Task RefreshPendings()
        {
            panelPendingsLoading.Visible = true;
            checkedListBoxPendings.Visible = false;
            panelPendingButtons.Visible = false;
            panelPendingNothing.Visible = false;

            if (keepRefreshPendings == false)
                keepRefreshPendings = true;
            while(keepRefreshPendings)
            {
                bool AddedNew = false; // Are we added a new element to the list?
                var confirmationList = await cSteamAuth.GetConfirmations().ConfigureAwait(true);
                foreach (var confirmation in confirmationList)
                    if (!checkedListBoxPendings.Items.Contains(confirmation))
                    {
                        checkedListBoxPendings.Items.Add(confirmation);
                        AddedNew = true;
                    }

                panelPendingsLoading.Visible = false;
                bool empty = (checkedListBoxPendings.Items.Count <= 0);
                checkedListBoxPendings.Visible = !empty;
                panelPendingButtons.Visible = !empty;
                panelPendingNothing.Visible = empty;

                if(AddedNew)
                {
                    checkedListBoxPendings.Update();
                    if (this.WindowState == FormWindowState.Minimized || this.Focused == false)
                        notifyIconMain.BalloonTipClicked += new EventHandler(buttonGoToPendings_Click);
                        notifyIconMain.ShowBalloonTip(3000, "Pending", "You have new pending", ToolTipIcon.Info);
                }
                await Task.Delay(1000); // Wait 1 sec
            }
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

            panelTwoFactorCode.Visible = false;
        }
        private void LoadingOff()
        {
            panelLoadingLogin.Visible = false;
            panelLoadingLink.Visible = false;
        }

        private void buttonLogin_Click(object sender, EventArgs e){
            ((Button)sender).Enabled = false;
            Login().Forget();
        } //Login button
        private void buttonLink_Click(object sender, EventArgs e){
            ((Button)sender).Enabled = false;
            Link().Forget();
        } // LinkButton
        private void buttonFinalize_Click(object sender, EventArgs e)
        {
            buttonFinalize.Enabled = false;
            FinalizeLink().Forget();
        } // Finalize link button
        private void buttonGoToPendings_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.Show();

            OpenPendingsTab();
        } // Go to pendings tab
        private void buttonShowRevocationCode_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            ShowRevocationCode().Forget();
        } // Show revocation code button
        private void buttonDeLink_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are u sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;

            ((Button)sender).Enabled = false;
            DeLink().Forget();
        } // Delete authenticator button
        private async void buttonPendingAccept_Click(object sender, EventArgs e)
        {
            if (checkedListBoxPendings.CheckedItems.Count <= 0)
                return;
            (sender as Button).Enabled = false;

            keepRefreshPendings = false;// Turn off list modifing

            List<Confirmation_light> confirmationList = new List<Confirmation_light>();
            confirmationList = checkedListBoxPendings.CheckedItems.Cast<Confirmation_light>().ToList();

            foreach (var confirmation in confirmationList)
            {
                if (await (confirmation as Confirmation_light).Confirm().ConfigureAwait(true))
                    checkedListBoxPendings.Items.Remove(confirmation);
                checkedListBoxPendings.Update();
            }

            RefreshPendings().Forget();// Keep refreshing
            (sender as Button).Enabled = true;
        } // Pending Accept
        private async void buttonPendingDeny_Click(object sender, EventArgs e)
        {
            if (checkedListBoxPendings.CheckedItems.Count <= 0)
                return;
            (sender as Button).Enabled = false;

            keepRefreshPendings = false;// Turn off list modifing

            List<Confirmation_light> confirmationList = new List<Confirmation_light>();
            confirmationList = checkedListBoxPendings.CheckedItems.Cast<Confirmation_light>().ToList();

            foreach (var confirmation in confirmationList)
            {
                if (await (confirmation as Confirmation_light).Deny().ConfigureAwait(true))
                    checkedListBoxPendings.Items.Remove(confirmation);
                checkedListBoxPendings.Update();
            }

            RefreshPendings().Forget();// Keep refreshing
            (sender as Button).Enabled = true;
        } // Pending Deny
        private void buttonGoToCodes_Click(object sender, EventArgs e)
        {
            OpenCodesTab();
        } // Go to codes Tab
        private void deSelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBoxPendings.Items.Count <= 0)
                return;
            for (int i = 0; i < checkedListBoxPendings.Items.Count; i++)
                checkedListBoxPendings.SetItemChecked(i, true);
        } // Deselct all pendings
        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBoxPendings.Items.Count <= 0)
                return;
            for (int i = 0; i < checkedListBoxPendings.Items.Count; i++)
                checkedListBoxPendings.SetItemChecked(i, false);
        } // Select all pendings
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_secret))
                return;

            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "json files (*.json)|*.json";
            var dialogRes = saveDialog.ShowDialog();
            if (dialogRes == DialogResult.OK)
                labelStatus.Text = "Saving result: " + cSteamAuth.SaveSGAccount(_secret, saveDialog.FileName);
        } // Export steamguard file
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Turn all off
            flowLayoutPanelLinker.Visible = false;
            flowLayoutPanelLogin.Visible = false;
            flowLayoutPanelPendingConfirmation.Visible = false;
            flowLayoutPanelTwoFactorCodes.Visible = false;
            toolStripMain.Visible = false;
            keepRefreshCode = false;
            keepRefreshPendings = false;

            var openDialog = new OpenFileDialog() { Filter = "json files (*.json)|*.json" };
            var dialogRes = openDialog.ShowDialog();
            if (dialogRes == DialogResult.OK && !string.IsNullOrEmpty(openDialog.FileName))
            {
                flowLayoutPanelCrypto.Visible = true;
                sgaPath = openDialog.FileName;
            }
        } // Import steamguard file
        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.Show();
        } // Show form after double click
        private void closeToolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            WantClose = true;
            this.Close();
        } // Close form
        private void defTextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 43)
                e.Handled = true;
        } // Phone textBox filter
        private void defTextBoxCryptoCode_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }// Secret code filter
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            buttonLogin.Enabled = false;
            Login().Forget();
        } //Username, password, captcha, email textboxes
        private void defTextBoxCryptoCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as defTextBox).text))
                if ((sender as defTextBox).text.Length == 4)
                    LoadSGAccount(defTextBoxCryptoCode.text);
        } // Load sga if user enter 4 numbers
        private void checkedListBoxPendings_MouseDown(object sender, MouseEventArgs e)
        {
            int y = e.Y / ((ListBox)sender).ItemHeight;
            if (y < ((ListBox)sender).Items.Count)
                ((ListBox)sender).SelectedIndex = y;
            else
                ((ListBox)sender).SelectedIndex = -1;
        } // Selecting empty zones
        private void toolStripTextBox2FACodes_Click(object sender, EventArgs e)
        {
            //toolStripTextBox2FACodes.SelectAll();
            Clipboard.SetText(toolStripTextBox2FACodes.Text);
            notifyIconMain.ShowBalloonTip(1000, "Copy to clipboard", "Two factor code was copied to clipboard.", ToolTipIcon.Info);
        } // Copy 2fa code from toolstrip to clipboard
        private void textBoxTwoFactorCode_Click(object sender, EventArgs e)
        {
            //textBoxTwoFactorCode.SelectAll();
            Clipboard.SetText(textBoxTwoFactorCode.Text);
            notifyIconMain.ShowBalloonTip(1000, "Copy to clipboard", "Two factor code was copied to clipboard.", ToolTipIcon.Info);
        }// Copy 2fa code from form to clipboard

        private void TimerRevocationCode_Tick(object sender, EventArgs e)
        {
            progressBarRevocationCode.Increment(10);
        } // Revocation code showing timer
    }
    public static class Extensions
    {
        public static void Forget(this Task task){ }
        public static void Center(this Control contr)
        {
            if (contr.Parent != null)
                if (!(contr.Parent is FormMain))
                    contr.Location = new Point((contr.Parent.Width - contr.Width) / 2, contr.Location.Y);
        }
    }
    // TODO: custom textbox for 2fa code with progress bar
    public class defTextBox : TextBox
    {
        private string defText;
        public string text { get { return isDef() ? null : Text; } }
        public bool isDef()
        {
            if (!this.Created)
                return true;
            return this.Text == defText;
        }
        public void Reset()
        {
            Text = defText;
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
