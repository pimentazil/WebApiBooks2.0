using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiBooks.Application.Model
{
    public class LivroRequest
    {
        public string titulo { get; set; }
        public string autor { get; set; }
        public decimal preco { get; set; }
        public DateTime dataLancamento { get; set; }
    }
}
