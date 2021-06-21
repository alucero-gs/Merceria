using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerceriaGit.Models
{
    public class PedidoCliente
    {
        private contextTienda db = new contextTienda();
        private List<Ventas> detalle_orden;

        public PedidoCliente()
        {
            detalle_orden = db.Ventas.ToList();
        }

        public Ventas Orden
        {
            get;
            set;
        }

        public string fecha
        {
            get;
            set;
        }

        public string envio
        {
            get;
            set;
        }
        public string status
        {
            get;
            set;
        }
        public string total
        {
            get;
            set;
        }

        public List<Ventas> ordenProductos
        {
            get;
            set;
        }
    }
}