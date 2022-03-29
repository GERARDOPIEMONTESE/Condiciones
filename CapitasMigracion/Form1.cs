using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapitasMigracion.Servicios;

namespace CapitasMigracion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            ServicioMigracion.MigrarProductosTarifas();
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            ServicioMigracion.MigrarGrupos();
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            ServicioMigracion.MigrarClausulas();
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            ServicioMigracion.MigrarValidezTerritorial();
            button4.Enabled = true;
        }
    }
}
