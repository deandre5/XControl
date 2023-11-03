using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_finanzas.data.DTOs
{
    public class ListResponseDTO<T>
    {
        public List<T> Data { get; set; }

        public ListResponseDTO(List<T> data)
        {
            Data = data;
        }
    }
}
