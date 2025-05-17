using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace quiz_pokemon
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
            this.Hide();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text;

            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool logado = usuarios.LogarUsuario(email, senha);

            if (logado)
            {
                string nomeUsuario = usuarios.ObterNomeDoUsuario(email);
                MessageBox.Show("Login realizado com sucesso!Bem vido,"+ nomeUsuario, "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Abre a tela principal, por exemplo:
                quizPokemon menu = new quizPokemon(nomeUsuario);
                menu.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("E-mail ou senha incorretos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                txtSenha.Focus();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void linklblEsqueceu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Esqueci_senha esqueciSenha = new Esqueci_senha();
            esqueciSenha.Show();
            this.Hide();
        }
    }
}
