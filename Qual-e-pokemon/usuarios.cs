using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Security.Cryptography;
using MySql.Data;
using System.Text.RegularExpressions;

namespace quiz_pokemon
{
    internal class usuarios
    {
        private int id;
        private string nome;
        private string email;
        private string senha;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        public static bool verificarEmail(string email)
        {
            string emailValido = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(emailValido);
            return regex.IsMatch(email);
        }
        public static string CriptografarSenha(string senha)
        {
            try
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }

                    return builder.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível criptografar a senha: " + ex.Message, "Erro - Método Criptografar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public void Inserirusuario() {
            try {
                if (!verificarEmail(Email)) {
                    MessageBox.Show("Email inválido. Por favor, insira um email válido.", "Erro - Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string senhacriptrografada = CriptografarSenha(Senha);
                using (MySqlConnection conexao = new ConexaoDB().Conectar())
                {
                    string query = "INSERT INTO usuarios (nome, email, senha) VALUES (@nome, @email, @senha)";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@nome", Nome);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senhacriptrografada);

                    int resultado = cmd.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("Erro ao inserir usuário.");
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao inserir usuário: " + ex.Message);
            }
        }
        public static bool LogarUsuario(string email, string senha)
        {
            try
            {
                using (MySqlConnection conexao = new ConexaoDB().Conectar())
                {
                    string query = "SELECT senha FROM usuarios WHERE email = @Email";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@Email", email);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        string senhaCriptografadaDB = resultado.ToString();
                        string senhaCriptografadaDigitada = CriptografarSenha(senha);

                        return senhaCriptografadaDigitada == senhaCriptografadaDB;
                    }
                    else
                    {
                        // E-mail não encontrado
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao acessar banco de dados: " + ex.Message);
                return false;
            }
        }
        public static bool RedefinirSenha(string email, string novaSenha)
        {
            try
            {
                if (!verificarEmail(email))
                {
                    MessageBox.Show("Email inválido. Por favor, insira um email válido.", "Erro - Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string novaSenhaCriptografada = CriptografarSenha(novaSenha);

                using (MySqlConnection conexao = new ConexaoDB().Conectar())
                {
                    // Verifica se o e-mail existe
                    string verificaQuery = "SELECT COUNT(*) FROM usuarios WHERE email = @Email";
                    MySqlCommand verificaCmd = new MySqlCommand(verificaQuery, conexao);
                    verificaCmd.Parameters.AddWithValue("@Email", email);

                    int count = Convert.ToInt32(verificaCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        MessageBox.Show("E-mail não encontrado.", "Erro - Redefinir Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // Atualiza a senha
                    string updateQuery = "UPDATE usuarios SET senha = @NovaSenha WHERE email = @Email";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conexao);
                    updateCmd.Parameters.AddWithValue("@NovaSenha", novaSenhaCriptografada);
                    updateCmd.Parameters.AddWithValue("@Email", email);

                    int resultado = updateCmd.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        //MessageBox.Show("Senha redefinida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao redefinir a senha.", "Erro - Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message, "Erro - MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static string ObterNomeDoUsuario(string email)
        {
            string nome = null;
            using (MySqlConnection conexao = new ConexaoDB().Conectar())
            {
                string query = "SELECT nome FROM usuarios WHERE email = @Email";
                using (var cmd = new MySqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nome = reader["nome"].ToString();
                        }
                    }
                }

            }
            return nome ?? "Desconhecido";
        }

    }
}
