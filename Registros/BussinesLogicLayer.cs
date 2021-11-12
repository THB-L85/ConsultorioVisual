using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros
{
    public class BussinesLogicLayer
    {
        private DataAccessLayer _dataAccessLayer;

        public BussinesLogicLayer()
        {
            _dataAccessLayer = new DataAccessLayer();
        }

        public Registro SaveRegistro(Registro registros)
        {
            if (registros.Id == 0)
                _dataAccessLayer.InsertRegistro(registros);
            //else
            //    _dataAccessLayer.UpdateTablaPacientes(tablaPacientes);

            return registros;
        }

        public List<Registro> GetRegistros()
        {
            return _dataAccessLayer.GetRegistros();
        }
    }
}