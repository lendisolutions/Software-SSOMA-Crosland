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
using SSOMA.Presentacion.Utils;
using System.IO;

namespace SSOMA.Presentacion.Modulos.Capacitacion.Maestros
{
    public partial class frmManMatriculaTema : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TemaPersonaBE> mLista = new List<TemaPersonaBE>();
        int IdCategoriaTema = 0;
        int IdTema = 0;
        string strDescTema = "";

        #endregion

        #region "Eventos"


        public frmManMatriculaTema()
        {
            InitializeComponent();
        }

        private void frmManMatriculaTema_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTreeview();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "CAT":
                    IdCategoriaTema = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewTemas(e.Node);
                    break;
                case "TEM":
                    IdTema = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    strDescTema = e.Node.Text;
                    Cargar();
                    break;
            }
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvTemaPersona_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.Assign(view.GetViewInfo().PaintAppearance.GetAppearance("FocusedRow"));
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                TemaPersonaBL objBL_TemaPersona = new TemaPersonaBL();

                objBL_TemaPersona.Actualiza(mLista, IdTema, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                XtraMessageBox.Show("La matricula se realizó correctamente. ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cargar();

                string strFechaIni = "";
                string strFechaFin = "";
                int intDuracion = 0;

                TemaBE objE_Tema = null;
                objE_Tema = new TemaBL().Selecciona(0, IdTema);
                if (objE_Tema != null)
                {
                    strFechaIni = objE_Tema.FechaIni.ToString("dd/MM/yyyy");
                    strFechaFin = objE_Tema.FechaFin.ToString("dd/MM/yyyy");
                    intDuracion = objE_Tema.Horas;
                }

                //ENVIO DE CORREO
                StringBuilder strMensaje = new StringBuilder();
                strMensaje.Append("*****************************************************************************\n\n");
                strMensaje.Append("Tema              : " + strDescTema + "\n");
                strMensaje.Append("Fecha de Vigencia : " + "DEL " + strFechaIni + "AL " + strFechaFin + "\n");
                strMensaje.Append("Duración          : " + intDuracion.ToString() + " Horas" + "\n");
                int i = 1;
                foreach (var item in mLista)
                {
                    if (item.FlagMatricula)
                    {
                        strMensaje.Append(" " + item.ApeNom + "\n\n");
                    }

                    i = i + 1;
                }

                strMensaje.Append("SE ADJUNTA EL MANUAL DE USUARIO\n\n");
                strMensaje.Append("*****************************************************************************\n\n");
                

                string strMailTO = "JVILLANUEVA@CROSLAND.COM.PE";
                foreach (var itempersona in mLista)
                {
                    if (itempersona.FlagMatricula)
                    {
                        PersonaBE objE_Persona = new PersonaBE();
                        objE_Persona = new PersonaBL().Selecciona(0, 0, 0, itempersona.IdPersona);
                        if (objE_Persona != null)
                        {
                            if (objE_Persona.Email.Length > 0 && objE_Persona.Email != "JVILLANUEVA@CROSLAND.COM.PE")
                            {
                                strMailTO = strMailTO + ";" + objE_Persona.Email;
                            }
                            
                        }
                    }
                    
                }

                string filename = Path.Combine(Directory.GetCurrentDirectory(), "Pdf\\Manual_SSOMA_Capacitacion.pdf");

                BSUtils.EmailSend(strMailTO, "MATRÍCULA DE CAPACITACIÓN VIRTUAL", strMensaje.ToString(), filename, "", "", "");

                Application.DoEvents();

                Cursor = Cursors.Default;


            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSelecciona_CheckedChanged(object sender, EventArgs e)
        {
            if (gvTemaPersona.RowCount > 0)
            {
                if (chkSelecciona.Checked)
                {
                    for (int i = 0; i < gvTemaPersona.RowCount; i++)
                        gvTemaPersona.SetRowCellValue(i, "FlagMatricula", true);
                }
                else
                {
                    for (int i = 0; i < gvTemaPersona.RowCount; i++)
                        gvTemaPersona.SetRowCellValue(i, "FlagMatricula", false);
                }
            }
            
        }

        #endregion

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            TreeNode nuevoNodo = new TreeNode();
            nuevoNodo.Text = "CATEGORIAS";
            nuevoNodo.ImageIndex = 0;
            nuevoNodo.SelectedImageIndex = 0;
            tvwDatos.Nodes.Add(nuevoNodo);

            List<CategoriaTemaBE> lstCategoriaTema = null;
            lstCategoriaTema = new CategoriaTemaBL().ListaTodosActivo(0);
            foreach (var item in lstCategoriaTema)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 1;
                nuevoNodoChild.SelectedImageIndex = 1;
                nuevoNodoChild.Text = item.DescCategoriaTema;
                nuevoNodoChild.Tag = "CAT" + item.IdCategoriaTema.ToString();
                nuevoNodo.Nodes.Add(nuevoNodoChild);

            }

            tvwDatos.ExpandAll();
        }

        void CargaTreeviewTemas(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<TemaBE> lstTema = null;
            lstTema = new TemaBL().ListaTodosActivo(0, IdCategoriaTema, Parametros.intTEMAVirtual,Parametros.intTEMAActivo,Parametros.intPeriodo);
            foreach (var item in lstTema)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 2;
                nuevoNodoChild.SelectedImageIndex = 2;
                nuevoNodoChild.Text = item.DescTema;
                nuevoNodoChild.Tag = "TEM" + item.IdTema.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        private void Cargar()
        {
            mLista = new TemaPersonaBL().ListaTodosActivo(0, IdTema,0);
            gcTemaPersona.DataSource = mLista;

            

        }

        private void CargarBusqueda()
        {
            gcTemaPersona.DataSource = mLista.Where(obj =>
                                                   obj.ApeNom.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }




        #endregion

        
    }
}