using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CD_Venta
    {
        public int RegistrarVenta(Venta venta)
        {
            using (var contexto = new BDProyectoMVCEntities())
            {
                var ventaCreada = contexto.Venta.Add(venta);
                var result = contexto.SaveChanges();
                return result;
            }
        }

        public int GetNextFolio()
        {
            using (var contexto = new BDProyectoMVCEntities())
            {
                int nextFolio;
                if (contexto.Venta.Count() >= 1)
                {
                    nextFolio = contexto.Venta.Max(u => u.idVenta);
                }
                else
                {
                    nextFolio = 1;
                }               
                return nextFolio;
            }
        }

    }
}
