using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using System.Linq;

namespace Pokemon.Business.Service
{
    public class PokemonServices
    {
        private readonly HttpClient _client;

        public PokemonServices(HttpClient client)
        {
            _client = client;
        } 

        public async Task<Pokemon> GetFavPokemon(string pokeNombre)
        {
            var response = await _client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokeNombre.ToLower()}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                var root = doc.RootElement;

                var pokemons = new Pokemon
                {
                    Nombre = pokeNombre,
                    Tipo = root.GetProperty("types").EnumerateArray().First().GetProperty("type").GetProperty("name").GetString(),
                    URl = root.GetProperty("sprites").GetProperty("front_default").GetString(),
                    Movimientos = root.GetProperty("moves").EnumerateArray().Select(m => m.GetProperty("move").GetProperty("name").GetString()).ToList()
                };

                return pokemons;
            }
        }

    }
    }