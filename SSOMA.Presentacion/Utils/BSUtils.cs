using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Principal;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Funciones;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSOMA.Presentacion.Utils
{
    public  class BSUtils
    {
        public static void LoaderLook(LookUpEdit Control, object DataSource, string FieldDisplay, string FieldValue, bool DefaulValue)
        {
            var _with1 = Control;
            _with1.Properties.DataSource = DataSource;
            _with1.Properties.Columns.Clear();
            _with1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(FieldDisplay, 200, "Descripción"));
            _with1.Properties.DisplayMember = FieldDisplay;
            _with1.Properties.ValueMember = FieldValue;
            if (DefaulValue)
                _with1.ItemIndex = 0;
            else
                _with1.EditValue = null;

        }

        public static void EmailSend(string MailTo, string Titulo, string Mensaje, string ArchivoEnvio1, string ArchivoEnvio2, string ArchivoEnvio3, string ArchivoEnvio4)
        {

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress("ssoma@crosland.com.pe", "Seguridad y Salud en el Trabajo "); //Quien Envia

            String[] AMailto = MailTo.Split(';');
            foreach (String strMail in AMailto)
            {
                mail.To.Add(strMail);  //Mail de la persona a enviar
            }
            
            mail.Body = Mensaje;
            mail.IsBodyHtml = false;
            mail.Priority = System.Net.Mail.MailPriority.High;  //Esto deberia evitar que los mails vayan al folder Junk-Email.            
            mail.Subject = Titulo;

            MailAddress copy1 = new MailAddress("jvillanueva@crosland.com.pe");
            mail.CC.Add(copy1);

            MailAddress copy2 = new MailAddress("zmonteverde@crosland.com.pe");
            mail.CC.Add(copy2);

            if (ArchivoEnvio1.Length > 0)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ArchivoEnvio1);
                mail.Attachments.Add(attachment);
            }

            if (ArchivoEnvio2.Length > 0)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ArchivoEnvio2);
                mail.Attachments.Add(attachment);
            }

            if (ArchivoEnvio3.Length > 0)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ArchivoEnvio3);
                mail.Attachments.Add(attachment);
            }

            if (ArchivoEnvio4.Length > 0)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ArchivoEnvio4);
                mail.Attachments.Add(attachment);
            }

            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("mail.crosland.com.pe");
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("ssoma@crosland.com.pe", "ssoma2017#");
            smtpClient.Credentials = basicAuthenticationInfo;
            smtpClient.EnableSsl = true;

            ServicePointManager.ServerCertificateValidationCallback =
               delegate (object s
                   , X509Certificate certificate
                   , X509Chain chai
                   , SslPolicyErrors sslPolicyErrors)
               { return true; };

            smtpClient.Send(mail);

            mail.Dispose();
            smtpClient.Dispose();
        }

        public static void ExportarFormatoExcel(string filename, int IdAccidente, int IdTipo, bool bMensaje)
        {
            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Accidente.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string strNumero = "";

                AccidenteBE objE_Accidente = null;
                objE_Accidente = new AccidenteBL().SeleccionaReporte(IdAccidente);
                if (objE_Accidente != null)
                {
                    PictureBox picImg = new PictureBox();
                    picImg.Image = new FuncionBase().Bytes2Image((byte[])objE_Accidente.Logo);
                    string strRuta = Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg");

                    picImg.Image.Save(strRuta, System.Drawing.Imaging.ImageFormat.Jpeg);

                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 55, 18, 60, 50);


                    if (IdTipo == Parametros.intTIAccidente)
                    {
                        xlHoja.Cells[2, "D"] = "REPORTE DE ACCIDENTES DE TRABAJO";
                        xlHoja.Cells[18, "A"] = "INVESTIGACIÓN DEL ACCIDENTE";
                        xlHoja.Cells[26, "A"] = "SOBRE EL ACCIDENTE";
                        xlHoja.Cells[34, "A"] = "CAUSAS DEL ACCIDENTE";
                        xlHoja.Cells[43, "A"] = "MEDIDAS DE PREVENCION / PROTECCION ADOPTADAS ANTES DEL ACCIDENTE";
                        xlHoja.Cells[49, "A"] = "MEDIDAS A ADOPTAR PARA EVITAR LA REPETICION DEL ACCIDENTE ";
                    }

                    else
                    {
                        xlHoja.Cells[2, "D"] = "REPORTE DE INCIDENTES DE TRABAJO";
                        xlHoja.Cells[18, "A"] = "INVESTIGACIÓN DEL INCIDENTE";
                        xlHoja.Cells[26, "A"] = "SOBRE EL INCIDENTE";
                        xlHoja.Cells[29, "A"] = "CAUSAS DEL INCIDENTE";
                        xlHoja.Cells[43, "A"] = "MEDIDAS DE PREVENCION / PROTECCION ADOPTADAS ANTES DEL INCIDENTE";
                        xlHoja.Cells[49, "A"] = "MEDIDAS A ADOPTAR PARA EVITAR LA REPETICION DEL INCIDENTE ";
                    }


                    strNumero = objE_Accidente.Numero;
                    xlHoja.Cells[7, "A"] = objE_Accidente.RazonSocial;
                    xlHoja.Cells[7, "D"] = objE_Accidente.Ruc;
                    xlHoja.Cells[7, "G"] = objE_Accidente.Direccion;
                    xlHoja.Cells[7, "J"] = objE_Accidente.ActividadEconomica;
                    xlHoja.Cells[7, "N"] = objE_Accidente.NumeroTrabajadores.ToString();
                    xlHoja.Cells[8, "D"] = objE_Accidente.EmpresaContratista;
                    string strTipoEvento = objE_Accidente.DescTipo;
                    if (strTipoEvento == "ACCIDENTE")
                    {
                        xlHoja.Cells[10, "E"] = "X";
                    }
                    if (strTipoEvento == "INCIDENTE PELIGROSO")
                    {
                        xlHoja.Cells[10, "G"] = "X";
                    }
                    if (strTipoEvento == "INCIDENTE")
                    {
                        xlHoja.Cells[10, "I"] = "X";
                    }
                    string strDanio = objE_Accidente.DescDanio;
                    if (strDanio == "TRABAJADOR")
                    {
                        xlHoja.Cells[10, "L"] = "X";
                    }
                    if (strDanio == "MATERIAL")
                    {
                        xlHoja.Cells[10, "N"] = "X";
                    }
                    xlHoja.Cells[12, "C"] = objE_Accidente.Responsable;
                    xlHoja.Cells[12, "J"] = objE_Accidente.Edad.ToString();
                    xlHoja.Cells[12, "N"] = objE_Accidente.DescTipoContrato;
                    xlHoja.Cells[13, "C"] = objE_Accidente.AreaResponsable;
                    xlHoja.Cells[13, "J"] = objE_Accidente.Cargo;
                    xlHoja.Cells[13, "N"] = objE_Accidente.JefeDirecto;
                    xlHoja.Cells[14, "C"] = objE_Accidente.Dni;
                    xlHoja.Cells[14, "J"] = objE_Accidente.TiempoExperiencia;
                    xlHoja.Cells[14, "N"] = objE_Accidente.UnidadMineraResponsable;
                    xlHoja.Cells[16, "D"] = objE_Accidente.TipoMaterial;
                    xlHoja.Cells[17, "D"] = objE_Accidente.ResponsableArea;
                    if (strDanio == "TRABAJADOR")
                    {
                        xlHoja.Cells[16, "L"] = "";
                        xlHoja.Cells[17, "L"] = "";
                    }
                    else
                    {
                        xlHoja.Cells[12, "J"] = "";
                        xlHoja.Cells[13, "C"] = "";
                        xlHoja.Cells[14, "N"] = "";
                        xlHoja.Cells[16, "L"] = objE_Accidente.AreaResponsable;
                        xlHoja.Cells[17, "L"] = objE_Accidente.SectorResponsable;
                    }

                    xlHoja.Cells[20, "A"] = objE_Accidente.Fecha.ToShortDateString();
                    xlHoja.Cells[20, "C"] = objE_Accidente.Hora.ToLongTimeString();
                    xlHoja.Cells[20, "D"] = objE_Accidente.FechaInicio.ToShortDateString();
                    xlHoja.Cells[20, "G"] = objE_Accidente.Lugar;
                    xlHoja.Cells[20, "L"] = objE_Accidente.HoraTrabajada;
                    string strPotenciaDanio = objE_Accidente.DescPotencialDanio;
                    if (strPotenciaDanio == "MORTAL")
                    {
                        xlHoja.Cells[21, "E"] = "X";
                    }
                    if (strPotenciaDanio == "INCAPACITANTE")
                    {
                        xlHoja.Cells[21, "G"] = "X";
                    }
                    if (strPotenciaDanio == "LEVE")
                    {
                        xlHoja.Cells[21, "I"] = "X";
                    }

                    string strProbabilidadOcurrencia = objE_Accidente.DescProbabilidadOcurrencia;
                    if (strProbabilidadOcurrencia == "ALTA")
                    {
                        xlHoja.Cells[21, "M"] = "X";
                    }
                    if (strProbabilidadOcurrencia == "MEDIA")
                    {
                        xlHoja.Cells[21, "O"] = "X";
                    }
                    if (strProbabilidadOcurrencia == "BAJA")
                    {
                        xlHoja.Cells[21, "R"] = "X";
                    }

                    string strGradoAccidente = objE_Accidente.DescGradoAccidente;
                    if (strGradoAccidente == "TOTAL PERMANENTE")
                    {
                        xlHoja.Cells[22, "E"] = "X";
                    }
                    if (strGradoAccidente == "PARCIAL PERMANENTE")
                    {
                        xlHoja.Cells[22, "G"] = "X";
                    }
                    if (strGradoAccidente == "PARCIAL TEMPORAL")
                    {
                        xlHoja.Cells[22, "I"] = "X";
                    }
                    if (strGradoAccidente == "TOTAL TEMPORAL")
                    {
                        xlHoja.Cells[23, "I"] = "X";
                    }

                    xlHoja.Cells[22, "L"] = objE_Accidente.Porque;
                    xlHoja.Cells[23, "L"] = objE_Accidente.TrabajoOrdenadoPor;
                    xlHoja.Cells[24, "D"] = objE_Accidente.DescTipoAccidente;
                    xlHoja.Cells[24, "I"] = objE_Accidente.DescParteLesionada;
                    xlHoja.Cells[24, "L"] = objE_Accidente.DescTipoLesion;
                    xlHoja.Cells[24, "P"] = objE_Accidente.DescFuenteLesion;
                    xlHoja.Cells[25, "D"] = objE_Accidente.DiasPerdido.ToString();
                    xlHoja.Cells[25, "I"] = objE_Accidente.CostoTotal.ToString();
                    xlHoja.Cells[25, "P"] = objE_Accidente.TrabajadoresAfectado.ToString();
                    xlHoja.Cells[28, "A"] = objE_Accidente.Descripcion;
                    xlHoja.Cells[61, "A"] = objE_Accidente.InvestigadoPor;
                    xlHoja.Cells[61, "J"] = objE_Accidente.RevisadoPor;
                }

                PictureBox picImage = new PictureBox();

                //FOTO
                List<AccidenteFotoBE> lstAccidenteFoto = null;
                lstAccidenteFoto = new AccidenteFotoBL().ListaTodosActivo(IdAccidente);
                if (lstAccidenteFoto.Count > 0)
                {
                    if (lstAccidenteFoto.Count == 1)
                    {
                        picImage.Image = new FuncionBase().Bytes2Image((byte[])lstAccidenteFoto[0].Foto);
                        string strRuta = Path.Combine(Directory.GetCurrentDirectory(), "Accidente1.jpg");

                        picImage.Image.Save(strRuta, System.Drawing.Imaging.ImageFormat.Jpeg);

                        xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Accidente1.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 1215, 400, 300);

                        xlHoja.Cells[33, "A"] = lstAccidenteFoto[0].DescripcionFoto;

                    }

                    if (lstAccidenteFoto.Count == 2)
                    {
                        picImage.Image = new FuncionBase().Bytes2Image((byte[])lstAccidenteFoto[0].Foto);
                        string strRuta = Path.Combine(Directory.GetCurrentDirectory(), "Accidente1.jpg");

                        picImage.Image.Save(strRuta, System.Drawing.Imaging.ImageFormat.Jpeg);

                        xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Accidente1.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 1215, 400, 300);

                        xlHoja.Cells[33, "A"] = lstAccidenteFoto[0].DescripcionFoto;


                        picImage.Image = new FuncionBase().Bytes2Image((byte[])lstAccidenteFoto[1].Foto);
                        string strRuta2 = Path.Combine(Directory.GetCurrentDirectory(), "Accidente2.jpg");

                        picImage.Image.Save(strRuta2, System.Drawing.Imaging.ImageFormat.Jpeg);

                        xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Accidente2.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 600, 1215, 400, 300);

                        xlHoja.Cells[33, "H"] = lstAccidenteFoto[1].DescripcionFoto;

                    }

                    if (lstAccidenteFoto.Count == 3)
                    {
                        picImage.Image = new FuncionBase().Bytes2Image((byte[])lstAccidenteFoto[0].Foto);
                        string strRuta = Path.Combine(Directory.GetCurrentDirectory(), "Accidente1.jpg");

                        picImage.Image.Save(strRuta, System.Drawing.Imaging.ImageFormat.Jpeg);

                        xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Accidente1.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 1215, 400, 300);

                        xlHoja.Cells[33, "A"] = lstAccidenteFoto[0].DescripcionFoto;


                        picImage.Image = new FuncionBase().Bytes2Image((byte[])lstAccidenteFoto[1].Foto);
                        string strRuta2 = Path.Combine(Directory.GetCurrentDirectory(), "Accidente2.jpg");

                        picImage.Image.Save(strRuta2, System.Drawing.Imaging.ImageFormat.Jpeg);

                        xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Accidente2.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 600, 1215, 400, 300);

                        xlHoja.Cells[33, "H"] = lstAccidenteFoto[1].DescripcionFoto;


                        picImage.Image = new FuncionBase().Bytes2Image((byte[])lstAccidenteFoto[2].Foto);
                        string strRuta3 = Path.Combine(Directory.GetCurrentDirectory(), "Accidente3.jpg");

                        picImage.Image.Save(strRuta3, System.Drawing.Imaging.ImageFormat.Jpeg);

                        xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Accidente3.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1100, 1215, 400, 300);

                        xlHoja.Cells[33, "L"] = lstAccidenteFoto[2].DescripcionFoto;

                    }

                    string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory());
                    foreach (string filePath in filePaths)
                    {
                        if (filePath.Contains(".jpg"))
                            File.Delete(filePath);
                    }

                }

                //ACTO SUB ESTANDAR
                List<AccidenteActoSubEstandarBE> lstAccidenteActoSubEstandar = null;
                lstAccidenteActoSubEstandar = new AccidenteActoSubEstandarBL().ListaTodosActivo(IdAccidente);
                if (lstAccidenteActoSubEstandar.Count > 0)
                {
                    if (lstAccidenteActoSubEstandar.Count == 1)
                    {
                        xlHoja.Cells[36, "B"] = lstAccidenteActoSubEstandar[0].DescActoSubEstandar;
                    }

                    if (lstAccidenteActoSubEstandar.Count == 2)
                    {
                        xlHoja.Cells[36, "B"] = lstAccidenteActoSubEstandar[0].DescActoSubEstandar;
                        xlHoja.Cells[37, "B"] = lstAccidenteActoSubEstandar[1].DescActoSubEstandar;
                    }

                    if (lstAccidenteActoSubEstandar.Count == 3)
                    {
                        xlHoja.Cells[36, "B"] = lstAccidenteActoSubEstandar[0].DescActoSubEstandar;
                        xlHoja.Cells[37, "B"] = lstAccidenteActoSubEstandar[1].DescActoSubEstandar;
                        xlHoja.Cells[38, "B"] = lstAccidenteActoSubEstandar[2].DescActoSubEstandar;
                    }

                }

                //ACTO SUB ESTANDAR
                List<AccidenteCondicionSubEstandarBE> lstAccidenteCondicionSubEstandar = null;
                lstAccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarBL().ListaTodosActivo(IdAccidente);
                if (lstAccidenteCondicionSubEstandar.Count > 0)
                {
                    if (lstAccidenteCondicionSubEstandar.Count == 1)
                    {
                        xlHoja.Cells[36, "J"] = lstAccidenteCondicionSubEstandar[0].DescCondicionSubEstandar;
                    }

                    if (lstAccidenteCondicionSubEstandar.Count == 2)
                    {
                        xlHoja.Cells[36, "J"] = lstAccidenteCondicionSubEstandar[0].DescCondicionSubEstandar;
                        xlHoja.Cells[37, "J"] = lstAccidenteCondicionSubEstandar[1].DescCondicionSubEstandar;
                    }

                    if (lstAccidenteCondicionSubEstandar.Count == 3)
                    {
                        xlHoja.Cells[36, "J"] = lstAccidenteCondicionSubEstandar[0].DescCondicionSubEstandar;
                        xlHoja.Cells[37, "J"] = lstAccidenteCondicionSubEstandar[1].DescCondicionSubEstandar;
                        xlHoja.Cells[38, "J"] = lstAccidenteCondicionSubEstandar[2].DescCondicionSubEstandar;
                    }
                }

                //FACTOR PERSONAL
                List<AccidenteFactorPersonalBE> lstAccidenteFactorPersonal = null;
                lstAccidenteFactorPersonal = new AccidenteFactorPersonalBL().ListaTodosActivo(IdAccidente);
                if (lstAccidenteFactorPersonal.Count > 0)
                {
                    if (lstAccidenteFactorPersonal.Count == 1)
                    {
                        xlHoja.Cells[40, "B"] = lstAccidenteFactorPersonal[0].DescFactorPersonal;
                    }

                    if (lstAccidenteFactorPersonal.Count == 2)
                    {
                        xlHoja.Cells[40, "B"] = lstAccidenteFactorPersonal[0].DescFactorPersonal;
                        xlHoja.Cells[41, "B"] = lstAccidenteFactorPersonal[1].DescFactorPersonal;
                    }

                    if (lstAccidenteFactorPersonal.Count == 3)
                    {
                        xlHoja.Cells[40, "B"] = lstAccidenteFactorPersonal[0].DescFactorPersonal;
                        xlHoja.Cells[41, "B"] = lstAccidenteFactorPersonal[1].DescFactorPersonal;
                        xlHoja.Cells[42, "B"] = lstAccidenteFactorPersonal[2].DescFactorPersonal;
                    }
                }

                //FACTOR TRABAJO
                List<AccidenteFactorTrabajoBE> lstAccidenteFactorTrabajo = null;
                lstAccidenteFactorTrabajo = new AccidenteFactorTrabajoBL().ListaTodosActivo(IdAccidente);
                if (lstAccidenteFactorTrabajo.Count > 0)
                {
                    if (lstAccidenteFactorTrabajo.Count == 1)
                    {
                        xlHoja.Cells[40, "J"] = lstAccidenteFactorTrabajo[0].DescFactorTrabajo;
                    }

                    if (lstAccidenteFactorTrabajo.Count == 2)
                    {
                        xlHoja.Cells[40, "J"] = lstAccidenteFactorTrabajo[0].DescFactorTrabajo;
                        xlHoja.Cells[41, "J"] = lstAccidenteFactorTrabajo[1].DescFactorTrabajo;
                    }

                    if (lstAccidenteFactorTrabajo.Count == 3)
                    {
                        xlHoja.Cells[40, "J"] = lstAccidenteFactorTrabajo[0].DescFactorTrabajo;
                        xlHoja.Cells[41, "J"] = lstAccidenteFactorTrabajo[1].DescFactorTrabajo;
                        xlHoja.Cells[42, "J"] = lstAccidenteFactorTrabajo[2].DescFactorTrabajo;
                    }
                }

                //MEDIDA DE PREVENCION
                List<AccidenteMedidaPrevencionBE> lstAccidenteMedidaPrevencion = null;
                lstAccidenteMedidaPrevencion = new AccidenteMedidaPrevencionBL().ListaTodosActivo(IdAccidente);
                if (lstAccidenteMedidaPrevencion.Count > 0)
                {
                    if (lstAccidenteMedidaPrevencion.Count == 1)
                    {
                        xlHoja.Cells[44, "A"] = lstAccidenteMedidaPrevencion[0].DescMedidaPrevencion;
                    }

                    if (lstAccidenteMedidaPrevencion.Count == 2)
                    {
                        xlHoja.Cells[44, "A"] = lstAccidenteMedidaPrevencion[0].DescMedidaPrevencion;
                        xlHoja.Cells[45, "A"] = lstAccidenteMedidaPrevencion[1].DescMedidaPrevencion;
                    }

                    if (lstAccidenteMedidaPrevencion.Count == 3)
                    {
                        xlHoja.Cells[44, "A"] = lstAccidenteMedidaPrevencion[0].DescMedidaPrevencion;
                        xlHoja.Cells[45, "A"] = lstAccidenteMedidaPrevencion[1].DescMedidaPrevencion;
                        xlHoja.Cells[46, "A"] = lstAccidenteMedidaPrevencion[2].DescMedidaPrevencion;
                    }
                }

                //ACCION CORRECTIVA
                List<AccidenteAccionCorrectivaBE> lstAccidenteAccionCorrectiva = null;
                lstAccidenteAccionCorrectiva = new AccidenteAccionCorrectivaBL().ListaTodosActivo(IdAccidente);
                if (lstAccidenteAccionCorrectiva.Count > 0)
                {
                    if (lstAccidenteAccionCorrectiva.Count == 1)
                    {
                        xlHoja.Cells[50, "A"] = lstAccidenteAccionCorrectiva[0].DescAccionCorrectiva;
                        xlHoja.Cells[50, "J"] = lstAccidenteAccionCorrectiva[0].Responsable;
                        xlHoja.Cells[50, "L"] = lstAccidenteAccionCorrectiva[0].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[50, "N"] = lstAccidenteAccionCorrectiva[0].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Green;
                        }
                    }

                    if (lstAccidenteAccionCorrectiva.Count == 2)
                    {
                        xlHoja.Cells[50, "A"] = lstAccidenteAccionCorrectiva[0].DescAccionCorrectiva;
                        xlHoja.Cells[50, "J"] = lstAccidenteAccionCorrectiva[0].Responsable;
                        xlHoja.Cells[50, "L"] = lstAccidenteAccionCorrectiva[0].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[50, "N"] = lstAccidenteAccionCorrectiva[0].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Green;
                        }


                        xlHoja.Cells[51, "A"] = lstAccidenteAccionCorrectiva[1].DescAccionCorrectiva;
                        xlHoja.Cells[51, "J"] = lstAccidenteAccionCorrectiva[1].Responsable;
                        xlHoja.Cells[51, "L"] = lstAccidenteAccionCorrectiva[1].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[51, "N"] = lstAccidenteAccionCorrectiva[1].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Green;
                        }
                    }

                    if (lstAccidenteAccionCorrectiva.Count == 3)
                    {
                        xlHoja.Cells[50, "A"] = lstAccidenteAccionCorrectiva[0].DescAccionCorrectiva;
                        xlHoja.Cells[50, "J"] = lstAccidenteAccionCorrectiva[0].Responsable;
                        xlHoja.Cells[50, "L"] = lstAccidenteAccionCorrectiva[0].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[50, "N"] = lstAccidenteAccionCorrectiva[0].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Green;
                        }


                        xlHoja.Cells[51, "A"] = lstAccidenteAccionCorrectiva[1].DescAccionCorrectiva;
                        xlHoja.Cells[51, "J"] = lstAccidenteAccionCorrectiva[1].Responsable;
                        xlHoja.Cells[51, "L"] = lstAccidenteAccionCorrectiva[1].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[51, "N"] = lstAccidenteAccionCorrectiva[1].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[52, "A"] = lstAccidenteAccionCorrectiva[2].DescAccionCorrectiva;
                        xlHoja.Cells[52, "J"] = lstAccidenteAccionCorrectiva[2].Responsable;
                        xlHoja.Cells[52, "L"] = lstAccidenteAccionCorrectiva[2].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[52, "N"] = lstAccidenteAccionCorrectiva[2].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Green;
                        }

                    }

                    if (lstAccidenteAccionCorrectiva.Count == 4)
                    {
                        xlHoja.Cells[50, "A"] = lstAccidenteAccionCorrectiva[0].DescAccionCorrectiva;
                        xlHoja.Cells[50, "J"] = lstAccidenteAccionCorrectiva[0].Responsable;
                        xlHoja.Cells[50, "L"] = lstAccidenteAccionCorrectiva[0].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[50, "N"] = lstAccidenteAccionCorrectiva[0].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Green;
                        }


                        xlHoja.Cells[51, "A"] = lstAccidenteAccionCorrectiva[1].DescAccionCorrectiva;
                        xlHoja.Cells[51, "J"] = lstAccidenteAccionCorrectiva[1].Responsable;
                        xlHoja.Cells[51, "L"] = lstAccidenteAccionCorrectiva[1].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[51, "N"] = lstAccidenteAccionCorrectiva[1].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[52, "A"] = lstAccidenteAccionCorrectiva[2].DescAccionCorrectiva;
                        xlHoja.Cells[52, "J"] = lstAccidenteAccionCorrectiva[2].Responsable;
                        xlHoja.Cells[52, "L"] = lstAccidenteAccionCorrectiva[2].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[52, "N"] = lstAccidenteAccionCorrectiva[2].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[53, "A"] = lstAccidenteAccionCorrectiva[3].DescAccionCorrectiva;
                        xlHoja.Cells[53, "J"] = lstAccidenteAccionCorrectiva[3].Responsable;
                        xlHoja.Cells[53, "L"] = lstAccidenteAccionCorrectiva[3].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[53, "N"] = lstAccidenteAccionCorrectiva[3].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Green;
                        }

                    }

                    if (lstAccidenteAccionCorrectiva.Count == 5)
                    {
                        xlHoja.Cells[50, "A"] = lstAccidenteAccionCorrectiva[0].DescAccionCorrectiva;
                        xlHoja.Cells[50, "J"] = lstAccidenteAccionCorrectiva[0].Responsable;
                        xlHoja.Cells[50, "L"] = lstAccidenteAccionCorrectiva[0].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[50, "N"] = lstAccidenteAccionCorrectiva[0].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Green;
                        }


                        xlHoja.Cells[51, "A"] = lstAccidenteAccionCorrectiva[1].DescAccionCorrectiva;
                        xlHoja.Cells[51, "J"] = lstAccidenteAccionCorrectiva[1].Responsable;
                        xlHoja.Cells[51, "L"] = lstAccidenteAccionCorrectiva[1].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[51, "N"] = lstAccidenteAccionCorrectiva[1].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[52, "A"] = lstAccidenteAccionCorrectiva[2].DescAccionCorrectiva;
                        xlHoja.Cells[52, "J"] = lstAccidenteAccionCorrectiva[2].Responsable;
                        xlHoja.Cells[52, "L"] = lstAccidenteAccionCorrectiva[2].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[52, "N"] = lstAccidenteAccionCorrectiva[2].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[53, "A"] = lstAccidenteAccionCorrectiva[3].DescAccionCorrectiva;
                        xlHoja.Cells[53, "J"] = lstAccidenteAccionCorrectiva[3].Responsable;
                        xlHoja.Cells[53, "L"] = lstAccidenteAccionCorrectiva[3].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[53, "N"] = lstAccidenteAccionCorrectiva[3].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[54, "A"] = lstAccidenteAccionCorrectiva[4].DescAccionCorrectiva;
                        xlHoja.Cells[54, "J"] = lstAccidenteAccionCorrectiva[4].Responsable;
                        xlHoja.Cells[54, "L"] = lstAccidenteAccionCorrectiva[4].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[54, "N"] = lstAccidenteAccionCorrectiva[4].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[4].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N54"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[4].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N54"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[4].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N54"].Interior.Color = Color.Green;
                        }
                    }

                    if (lstAccidenteAccionCorrectiva.Count == 6)
                    {
                        xlHoja.Cells[50, "A"] = lstAccidenteAccionCorrectiva[0].DescAccionCorrectiva;
                        xlHoja.Cells[50, "J"] = lstAccidenteAccionCorrectiva[0].Responsable;
                        xlHoja.Cells[50, "L"] = lstAccidenteAccionCorrectiva[0].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[50, "N"] = lstAccidenteAccionCorrectiva[0].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Green;
                        }


                        xlHoja.Cells[51, "A"] = lstAccidenteAccionCorrectiva[1].DescAccionCorrectiva;
                        xlHoja.Cells[51, "J"] = lstAccidenteAccionCorrectiva[1].Responsable;
                        xlHoja.Cells[51, "L"] = lstAccidenteAccionCorrectiva[1].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[51, "N"] = lstAccidenteAccionCorrectiva[1].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[52, "A"] = lstAccidenteAccionCorrectiva[2].DescAccionCorrectiva;
                        xlHoja.Cells[52, "J"] = lstAccidenteAccionCorrectiva[2].Responsable;
                        xlHoja.Cells[52, "L"] = lstAccidenteAccionCorrectiva[2].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[52, "N"] = lstAccidenteAccionCorrectiva[2].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[53, "A"] = lstAccidenteAccionCorrectiva[3].DescAccionCorrectiva;
                        xlHoja.Cells[53, "J"] = lstAccidenteAccionCorrectiva[3].Responsable;
                        xlHoja.Cells[53, "L"] = lstAccidenteAccionCorrectiva[3].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[53, "N"] = lstAccidenteAccionCorrectiva[3].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[54, "A"] = lstAccidenteAccionCorrectiva[4].DescAccionCorrectiva;
                        xlHoja.Cells[54, "J"] = lstAccidenteAccionCorrectiva[4].Responsable;
                        xlHoja.Cells[54, "L"] = lstAccidenteAccionCorrectiva[4].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[54, "N"] = lstAccidenteAccionCorrectiva[4].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[4].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N54"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[4].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N54"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[4].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N54"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[55, "A"] = lstAccidenteAccionCorrectiva[5].DescAccionCorrectiva;
                        xlHoja.Cells[55, "J"] = lstAccidenteAccionCorrectiva[5].Responsable;
                        xlHoja.Cells[55, "L"] = lstAccidenteAccionCorrectiva[5].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[55, "N"] = lstAccidenteAccionCorrectiva[5].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[5].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N55"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[5].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N55"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[5].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N55"].Interior.Color = Color.Green;
                        }
                    }

                    if (lstAccidenteAccionCorrectiva.Count == 7)
                    {
                        xlHoja.Cells[50, "A"] = lstAccidenteAccionCorrectiva[0].DescAccionCorrectiva;
                        xlHoja.Cells[50, "J"] = lstAccidenteAccionCorrectiva[0].Responsable;
                        xlHoja.Cells[50, "L"] = lstAccidenteAccionCorrectiva[0].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[50, "N"] = lstAccidenteAccionCorrectiva[0].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[0].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N50"].Interior.Color = Color.Green;
                        }


                        xlHoja.Cells[51, "A"] = lstAccidenteAccionCorrectiva[1].DescAccionCorrectiva;
                        xlHoja.Cells[51, "J"] = lstAccidenteAccionCorrectiva[1].Responsable;
                        xlHoja.Cells[51, "L"] = lstAccidenteAccionCorrectiva[1].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[51, "N"] = lstAccidenteAccionCorrectiva[1].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[1].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N51"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[52, "A"] = lstAccidenteAccionCorrectiva[2].DescAccionCorrectiva;
                        xlHoja.Cells[52, "J"] = lstAccidenteAccionCorrectiva[2].Responsable;
                        xlHoja.Cells[52, "L"] = lstAccidenteAccionCorrectiva[2].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[52, "N"] = lstAccidenteAccionCorrectiva[2].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[2].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N52"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[53, "A"] = lstAccidenteAccionCorrectiva[3].DescAccionCorrectiva;
                        xlHoja.Cells[53, "J"] = lstAccidenteAccionCorrectiva[3].Responsable;
                        xlHoja.Cells[53, "L"] = lstAccidenteAccionCorrectiva[3].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[53, "N"] = lstAccidenteAccionCorrectiva[3].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[3].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N53"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[54, "A"] = lstAccidenteAccionCorrectiva[4].DescAccionCorrectiva;
                        xlHoja.Cells[54, "J"] = lstAccidenteAccionCorrectiva[4].Responsable;
                        xlHoja.Cells[54, "L"] = lstAccidenteAccionCorrectiva[4].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[54, "N"] = lstAccidenteAccionCorrectiva[4].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[4].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N54"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[4].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N54"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[4].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N54"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[55, "A"] = lstAccidenteAccionCorrectiva[5].DescAccionCorrectiva;
                        xlHoja.Cells[55, "J"] = lstAccidenteAccionCorrectiva[5].Responsable;
                        xlHoja.Cells[55, "L"] = lstAccidenteAccionCorrectiva[5].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[55, "N"] = lstAccidenteAccionCorrectiva[5].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[5].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N55"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[5].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N55"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[5].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N55"].Interior.Color = Color.Green;
                        }

                        xlHoja.Cells[56, "A"] = lstAccidenteAccionCorrectiva[6].DescAccionCorrectiva;
                        xlHoja.Cells[56, "J"] = lstAccidenteAccionCorrectiva[6].Responsable;
                        xlHoja.Cells[56, "L"] = lstAccidenteAccionCorrectiva[6].FechaCumplimiento.ToShortDateString();
                        xlHoja.Cells[56, "N"] = lstAccidenteAccionCorrectiva[6].DescSituacion;

                        if (lstAccidenteAccionCorrectiva[6].DescSituacion == "PENDIENTE")
                        {
                            xlHoja.Range["N56"].Interior.Color = Color.Red;
                        }

                        if (lstAccidenteAccionCorrectiva[6].DescSituacion == "PROCESO")
                        {
                            xlHoja.Range["N56"].Interior.Color = Color.Yellow;
                        }

                        if (lstAccidenteAccionCorrectiva[6].DescSituacion == "EJECUTADO")
                        {
                            xlHoja.Range["N56"].Interior.Color = Color.Green;
                        }
                    }
                }

                //TESTIGOS
                List<AccidenteTestigoBE> lstAccidenteTestigo = null;
                lstAccidenteTestigo = new AccidenteTestigoBL().ListaTodosActivo(IdAccidente);
                if (lstAccidenteTestigo.Count > 0)
                {
                    if (lstAccidenteTestigo.Count == 1)
                    {
                        xlHoja.Cells[57, "A"] = lstAccidenteTestigo[0].Testigo;
                    }

                    if (lstAccidenteTestigo.Count == 2)
                    {
                        xlHoja.Cells[57, "A"] = lstAccidenteTestigo[0].Testigo;
                        xlHoja.Cells[58, "A"] = lstAccidenteTestigo[1].Testigo;
                    }

                    if (lstAccidenteTestigo.Count == 3)
                    {
                        xlHoja.Cells[57, "A"] = lstAccidenteTestigo[0].Testigo;
                        xlHoja.Cells[58, "A"] = lstAccidenteTestigo[1].Testigo;
                        xlHoja.Cells[59, "A"] = lstAccidenteTestigo[2].Testigo;
                    }
                }

                //ENTREVISTADOS
                List<AccidenteEntrevistadoBE> lstAccidenteEntrevistado = null;
                lstAccidenteEntrevistado = new AccidenteEntrevistadoBL().ListaTodosActivo(IdAccidente);
                if (lstAccidenteEntrevistado.Count > 0)
                {
                    if (lstAccidenteEntrevistado.Count == 1)
                    {
                        xlHoja.Cells[57, "J"] = lstAccidenteEntrevistado[0].Entrevistado;
                    }

                    if (lstAccidenteEntrevistado.Count == 2)
                    {
                        xlHoja.Cells[57, "J"] = lstAccidenteEntrevistado[0].Entrevistado;
                        xlHoja.Cells[58, "J"] = lstAccidenteEntrevistado[1].Entrevistado;
                    }

                    if (lstAccidenteEntrevistado.Count == 3)
                    {
                        xlHoja.Cells[57, "J"] = lstAccidenteEntrevistado[0].Entrevistado;
                        xlHoja.Cells[58, "J"] = lstAccidenteEntrevistado[1].Entrevistado;
                        xlHoja.Cells[59, "J"] = lstAccidenteEntrevistado[2].Entrevistado;
                    }
                }

                string strMensaje = "";

                if (IdTipo == Parametros.intTIAccidente)
                {
                    xlLibro.SaveAs("D:\\" + objE_Accidente.DescTipo + " " + strNumero + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    strMensaje = "El Formato de Accidente de Trabajo se exportó correctamente \n Se generó el archivo D:\\ACCIDENTE" + strNumero + ".xlsx";
                }
                if (IdTipo == Parametros.intTIIncidente)
                {
                    xlLibro.SaveAs("D:\\INCIDENTE " + strNumero + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    strMensaje = "El Formato de Incidente de Trabajo se exportó correctamente \n Se generó el archivo D:\\INCIDENTE" + strNumero + ".xlsx";
                }
                if (IdTipo == Parametros.intTIIncidentePeligroso)
                {
                    xlLibro.SaveAs("D:\\INCIDENTE PELIGROSO " + strNumero + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    strMensaje = "El Formato de Incidente Peligroso de Trabajo se exportó correctamente \n Se generó el archivo D:\\INCIDENTE PELIGROSO" + strNumero + ".xlsx";
                }

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;

                if (bMensaje)
                {
                    XtraMessageBox.Show(strMensaje, "Accidente de Trabajo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
            catch (Exception ex)
            {
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
