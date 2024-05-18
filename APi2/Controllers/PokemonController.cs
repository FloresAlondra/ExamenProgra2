using Microsoft.AspNetCore.Mvc;
using Pokemon.Business.Service;

namespace Pokemon.API.Controllers
{
    [ApiController]
    [Route("Mis_[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonServices _pokeServices;

        public PokemonController(PokemonServices pokeServices)
        {
            _pokeServices = pokeServices;
        }

        [HttpGet("{Pokemon}")]
        public async Task<ActionResult> GetPokemon(string Pokemon)
        {
            
                var pokemon = await _pokeServices.GetFavPokemon(Pokemon);
                return Ok(pokemon);
            
        }
    }
}
