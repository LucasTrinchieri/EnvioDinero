using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get { return EsEmisor ? Monto * -1 : Monto; } set { Monto = value; } }
        public bool EsEmisor { get; set; }

        public Movimiento()
        {

        }

        public Movimiento(int id, string descripcion, decimal monto, bool esEmisor)
        {
            Id = id;
            Fecha = DateTime.Now;
            Descripcion = descripcion;
            Monto = monto;
            EsEmisor = esEmior;
        }
    }
}
