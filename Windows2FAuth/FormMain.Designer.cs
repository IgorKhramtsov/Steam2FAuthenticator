namespace Windows2FAuth
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelStatus = new System.Windows.Forms.Label();
            this.flowLayoutPanelLogin = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLoginPass = new System.Windows.Forms.Panel();
            this.defTextBoxUsername = new Windows2FAuth.defTextBox();
            this.defTextBoxPassword = new Windows2FAuth.defTextBox();
            this.panelEmailCode = new System.Windows.Forms.Panel();
            this.defTextBoxEmailCode = new Windows2FAuth.defTextBox();
            this.panelTwoFactorCode = new System.Windows.Forms.Panel();
            this.defTextBoxTwoFactorCode = new Windows2FAuth.defTextBox();
            this.panelCaptcha = new System.Windows.Forms.Panel();
            this.defTextBoxCaptcha = new Windows2FAuth.defTextBox();
            this.pictureBoxCaptcha = new System.Windows.Forms.PictureBox();
            this.panelLoginButton = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.flowLayoutPanelLinker = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLinkButton = new System.Windows.Forms.Panel();
            this.buttonLink = new System.Windows.Forms.Button();
            this.panelPhone = new System.Windows.Forms.Panel();
            this.defTextBoxPhone = new Windows2FAuth.defTextBox();
            this.panelSMS = new System.Windows.Forms.Panel();
            this.defTextBoxSMS = new Windows2FAuth.defTextBox();
            this.panelSecret = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.defTextBoxSecret = new Windows2FAuth.defTextBox();
            this.panelFinalizeLink = new System.Windows.Forms.Panel();
            this.buttonFinalize = new System.Windows.Forms.Button();
            this.flowLayoutPanelTwoFactorCodes = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTwoFactorCodes = new System.Windows.Forms.Panel();
            this.progressBarTwoFactorCode = new System.Windows.Forms.ProgressBar();
            this.textBoxTwoFactorCode = new System.Windows.Forms.TextBox();
            this.panelRevocationCode = new System.Windows.Forms.Panel();
            this.progressBarRevocationCode = new System.Windows.Forms.ProgressBar();
            this.textBoxRevocationCode = new System.Windows.Forms.TextBox();
            this.panelGoToPending = new System.Windows.Forms.Panel();
            this.buttonGoToPendings = new System.Windows.Forms.Button();
            this.panelShowRevocationCode = new System.Windows.Forms.Panel();
            this.buttonShowRevocationCode = new System.Windows.Forms.Button();
            this.panelDeleteTwoFactor = new System.Windows.Forms.Panel();
            this.buttonDeLink = new System.Windows.Forms.Button();
            this.flowLayoutPanelPendingConfirmation = new System.Windows.Forms.FlowLayoutPanel();
            this.checkedListBoxPendings = new Windows2FAuth.CheckedListBoxExtended();
            this.panelPendingButtons = new System.Windows.Forms.Panel();
            this.buttonPendingDeny = new System.Windows.Forms.Button();
            this.buttonPendingAccept = new System.Windows.Forms.Button();
            this.panelGoToCodes = new System.Windows.Forms.Panel();
            this.buttonGoToCodes = new System.Windows.Forms.Button();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBox2FACodes = new System.Windows.Forms.ToolStripTextBox();
            this.closeToolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanelCrypto = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCryptoCode = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.defTextBoxCryptoCode = new Windows2FAuth.defTextBox();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelLoading = new Windows2FAuth.TransparentPanel();
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelLogin.SuspendLayout();
            this.panelLoginPass.SuspendLayout();
            this.panelEmailCode.SuspendLayout();
            this.panelTwoFactorCode.SuspendLayout();
            this.panelCaptcha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).BeginInit();
            this.panelLoginButton.SuspendLayout();
            this.flowLayoutPanelLinker.SuspendLayout();
            this.panelLinkButton.SuspendLayout();
            this.panelPhone.SuspendLayout();
            this.panelSMS.SuspendLayout();
            this.panelSecret.SuspendLayout();
            this.panelFinalizeLink.SuspendLayout();
            this.flowLayoutPanelTwoFactorCodes.SuspendLayout();
            this.panelTwoFactorCodes.SuspendLayout();
            this.panelRevocationCode.SuspendLayout();
            this.panelGoToPending.SuspendLayout();
            this.panelShowRevocationCode.SuspendLayout();
            this.panelDeleteTwoFactor.SuspendLayout();
            this.flowLayoutPanelPendingConfirmation.SuspendLayout();
            this.panelPendingButtons.SuspendLayout();
            this.panelGoToCodes.SuspendLayout();
            this.contextMenuStripNotifyIcon.SuspendLayout();
            this.flowLayoutPanelCrypto.SuspendLayout();
            this.panelCryptoCode.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.panelLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(626, 422);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(39, 15);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Status";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanelLogin
            // 
            this.flowLayoutPanelLogin.Controls.Add(this.panelLoginPass);
            this.flowLayoutPanelLogin.Controls.Add(this.panelEmailCode);
            this.flowLayoutPanelLogin.Controls.Add(this.panelTwoFactorCode);
            this.flowLayoutPanelLogin.Controls.Add(this.panelCaptcha);
            this.flowLayoutPanelLogin.Controls.Add(this.panelLoginButton);
            this.flowLayoutPanelLogin.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelLogin.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanelLogin.Name = "flowLayoutPanelLogin";
            this.flowLayoutPanelLogin.Size = new System.Drawing.Size(305, 412);
            this.flowLayoutPanelLogin.TabIndex = 0;
            // 
            // panelLoginPass
            // 
            this.panelLoginPass.Controls.Add(this.defTextBoxUsername);
            this.panelLoginPass.Controls.Add(this.defTextBoxPassword);
            this.panelLoginPass.Location = new System.Drawing.Point(4, 5);
            this.panelLoginPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLoginPass.Name = "panelLoginPass";
            this.panelLoginPass.Size = new System.Drawing.Size(300, 91);
            this.panelLoginPass.TabIndex = 0;
            // 
            // defTextBoxUsername
            // 
            this.defTextBoxUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.defTextBoxUsername.ForeColor = System.Drawing.Color.LightGray;
            this.defTextBoxUsername.Location = new System.Drawing.Point(47, 15);
            this.defTextBoxUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defTextBoxUsername.Name = "defTextBoxUsername";
            this.defTextBoxUsername.Size = new System.Drawing.Size(212, 25);
            this.defTextBoxUsername.TabIndex = 0;
            this.defTextBoxUsername.Text = "Username";
            this.defTextBoxUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // defTextBoxPassword
            // 
            this.defTextBoxPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.defTextBoxPassword.ForeColor = System.Drawing.Color.LightGray;
            this.defTextBoxPassword.Location = new System.Drawing.Point(47, 55);
            this.defTextBoxPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defTextBoxPassword.Name = "defTextBoxPassword";
            this.defTextBoxPassword.Size = new System.Drawing.Size(212, 25);
            this.defTextBoxPassword.TabIndex = 1;
            this.defTextBoxPassword.Text = "Password";
            this.defTextBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxPassword.UseSystemPasswordChar = true;
            this.defTextBoxPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // panelEmailCode
            // 
            this.panelEmailCode.Controls.Add(this.defTextBoxEmailCode);
            this.panelEmailCode.Location = new System.Drawing.Point(4, 106);
            this.panelEmailCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelEmailCode.Name = "panelEmailCode";
            this.panelEmailCode.Size = new System.Drawing.Size(300, 36);
            this.panelEmailCode.TabIndex = 6;
            this.panelEmailCode.Visible = false;
            // 
            // defTextBoxEmailCode
            // 
            this.defTextBoxEmailCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.defTextBoxEmailCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.defTextBoxEmailCode.ForeColor = System.Drawing.Color.LightGray;
            this.defTextBoxEmailCode.Location = new System.Drawing.Point(79, 5);
            this.defTextBoxEmailCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defTextBoxEmailCode.MaxLength = 5;
            this.defTextBoxEmailCode.Name = "defTextBoxEmailCode";
            this.defTextBoxEmailCode.Size = new System.Drawing.Size(141, 26);
            this.defTextBoxEmailCode.TabIndex = 0;
            this.defTextBoxEmailCode.Text = "EMAIL CODE";
            this.defTextBoxEmailCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxEmailCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // panelTwoFactorCode
            // 
            this.panelTwoFactorCode.Controls.Add(this.defTextBoxTwoFactorCode);
            this.panelTwoFactorCode.Location = new System.Drawing.Point(4, 152);
            this.panelTwoFactorCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTwoFactorCode.Name = "panelTwoFactorCode";
            this.panelTwoFactorCode.Size = new System.Drawing.Size(300, 36);
            this.panelTwoFactorCode.TabIndex = 7;
            this.panelTwoFactorCode.Visible = false;
            // 
            // defTextBoxTwoFactorCode
            // 
            this.defTextBoxTwoFactorCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.defTextBoxTwoFactorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.defTextBoxTwoFactorCode.ForeColor = System.Drawing.Color.LightGray;
            this.defTextBoxTwoFactorCode.Location = new System.Drawing.Point(100, 0);
            this.defTextBoxTwoFactorCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defTextBoxTwoFactorCode.MaxLength = 10;
            this.defTextBoxTwoFactorCode.Name = "defTextBoxTwoFactorCode";
            this.defTextBoxTwoFactorCode.Size = new System.Drawing.Size(92, 26);
            this.defTextBoxTwoFactorCode.TabIndex = 0;
            this.defTextBoxTwoFactorCode.Text = "2FA CODE";
            this.defTextBoxTwoFactorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxTwoFactorCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // panelCaptcha
            // 
            this.panelCaptcha.Controls.Add(this.defTextBoxCaptcha);
            this.panelCaptcha.Controls.Add(this.pictureBoxCaptcha);
            this.panelCaptcha.Location = new System.Drawing.Point(3, 196);
            this.panelCaptcha.Name = "panelCaptcha";
            this.panelCaptcha.Size = new System.Drawing.Size(301, 78);
            this.panelCaptcha.TabIndex = 9;
            this.panelCaptcha.Visible = false;
            // 
            // defTextBoxCaptcha
            // 
            this.defTextBoxCaptcha.Location = new System.Drawing.Point(50, 49);
            this.defTextBoxCaptcha.Name = "defTextBoxCaptcha";
            this.defTextBoxCaptcha.Size = new System.Drawing.Size(200, 23);
            this.defTextBoxCaptcha.TabIndex = 0;
            this.defTextBoxCaptcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxCaptcha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // pictureBoxCaptcha
            // 
            this.pictureBoxCaptcha.ErrorImage = null;
            this.pictureBoxCaptcha.InitialImage = null;
            this.pictureBoxCaptcha.Location = new System.Drawing.Point(48, 3);
            this.pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            this.pictureBoxCaptcha.Size = new System.Drawing.Size(206, 40);
            this.pictureBoxCaptcha.TabIndex = 0;
            this.pictureBoxCaptcha.TabStop = false;
            // 
            // panelLoginButton
            // 
            this.panelLoginButton.Controls.Add(this.buttonLogin);
            this.panelLoginButton.Location = new System.Drawing.Point(4, 282);
            this.panelLoginButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLoginButton.Name = "panelLoginButton";
            this.panelLoginButton.Size = new System.Drawing.Size(300, 47);
            this.panelLoginButton.TabIndex = 4;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonLogin.Location = new System.Drawing.Point(97, 5);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 37);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // flowLayoutPanelLinker
            // 
            this.flowLayoutPanelLinker.Controls.Add(this.panelLinkButton);
            this.flowLayoutPanelLinker.Controls.Add(this.panelPhone);
            this.flowLayoutPanelLinker.Controls.Add(this.panelSMS);
            this.flowLayoutPanelLinker.Controls.Add(this.panelSecret);
            this.flowLayoutPanelLinker.Controls.Add(this.panelFinalizeLink);
            this.flowLayoutPanelLinker.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelLinker.Location = new System.Drawing.Point(311, 0);
            this.flowLayoutPanelLinker.Name = "flowLayoutPanelLinker";
            this.flowLayoutPanelLinker.Size = new System.Drawing.Size(305, 412);
            this.flowLayoutPanelLinker.TabIndex = 1;
            this.flowLayoutPanelLinker.Visible = false;
            // 
            // panelLinkButton
            // 
            this.panelLinkButton.Controls.Add(this.buttonLink);
            this.panelLinkButton.Location = new System.Drawing.Point(3, 3);
            this.panelLinkButton.Name = "panelLinkButton";
            this.panelLinkButton.Size = new System.Drawing.Size(299, 54);
            this.panelLinkButton.TabIndex = 0;
            // 
            // buttonLink
            // 
            this.buttonLink.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonLink.Location = new System.Drawing.Point(99, 11);
            this.buttonLink.Name = "buttonLink";
            this.buttonLink.Size = new System.Drawing.Size(100, 32);
            this.buttonLink.TabIndex = 0;
            this.buttonLink.Text = "Link";
            this.buttonLink.UseVisualStyleBackColor = true;
            this.buttonLink.Click += new System.EventHandler(this.buttonLink_Click);
            // 
            // panelPhone
            // 
            this.panelPhone.Controls.Add(this.defTextBoxPhone);
            this.panelPhone.Location = new System.Drawing.Point(3, 63);
            this.panelPhone.Name = "panelPhone";
            this.panelPhone.Size = new System.Drawing.Size(298, 38);
            this.panelPhone.TabIndex = 9;
            this.panelPhone.Visible = false;
            // 
            // defTextBoxPhone
            // 
            this.defTextBoxPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.defTextBoxPhone.ForeColor = System.Drawing.Color.LightGray;
            this.defTextBoxPhone.Location = new System.Drawing.Point(89, 5);
            this.defTextBoxPhone.MaxLength = 12;
            this.defTextBoxPhone.Name = "defTextBoxPhone";
            this.defTextBoxPhone.Size = new System.Drawing.Size(120, 29);
            this.defTextBoxPhone.TabIndex = 0;
            this.defTextBoxPhone.Text = "+12345678900";
            this.defTextBoxPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.defTextBoxPhone_KeyPress);
            // 
            // panelSMS
            // 
            this.panelSMS.Controls.Add(this.defTextBoxSMS);
            this.panelSMS.Location = new System.Drawing.Point(3, 107);
            this.panelSMS.Name = "panelSMS";
            this.panelSMS.Size = new System.Drawing.Size(298, 40);
            this.panelSMS.TabIndex = 10;
            this.panelSMS.Visible = false;
            // 
            // defTextBoxSMS
            // 
            this.defTextBoxSMS.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.defTextBoxSMS.ForeColor = System.Drawing.Color.LightGray;
            this.defTextBoxSMS.Location = new System.Drawing.Point(107, 5);
            this.defTextBoxSMS.MaxLength = 5;
            this.defTextBoxSMS.Name = "defTextBoxSMS";
            this.defTextBoxSMS.Size = new System.Drawing.Size(83, 29);
            this.defTextBoxSMS.TabIndex = 0;
            this.defTextBoxSMS.Text = "SMS Code";
            this.defTextBoxSMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelSecret
            // 
            this.panelSecret.Controls.Add(this.label2);
            this.panelSecret.Controls.Add(this.defTextBoxSecret);
            this.panelSecret.Location = new System.Drawing.Point(3, 153);
            this.panelSecret.Name = "panelSecret";
            this.panelSecret.Size = new System.Drawing.Size(298, 86);
            this.panelSecret.TabIndex = 11;
            this.panelSecret.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(39, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter combination of 4 numbers\r\nRemember this combination!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // defTextBoxSecret
            // 
            this.defTextBoxSecret.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.defTextBoxSecret.ForeColor = System.Drawing.Color.LightGray;
            this.defTextBoxSecret.Location = new System.Drawing.Point(106, 52);
            this.defTextBoxSecret.MaxLength = 4;
            this.defTextBoxSecret.Name = "defTextBoxSecret";
            this.defTextBoxSecret.Size = new System.Drawing.Size(98, 29);
            this.defTextBoxSecret.TabIndex = 0;
            this.defTextBoxSecret.Text = "Secret code";
            this.defTextBoxSecret.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxSecret.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.defTextBoxCryptoCode_KeyPress);
            // 
            // panelFinalizeLink
            // 
            this.panelFinalizeLink.Controls.Add(this.buttonFinalize);
            this.panelFinalizeLink.Location = new System.Drawing.Point(3, 245);
            this.panelFinalizeLink.Name = "panelFinalizeLink";
            this.panelFinalizeLink.Size = new System.Drawing.Size(299, 54);
            this.panelFinalizeLink.TabIndex = 1;
            this.panelFinalizeLink.Visible = false;
            // 
            // buttonFinalize
            // 
            this.buttonFinalize.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonFinalize.Location = new System.Drawing.Point(93, 12);
            this.buttonFinalize.Name = "buttonFinalize";
            this.buttonFinalize.Size = new System.Drawing.Size(112, 32);
            this.buttonFinalize.TabIndex = 0;
            this.buttonFinalize.Text = "Finalize link";
            this.buttonFinalize.UseVisualStyleBackColor = true;
            this.buttonFinalize.Click += new System.EventHandler(this.buttonFinalize_Click);
            // 
            // flowLayoutPanelTwoFactorCodes
            // 
            this.flowLayoutPanelTwoFactorCodes.Controls.Add(this.panelTwoFactorCodes);
            this.flowLayoutPanelTwoFactorCodes.Controls.Add(this.panelRevocationCode);
            this.flowLayoutPanelTwoFactorCodes.Controls.Add(this.panelGoToPending);
            this.flowLayoutPanelTwoFactorCodes.Controls.Add(this.panelShowRevocationCode);
            this.flowLayoutPanelTwoFactorCodes.Controls.Add(this.panelDeleteTwoFactor);
            this.flowLayoutPanelTwoFactorCodes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTwoFactorCodes.Location = new System.Drawing.Point(623, 0);
            this.flowLayoutPanelTwoFactorCodes.Name = "flowLayoutPanelTwoFactorCodes";
            this.flowLayoutPanelTwoFactorCodes.Size = new System.Drawing.Size(305, 412);
            this.flowLayoutPanelTwoFactorCodes.TabIndex = 2;
            this.flowLayoutPanelTwoFactorCodes.Visible = false;
            // 
            // panelTwoFactorCodes
            // 
            this.panelTwoFactorCodes.Controls.Add(this.progressBarTwoFactorCode);
            this.panelTwoFactorCodes.Controls.Add(this.textBoxTwoFactorCode);
            this.panelTwoFactorCodes.Location = new System.Drawing.Point(3, 3);
            this.panelTwoFactorCodes.Name = "panelTwoFactorCodes";
            this.panelTwoFactorCodes.Size = new System.Drawing.Size(302, 65);
            this.panelTwoFactorCodes.TabIndex = 0;
            // 
            // progressBarTwoFactorCode
            // 
            this.progressBarTwoFactorCode.Location = new System.Drawing.Point(3, 55);
            this.progressBarTwoFactorCode.Maximum = 30;
            this.progressBarTwoFactorCode.Name = "progressBarTwoFactorCode";
            this.progressBarTwoFactorCode.Size = new System.Drawing.Size(296, 10);
            this.progressBarTwoFactorCode.TabIndex = 1;
            // 
            // textBoxTwoFactorCode
            // 
            this.textBoxTwoFactorCode.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.textBoxTwoFactorCode.Location = new System.Drawing.Point(99, 10);
            this.textBoxTwoFactorCode.MaxLength = 5;
            this.textBoxTwoFactorCode.Name = "textBoxTwoFactorCode";
            this.textBoxTwoFactorCode.ReadOnly = true;
            this.textBoxTwoFactorCode.Size = new System.Drawing.Size(110, 39);
            this.textBoxTwoFactorCode.TabIndex = 0;
            this.textBoxTwoFactorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTwoFactorCode.Click += new System.EventHandler(this.textBoxTwoFactorCode_Click);
            // 
            // panelRevocationCode
            // 
            this.panelRevocationCode.Controls.Add(this.progressBarRevocationCode);
            this.panelRevocationCode.Controls.Add(this.textBoxRevocationCode);
            this.panelRevocationCode.Location = new System.Drawing.Point(3, 74);
            this.panelRevocationCode.Name = "panelRevocationCode";
            this.panelRevocationCode.Size = new System.Drawing.Size(302, 63);
            this.panelRevocationCode.TabIndex = 2;
            this.panelRevocationCode.Visible = false;
            // 
            // progressBarRevocationCode
            // 
            this.progressBarRevocationCode.Location = new System.Drawing.Point(3, 49);
            this.progressBarRevocationCode.Name = "progressBarRevocationCode";
            this.progressBarRevocationCode.Size = new System.Drawing.Size(296, 10);
            this.progressBarRevocationCode.Step = 1;
            this.progressBarRevocationCode.TabIndex = 2;
            // 
            // textBoxRevocationCode
            // 
            this.textBoxRevocationCode.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.textBoxRevocationCode.Location = new System.Drawing.Point(99, 7);
            this.textBoxRevocationCode.MaxLength = 5;
            this.textBoxRevocationCode.Name = "textBoxRevocationCode";
            this.textBoxRevocationCode.ReadOnly = true;
            this.textBoxRevocationCode.Size = new System.Drawing.Size(110, 39);
            this.textBoxRevocationCode.TabIndex = 1;
            this.textBoxRevocationCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelGoToPending
            // 
            this.panelGoToPending.Controls.Add(this.buttonGoToPendings);
            this.panelGoToPending.Location = new System.Drawing.Point(3, 143);
            this.panelGoToPending.Name = "panelGoToPending";
            this.panelGoToPending.Size = new System.Drawing.Size(302, 42);
            this.panelGoToPending.TabIndex = 10;
            // 
            // buttonGoToPendings
            // 
            this.buttonGoToPendings.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonGoToPendings.Location = new System.Drawing.Point(82, 3);
            this.buttonGoToPendings.Name = "buttonGoToPendings";
            this.buttonGoToPendings.Size = new System.Drawing.Size(136, 35);
            this.buttonGoToPendings.TabIndex = 0;
            this.buttonGoToPendings.Text = "Pendings";
            this.buttonGoToPendings.UseVisualStyleBackColor = true;
            this.buttonGoToPendings.Click += new System.EventHandler(this.buttonGoToPendings_Click);
            // 
            // panelShowRevocationCode
            // 
            this.panelShowRevocationCode.Controls.Add(this.buttonShowRevocationCode);
            this.panelShowRevocationCode.Location = new System.Drawing.Point(3, 191);
            this.panelShowRevocationCode.Name = "panelShowRevocationCode";
            this.panelShowRevocationCode.Size = new System.Drawing.Size(302, 45);
            this.panelShowRevocationCode.TabIndex = 2;
            // 
            // buttonShowRevocationCode
            // 
            this.buttonShowRevocationCode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonShowRevocationCode.Location = new System.Drawing.Point(63, 5);
            this.buttonShowRevocationCode.Name = "buttonShowRevocationCode";
            this.buttonShowRevocationCode.Size = new System.Drawing.Size(179, 34);
            this.buttonShowRevocationCode.TabIndex = 0;
            this.buttonShowRevocationCode.Text = "Show Revocation code";
            this.buttonShowRevocationCode.UseVisualStyleBackColor = true;
            this.buttonShowRevocationCode.Click += new System.EventHandler(this.buttonShowRevocationCode_Click);
            // 
            // panelDeleteTwoFactor
            // 
            this.panelDeleteTwoFactor.Controls.Add(this.buttonDeLink);
            this.panelDeleteTwoFactor.Location = new System.Drawing.Point(3, 242);
            this.panelDeleteTwoFactor.Name = "panelDeleteTwoFactor";
            this.panelDeleteTwoFactor.Size = new System.Drawing.Size(302, 45);
            this.panelDeleteTwoFactor.TabIndex = 1;
            // 
            // buttonDeLink
            // 
            this.buttonDeLink.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonDeLink.Location = new System.Drawing.Point(66, 5);
            this.buttonDeLink.Name = "buttonDeLink";
            this.buttonDeLink.Size = new System.Drawing.Size(170, 34);
            this.buttonDeLink.TabIndex = 0;
            this.buttonDeLink.Text = "Delete authenticator";
            this.buttonDeLink.UseVisualStyleBackColor = true;
            this.buttonDeLink.Click += new System.EventHandler(this.buttonDeLink_Click);
            // 
            // flowLayoutPanelPendingConfirmation
            // 
            this.flowLayoutPanelPendingConfirmation.Controls.Add(this.checkedListBoxPendings);
            this.flowLayoutPanelPendingConfirmation.Controls.Add(this.panelPendingButtons);
            this.flowLayoutPanelPendingConfirmation.Controls.Add(this.panelGoToCodes);
            this.flowLayoutPanelPendingConfirmation.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelPendingConfirmation.Location = new System.Drawing.Point(934, 0);
            this.flowLayoutPanelPendingConfirmation.Name = "flowLayoutPanelPendingConfirmation";
            this.flowLayoutPanelPendingConfirmation.Size = new System.Drawing.Size(305, 412);
            this.flowLayoutPanelPendingConfirmation.TabIndex = 3;
            this.flowLayoutPanelPendingConfirmation.Visible = false;
            // 
            // checkedListBoxPendings
            // 
            this.checkedListBoxPendings.Enabled = false;
            this.checkedListBoxPendings.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxPendings.Name = "checkedListBoxPendings";
            this.checkedListBoxPendings.Size = new System.Drawing.Size(300, 213);
            this.checkedListBoxPendings.TabIndex = 0;
            this.checkedListBoxPendings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxPendings_MouseDown);
            // 
            // panelPendingButtons
            // 
            this.panelPendingButtons.Controls.Add(this.buttonPendingDeny);
            this.panelPendingButtons.Controls.Add(this.buttonPendingAccept);
            this.panelPendingButtons.Location = new System.Drawing.Point(3, 222);
            this.panelPendingButtons.Name = "panelPendingButtons";
            this.panelPendingButtons.Size = new System.Drawing.Size(302, 43);
            this.panelPendingButtons.TabIndex = 1;
            this.panelPendingButtons.Visible = false;
            // 
            // buttonPendingDeny
            // 
            this.buttonPendingDeny.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonPendingDeny.Location = new System.Drawing.Point(179, 4);
            this.buttonPendingDeny.Name = "buttonPendingDeny";
            this.buttonPendingDeny.Size = new System.Drawing.Size(120, 35);
            this.buttonPendingDeny.TabIndex = 1;
            this.buttonPendingDeny.Text = "Deny";
            this.buttonPendingDeny.UseVisualStyleBackColor = true;
            this.buttonPendingDeny.Click += new System.EventHandler(this.buttonPendingDeny_Click);
            // 
            // buttonPendingAccept
            // 
            this.buttonPendingAccept.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonPendingAccept.Location = new System.Drawing.Point(3, 4);
            this.buttonPendingAccept.Name = "buttonPendingAccept";
            this.buttonPendingAccept.Size = new System.Drawing.Size(120, 35);
            this.buttonPendingAccept.TabIndex = 0;
            this.buttonPendingAccept.Text = "Accept";
            this.buttonPendingAccept.UseVisualStyleBackColor = true;
            this.buttonPendingAccept.Click += new System.EventHandler(this.buttonPendingAccept_Click);
            // 
            // panelGoToCodes
            // 
            this.panelGoToCodes.Controls.Add(this.buttonGoToCodes);
            this.panelGoToCodes.Location = new System.Drawing.Point(3, 271);
            this.panelGoToCodes.Name = "panelGoToCodes";
            this.panelGoToCodes.Size = new System.Drawing.Size(302, 42);
            this.panelGoToCodes.TabIndex = 11;
            // 
            // buttonGoToCodes
            // 
            this.buttonGoToCodes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonGoToCodes.Location = new System.Drawing.Point(82, 3);
            this.buttonGoToCodes.Name = "buttonGoToCodes";
            this.buttonGoToCodes.Size = new System.Drawing.Size(136, 35);
            this.buttonGoToCodes.TabIndex = 0;
            this.buttonGoToCodes.Text = "Codes";
            this.buttonGoToCodes.UseVisualStyleBackColor = true;
            this.buttonGoToCodes.Click += new System.EventHandler(this.buttonGoToCodes_Click);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconMain.BalloonTipText = "text";
            this.notifyIconMain.BalloonTipTitle = "title";
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripNotifyIcon;
            this.notifyIconMain.Text = "Steam authenticator";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseDoubleClick);
            // 
            // contextMenuStripNotifyIcon
            // 
            this.contextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2FACodes,
            this.closeToolStripMenuItemClose});
            this.contextMenuStripNotifyIcon.Name = "contextMenuStrip1";
            this.contextMenuStripNotifyIcon.Size = new System.Drawing.Size(161, 59);
            // 
            // toolStripTextBox2FACodes
            // 
            this.toolStripTextBox2FACodes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripTextBox2FACodes.Name = "toolStripTextBox2FACodes";
            this.toolStripTextBox2FACodes.ReadOnly = true;
            this.toolStripTextBox2FACodes.Size = new System.Drawing.Size(100, 29);
            this.toolStripTextBox2FACodes.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolStripTextBox2FACodes.Visible = false;
            this.toolStripTextBox2FACodes.Click += new System.EventHandler(this.toolStripTextBox2FACodes_Click);
            // 
            // closeToolStripMenuItemClose
            // 
            this.closeToolStripMenuItemClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.closeToolStripMenuItemClose.Name = "closeToolStripMenuItemClose";
            this.closeToolStripMenuItemClose.Size = new System.Drawing.Size(160, 24);
            this.closeToolStripMenuItemClose.Text = "Close";
            this.closeToolStripMenuItemClose.Click += new System.EventHandler(this.closeToolStripMenuItemClose_Click);
            // 
            // flowLayoutPanelCrypto
            // 
            this.flowLayoutPanelCrypto.Controls.Add(this.panelCryptoCode);
            this.flowLayoutPanelCrypto.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelCrypto.Location = new System.Drawing.Point(3, 422);
            this.flowLayoutPanelCrypto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanelCrypto.Name = "flowLayoutPanelCrypto";
            this.flowLayoutPanelCrypto.Size = new System.Drawing.Size(302, 412);
            this.flowLayoutPanelCrypto.TabIndex = 4;
            // 
            // panelCryptoCode
            // 
            this.panelCryptoCode.Controls.Add(this.label1);
            this.panelCryptoCode.Controls.Add(this.defTextBoxCryptoCode);
            this.panelCryptoCode.Location = new System.Drawing.Point(3, 3);
            this.panelCryptoCode.Name = "panelCryptoCode";
            this.panelCryptoCode.Size = new System.Drawing.Size(299, 100);
            this.panelCryptoCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.Location = new System.Drawing.Point(47, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type your secret code";
            // 
            // defTextBoxCryptoCode
            // 
            this.defTextBoxCryptoCode.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.defTextBoxCryptoCode.ForeColor = System.Drawing.Color.LightGray;
            this.defTextBoxCryptoCode.Location = new System.Drawing.Point(86, 42);
            this.defTextBoxCryptoCode.MaxLength = 4;
            this.defTextBoxCryptoCode.Name = "defTextBoxCryptoCode";
            this.defTextBoxCryptoCode.Size = new System.Drawing.Size(116, 32);
            this.defTextBoxCryptoCode.TabIndex = 0;
            this.defTextBoxCryptoCode.Text = "Secret code";
            this.defTextBoxCryptoCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxCryptoCode.TextChanged += new System.EventHandler(this.defTextBoxCryptoCode_TextChanged);
            this.defTextBoxCryptoCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.defTextBoxCryptoCode_KeyPress);
            // 
            // toolStripMain
            // 
            this.toolStripMain.AllowMerge = false;
            this.toolStripMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownMenu});
            this.toolStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1243, 26);
            this.toolStripMain.TabIndex = 11;
            this.toolStripMain.Text = "Tool Strip";
            this.toolStripMain.Visible = false;
            // 
            // toolStripDropDownMenu
            // 
            this.toolStripDropDownMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem});
            this.toolStripDropDownMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownMenu.Name = "toolStripDropDownMenu";
            this.toolStripDropDownMenu.Size = new System.Drawing.Size(42, 23);
            this.toolStripDropDownMenu.Text = "File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Visible = false;
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Visible = false;
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // panelLoading
            // 
            this.panelLoading.BackColor = System.Drawing.Color.White;
            this.panelLoading.Controls.Add(this.pictureBoxLoading);
            this.panelLoading.Location = new System.Drawing.Point(316, 422);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(300, 400);
            this.panelLoading.TabIndex = 12;
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.ErrorImage = null;
            this.pictureBoxLoading.Image = global::Windows2FAuth.Properties.Resources.loading80;
            this.pictureBoxLoading.InitialImage = null;
            this.pictureBoxLoading.Location = new System.Drawing.Point(110, 160);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxLoading.TabIndex = 1;
            this.pictureBoxLoading.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1243, 733);
            this.Controls.Add(this.panelLoading);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.flowLayoutPanelCrypto);
            this.Controls.Add(this.flowLayoutPanelPendingConfirmation);
            this.Controls.Add(this.flowLayoutPanelTwoFactorCodes);
            this.Controls.Add(this.flowLayoutPanelLinker);
            this.Controls.Add(this.flowLayoutPanelLogin);
            this.Controls.Add(this.toolStripMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "Steam authenticator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.flowLayoutPanelLogin.ResumeLayout(false);
            this.panelLoginPass.ResumeLayout(false);
            this.panelLoginPass.PerformLayout();
            this.panelEmailCode.ResumeLayout(false);
            this.panelEmailCode.PerformLayout();
            this.panelTwoFactorCode.ResumeLayout(false);
            this.panelTwoFactorCode.PerformLayout();
            this.panelCaptcha.ResumeLayout(false);
            this.panelCaptcha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).EndInit();
            this.panelLoginButton.ResumeLayout(false);
            this.flowLayoutPanelLinker.ResumeLayout(false);
            this.panelLinkButton.ResumeLayout(false);
            this.panelPhone.ResumeLayout(false);
            this.panelPhone.PerformLayout();
            this.panelSMS.ResumeLayout(false);
            this.panelSMS.PerformLayout();
            this.panelSecret.ResumeLayout(false);
            this.panelSecret.PerformLayout();
            this.panelFinalizeLink.ResumeLayout(false);
            this.flowLayoutPanelTwoFactorCodes.ResumeLayout(false);
            this.panelTwoFactorCodes.ResumeLayout(false);
            this.panelTwoFactorCodes.PerformLayout();
            this.panelRevocationCode.ResumeLayout(false);
            this.panelRevocationCode.PerformLayout();
            this.panelGoToPending.ResumeLayout(false);
            this.panelShowRevocationCode.ResumeLayout(false);
            this.panelDeleteTwoFactor.ResumeLayout(false);
            this.flowLayoutPanelPendingConfirmation.ResumeLayout(false);
            this.panelPendingButtons.ResumeLayout(false);
            this.panelGoToCodes.ResumeLayout(false);
            this.contextMenuStripNotifyIcon.ResumeLayout(false);
            this.contextMenuStripNotifyIcon.PerformLayout();
            this.flowLayoutPanelCrypto.ResumeLayout(false);
            this.panelCryptoCode.ResumeLayout(false);
            this.panelCryptoCode.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.panelLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private defTextBox defTextBoxUsername;
        private defTextBox defTextBoxPassword;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLogin;
        private System.Windows.Forms.Panel panelLoginPass;
        private System.Windows.Forms.Panel panelEmailCode;
        private defTextBox defTextBoxEmailCode;
        private System.Windows.Forms.Panel panelLoginButton;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLinker;
        private System.Windows.Forms.Panel panelLinkButton;
        private System.Windows.Forms.Button buttonLink;
        private System.Windows.Forms.Panel panelCaptcha;
        private System.Windows.Forms.PictureBox pictureBoxCaptcha;
        private defTextBox defTextBoxCaptcha;
        private System.Windows.Forms.Panel panelPhone;
        private defTextBox defTextBoxPhone;
        private System.Windows.Forms.Panel panelSMS;
        private defTextBox defTextBoxSMS;
        private System.Windows.Forms.Panel panelTwoFactorCode;
        private defTextBox defTextBoxTwoFactorCode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTwoFactorCodes;
        private System.Windows.Forms.Panel panelTwoFactorCodes;
        private System.Windows.Forms.TextBox textBoxTwoFactorCode;
        private System.Windows.Forms.Panel panelRevocationCode;
        private System.Windows.Forms.Panel panelDeleteTwoFactor;
        private System.Windows.Forms.Button buttonDeLink;
        private System.Windows.Forms.Panel panelFinalizeLink;
        private System.Windows.Forms.Button buttonFinalize;
        private System.Windows.Forms.Panel panelShowRevocationCode;
        private System.Windows.Forms.Button buttonShowRevocationCode;
        private System.Windows.Forms.TextBox textBoxRevocationCode;
        private System.Windows.Forms.ProgressBar progressBarTwoFactorCode;
        private System.Windows.Forms.ProgressBar progressBarRevocationCode;
        private System.Windows.Forms.Panel panelGoToPending;
        private System.Windows.Forms.Button buttonGoToPendings;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPendingConfirmation;
        private CheckedListBoxExtended checkedListBoxPendings;
        private System.Windows.Forms.Panel panelPendingButtons;
        private System.Windows.Forms.Button buttonPendingDeny;
        private System.Windows.Forms.Button buttonPendingAccept;
        private System.Windows.Forms.Panel panelGoToCodes;
        private System.Windows.Forms.Button buttonGoToCodes;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCrypto;
        private System.Windows.Forms.Panel panelCryptoCode;
        private defTextBox defTextBoxCryptoCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSecret;
        private defTextBox defTextBoxSecret;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownMenu;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIcon;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2FACodes;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItemClose;
        private TransparentPanel panelLoading;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
    }
}

