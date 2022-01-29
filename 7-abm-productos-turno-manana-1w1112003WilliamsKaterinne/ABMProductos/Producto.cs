using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABMProductos
{
    class Producto
    {
        int codigo;

        public int pCodigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        string detalle;

        public string pDetalle
        {
            get { return detalle; }
            set { detalle = value; }
        }
        double precio;

        public double pPrecio
        {
            get { return precio; }
            set { precio = value; }
        }
        int tipo;

        public int pTipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        int marca;

        public int pMarca
        {
            get { return marca; }
            set { marca = value; }
        }
        DateTime fecha;

        public DateTime pFecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        override public string ToString() //Acá es override porque trabaja sobre el ToString()
        {
            return codigo + " - " + detalle;
        }
      
    }
}
