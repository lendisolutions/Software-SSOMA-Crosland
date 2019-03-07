using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using SSOMA.BusinessLogic;
using SSOMA.BusinessEntity;
using SSOMA.Presentacion.Funciones;

namespace SSOMA.Presentacion.Modulos.Capacitacion.Registros
{
    public partial class frmRegCapacitacionVirtual : DevExpress.XtraEditors.XtraForm
    {
        public frmRegCapacitacionVirtual()
        {
            InitializeComponent();
        }

        private void frmRegCapacitacionVirtual_Load(object sender, EventArgs e)
        {
            InitData();
            SetupView();
            tileView1.OptionsTiles.Orientation = Orientation.Vertical;
            tileView1.OptionsBehavior.AllowSmoothScrolling = true;
        }

        protected virtual void InitData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                //TRAEMOS LA INFORMACION DE LA BASE DE DATOS
                List<TemaPersonaBE> lstTemaPersonal = null;
                lstTemaPersonal = new TemaPersonaBL().ListaPersona(Parametros.intEmpresaId, Parametros.intPersonaId);

                //var homesTable = VideoCatalogDataSet();
                var homesTable = new FuncionBase().ToDataTable(lstTemaPersonal);
                homesTable.Columns.Add("Image", typeof(Image));
                homesTable.Columns.Add("Curso", typeof(String));
                foreach (DataRow row in homesTable.Rows)
                {
                    var img = DevExpress.XtraEditors.Controls.ByteImageConverter.FromByteArray(row["Logo"] as byte[]);
                    row["Image"] = new Bitmap(img, new Size(351, 234));
                    row["Curso"] = row["DescSituacion"].ToString();
                }

                gridControl1.DataSource = homesTable;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SetupView()
        {
            try
            {
                // Setup tiles options
                tileView1.BeginUpdate();
                tileView1.OptionsTiles.RowCount = 3;
                tileView1.OptionsTiles.Padding = new Padding(20);
                tileView1.OptionsTiles.ItemPadding = new Padding(10);
                tileView1.OptionsTiles.IndentBetweenItems = 20;
                tileView1.OptionsTiles.ItemSize = new Size(450, 250);
                tileView1.Appearance.ItemNormal.ForeColor = Color.White;
                tileView1.Appearance.ItemNormal.BorderColor = Color.Transparent;
                //Setup tiles template
                TileViewItemElement leftPanel = new TileViewItemElement();
                TileViewItemElement splitLine = new TileViewItemElement();
                TileViewItemElement addressCaption = new TileViewItemElement();
                TileViewItemElement addressValue = new TileViewItemElement();
                TileViewItemElement yearBuiltCaption = new TileViewItemElement();
                TileViewItemElement yearBuiltValue = new TileViewItemElement();
                TileViewItemElement price = new TileViewItemElement();
                TileViewItemElement image = new TileViewItemElement();
                tileView1.TileTemplate.Add(leftPanel);
                tileView1.TileTemplate.Add(splitLine);
                tileView1.TileTemplate.Add(addressCaption);
                tileView1.TileTemplate.Add(addressValue);
                tileView1.TileTemplate.Add(yearBuiltCaption);
                tileView1.TileTemplate.Add(yearBuiltValue);
                tileView1.TileTemplate.Add(price);
                tileView1.TileTemplate.Add(image);
                //
                leftPanel.StretchVertical = true;
                leftPanel.Width = 135;
                leftPanel.TextLocation = new Point(-10, 0);
                leftPanel.Appearance.Normal.BackColor = Color.FromArgb(58, 166, 101);
                //
                //splitLine.StretchVertical = true;
                //splitLine.Width = 3;
                //splitLine.TextAlignment = TileItemContentAlignment.Manual;
                //splitLine.TextLocation = new Point(110, 0);
                //splitLine.Appearance.Normal.BackColor = Color.White;
                //
                addressCaption.Text = "CURSO";
                addressCaption.TextAlignment = TileItemContentAlignment.TopLeft;
                addressCaption.Appearance.Normal.FontSizeDelta = -1;
                //
                addressValue.Column = tileView1.Columns["DescTema"];
                addressValue.AnchorElement = addressCaption;
                addressValue.AnchorIndent = 2;
                addressValue.MaxWidth = 120;
                addressValue.Appearance.Normal.FontStyleDelta = FontStyle.Bold;
                //
                yearBuiltCaption.Text = "FECHA TERMINO";
                yearBuiltCaption.AnchorElement = addressValue;
                yearBuiltCaption.AnchorIndent = 14;
                yearBuiltCaption.Appearance.Normal.FontSizeDelta = -1;
                //
                yearBuiltValue.Column = tileView1.Columns["FechaFin"];
                yearBuiltValue.AnchorElement = yearBuiltCaption;
                yearBuiltValue.AnchorIndent = 2;
                yearBuiltValue.Appearance.Normal.FontStyleDelta = FontStyle.Bold;
                //
                price.Column = tileView1.Columns["Curso"];
                price.TextAlignment = TileItemContentAlignment.BottomLeft;
                price.Appearance.Normal.Font = new Font("Segoe UI Semilight", 16.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //
                image.Column = tileView1.Columns["Image"];
                image.ImageSize = new Size(308, 233);
                image.ImageAlignment = TileItemContentAlignment.MiddleRight;
                image.ImageScaleMode = TileItemImageScaleMode.ZoomOutside;
                image.ImageLocation = new Point(8, 4);

            }
            finally
            {
                tileView1.EndUpdate();
            }
        }

        private void tileView1_DoubleClick(object sender, EventArgs e)
        {
            if (tileView1.RowCount > 0)
            {
                int intIdEmpresa = int.Parse(tileView1.GetFocusedRowCellValue("IdEmpresa").ToString());
                int intIdTema = int.Parse(tileView1.GetFocusedRowCellValue("IdTema").ToString());
                string strDescTema = tileView1.GetFocusedRowCellValue("DescTema").ToString();

                TemaBE objE_Tema = null;
                objE_Tema = new TemaBL().Selecciona(intIdEmpresa, intIdTema);
                if (objE_Tema != null)
                {
                    if (objE_Tema.IdSituacion == Parametros.intTEMAInactivo)
                    {
                        XtraMessageBox.Show("El Curso se encuentra inactivo no puede ingresar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        frmRegCapacitacionVirtualEdit frm = new frmRegCapacitacionVirtualEdit();
                        frm.strDescTema = strDescTema;
                        frm.strParticipante = Parametros.strUsuarioNombres;
                        frm.Show();
                    }
                }


            }
        }
    }
}