using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RetornarError
    {
        public Error tipoError { get; set; }

        public RetornarError() { }

        public RetornarError(Error error)
        {
            tipoError = error;
        }
    }

    public enum Error
    {
        NoExisteEmisor,
        NoExisteReceptor,
        NoExisteSaldo,
        NoExisteLaLista
    }
}
