using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend.Homes;
using CondicionesMigracion.ACNetDatos;
using CondicionesMigracion.ACNet;
using CondicionesMigracion.ACNetServicio;

namespace CondicionesMigracion
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

            /*
             en rango
            tipoplan //plan familiar, individual o 
                     //todos tomarlo del grupo - para prod viejos y upgrades es ALL
            categoria para upgrades ver!
             
             */
            //DAOClausulaTarifaGrupo.Instancia().Buscar(ClausulaTarifaGrupo.PRODUCTO);
            label1.Text = "Migrando Clausulas de Productos";
            ServicioMigracion.Instancia().Migrar(ClausulaTarifaGrupo.PRODUCTO);
            
            label1.Text = "Migrando Clausulas de Upgrades";
            ServicioMigracionUpgrades.Instancia().Migrar(ClausulaTarifaGrupo.UPGRADE);

            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            ServicioMigracionGrupoPaises.Instancia().Migrar();
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            ServicioMigracionProductosTarifas.Instancia().Migrar();
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            ServicioMigracionDocumentos.Instancia().Migrar();
            button4.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //button5.Enabled = false;
            ServicioMigracionClausula.Instancia().Migrar();
            //button5.Enabled = true;
        }
    }
}
