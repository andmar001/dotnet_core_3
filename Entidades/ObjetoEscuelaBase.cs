using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    public class ObjetoEscuelaBase
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
        
    }
}