using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;


namespace Repository.Data
{
    public class FacturaModel
    {
        public int id { get; set; }
        public int id_cliente { get; set; }

        [RegularExpression(@"^\d{3}-\d{3}-\d{6}$", ErrorMessage = "El número de factura debe tener el formato XXX-XXX-XXXXXX.")]
        public string NumeroFactura { get; set; }
        public DateTime fecha_hora { get; set; }
        [Required(ErrorMessage = "El campo Total es obligatorio.")]
        public decimal Total { get; set; }
        [Required(ErrorMessage = "El campo Total_Iva5 es obligatorio.")]
        public decimal TotalIva5 { get; set; }
        [Required(ErrorMessage = "El campo Total_Iva10 es obligatorio.")]
        public decimal TotalIva10 { get; set; }
        public double total_iva { get; set; }
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El campo TotalEnLetras debe tener como mínimo 6 caracteres.")]
        [Required(ErrorMessage = "El campo TotalEnLetras es obligatorio.")]
        public string TotalEnLetras { get; set; }
        public string sucursal { get; set; }
    }
}
