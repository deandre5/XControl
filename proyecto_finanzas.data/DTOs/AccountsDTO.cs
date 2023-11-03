using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_finanzas.data.DTOs
{
    public class AccountsDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public long Saldo { get; set; }
        [Required]
        public int MonedaId { get; set; }
        public int Id { get; set; }
        [Required]
        public int IdUser { get; set; }

        public AccountsDTO(string nombre, long saldo, int monedaId, int id, int idUser) 
        {
            Nombre = nombre;
            Saldo = saldo;
            MonedaId = monedaId;
            Id = id;
            IdUser = idUser;

        }
    }
}
