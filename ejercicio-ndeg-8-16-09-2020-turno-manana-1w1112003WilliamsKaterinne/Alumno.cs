using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._8
{
    class Alumno
    {
        private string nombre;
        private double legajo;
        private double nota1;
        private double nota2;
        private double nota3;

        public string pNombre { get => nombre; set => nombre = value; }
        public double pLegajo { get => legajo; set => legajo = value; }
        public double pNota1 { get => nota1; set => nota1 = value; }
        public double pNota2 { get => nota2; set => nota2 = value; }
        public double pNota3 { get => nota3; set => nota3 = value; }

        public Alumno(string nombre, int legajo, int nota1, int nota2, int nota3)
        {
            this.nombre = nombre;
            this.legajo = legajo;
            this.nota1 = nota1;
            this.nota2 = nota2;
            this.nota3 = nota3;
        }
        public Alumno()
        {
            this.nombre = "";
            this.legajo = 0;
            this.nota1 = 0;
            this.nota2 = 0;
            this.nota3 = 0;
        }
        public double calcularPromedio()
        {
            return Math.Round((nota1 + nota2 + nota3) / 3, 2);
        }
        public string toStringAlumno()
        {
            return "Alumno: " + nombre + "\nLegajo: " + legajo + "\nPromedio: " + calcularPromedio();
        }
    }
}
