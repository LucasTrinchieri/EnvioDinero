using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public sealed class Servicio
    {
        private static readonly Servicio _instance = new Servicio();

        private Servicio() { }

        private static Servicio Instance { get { return _instance; } }

        List<Usuario> usuarios = new List<Usuario>();

        private static int Identificador { get; set; }

        private int AumentarContador()
        {
            return Identificador + 1;
        }

        public string RealizarMovimiento(int dniEmisor, int dniReceptor, string descripcion, decimal monto)
        {
            if(Validacion(dniEmisor, dniReceptor, monto) == null)
            {
                int id = AumentarContador();

                CrearMovimiento(dniEmisor, id, true, descripcion, monto);
                CrearMovimiento(dniReceptor, id, false, descripcion, monto);

                return "201";
            }

            throw new Exception($" 400: Error en la validacion {Validacion(dniEmisor, dniReceptor, monto)}");
        }

        public void CrearMovimiento(int dni, int id, bool esEmisor, string des, decimal monto)
        {
            BuscarUsuario(dni).AgregarMovimiento(new Movimiento(id, des, monto, esEmisor));
        }

        public string Validacion(int dniEmisor, int dniReceptor, decimal monto)
        {
            if (BuscarUsuario(dniEmisor) != null)
            {
                return new RetornarError(Error.NoExisteEmisor).ToString();
            }
                
            if (BuscarUsuario(dniReceptor) != null)
            {
                return new RetornarError(Error.NoExisteReceptor).ToString();
            }
            if (BuscarUsuario(dniEmisor).Saldo >= monto)
            {
                return new RetornarError(Error.NoExisteSaldo).ToString();
            }

            return null;
        }

        public void EliminarMovimiento(int id)
        {
            int identidicador = AumentarContador();

            foreach (var item in usuarios)
            {
                if(BuscarMovimiento(item.Historial, id) != null)
                {
                    item.AgregarMovimiento(new Movimiento(identidicador,
                                                          $" Cancelacion: {BuscarMovimiento(item.Historial, id).Descripcion}",
                                                          BuscarMovimiento(item.Historial, id).Monto * -1,
                                                          !BuscarMovimiento(item.Historial, id).EsEmisor));

                }
            }
        }

        public List<Movimiento> RetornarMovimientos()
        {
            return null;
        }

        public Usuario BuscarUsuario(int dni)
        {
            return usuarios.FirstOrDefault(x => x.Dni >= dni);
        }

        public Movimiento BuscarMovimiento(List<Movimiento> lista, int id)
        {
            return lista.FirstOrDefault(x => x.Id == id);
        }
    }
}
