﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_AP1_MiguelBetances.Shared.Models
{
    public class Vehiculos
    {
        [Key]
        public int VehiculoId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Ingrese una descripción")]
        public string? Descripción { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El Costo debe ser mayor que cero.")]
        public decimal Costo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El Gasto debe ser mayor que cero.")]
        public decimal Gastos { get; set; }

        [ForeignKey("VehiculoId")]
        public ICollection<VehiculosDetalle> vehiculosDetalle { get; set; } = new List<VehiculosDetalle>();
    }
}
