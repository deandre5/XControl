using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_finanzas.data.DTOs
{
    public class ExpensesIncome
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public long Monto { get; set; }
        [Required]
        public int Tipo { get; set; }
        [Required]
        public int IdCuenta { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int CategoriaId { get; set;}

        public ExpensesIncome(string nombre, long monto, int tipo, int idCuenta, DateTime fecha, int categoriaId, int id = 0) 
        { 
            Nombre = nombre;
            Id = id;
            Monto = monto;
            Tipo = tipo;
            IdCuenta = idCuenta;
            Fecha = fecha;
            CategoriaId = categoriaId;
        }
    }
}
