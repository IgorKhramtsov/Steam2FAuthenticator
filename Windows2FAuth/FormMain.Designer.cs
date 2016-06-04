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
            this.labelStatus = new System.Windows.Forms.Label();
            this.flowLayoutPanelLogin = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLoginPass = new System.Windows.Forms.Panel();
            this.panelEmailCode = new System.Windows.Forms.Panel();
            this.panelTwoFactorCode = new System.Windows.Forms.Panel();
            this.panelCaptcha = new System.Windows.Forms.Panel();
            this.pictureBoxCaptcha = new System.Windows.Forms.PictureBox();
            this.panelLoginButton = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panelLoadingLogin = new System.Windows.Forms.Panel();
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelLinker = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLinkButton = new System.Windows.Forms.Panel();
            this.buttonLink = new System.Windows.Forms.Button();
            this.panelSMS = new System.Windows.Forms.Panel();
            this.panelPhone = new System.Windows.Forms.Panel();
            this.panelFinalizeLink = new System.Windows.Forms.Panel();
            this.buttonFinalize = new System.Windows.Forms.Button();
            this.panelLoadingLink = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelTwoFactorCodes = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTwoFactorCodes = new System.Windows.Forms.Panel();
            this.progressBarTwoFactorCode = new System.Windows.Forms.ProgressBar();
            this.textBoxTwoFactorCode = new System.Windows.Forms.TextBox();
            this.panelRevocationCode = new System.Windows.Forms.Panel();
            this.progressBarRevocationCode = new System.Windows.Forms.ProgressBar();
            this.textBoxRevocationCode = new System.Windows.Forms.TextBox();
            this.panelDeleteTwoFactor = new System.Windows.Forms.Panel();
            this.buttonDeLink = new System.Windows.Forms.Button();
            this.panelShowRevocationCode = new System.Windows.Forms.Panel();
            this.buttonShowRevocationCode = new System.Windows.Forms.Button();
            this.panelTwoFactorLoading = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.defTextBoxSMS = new Windows2FAuth.defTextBox();
            this.defTextBoxPhone = new Windows2FAuth.defTextBox();
            this.defTextBoxUsername = new Windows2FAuth.defTextBox();
            this.defTextBoxPassword = new Windows2FAuth.defTextBox();
            this.defTextBoxEmailCode = new Windows2FAuth.defTextBox();
            this.defTextBoxTwoFactorCode = new Windows2FAuth.defTextBox();
            this.defTextBoxCaptcha = new Windows2FAuth.defTextBox();
            this.flowLayoutPanelLogin.SuspendLayout();
            this.panelLoginPass.SuspendLayout();
            this.panelEmailCode.SuspendLayout();
            this.panelTwoFactorCode.SuspendLayout();
            this.panelCaptcha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).BeginInit();
            this.panelLoginButton.SuspendLayout();
            this.panelLoadingLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.flowLayoutPanelLinker.SuspendLayout();
            this.panelLinkButton.SuspendLayout();
            this.panelSMS.SuspendLayout();
            this.panelPhone.SuspendLayout();
            this.panelFinalizeLink.SuspendLayout();
            this.panelLoadingLink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanelTwoFactorCodes.SuspendLayout();
            this.panelTwoFactorCodes.SuspendLayout();
            this.panelRevocationCode.SuspendLayout();
            this.panelDeleteTwoFactor.SuspendLayout();
            this.panelShowRevocationCode.SuspendLayout();
            this.panelTwoFactorLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(1, 417);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 15);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanelLogin
            // 
            this.flowLayoutPanelLogin.Controls.Add(this.panelLoginPass);
            this.flowLayoutPanelLogin.Controls.Add(this.panelEmailCode);
            this.flowLayoutPanelLogin.Controls.Add(this.panelTwoFactorCode);
            this.flowLayoutPanelLogin.Controls.Add(this.panelCaptcha);
            this.flowLayoutPanelLogin.Controls.Add(this.panelLoginButton);
            this.flowLayoutPanelLogin.Controls.Add(this.panelLoadingLogin);
            this.flowLayoutPanelLogin.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelLogin.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanelLogin.Name = "flowLayoutPanelLogin";
            this.flowLayoutPanelLogin.Size = new System.Drawing.Size(305, 412);
            this.flowLayoutPanelLogin.TabIndex = 4;
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
            // panelLoadingLogin
            // 
            this.panelLoadingLogin.Controls.Add(this.pictureBoxLoading);
            this.panelLoadingLogin.Location = new System.Drawing.Point(311, 3);
            this.panelLoadingLogin.Name = "panelLoadingLogin";
            this.panelLoadingLogin.Size = new System.Drawing.Size(302, 110);
            this.panelLoadingLogin.TabIndex = 7;
            this.panelLoadingLogin.Visible = false;
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.ErrorImage = null;
            this.pictureBoxLoading.Image = global::Windows2FAuth.Properties.Resources.loading80;
            this.pictureBoxLoading.InitialImage = null;
            this.pictureBoxLoading.Location = new System.Drawing.Point(109, 12);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxLoading.TabIndex = 0;
            this.pictureBoxLoading.TabStop = false;
            // 
            // flowLayoutPanelLinker
            // 
            this.flowLayoutPanelLinker.Controls.Add(this.panelLinkButton);
            this.flowLayoutPanelLinker.Controls.Add(this.panelSMS);
            this.flowLayoutPanelLinker.Controls.Add(this.panelPhone);
            this.flowLayoutPanelLinker.Controls.Add(this.panelFinalizeLink);
            this.flowLayoutPanelLinker.Controls.Add(this.panelLoadingLink);
            this.flowLayoutPanelLinker.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelLinker.Location = new System.Drawing.Point(311, 0);
            this.flowLayoutPanelLinker.Name = "flowLayoutPanelLinker";
            this.flowLayoutPanelLinker.Size = new System.Drawing.Size(305, 412);
            this.flowLayoutPanelLinker.TabIndex = 7;
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
            // panelSMS
            // 
            this.panelSMS.Controls.Add(this.defTextBoxSMS);
            this.panelSMS.Location = new System.Drawing.Point(3, 63);
            this.panelSMS.Name = "panelSMS";
            this.panelSMS.Size = new System.Drawing.Size(298, 40);
            this.panelSMS.TabIndex = 10;
            this.panelSMS.Visible = false;
            // 
            // panelPhone
            // 
            this.panelPhone.Controls.Add(this.defTextBoxPhone);
            this.panelPhone.Location = new System.Drawing.Point(3, 109);
            this.panelPhone.Name = "panelPhone";
            this.panelPhone.Size = new System.Drawing.Size(298, 38);
            this.panelPhone.TabIndex = 9;
            this.panelPhone.Visible = false;
            // 
            // panelFinalizeLink
            // 
            this.panelFinalizeLink.Controls.Add(this.buttonFinalize);
            this.panelFinalizeLink.Location = new System.Drawing.Point(3, 153);
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
            // panelLoadingLink
            // 
            this.panelLoadingLink.Controls.Add(this.pictureBox1);
            this.panelLoadingLink.Location = new System.Drawing.Point(3, 213);
            this.panelLoadingLink.Name = "panelLoadingLink";
            this.panelLoadingLink.Size = new System.Drawing.Size(302, 110);
            this.panelLoadingLink.TabIndex = 8;
            this.panelLoadingLink.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::Windows2FAuth.Properties.Resources.loading80;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(109, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanelTwoFactorCodes
            // 
            this.flowLayoutPanelTwoFactorCodes.Controls.Add(this.panelTwoFactorCodes);
            this.flowLayoutPanelTwoFactorCodes.Controls.Add(this.panelRevocationCode);
            this.flowLayoutPanelTwoFactorCodes.Controls.Add(this.panelDeleteTwoFactor);
            this.flowLayoutPanelTwoFactorCodes.Controls.Add(this.panelShowRevocationCode);
            this.flowLayoutPanelTwoFactorCodes.Controls.Add(this.panelTwoFactorLoading);
            this.flowLayoutPanelTwoFactorCodes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTwoFactorCodes.Location = new System.Drawing.Point(623, 0);
            this.flowLayoutPanelTwoFactorCodes.Name = "flowLayoutPanelTwoFactorCodes";
            this.flowLayoutPanelTwoFactorCodes.Size = new System.Drawing.Size(305, 412);
            this.flowLayoutPanelTwoFactorCodes.TabIndex = 8;
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
            this.textBoxTwoFactorCode.Location = new System.Drawing.Point(105, 10);
            this.textBoxTwoFactorCode.MaxLength = 5;
            this.textBoxTwoFactorCode.Name = "textBoxTwoFactorCode";
            this.textBoxTwoFactorCode.ReadOnly = true;
            this.textBoxTwoFactorCode.Size = new System.Drawing.Size(98, 39);
            this.textBoxTwoFactorCode.TabIndex = 0;
            this.textBoxTwoFactorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.textBoxRevocationCode.Location = new System.Drawing.Point(105, 7);
            this.textBoxRevocationCode.MaxLength = 5;
            this.textBoxRevocationCode.Name = "textBoxRevocationCode";
            this.textBoxRevocationCode.ReadOnly = true;
            this.textBoxRevocationCode.Size = new System.Drawing.Size(98, 39);
            this.textBoxRevocationCode.TabIndex = 1;
            this.textBoxRevocationCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelDeleteTwoFactor
            // 
            this.panelDeleteTwoFactor.Controls.Add(this.buttonDeLink);
            this.panelDeleteTwoFactor.Location = new System.Drawing.Point(3, 143);
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
            // panelShowRevocationCode
            // 
            this.panelShowRevocationCode.Controls.Add(this.buttonShowRevocationCode);
            this.panelShowRevocationCode.Location = new System.Drawing.Point(3, 194);
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
            // panelTwoFactorLoading
            // 
            this.panelTwoFactorLoading.Controls.Add(this.pictureBox2);
            this.panelTwoFactorLoading.Location = new System.Drawing.Point(3, 245);
            this.panelTwoFactorLoading.Name = "panelTwoFactorLoading";
            this.panelTwoFactorLoading.Size = new System.Drawing.Size(302, 110);
            this.panelTwoFactorLoading.TabIndex = 9;
            this.panelTwoFactorLoading.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = global::Windows2FAuth.Properties.Resources.loading80;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(109, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 80);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
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
            // defTextBoxUsername
            // 
            this.defTextBoxUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.defTextBoxUsername.ForeColor = System.Drawing.Color.LightGray;
            this.defTextBoxUsername.Location = new System.Drawing.Point(47, 15);
            this.defTextBoxUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defTextBoxUsername.Name = "defTextBoxUsername";
            this.defTextBoxUsername.Size = new System.Drawing.Size(212, 25);
            this.defTextBoxUsername.TabIndex = 1;
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
            this.defTextBoxPassword.TabIndex = 2;
            this.defTextBoxPassword.Text = "Password";
            this.defTextBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxPassword.UseSystemPasswordChar = true;
            this.defTextBoxPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
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
            this.defTextBoxEmailCode.TabIndex = 3;
            this.defTextBoxEmailCode.Text = "EMAIL CODE";
            this.defTextBoxEmailCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxEmailCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // defTextBoxTwoFactorCode
            // 
            this.defTextBoxTwoFactorCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.defTextBoxTwoFactorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.defTextBoxTwoFactorCode.ForeColor = System.Drawing.Color.LightGray;
            this.defTextBoxTwoFactorCode.Location = new System.Drawing.Point(100, 0);
            this.defTextBoxTwoFactorCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defTextBoxTwoFactorCode.MaxLength = 5;
            this.defTextBoxTwoFactorCode.Name = "defTextBoxTwoFactorCode";
            this.defTextBoxTwoFactorCode.Size = new System.Drawing.Size(92, 26);
            this.defTextBoxTwoFactorCode.TabIndex = 3;
            this.defTextBoxTwoFactorCode.Text = "2FA CODE";
            this.defTextBoxTwoFactorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxTwoFactorCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // defTextBoxCaptcha
            // 
            this.defTextBoxCaptcha.Location = new System.Drawing.Point(50, 49);
            this.defTextBoxCaptcha.Name = "defTextBoxCaptcha";
            this.defTextBoxCaptcha.Size = new System.Drawing.Size(200, 23);
            this.defTextBoxCaptcha.TabIndex = 4;
            this.defTextBoxCaptcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.defTextBoxCaptcha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(931, 435);
            this.Controls.Add(this.flowLayoutPanelTwoFactorCodes);
            this.Controls.Add(this.flowLayoutPanelLinker);
            this.Controls.Add(this.flowLayoutPanelLogin);
            this.Controls.Add(this.labelStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "Steam authenticator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
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
            this.panelLoadingLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.flowLayoutPanelLinker.ResumeLayout(false);
            this.panelLinkButton.ResumeLayout(false);
            this.panelSMS.ResumeLayout(false);
            this.panelSMS.PerformLayout();
            this.panelPhone.ResumeLayout(false);
            this.panelPhone.PerformLayout();
            this.panelFinalizeLink.ResumeLayout(false);
            this.panelLoadingLink.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanelTwoFactorCodes.ResumeLayout(false);
            this.panelTwoFactorCodes.ResumeLayout(false);
            this.panelTwoFactorCodes.PerformLayout();
            this.panelRevocationCode.ResumeLayout(false);
            this.panelRevocationCode.PerformLayout();
            this.panelDeleteTwoFactor.ResumeLayout(false);
            this.panelShowRevocationCode.ResumeLayout(false);
            this.panelTwoFactorLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.Panel panelLoadingLogin;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
        private System.Windows.Forms.Panel panelLoadingLink;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.Panel panelTwoFactorLoading;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelFinalizeLink;
        private System.Windows.Forms.Button buttonFinalize;
        private System.Windows.Forms.Panel panelShowRevocationCode;
        private System.Windows.Forms.Button buttonShowRevocationCode;
        private System.Windows.Forms.TextBox textBoxRevocationCode;
        private System.Windows.Forms.ProgressBar progressBarTwoFactorCode;
        private System.Windows.Forms.ProgressBar progressBarRevocationCode;
    }
}

