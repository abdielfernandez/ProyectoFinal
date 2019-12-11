using AbdielClub.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AbdielClub.Models
{
    public class Socio
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellidos { get; set; }
        [Key]
        [Required(ErrorMessage = "La Cedula es obligatoria")]
        public string Cedula { get; set; }

        public byte[] Foto { get; set; }

        [Required(ErrorMessage = "La direccion es obligatoria")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El fax es obligatorio")]

        public string Fax { get; set; }

        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]

        public int Edad { get; set; }

        public Afiliados Afiliados { get; set; }

        [Display(Name = "Tipo de membresia")]
        public Membresias Tipo_Membresia { get; set; }

        
        [Required(ErrorMessage = "La direccion de trabajo es obligatoria")]
        [Display(Name = "Direccion de trabajo")]
        public string Lugar_Trabajo { get; set; }

        [Required(ErrorMessage ="La direccion de oficina es obligatoria")]
        [Display(Name ="Direccion de oficina")]
        public string Direccion_Oficina { get; set; }

        [Required(ErrorMessage ="El telefono de oficina es obligatoria")]
        [Display(Name = "Telefono de oficina")]
        public string Telefono_Oficina { get; set; }

        public Estados Estado { get; set; }

    
    }
}