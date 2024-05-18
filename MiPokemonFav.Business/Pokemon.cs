
using System.Collections.Generic;
 
namespace Pokemon.Business.Service
{
    public class Pokemon
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string URl { get; set; }
        public List<string> Movimientos { get; set; }
    }
}

