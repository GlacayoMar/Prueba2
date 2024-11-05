using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.models
{
    public struct Estudiante
    {
     
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double NotaFinal { get; set; }

        public Estudiante(string nombre, string apellido, double notaFinal)
        {
            Nombre = nombre;
            Apellido = apellido;
            NotaFinal = notaFinal;
        }

        public string obtenerCalificacionLetra()
        {
            if (NotaFinal >= 90) 
            {
                return "A";
            }
            if (NotaFinal >= 80) 
            {
                return "B";
            }
            if (NotaFinal >= 70) 
            {
                return "C"; 
            }
            if (NotaFinal >= 60) 
            {
                return "D"; 
            }
            return "F";
        }
    }
}
