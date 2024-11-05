using Prueba2.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba2
{
    public partial class Form1 : Form
    {
        private List<Estudiante> estudiantes = new List<Estudiante>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Estudiante estudiante = new Estudiante(
                    txtNombre.Text,
                    txtApellido.Text,
                    double.Parse(txtNotaFinal.Text)
                );
                estudiantes.Add(estudiante);

                txtNombre.Clear();
                txtApellido.Clear();
                txtNotaFinal.Clear();

                estudiantes = MergeSort(estudiantes);

                actualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar estudiante: " + ex.Message);
            }

        }
        private void actualizarDataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var estudiante in estudiantes)
            {
                dataGridView1.Rows.Add(
                    estudiante.Nombre,
                    estudiante.Apellido,
                    estudiante.NotaFinal,
                    estudiante.obtenerCalificacionLetra()
                );
            }
        }

        private List<Estudiante> MergeSort(List<Estudiante> lista)
        {
            if (lista.Count <= 1)
                return lista;

            int medio = lista.Count / 2;
            var izquierda = MergeSort(lista.GetRange(0, medio));
            var derecha = MergeSort(lista.GetRange(medio, lista.Count - medio));

            return Merge(izquierda, derecha);
        }

        private List<Estudiante> Merge(List<Estudiante> izquierda, List<Estudiante> derecha)
        {
            var resultado = new List<Estudiante>();
            int i = 0, j = 0;

            while (i < izquierda.Count && j < derecha.Count)
            {
                if (izquierda[i].NotaFinal >= derecha[j].NotaFinal)
                    resultado.Add(izquierda[i++]);
                else
                    resultado.Add(derecha[j++]);
            }

            while (i < izquierda.Count)
                resultado.Add(izquierda[i++]);
            while (j < derecha.Count)
                resultado.Add(derecha[j++]);

            return resultado;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Nombre";
            dataGridView1.Columns[1].Name = "Apellido";
            dataGridView1.Columns[2].Name = "Nota Final";
            dataGridView1.Columns[3].Name = "Calificación";
        }
    }

}
