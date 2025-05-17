namespace quiz_pokemon
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            txtEmail = new TextBox();
            btnLogin = new Button();
            button2 = new Button();
            txtSenha = new TextBox();
            pictureBox4 = new PictureBox();
            panel2 = new Panel();
            linklblEsqueceu = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DeepSkyBlue;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1132, 41);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(403, 0);
            label1.Name = "label1";
            label1.Size = new Size(183, 29);
            label1.TabIndex = 10;
            label1.Text = "L    O    G    I    N";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(960, 219);
            button1.Name = "button1";
            button1.Size = new Size(195, 34);
            button1.TabIndex = 9;
            button1.Text = "cadastre-se";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.icons8_linha_horizontal_24;
            pictureBox3.Location = new Point(1054, 5);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(24, 24);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icons8_excluir_24__1_;
            pictureBox2.Location = new Point(1084, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 24);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-32, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(119, 43);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.DeepSkyBlue;
            label2.Location = new Point(619, 181);
            label2.Name = "label2";
            label2.Size = new Size(57, 18);
            label2.TabIndex = 2;
            label2.Text = "E-mail:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.DeepSkyBlue;
            label3.Location = new Point(619, 262);
            label3.Name = "label3";
            label3.Size = new Size(57, 18);
            label3.TabIndex = 3;
            label3.Text = "Senha:";
            label3.Click += label3_Click;
            // 
            // txtEmail
            // 
            txtEmail.Cursor = Cursors.IBeam;
            txtEmail.Location = new Point(732, 178);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Example@example.com";
            txtEmail.Size = new Size(303, 26);
            txtEmail.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DeepSkyBlue;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.ForeColor = Color.Yellow;
            btnLogin.Location = new Point(657, 332);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(134, 44);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DeepSkyBlue;
            button2.Cursor = Cursors.Hand;
            button2.ForeColor = Color.Yellow;
            button2.Location = new Point(843, 332);
            button2.Name = "button2";
            button2.Size = new Size(165, 44);
            button2.TabIndex = 4;
            button2.Text = "Cadastro";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(732, 259);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(303, 26);
            txtSenha.TabIndex = 2;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(71, 87);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(525, 334);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(linklblEsqueceu);
            panel2.Controls.Add(txtSenha);
            panel2.Controls.Add(pictureBox4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnLogin);
            panel2.Controls.Add(button2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1132, 486);
            panel2.TabIndex = 6;
            // 
            // linklblEsqueceu
            // 
            linklblEsqueceu.ActiveLinkColor = Color.Yellow;
            linklblEsqueceu.AutoSize = true;
            linklblEsqueceu.LinkColor = Color.DeepSkyBlue;
            linklblEsqueceu.Location = new Point(732, 394);
            linklblEsqueceu.Name = "linklblEsqueceu";
            linklblEsqueceu.Size = new Size(124, 18);
            linklblEsqueceu.TabIndex = 6;
            linklblEsqueceu.TabStop = true;
            linklblEsqueceu.Text = "Esqueci a senha";
            linklblEsqueceu.LinkClicked += linklblEsqueceu_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 486);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Label lblNome;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox txtEmail;
        private Button btnLogin;
        private Button button1;
        private Label label1;
        private Button button2;
        private TextBox txtSenha;
        private PictureBox pictureBox4;
        private Panel panel2;
        private LinkLabel linklblEsqueceu;
    }
}