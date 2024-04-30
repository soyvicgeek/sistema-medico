using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Modelos
{
    public class Area
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Descripción es Requerido")]
        [MaxLength(60, ErrorMessage = "La Descripción sólo se compone de 60 Caracteres como Máximo")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Campo Turno es Requerido")]
        [MaxLength(60, ErrorMessage = "El Turno sólo se compone de 60 Caracteres como Máximo")]
        public string Turno { get; set; }
    }
}
