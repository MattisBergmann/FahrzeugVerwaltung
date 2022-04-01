using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// Interface for Classes that have a dialog result
    /// </summary>
    public interface IDialogResultable : IClosable
    {
        public bool? DialogResult { get; set; }
    }
}
