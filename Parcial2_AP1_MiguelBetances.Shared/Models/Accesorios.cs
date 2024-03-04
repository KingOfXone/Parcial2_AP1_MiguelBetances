using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_AP1_MiguelBetances.Shared.Models
{
    public class Accesorios
    {
        [Key]
        public int AccesorioId { get; set; }

        [Required(ErrorMessage = "Descripción Requerida")]

        public string? Descripción { get; set; }
    }
}
