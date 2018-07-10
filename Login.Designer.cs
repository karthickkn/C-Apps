namespace Learn2Prog
{
    partial class UserValidation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserValidation));
            this.LoginLbl = new System.Windows.Forms.Label();
            this.Learn2ProgLbl = new System.Windows.Forms.Label();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.UnameTxtBx = new System.Windows.Forms.TextBox();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.PasswordTxtBx = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.toolTipLogin = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // LoginLbl
            // 
            this.LoginLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LoginLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LoginLbl.Location = new System.Drawing.Point(571, 245);
            this.LoginLbl.Name = "LoginLbl";
            this.LoginLbl.Size = new System.Drawing.Size(150, 40);
            this.LoginLbl.TabIndex = 0;
            this.LoginLbl.Text = "Log in!";
            // 
            // Learn2ProgLbl
            // 
            this.Learn2ProgLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Learn2ProgLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Learn2ProgLbl.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Learn2ProgLbl.Location = new System.Drawing.Point(573, 189);
            this.Learn2ProgLbl.Name = "Learn2ProgLbl";
            this.Learn2ProgLbl.Size = new System.Drawing.Size(232, 33);
            this.Learn2ProgLbl.TabIndex = 1;
            this.Learn2ProgLbl.Text = "Learn2Prog.Ltd";
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.UsernameLbl.Location = new System.Drawing.Point(575, 294);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(98, 20);
            this.UsernameLbl.TabIndex = 0;
            this.UsernameLbl.Text = "USERNAME";
            // 
            // UnameTxtBx
            // 
            this.UnameTxtBx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UnameTxtBx.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnameTxtBx.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UnameTxtBx.Location = new System.Drawing.Point(578, 317);
            this.UnameTxtBx.Name = "UnameTxtBx";
            this.UnameTxtBx.Size = new System.Drawing.Size(193, 21);
            this.UnameTxtBx.TabIndex = 1;
            this.UnameTxtBx.Text = "Ex.John";
            this.UnameTxtBx.Click += new System.EventHandler(this.UnameTxtBx_Click);
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PasswordLbl.Location = new System.Drawing.Point(575, 367);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(103, 20);
            this.PasswordLbl.TabIndex = 4;
            this.PasswordLbl.Text = "PASSWORD";
            // 
            // PasswordTxtBx
            // 
            this.PasswordTxtBx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTxtBx.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTxtBx.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.PasswordTxtBx.Location = new System.Drawing.Point(578, 390);
            this.PasswordTxtBx.Name = "PasswordTxtBx";
            this.PasswordTxtBx.Size = new System.Drawing.Size(193, 21);
            this.PasswordTxtBx.TabIndex = 2;
            this.PasswordTxtBx.UseSystemPasswordChar = true;
            this.PasswordTxtBx.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PasswordTxtBx_MouseClick);
            this.PasswordTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTxtBx_KeyDown);
            // 
            // loginBtn
            // 
            this.loginBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginBtn.BackColor = System.Drawing.Color.OliveDrab;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginBtn.Location = new System.Drawing.Point(578, 450);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(84, 36);
            this.loginBtn.TabIndex = 1;
            this.loginBtn.Text = "&Login";
            this.toolTipLogin.SetToolTip(this.loginBtn, "Click to Login");
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // UserValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.PasswordTxtBx);
            this.Controls.Add(this.PasswordLbl);
            this.Controls.Add(this.UnameTxtBx);
            this.Controls.Add(this.UsernameLbl);
            this.Controls.Add(this.Learn2ProgLbl);
            this.Controls.Add(this.LoginLbl);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserValidation";
            this.Text = "Learn2Prog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginLbl;
        private System.Windows.Forms.Label Learn2ProgLbl;
        private System.Windows.Forms.Label UsernameLbl;
        private System.Windows.Forms.TextBox UnameTxtBx;
        private System.Windows.Forms.Label PasswordLbl;
        private System.Windows.Forms.TextBox PasswordTxtBx;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.ToolTip toolTipLogin;
    }
}

