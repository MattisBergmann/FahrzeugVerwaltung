using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.UI
{
    public class User
    {
        public string Name { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public bool Created { get; set; } = false;
        public bool Keep { get; set; }
    }
}
