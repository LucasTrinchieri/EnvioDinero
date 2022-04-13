using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public decimal Saldo { get; set; }
        public List<Movimiento> Historial { get; set; }

        public void AgregarMovimiento(Movimiento movimiento)
        {
            Historial.Add(movimiento);

            Saldo += movimiento.Monto;
        }
    }
}
