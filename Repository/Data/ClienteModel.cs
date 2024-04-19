using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Repository.Data
{
    public class ClienteModel
    {
        public int id { get; set; }
        public int id_banco { get; set; }
        
        [Required]
        [StringLength (100, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Celular { get; set; }
        public string Estado { get; set; }

    }
}
