using System;
using System.Net.Http;
using System.Text.Json;
using System.Drawing;  // Necessário para Image
using System.Threading.Tasks;

namespace quiz_pokemon
{
    public class ApiPokemon
    {
        private static readonly HttpClient client = new HttpClient() {
            DefaultRequestHeaders =
            {
                { "User-Agent", "quizPokemonApp/1.0" }
            }
        };

        private static readonly Random random = new Random(); // Instância única de Random

        public async Task<Pokemon> GetRandomPokemonAsync()
        {
            int id = random.Next(1, 152); // Apenas Pokémon da 1ª geração (1 a 151)
            try {
                var response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}/");
                if(response.StatusCode == System.Net.HttpStatusCode.TooManyRequests){
                    await Task.Delay(2000); // Espera 2 segundo antes de tentar novamente
                    return null; // Tenta novamente
                }
                response.EnsureSuccessStatusCode(); // Lança exceção se o status não for 200 

                var json = await response.Content.ReadAsStringAsync();
                var pokemon = JsonSerializer.Deserialize<Pokemon>(json);

                return pokemon;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter Pokémon: {ex.Message}");
                return null;
            }
        }

        public async Task<Image> DownloadImageAsync(string url)
        {
            try {
                var stream = await client.GetStreamAsync(url);
                return Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao baixar imagem: {ex.Message}");
                return null;
            }
        }
    } 
}

