using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problema_1._8
{
    public partial class frmCursos : Form
    {
        const int fil=3;
        const int col=5;
        int ff, cc;
        Alumno[,] mAlumnos = new Alumno[fil, col];
        int fila;
        int columna;
        public frmCursos()
        {
            InitializeComponent();
            ff = cc = 0;
            fila = columna = 0;
            for(int f = 0; f < fil; f++)
            {
                for (int c = 0; c < col; c++)
                    mAlumnos[f, c] = null;
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double total=0;
            double count=0;
            lstPromedios.Items.Clear();

            foreach(Alumno a in mAlumnos)
            {
                if (a != null)
                {
                    lstPromedios.Items.Add(a.calcularPromedio());
                    total += a.calcularPromedio();
                    count++;
                }
                
            }
            //for(int f = 0; f < fil; f++)
            //{
            //    for(int c=0; c<col;c++)
            //    {
            //        lstPromedios.Items.Add(mAlumnos[f, c].calcularPromedio());
            //        total += mAlumnos[f, c].calcularPromedio();
            //        count++;
            //    }
            //}
            txtPromGral.Text = Convert.ToString(Math.Round(total / count, 2));
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

            fila = (lstNombres.SelectedIndex / col);
            columna = lstNombres.SelectedIndex % col;
            MessageBox.Show(mAlumnos[fila, columna].toStringAlumno(),"Informacion de Alumno",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("Esta seguro que desea salir?",
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (opcion == DialogResult.Yes)
                Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                mAlumnos[ff, cc] = new Alumno();
                mAlumnos[ff, cc].pNombre = txtNombre.Text;
                mAlumnos[ff, cc].pLegajo = Convert.ToDouble(txtLegajo.Text);
                mAlumnos[ff, cc].pNota1 = Convert.ToDouble(txtNota1.Text);
                mAlumnos[ff, cc].pNota2 = Convert.ToDouble(txtNota2.Text);
                mAlumnos[ff, cc].pNota3 = Convert.ToDouble(txtNota3.Text);
                lstNombres.Items.Add(mAlumnos[ff, cc].pNombre);
                lstLegajos.Items.Add(mAlumnos[ff, cc].pLegajo);
                cc++;
                if (cc == col)
                {
                    cc = 0;
                    ff++;
                    MessageBox.Show("El curso nro: " + ff + " se ha completado",
                        "Curso" + ff,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                if (ff == fil)
                {
                    MessageBox.Show("Se han completado todos los cursos",
                        "Completado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    btnCargar.Enabled = false;
                }
               
                txtNota1.Clear();
                txtNota2.Clear();
                txtNota3.Clear();
                txtNota1.Focus();
            }
        }
        public bool validarDatos()
        {
         
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del alumno");
                return false;
            }


            if (string.IsNullOrEmpty(txtLegajo.Text))
            {
                MessageBox.Show("Ingrese el legajo del alumno");
                return false;
            }
            if (string.IsNullOrEmpty(txtNota1.Text))
            {
                MessageBox.Show("Ingrese la nota 1 del alumno");
                return false;
            }

            if (string.IsNullOrEmpty(txtNota2.Text))
            {
                MessageBox.Show("Ingrese la nota 2 del alumno");
                return false;
            }
            if (string.IsNullOrEmpty(txtNota3.Text))
            {
                MessageBox.Show("Ingrese la nota 3 del alumno");
                return false;
            }
            return true;
        }
    }
}
