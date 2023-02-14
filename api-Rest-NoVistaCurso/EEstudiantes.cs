namespace api_Rest_NoVistaCurso
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EEstudiantes
    {
        [Key]
        public int IdEstudiante { get; set; }

        [Required]
        [StringLength(128)]
        public string Matricula { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(16)]
        public string Telefono { get; set; }

        [Required]
        public string Direccion { get; set; }
    }
}
