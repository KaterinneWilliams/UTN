using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicio_5_prog2
{
    public partial class frmProductos : Form
    {
        const int pro = 10;
        string[] aNombre = new string[pro];
        double[] aPrecio = new double[pro];
        double[] aCantidad = new double[pro];
        double[] aTotalProducto = new double[pro];

        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            aNombre[0] = "Heladera";
            aNombre[1] = "Lavarropas";
            aNombre[2] = "Microhondas";
            aNombre[3] = "Cocina";
            aNombre[4] = "Horno Helectrico";
            aNombre[5] = "Licuadora";
            aNombre[6] = "Tostadora";
            aNombre[7] = "Sanguchera";
            aNombre[8] = "Televisor";
            aNombre[9] = "Computadora";

            aPrecio[0] = 40500;
            aPrecio[1] = 30000;
            aPrecio[2] = 21200;
            aPrecio[3] = 38000;
            aPrecio[4] = 10000;
            aPrecio[5] = 8000;
            aPrecio[6] = 3000;
            aPrecio[7] = 1500;
            aPrecio[8] = 48000;
            aPrecio[9] = 80500;

            aCantidad[0] = 6;
            aCantidad[1] = 3;
            aCantidad[2] = 4;
            aCantidad[3] = 2;
            aCantidad[4] = 5;
            aCantidad[5] = 3;
            aCantidad[6] = 7;
            aCantidad[7] = 10;
            aCantidad[8] = 12;
            aCantidad[9] = 8;

            for(int i=0; i< pro; i++)
            {
                lstNombre.Items.Add(aNombre[i]);
                lstPrecio.Items.Add(aPrecio[i]);
                lstCantidad.Items.Add(aCantidad[i]);
            }
        }

        private void btnPrecioProducto_Click(object sender, EventArgs e)
        {
            double total = 0;
            lstTotalProducto.Items.Clear();
            for(int i=0; i< pro; i++)
            {
                aTotalProducto[i] = aPrecio[i] * aCantidad[i];
                lstTotalProducto.Items.Add(Math.Round(aTotalProducto[i],2));
                total += aTotalProducto[i];
            }
            txtTotal.Text = total.ToString("0.00");
        }
    }
}
