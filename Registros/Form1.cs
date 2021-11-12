using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registros
{
    public partial class Form1 : Form
    {
        private BussinesLogicLayer _bussinesLogicLayer;
        public Form1()
        {
            InitializeComponent();
            _bussinesLogicLayer = new BussinesLogicLayer(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateRegistros();
        }
        public void PopulateRegistros()
        {
            List<Registro> registro = _bussinesLogicLayer.GetRegistros();
            dataGridView1.DataSource = registro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarRegistro();
        }

        private void AgregarRegistro()
        {
            RegistroDetails registroDetails = new RegistroDetails();
            registroDetails.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
