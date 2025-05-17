using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Drawing.Imaging;
using Google.Protobuf.WellKnownTypes;
namespace quiz_pokemon
{
    public partial class quizPokemon : Form
    {
        private ApiPokemon apiPokemon = new ApiPokemon();
        private Pokemon currentPokemon;
        private string nomeUsuario;
        public quizPokemon(string nomeUsuario)
        {
            InitializeComponent();
            LoadPokemon();
            this.nomeUsuario = nomeUsuario;


        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;


        private Image MakeSilhouette(Image original)
        {
            Bitmap bmp = new Bitmap(original.Width, original.Height);
            Bitmap originalBitmap = new Bitmap(original);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixel = originalBitmap.GetPixel(x, y);

                    // Se o pixel for transparente, mantém transparente
                    if (pixel.A < 128)
                    {
                        bmp.SetPixel(x, y, Color.Transparent);
                    }
                    else
                    {
                        // Se for visível, pinta de preto
                        bmp.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return bmp;
        }

        private ImageAttributes GetBlackAttributes()
        {
            var matrix = new ColorMatrix(new float[][]
            {
                new float[] {0, 0, 0, 0, 0},
                new float[] {0, 0, 0, 0, 0},
                new float[] {0, 0, 0, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            });

            var attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix);
            return attributes;
        }
        private async Task LoadPokemon()
        {
            currentPokemon = await apiPokemon.GetRandomPokemonAsync();

            var image = await apiPokemon.DownloadImageAsync(currentPokemon.sprites.other.officialArtwork.front_default);
            pictureBox4.Image = MakeSilhouette(image);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            lblNomeU.Text = "Ola: "+ nomeUsuario;


            // Reseta os textos
            labelStatus.Text = "Quem é esse Pokémon?";
            lbltipo1.Text = "";
            lblTipo2.Text = "";
            lblAltura.Text = "";
            lblPeso.Text = "";
            txtNome.Text = ""; ;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            string resposta = txtNome.Text.Trim().ToLower();

            if (resposta == currentPokemon.name.ToLower())
            {
                labelStatus.Text = "Você acertou!";
                labelStatus.ForeColor = Color.Green;

                // Mostra a imagem colorida
                pictureBox4.Image = await apiPokemon.DownloadImageAsync(currentPokemon.sprites.other.officialArtwork.front_default);
                pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;


                // Mostra os tipos
                lbltipo1.Text = currentPokemon.types.Count > 0 ? currentPokemon.types[0].type.name : "";
                lblTipo2.Text = currentPokemon.types.Count > 1 ? currentPokemon.types[1].type.name : "";

                // Mostra altura e peso
                lblAltura.Text = $"{currentPokemon.height / 10.0} m";
                lblPeso.Text = $"{currentPokemon.weight / 10.0} kg";
            }
            else
            {
                labelStatus.Text = "Você errou! Tente novamente.";
                labelStatus.ForeColor = Color.Red;
                // Dicas mesmo se errar
                lbltipo1.Text = currentPokemon.types.Count > 0 ? currentPokemon.types[0].type.name : "";
                lblTipo2.Text = currentPokemon.types.Count > 1 ? currentPokemon.types[1].type.name : "";

                lblAltura.Text = $"{currentPokemon.height / 10.0} m";
                lblPeso.Text = $"{currentPokemon.weight / 10.0} kg";
            }

            txtNome.Text = "";
        }

        private async void btnRecomeçar_Click(object sender, EventArgs e)
        {
            btnRecomeçar.Enabled = false; // Impede múltiplos cliques

            labelStatus.Text = "Carregando Pokémon...";
            lbltipo1.Text = "";
            lblTipo2.Text = "";
            lblAltura.Text = "";
            lblPeso.Text = "";
            txtNome.Text = "";

            var pokemon = await apiPokemon.GetRandomPokemonAsync();

            if (pokemon == null)
            {
                MessageBox.Show("Não foi possível carregar o Pokémon. Aguarde um pouco e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                labelStatus.Text = "Erro ao carregar Pokémon.";
            }
            else
            {
                await LoadPokemon();

                // Limpa todos os labels e status
                labelStatus.Text = "Quem é esse Pokémon?";
                lbltipo1.Text = "";
                lblTipo2.Text = "";
                lblAltura.Text = "";
                lblPeso.Text = "";
                txtNome.Text = "";
            }
            btnRecomeçar.Enabled = true; // Habilita novamente o botão
        }
    }
}
