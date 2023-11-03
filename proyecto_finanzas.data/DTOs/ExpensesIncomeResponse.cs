using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_finanzas.data.DTOs
{
    public class ExpensesIncomeResponse
    {
        public string Nombre { get; set; }
        public string Monto { get; set; }
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int TipoId {  get; set; }
        public int IdCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Categoria {  get; set; }
        public int CategoriaId { get; set; }
        public ExpensesIncomeResponse(string nombre, string monto, int id, string tipo, int tipoId, int idCuenta, DateTime fecha, string categoria, int categoriaId) 
        { 
            Nombre = nombre;
            Monto = monto;
            Id = id;
            Tipo = tipo;
            TipoId = tipoId;
            IdCuenta = idCuenta;
            Fecha = fecha;
            Categoria = categoria;
            CategoriaId = categoriaId;
        }
    }
}
