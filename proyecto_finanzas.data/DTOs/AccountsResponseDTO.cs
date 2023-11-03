using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_finanzas.data.DTOs
{
    public class AccountsResponseDTO
    {
        public string Nombre { get; set; }
        public string Saldo { get; set; }
        public string Moneda { get; set; }
        public int Id { get; set; }
        

        public AccountsResponseDTO(string nombre, string saldo, string moneda, int id) {
            Nombre = nombre;
            Saldo = saldo;
            Moneda = moneda;
            Id = id;
        }

    }
}
