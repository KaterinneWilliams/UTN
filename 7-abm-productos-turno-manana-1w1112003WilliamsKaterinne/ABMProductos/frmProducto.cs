using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ABMProductos
{
    public partial class frmProducto : Form
    {
        Datos oDato = new Datos();
        const int tam = 15;
        Producto[] aProductos = new Producto[tam];
        int c;
        string consultaSQL;
        bool nuevo = false;
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            mostrarLista();
            cargarCombo(cboMarca, "marca", "id_tipo_marca", "n_tipo_marca");
            habilitarTxt(false);
        }

        //método mostrar Lista
        private void mostrarLista()
        {
            lstProducto.Items.Clear();
            oDato.leerTabla("Producto");

            c = 0;

            while(oDato.pLector.Read())
            {
                //instancio un producto DENTRO DEL WHILE
                Producto p = new Producto();
                if (!oDato.pLector.IsDBNull(0))
                {
                    p.pCodigo = Convert.ToInt32(oDato.pLector["codigo"]);
                }
                if (!oDato.pLector.IsDBNull(1))
                {
                    p.pDetalle = oDato.pLector.GetString(1);
                }
                if (!oDato.pLector.IsDBNull(2))
                {
                    p.pTipo = oDato.pLector.GetInt32(2);
                }
                if (!oDato.pLector.IsDBNull(3))
                {
                    p.pMarca = (int)oDato.pLector["marca"];
                }
                if (!oDato.pLector.IsDBNull(4))
                {
                    p.pPrecio = Convert.ToDouble(oDato.pLector["precio"]);
                }
                if (!oDato.pLector.IsDBNull(5))
                {
                    p.pFecha = oDato.pLector.GetDateTime(5);
                }

                //cargo mi arreglo
                aProductos[c] = p;
                c++;
            }

            oDato.pLector.Close();
            oDato.desconectar();

            for (int i = 0; i < c; i++)
            {
                lstProducto.Items.Add(aProductos[i].ToString()); //acá le digo qué quiero que me muestre
                //Recordar que lo que agrego a mis listas debe ser string
            }
        }

        //mostrarCombos
        private void cargarCombo(ComboBox combo, string nombreTabla, string pk, string display)
        {
            DataTable  tabla = new DataTable();
            tabla = oDato.cargarTabla(nombreTabla); 
            combo.DataSource = tabla;
            combo.DisplayMember = display; //nombre del campo que quiero visualizar entre ""
            combo.ValueMember = pk; //lo que toma valor es el value member. Quiero que recupere los id

        }
        //evento cuando se cambia el item seleccionado
        private void lstProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTxt(lstProducto.SelectedIndex);
            habilitarTxt(false);
        }
        //método para que me muestre los datos del producto seleccionado en los txt
        private void cargarTxt(int i) //le paso por parámetro la posición
        {
            txtCodigo.Text = aProductos[i].pCodigo.ToString();
            txtDetalle.Text = aProductos[i].pDetalle;
            txtPrecio.Text = aProductos[i].pPrecio.ToString();
            dtpFecha.Value = aProductos[i].pFecha;
            cboMarca.SelectedValue = aProductos[i].pMarca;
            if (aProductos[i].pTipo == 1)
                rbtNoteBook.Checked = true;
            else if (aProductos[i].pTipo ==2)
                rbtNetBook.Checked = true;
            
        }

        private void habilitarTxt(bool h)
        {
            txtCodigo.Enabled = h;
            txtDetalle.Enabled = h;
            cboMarca.Enabled = h;
            rbtNetBook.Enabled = h;
            rbtNoteBook.Enabled = h;
            txtPrecio.Enabled = h;
            dtpFecha.Enabled = h;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarTxt(true);
            txtCodigo.Enabled = false;
        }

        private void limpiarTxt()
        {
            txtCodigo.Clear();
            txtDetalle.Clear();
            cboMarca.SelectedIndex = -1;
            rbtNetBook.Checked = false;
            rbtNoteBook.Checked = false;
            txtPrecio.Clear();
            dtpFecha.Value = DateTime.Today;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarTxt();
            lstProducto.Enabled = false;
            habilitarTxt(true);
            nuevo = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lstProducto.Enabled = true;
            limpiarTxt();
            habilitarTxt(false);
        }

        private void frmProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "SALIENDO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar este registro?", "ELIMINANDO REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //EN ACCESS SI O SI HAY QUE PONER EL FROM
                consultaSQL = "delete from producto where codigo=" + aProductos[lstProducto.SelectedIndex].pCodigo;
                oDato.actualizar(consultaSQL);
                mostrarLista();
                limpiarTxt();
            }   
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (nuevo)
            {
                Producto p = new Producto();
                p.pCodigo = int.Parse(txtCodigo.Text);
                p.pDetalle = txtDetalle.Text;
                if (rbtNoteBook.Checked)
                    p.pTipo = 1;
                else if (rbtNetBook.Checked)
                    p.pTipo = 2;
                p.pMarca = (int)cboMarca.SelectedValue; //Selected Value para que me tome el valor de mi pk
                p.pPrecio = Convert.ToDouble(txtPrecio.Text);
                p.pFecha = dtpFecha.Value;
                if (!existe(p.pCodigo))
                {
                    consultaSQL = "insert into producto values (" +
                                   p.pCodigo + ",'" +
                                   p.pDetalle + "'," +
                                   p.pTipo + "," +
                                   p.pMarca + ",'" +
                                   p.pPrecio + "','" +
                                   p.pFecha + "')";

                    oDato.actualizar(consultaSQL);
                    nuevo = false;
                    limpiarTxt();
                    
                }
            }
            else 
            {
                
                int i = lstProducto.SelectedIndex;
                aProductos[i].pCodigo = Convert.ToInt32(txtCodigo.Text);
                aProductos[i].pDetalle = txtDetalle.Text;
                if (rbtNoteBook.Checked)
                    aProductos[i].pTipo = 1;
                else if (rbtNetBook.Checked)
                    aProductos[i].pTipo = 2;
                aProductos[i].pMarca = (int)cboMarca.SelectedValue;
                aProductos[i].pPrecio = Convert.ToDouble(txtPrecio.Text);
                aProductos[i].pFecha = dtpFecha.Value;

                consultaSQL = "update producto " + //OJO CON LOS ESPACIOS
                              "set detalle='" + aProductos[i].pDetalle + "'," +
                              "tipo=" + aProductos[i].pTipo + "," +
                              "marca=" + aProductos[i].pMarca + "," +
                              "precio=" + aProductos[i].pPrecio + "," +
                              "fecha='" + aProductos[i].pFecha + "' " + //OJO CON LOS ESPACIOS
                              "where codigo=" + aProductos[i].pCodigo;

                oDato.actualizar(consultaSQL);
                
            }
            mostrarLista();
            lstProducto.Enabled = true;
            habilitarTxt(false);
        }

        private bool existe(int pk)
        {
            for (int i = 0; i < c; i++)
            {
                if (aProductos[i].pCodigo == pk)
                    return true;
            }
             return false;
        }
    }
}
