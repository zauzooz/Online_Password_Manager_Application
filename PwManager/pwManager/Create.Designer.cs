
namespace pwManager
{
    partial class Create
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
            this.buttonCreate = new System.Windows.Forms.Button();
            this.labelapp = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxApp = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPw = new System.Windows.Forms.TextBox();
            this.labelconfirm = new System.Windows.Forms.Label();
            this.textBoxconfirm = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonShow1 = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonHind = new System.Windows.Forms.Button();
            this.buttonHind1 = new System.Windows.Forms.Button();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.FlatAppearance.BorderSize = 0;
            this.buttonCreate.Location = new System.Drawing.Point(358, 421);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(133, 57);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Create";
            this.toolTip1.SetToolTip(this.buttonCreate, "Create");
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // labelapp
            // 
            this.labelapp.AutoSize = true;
            this.labelapp.Location = new System.Drawing.Point(130, 70);
            this.labelapp.Name = "labelapp";
            this.labelapp.Size = new System.Drawing.Size(95, 32);
            this.labelapp.TabIndex = 1;
            this.labelapp.Text = "New app";
            this.labelapp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(35, 176);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(108, 32);
            this.labelUser.TabIndex = 2;
            this.labelUser.Text = "Username";
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxApp
            // 
            this.textBoxApp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxApp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxApp.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxApp.Location = new System.Drawing.Point(251, 70);
            this.textBoxApp.Multiline = true;
            this.textBoxApp.Name = "textBoxApp";
            this.textBoxApp.Size = new System.Drawing.Size(295, 41);
            this.textBoxApp.TabIndex = 5;
            // 
            // textBoxUser
            // 
            this.textBoxUser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUser.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxUser.Location = new System.Drawing.Point(169, 172);
            this.textBoxUser.Multiline = true;
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(377, 41);
            this.textBoxUser.TabIndex = 6;
            // 
            // textBoxPw
            // 
            this.textBoxPw.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxPw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPw.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxPw.Location = new System.Drawing.Point(169, 252);
            this.textBoxPw.Multiline = true;
            this.textBoxPw.Name = "textBoxPw";
            this.textBoxPw.PasswordChar = '*';
            this.textBoxPw.Size = new System.Drawing.Size(377, 41);
            this.textBoxPw.TabIndex = 7;
            this.textBoxPw.Leave += new System.EventHandler(this.password_leave);
            // 
            // labelconfirm
            // 
            this.labelconfirm.AutoSize = true;
            this.labelconfirm.Location = new System.Drawing.Point(53, 332);
            this.labelconfirm.Name = "labelconfirm";
            this.labelconfirm.Size = new System.Drawing.Size(90, 32);
            this.labelconfirm.TabIndex = 11;
            this.labelconfirm.Text = "Confirm";
            this.labelconfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxconfirm
            // 
            this.textBoxconfirm.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxconfirm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxconfirm.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxconfirm.Location = new System.Drawing.Point(169, 328);
            this.textBoxconfirm.Multiline = true;
            this.textBoxconfirm.Name = "textBoxconfirm";
            this.textBoxconfirm.PasswordChar = '*';
            this.textBoxconfirm.Size = new System.Drawing.Size(377, 41);
            this.textBoxconfirm.TabIndex = 12;
            this.textBoxconfirm.Leave += new System.EventHandler(this.confirm_pass_leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::pwManager.Properties.Resources.icons8_secure_100;
            this.pictureBox1.Location = new System.Drawing.Point(19, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 97);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonShow1
            // 
            this.buttonShow1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonShow1.FlatAppearance.BorderSize = 0;
            this.buttonShow1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShow1.Image = global::pwManager.Properties.Resources._259390847_2964650720455445_5633401746013943908_n1;
            this.buttonShow1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonShow1.Location = new System.Drawing.Point(510, 328);
            this.buttonShow1.Name = "buttonShow1";
            this.buttonShow1.Size = new System.Drawing.Size(34, 41);
            this.buttonShow1.TabIndex = 13;
            this.buttonShow1.UseVisualStyleBackColor = false;
            this.buttonShow1.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonShow.FlatAppearance.BorderSize = 0;
            this.buttonShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShow.Image = global::pwManager.Properties.Resources._259390847_2964650720455445_5633401746013943908_n1;
            this.buttonShow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonShow.Location = new System.Drawing.Point(512, 252);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(34, 41);
            this.buttonShow.TabIndex = 8;
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
            this.buttonHind.Location = new System.Drawing.Point(512, 252);
            this.buttonHind.Name = "buttonHind";
            this.buttonHind.Size = new System.Drawing.Size(34, 41);
            this.buttonHind.TabIndex = 9;
            this.buttonHind.UseVisualStyleBackColor = false;
            this.buttonHind.Click += new System.EventHandler(this.buttonHind_Click);
            // 
            // buttonHind1
            // 
            this.buttonHind1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonHind1.FlatAppearance.BorderSize = 0;
            this.buttonHind1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHind1.Image = global::pwManager.Properties.Resources._283513108_558654555913055_3601192219442731041_n1;
            this.buttonHind1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHind1.Location = new System.Drawing.Point(510, 328);
            this.buttonHind1.Name = "buttonHind1";
            this.buttonHind1.Size = new System.Drawing.Size(34, 41);
            this.buttonHind1.TabIndex = 14;
            this.buttonHind1.UseVisualStyleBackColor = false;
            this.buttonHind1.Click += new System.EventHandler(this.buttonHind_Click);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(41, 421);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(213, 57);
            this.buttonRandom.TabIndex = 16;
            this.buttonRandom.Text = "Random password";
            this.toolTip1.SetToolTip(this.buttonRandom, "Random strong password");
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.buttonRandom);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonShow1);
            this.Controls.Add(this.labelconfirm);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.textBoxApp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelapp);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonHind);
            this.Controls.Add(this.textBoxPw);
            this.Controls.Add(this.buttonHind1);
            this.Controls.Add(this.textBoxconfirm);
            this.Font = new System.Drawing.Font("Sitka Display", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SteelBlue;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Create";
            this.Size = new System.Drawing.Size(579, 523);
            this.Load += new System.EventHandler(this.Create_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label labelapp;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxApp;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPw;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonHind;
        private System.Windows.Forms.Label labelconfirm;
        private System.Windows.Forms.TextBox textBoxconfirm;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Button buttonShow1;
        private System.Windows.Forms.Button buttonHind1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonRandom;
    }
}
