using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuardiansOfTheGlobeApi.Models
{
    public class Villanomas
    {
        public string NombreVillano { get; set; }
        public int CantidadDePeleas { get; set; }
    }
}
