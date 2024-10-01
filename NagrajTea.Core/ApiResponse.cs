using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagrajTea.Core
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public bool Success => Errors.Count == 0;
        public string Message { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; }
        public ApiResponse()
        {
            Errors = new List<string>();
        }
    }
}
