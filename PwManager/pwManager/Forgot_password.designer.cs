namespace pwManager
{
    partial class Forgot_password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forgot_password));
            this.button3 = new System.Windows.Forms.Button();
            this.Phone_number = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.send = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.enter_code = new System.Windows.Forms.TextBox();
            this.verify = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(393, 15);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 25);
            this.button3.TabIndex = 15;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Phone_number
            // 
            this.Phone_number.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Phone_number.Font = new System.Drawing.Font("Sitka Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Phone_number.ForeColor = System.Drawing.Color.SteelBlue;
            this.Phone_number.Location = new System.Drawing.Point(48, 155);
            this.Phone_number.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Phone_number.Multiline = true;
            this.Phone_number.Name = "Phone_number";
            this.Phone_number.Size = new System.Drawing.Size(327, 37);
            this.Phone_number.TabIndex = 16;
            this.Phone_number.Text = "Enter email";
            this.Phone_number.MouseEnter += new System.EventHandler(this.txtEnter);
            this.Phone_number.MouseLeave += new System.EventHandler(this.txtLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(48, 199);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 1);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // send
            // 
            this.send.BackColor = System.Drawing.Color.SteelBlue;
            this.send.FlatAppearance.BorderSize = 0;
            this.send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.send.Font = new System.Drawing.Font("Sitka Display", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.send.ForeColor = System.Drawing.SystemColors.Window;
            this.send.Location = new System.Drawing.Point(172, 208);
            this.send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(95, 37);
            this.send.TabIndex = 18;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = false;
            this.send.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(48, 319);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 1);
            this.panel2.TabIndex = 18;
            // 
            // enter_code
            // 
            this.enter_code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.enter_code.Font = new System.Drawing.Font("Sitka Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enter_code.ForeColor = System.Drawing.Color.SteelBlue;
            this.enter_code.Location = new System.Drawing.Point(48, 274);
            this.enter_code.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enter_code.Multiline = true;
            this.enter_code.Name = "enter_code";
            this.enter_code.Size = new System.Drawing.Size(327, 37);
            this.enter_code.TabIndex = 19;
            this.enter_code.Text = "Enter code";
            this.enter_code.TextChanged += new System.EventHandler(this.enter_code_TextChanged);
            this.enter_code.MouseEnter += new System.EventHandler(this.CodeEnter);
            this.enter_code.MouseLeave += new System.EventHandler(this.Codeleave);
            // 
            // verify
            // 
            this.verify.BackColor = System.Drawing.Color.SteelBlue;
            this.verify.FlatAppearance.BorderSize = 0;
            this.verify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verify.Font = new System.Drawing.Font("Sitka Display", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verify.ForeColor = System.Drawing.SystemColors.Window;
            this.verify.Location = new System.Drawing.Point(172, 346);
            this.verify.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.verify.Name = "verify";
            this.verify.Size = new System.Drawing.Size(95, 39);
            this.verify.TabIndex = 20;
            this.verify.Text = "Verify";
            this.verify.UseVisualStyleBackColor = false;
            this.verify.Click += new System.EventHandler(this.verify_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(133, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // back
            // 
            this.back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("back.BackgroundImage")));
            this.back.FlatAppearance.BorderSize = 0;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Location = new System.Drawing.Point(341, 9);
            this.back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(40, 37);
            this.back.TabIndex = 22;
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // Forgot_password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(436, 430);
            this.Controls.Add(this.back);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.verify);
            this.Controls.Add(this.enter_code);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.send);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Phone_number);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Forgot_password";
            this.Text = "Enter code";
            this.Load += new System.EventHandler(this.Forgot_password_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouse_down);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouse_move);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox Phone_number;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox enter_code;
        private System.Windows.Forms.Button verify;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button back;
    }
}