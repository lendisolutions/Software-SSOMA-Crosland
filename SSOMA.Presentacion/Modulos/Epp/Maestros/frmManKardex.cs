using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Epp.Maestros
{
    public partial class frmManKardex : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<KardexBE> mLista = new List<KardexBE>();

        public int IdEmpresa { get; set; }
        public int IdUnidadMinera { get; set; }
        public String DescOrdenInterna { get; set; }

        #endregion

        #region "Eventos"

        public frmManKardex()
        {
            InitializeComponent();
        }

        private void frmManKardex_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManKardexMasivoEdit objManKardex = new frmManKardexMasivoEdit();
                objManKardex.pOperacion = frmManKardexMasivoEdit.Operacion.Nuevo;
                objManKardex.IdKardex = 0;
                objManKardex.IdEmpresa = IdEmpresa;
                objManKardex.IdUnidadMinera = IdUnidadMinera;
                objManKardex.DescOrdenInterna = DescOrdenInterna;
                objManKardex.StartPosition = FormStartPosition.CenterParent;
                objManKardex.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        KardexBE objE_Kardex = new KardexBE();
                        objE_Kardex.IdKardex = int.Parse(gvKardex.GetFocusedRowCellValue("IdKardex").ToString());
                        objE_Kardex.Usuario = Parametros.strUsuarioLogin;
                        objE_Kardex.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Kardex.IdEmpresa = Parametros.intEmpresaId;

                        KardexBL objBL_Kardex = new KardexBL();
                        objBL_Kardex.Elimina(objE_Kardex);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvKardex_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new KardexBL().ListaTodosActivo(IdEmpresa,IdUnidadMinera, DescOrdenInterna, "I");
            gcKardex.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcKardex.DataSource = mLista.Where(obj =>
                                                   obj.DescEquipo.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvKardex.RowCount > 0)
            {
                KardexBE objKardex = new KardexBE();
                objKardex.IdKardex = int.Parse(gvKardex.GetFocusedRowCellValue("IdKardex").ToString());

                frmManKardexEdit objManKardexEdit = new frmManKardexEdit();
                objManKardexEdit.pOperacion = frmManKardexEdit.Operacion.Modificar;
                objManKardexEdit.IdKardex = objKardex.IdKardex;
                objManKardexEdit.IdEmpresa = IdEmpresa;
                objManKardexEdit.IdUnidadMinera = IdUnidadMinera;
                objManKardexEdit.DescOrdenInterna = DescOrdenInterna;
                objManKardexEdit.pKardexBE = objKardex;
                objManKardexEdit.StartPosition = FormStartPosition.CenterParent;
                objManKardexEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvKardex.GetFocusedRowCellValue("IdKardex").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un elemento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion


    }
}