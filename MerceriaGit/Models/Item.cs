using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerceriaGit.Models
{
    public class Item
    {
        public Productos Product
        {
            get;
            set;
        }

        public int Cantidad
        {
            get;
            set;
        }
    }
}