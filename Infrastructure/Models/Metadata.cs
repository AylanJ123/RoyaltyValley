using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Models.Metadata;

namespace Infrastructure.Models
{
    [MetadataType(typeof(ResidenciaMTDT))] public partial class Residencia { }
    [MetadataType(typeof(PlanCobroMTDT))] public partial class PlanCobro { }
    [MetadataType(typeof(CobroMTDT))] public partial class Cobro { }
    [MetadataType(typeof(UsuarioMTDT))] public partial class Usuario { }
    [MetadataType(typeof(RubroMTDT))] public partial class Rubro { }
    public static class Metadata
    {
        public class ResidenciaMTDT
        {
            [Display(Name = "No. De Residencia")]
            public int ID { get; set; }
            [Display(Name = "Monto mensual")]
            public decimal montoMensual { get; set; }
            [Display(Name = "Cantidad de inquilinos")]
            public byte cantInquilinos { get; set; }
            [Display(Name = "Espacios en el garaje")]
            public byte espacioGaraje { get; set; }
            [Display(Name = "Habitaciones")]
            public byte habitaciones { get; set; }
            [Display(Name = "Calle")]
            public string calle { get; set; }
            [Display(Name = "Avenida")]
            public string avenida { get; set; }
            [Display(Name = "Descripción")]
            public string descripcion { get; set; }
            [Display(Name = "Fecha de construcción")]
            public DateTime? fechaConst { get; set; }
            [Display(Name = "Estado de construcción")]
            public byte estado { get; set; }
        }
        
        public class PlanCobroMTDT
        {
            [Display(Name = "No. De Plan")]
            public int ID { get; set; }
            [Display(Name = "Nombre")]
            public string nombre { get; set; }
            [Display(Name = "Descripción")]
            public string descripcion { get; set; }
            [Display(Name = "Es aplicado por defecto?")]
            public bool automatico { get; set; }
        }
        
        public class CobroMTDT
        {
            [Display(Name = "Mes de cobro")]
            public System.DateTime fecha { get; set; }
            [Display(Name = "Plan de cobro aplicado")]
            public int IDPlanCobro { get; set; }
            [Display(Name = "Residencia")]
            public int IDResidencia { get; set; }
            [Display(Name = "Monto Total")]
            public decimal total { get; set; }
            [Display(Name = "Está pago?")]
            public bool pagado { get; set; }
            [Display(Name = "Fecha de pago")]
            public DateTime? fechaPago { get; set; }
        }

        public class UsuarioMTDT
        {
            [Display(Name = "ID de Usuario")]
            public int ID { get; set; }
            [Display(Name = "Nombre")]
            public string nombre { get; set; }
            [Display(Name = "Primer apellido")]
            public string apellido1 { get; set; }
            [Display(Name = "Segundo apellido")]
            public string apellido2 { get; set; }
            [Display(Name = "Teléfono")]
            public string telefono { get; set; }
            [Display(Name = "Correo electrónico")]
            public string correo { get; set; }
            [Display(Name = "Cédula")]
            public string cedula { get; set; }
            [Display(Name = "Tipo de usuario")]
            public byte tipo { get; set; }
        }

        public class RubroMTDT
        {
            [Display(Name = "No. De Rubro")]
            public int ID { get; set; }
            [Display(Name = "Monto")]
            public decimal monto { get; set; }
            [Display(Name = "Es porcentual?")]
            public bool porcentual { get; set; }
            [Display(Name = "Motivo de cobro")]
            public string motivo { get; set; }
        }

    }
}
