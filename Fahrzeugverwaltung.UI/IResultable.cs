using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.UI
{
    public interface IResultable : IClosable
    {
        // public void Result(bool? accepted);
        public bool? DialogResult { get; set; }
    }
}
