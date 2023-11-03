using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_finanzas.data.DTOs
{
    public class ObjectResponseDTO<T>
    {
        public T Data {  get; set; }
        public ObjectResponseDTO(T data) { 
            Data = data;
        }
    }
}
