using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dia3_aspNetIntroducao.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }
}