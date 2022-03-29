using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CondicionesParser.Parser;

namespace CondicionesParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDictionary<string, object> Imputaciones = new Dictionary<string, object>();

            Imputaciones.Add("MONTO", 10);
            Imputaciones.Add("EDAD", 35);       

            IList<string> Listas = new List<string>();
            Listas.Add(textBox1.Text);

            IList<string> Parametros = LenguajeCondicionesParser.Instancia("C:/Desarrollo_F4/Condiciones/CondicionesParser/").
                ObtenerParametrosLista(Listas);

            bool Evaluacion = LenguajeCondicionesParser.Instancia("C:/Desarrollo_F4/Condiciones/CondicionesParser/").
                Evaluar(Imputaciones, textBox1.Text);

            //ver estooo
            IList<string> condiciones = LenguajeCondicionesParser.Instancia("C:/Desarrollo_F4/Condiciones/CondicionesParser/").
                ObtenerCondicionesInvalidas(Imputaciones, textBox1.Text);

            IDictionary<string, string> Valores = LenguajeCondicionesParser.Instancia("C:/Desarrollo_F4/Condiciones/CondicionesParser/").
                ObtenerValoresContenido(textBox1.Text);

            label1.Text = "Resultado: " + Evaluacion + " ";
            //foreach (string Condicion in condiciones)
            //{
            //    label1.Text += Condicion;
            //}
        }
    }
}
