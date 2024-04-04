using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiBooks.Application.Model
{
    public class LoginResponse
    {
        public string token { get; set; }
        public int codigo { get; set; }
        public string nome { get; set; }

        public int tipo { get; set; }

        public int unidade { get; set; }
    }
}
