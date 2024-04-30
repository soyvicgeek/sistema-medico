using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Modelos
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Requerido")]
        [MaxLength(60, ErrorMessage = "El Nombre sólo se compone de 60 Caracteres como Máximo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Apellido Paterno es Requerido")]
        [MaxLength(60, ErrorMessage = "El Apellido Paterno sólo se compone de 60 Caracteres como Máximo")]
        public string APaterno { get; set; }
        [Required(ErrorMessage = "El Campo Apellido Materno es Requerido")]
        [MaxLength(60, ErrorMessage = "El Apellido Paterno sólo se compone de 60 Caracteres como Máximo")]
        public string AMaterno { get; set; }
        [Required(ErrorMessage = "El Campo Direccion es Requerido")]
        [MaxLength(60, ErrorMessage = "El Campo Dirección sólo se compone de 60 Caracteres como Máximo")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El Campo Teléfono es Requerido")]
        [MaxLength(20, ErrorMessage = "El Teléfono sólo se compone de 20 Caracteres como Máximo")]
        public string Telefono { get; set; }

        //Hagamos la relación con la tabla area
        [Required(ErrorMessage = "La area es requerida")]
        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public Area Area { get; set; }

        //Hagamos la relación en la tabla Puesto
        [Required(ErrorMessage = "El Puesto es Requerido")]
        public int PuestoId { get; set; }
        [ForeignKey("PuestoId")]
        public Puesto Puesto { get; set; }
    }
}
