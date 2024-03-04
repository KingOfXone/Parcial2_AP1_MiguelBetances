using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_AP1_MiguelBetances.Shared.Models
{
    public class VehiculosDetalle
    {
        [Key]
        public int DetalleId { get; set; }


        [Required(ErrorMessage = "Debes de insertar el Id del vehiculo")]
        public int VehiculosId { get; set; }


        [Required(ErrorMessage = "Debes de insertar el Id del accesorio")]
        public int AccesorrioId { get; set; }


        [Required(ErrorMessage = "Debes de insertar un valor")]
        public decimal Valor { get; set; }
    }
}
