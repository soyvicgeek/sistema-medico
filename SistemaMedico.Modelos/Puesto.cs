using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Modelos
{
    public class Puesto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Requerido")]
        [MaxLength(60, ErrorMessage = "El Nombre sólo se compone de 60 Caracteres como Máximo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Tipo es Requerido")]
        [MaxLength(60, ErrorMessage = "El Tipo sólo se compone de 60 Caracteres como Máximo")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "El Campo Salario es Requerido")]
        [MaxLength(60, ErrorMessage = "El Tipo sólo se compone de 60 Caracteres como Máximo")]
        public string Salario { get; set; }
        [Required(ErrorMessage = "El Campo Horario es Requerido")]
        [MaxLength(60, ErrorMessage = "El Tipo sólo se compone de 60 Caracteres como Máximo")]
        public string Horario { get; set; }
    }
}
