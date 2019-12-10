using BL.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARYA
{
    public partial class FormReporteEquipos : Form
    {
        public FormReporteEquipos()
        {
            InitializeComponent();

            var _equiposBL = new EquiposBL();
            var bindingsource = new BindingSource();
            bindingsource.DataSource = _equiposBL.ObtenerEquipos();

            var reporte = new ReporteEquipos();
            reporte.SetDataSource(bindingsource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
