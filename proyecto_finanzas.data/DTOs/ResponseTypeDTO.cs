using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_finanzas.data.DTOs
{
    public class ResponseTypeDTO
    {
            public string Message { get; set; }
            public int Status { get; set; }
            public int Code { get; set; }

        public ResponseTypeDTO(string message, int status, int code) {
            Message = message;
            Status = status;
            Code = code;
        }
    }
}
