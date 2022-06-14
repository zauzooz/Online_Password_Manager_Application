
namespace pwManager
{
    partial class account
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
            this.labelmasterUser = new System.Windows.Forms.Label();
            this.labelmasterPass = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxMstPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonShow = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonHind = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelmasterUser
            // 
            this.labelmasterUser.AutoSize = true;
            this.labelmasterUser.Location = new System.Drawing.Point(93, 232);
            this.labelmasterUser.Name = "labelmasterUser";
            this.labelmasterUser.Size = new System.Drawing.Size(109, 32);
            this.labelmasterUser.TabIndex = 1;
            this.labelmasterUser.Text = "Username";
            // 
            // labelmasterPass
            // 
            this.labelmasterPass.AutoSize = true;
            this.labelmasterPass.Location = new System.Drawing.Point(28, 380);
            this.labelmasterPass.Name = "labelmasterPass";
            this.labelmasterPass.Size = new System.Drawing.Size(174, 32);
            this.labelmasterPass.TabIndex = 2;
            this.labelmasterPass.Text = "Master password";
            // 
            // textBoxUser
            // 
            this.textBoxUser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUser.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxUser.Location = new System.Drawing.Point(226, 224);
            this.textBoxUser.Multiline = true;
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(317, 41);
            this.textBoxUser.TabIndex = 6;
            // 
            // textBoxMstPass
            // 
            this.textBoxMstPass.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxMstPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMstPass.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxMstPass.Location = new System.Drawing.Point(226, 375);
            this.textBoxMstPass.Multiline = true;
            this.textBoxMstPass.Name = "textBoxMstPass";
            this.textBoxMstPass.PasswordChar = '*';
            this.textBoxMstPass.Size = new System.Drawing.Size(286, 41);
            this.textBoxMstPass.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 32);
            this.label2.TabIndex = 13;
            this.label2.Text = "Email";
            // 
            // buttonShow
            // 
            this.buttonShow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonShow.FlatAppearance.BorderSize = 0;
            this.buttonShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShow.Image = global::pwManager.Properties.Resources._259390847_2964650720455445_5633401746013943908_n1;
            this.buttonShow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonShow.Location = new System.Drawing.Point(513, 375);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(30, 41);
            this.buttonShow.TabIndex = 9;
            this.buttonShow.UseVisualStyleBackColor = false;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::pwManager.Properties.Resources.icons8_user_100;
            this.pictureBox1.Location = new System.Drawing.Point(44, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonHind
            // 
            this.buttonHind.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonHind.FlatAppearance.BorderSize = 0;
            this.buttonHind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHind.Image = global::pwManager.Properties.Resources._283513108_558654555913055_3601192219442731041_n1;
            this.buttonHind.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHind.Location = new System.Drawing.Point(509, 375);
            this.buttonHind.Name = "buttonHind";
            this.buttonHind.Size = new System.Drawing.Size(34, 41);
            this.buttonHind.TabIndex = 10;
            this.buttonHind.UseVisualStyleBackColor = false;
            this.buttonHind.Click += new System.EventHandler(this.buttonHind_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBox1.Location = new System.Drawing.Point(226, 301);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(317, 41);
            this.textBox1.TabIndex = 14;
            // 
            // account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelmasterPass);
            this.Controls.Add(this.labelmasterUser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonHind);
            this.Controls.Add(this.textBoxMstPass);
            this.Font = new System.Drawing.Font("Sitka Display", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SteelBlue;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "account";
            this.Size = new System.Drawing.Size(579, 523);
            this.Load += new System.EventHandler(this.account_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelmasterUser;
        private System.Windows.Forms.Label labelmasterPass;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxMstPass;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonHind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
