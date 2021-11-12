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
    public partial class RegistroDetails : Form
    {
        private BussinesLogicLayer _bussinesLogicLayer;
        private Registro _registro;
        public RegistroDetails()
        {
            InitializeComponent();
            _bussinesLogicLayer = new BussinesLogicLayer();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveRegistro();
            this.Close();
            ((Form1)this.Owner).PopulateRegistros();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveRegistro()
        {
            Registro registro = new Registro();
            registro.Paciente = txtNombre.Text;
            registro.Apellidos = txtApellido.Text;
            registro.Servicio = txtServicio.Text;
            registro.Costo = txtCosto.Text;
            registro.Fecha = txtFecha.Text;


            _bussinesLogicLayer.SaveRegistro(registro);
        }
    }
}
