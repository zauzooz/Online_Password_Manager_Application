
namespace pwManager
{
    partial class pw
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPw = new System.Windows.Forms.Label();
            this.labelWeb = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPw = new System.Windows.Forms.TextBox();
            this.textBoxWeb = new System.Windows.Forms.TextBox();
            this.toolTippw = new System.Windows.Forms.ToolTip(this.components);
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonWeb = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonHind = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelApp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(29, 124);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(108, 32);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPw
            // 
            this.labelPw.AutoSize = true;
            this.labelPw.Location = new System.Drawing.Point(34, 209);
            this.labelPw.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPw.Name = "labelPw";
            this.labelPw.Size = new System.Drawing.Size(103, 32);
            this.labelPw.TabIndex = 1;
            this.labelPw.Text = "Password";
            // 
            // labelWeb
            // 
            this.labelWeb.AutoSize = true;
            this.labelWeb.Location = new System.Drawing.Point(51, 302);
            this.labelWeb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWeb.Name = "labelWeb";
            this.labelWeb.Size = new System.Drawing.Size(86, 32);
            this.labelWeb.TabIndex = 2;
            this.labelWeb.Text = "Website";
            // 
            // textBoxUser
            // 
            this.textBoxUser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUser.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxUser.Location = new System.Drawing.Point(161, 121);
            this.textBoxUser.Multiline = true;
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(378, 41);
            this.textBoxUser.TabIndex = 3;
            this.toolTippw.SetToolTip(this.textBoxUser, "Change username");
            // 
            // textBoxPw
            // 
            this.textBoxPw.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxPw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPw.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxPw.Location = new System.Drawing.Point(161, 205);
            this.textBoxPw.Multiline = true;
            this.textBoxPw.Name = "textBoxPw";
            this.textBoxPw.PasswordChar = '*';
            this.textBoxPw.Size = new System.Drawing.Size(345, 41);
            this.textBoxPw.TabIndex = 4;
            this.toolTippw.SetToolTip(this.textBoxPw, "Change password");
            // 
            // textBoxWeb
            // 
            this.textBoxWeb.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxWeb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWeb.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxWeb.Location = new System.Drawing.Point(161, 298);
            this.textBoxWeb.Multiline = true;
            this.textBoxWeb.Name = "textBoxWeb";
            this.textBoxWeb.Size = new System.Drawing.Size(345, 41);
            this.textBoxWeb.TabIndex = 5;
            // 
            // buttonRemove
            // 
            this.buttonRemove.FlatAppearance.BorderSize = 0;
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemove.Image = global::pwManager.Properties.Resources.icons8_delete_30;
            this.buttonRemove.Location = new System.Drawing.Point(372, 414);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(167, 60);
            this.buttonRemove.TabIndex = 11;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTippw.SetToolTip(this.buttonRemove, "Remove this account");
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonWeb
            // 
            this.buttonWeb.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonWeb.FlatAppearance.BorderSize = 0;
            this.buttonWeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWeb.Image = global::pwManager.Properties.Resources.icons8_browser_full_size_20;
            this.buttonWeb.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonWeb.Location = new System.Drawing.Point(505, 298);
            this.buttonWeb.Name = "buttonWeb";
            this.buttonWeb.Size = new System.Drawing.Size(36, 41);
            this.buttonWeb.TabIndex = 8;
            this.toolTippw.SetToolTip(this.buttonWeb, "Go to website");
            this.buttonWeb.UseVisualStyleBackColor = false;
            this.buttonWeb.Click += new System.EventHandler(this.buttonWeb_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonShow.FlatAppearance.BorderSize = 0;
            this.buttonShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShow.Image = global::pwManager.Properties.Resources._259390847_2964650720455445_5633401746013943908_n1;
            this.buttonShow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonShow.Location = new System.Drawing.Point(504, 205);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(36, 40);
            this.buttonShow.TabIndex = 7;
            this.toolTippw.SetToolTip(this.buttonShow, "Show password");
            this.buttonShow.UseVisualStyleBackColor = false;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // buttonHind
            // 
            this.buttonHind.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonHind.FlatAppearance.BorderSize = 0;
            this.buttonHind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHind.Image = global::pwManager.Properties.Resources._283513108_558654555913055_3601192219442731041_n1;
            this.buttonHind.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHind.Location = new System.Drawing.Point(503, 205);
            this.buttonHind.Name = "buttonHind";
            this.buttonHind.Size = new System.Drawing.Size(36, 41);
            this.buttonHind.TabIndex = 6;
            this.toolTippw.SetToolTip(this.buttonHind, "Hind password");
            this.buttonHind.UseVisualStyleBackColor = false;
            this.buttonHind.Click += new System.EventHandler(this.buttonHind_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::pwManager.Properties.Resources._280932346_407754631225305_2352177184858265782_n1;
            this.pictureBox2.Location = new System.Drawing.Point(67, 388);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 101);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // labelApp
            // 
            this.labelApp.AutoSize = true;
            this.labelApp.Font = new System.Drawing.Font("Sitka Display", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApp.Location = new System.Drawing.Point(143, 28);
            this.labelApp.Name = "labelApp";
            this.labelApp.Size = new System.Drawing.Size(98, 48);
            this.labelApp.TabIndex = 12;
            this.labelApp.Text = "label1";
            this.labelApp.Click += new System.EventHandler(this.labelApp_Click_1);
            // 
            // pw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.labelApp);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonWeb);
            this.Controls.Add(this.textBoxWeb);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelWeb);
            this.Controls.Add(this.labelPw);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonHind);
            this.Controls.Add(this.textBoxPw);
            this.Font = new System.Drawing.Font("Sitka Display", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SteelBlue;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "pw";
            this.Size = new System.Drawing.Size(579, 523);
            this.Load += new System.EventHandler(this.pw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPw;
        private System.Windows.Forms.Label labelWeb;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPw;
        private System.Windows.Forms.TextBox textBoxWeb;
        private System.Windows.Forms.Button buttonHind;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonWeb;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTippw;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Label labelApp;
    }
}
