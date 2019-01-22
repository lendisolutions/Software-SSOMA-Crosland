using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.LookAndFeel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SSOMA.Presentacion;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Criptografia;
using System.Security.Principal;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Modulos.Accidente.Rpt;

namespace SSOMA.Presentacion.Inicio
{
    public partial class frmIDE : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        Ribbon _ribbon;

        bool bEnviarCorreoAccionCorrectiva = true;

        public frmIDE()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("Office 2007 Blue");
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Money Twins");
        }

        void _ribbon_RibbonClick(string menuCodigo, string ensamblado, string modoCarga, string titulo, string clase)
        {
            try
            {
                Application.DoEvents();
                //Application.EnableVisualStyles();

                if (ensamblado == "")
                {
                    MessageBox.Show("Objeto no implementado en la Base de Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (modoCarga == "1")
                {
                    //if (!FormCheched(titulo))
                    //{
                        Cursor = Cursors.WaitCursor;
                        //RibbonForm f = new RibbonForm();
                        XtraForm f = new XtraForm();
                        //f = (RibbonForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f = (XtraForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f.MdiParent = this;
                        f.Text = titulo;
                        f.Tag = ensamblado;
                        f.Show();
                        Cursor = Cursors.Default;
                    //}
                }

                if (modoCarga == "2")
                {
                    //if (!FormCheched(titulo))
                    //{
                        Cursor = Cursors.WaitCursor;
                        //RibbonForm f = new RibbonForm();
                        XtraForm f = new XtraForm();
                        //f = (RibbonForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f = (XtraForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f.MdiParent = this;
                        f.Text = titulo;
                        f.Tag = ensamblado;
                        f.WindowState = FormWindowState.Maximized;
                        f.Show();
                        Cursor = Cursors.Default;
                    //}
                }

                if (modoCarga == "9")
                {
                    //if (!FormCheched(titulo))
                    //{
                        Cursor = Cursors.WaitCursor;
                        //RibbonForm f = new RibbonForm();
                        XtraForm f = new XtraForm();
                        //f = (RibbonForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f = (XtraForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ensamblado);
                        f.Text = titulo;
                        f.Tag = ensamblado;
                        f.Show();
                        Cursor = Cursors.Default;
                    //}
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void frmIDE_Load(object sender, EventArgs e)
        {
            //frmImage f = new frmImage();
            //f.MdiParent = this;
            //f.WindowState = FormWindowState.Maximized;
            //f.Show();

            //comprobamos si se han pasado parámetros 
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                tmr_ExintorPorVencer.Enabled = true;
                tmr_ExintorPorVencer.Start();
                //String[] parametros = Environment.GetCommandLineArgs();

                string srtUsuario = Environment.GetCommandLineArgs()[1];
                string srtClave = Environment.GetCommandLineArgs()[2];
                string srtNombre = Environment.GetCommandLineArgs()[3];
                string srtCodUnidadP = Environment.GetCommandLineArgs()[4];
                string srtCodCentroP = Environment.GetCommandLineArgs()[5];

                //srtUsuario = parametros[0].ToString();
                //srtClave = parametros[1].ToString();
                //srtNombre = parametros[2].ToString();
                //srtCodUnidadP = parametros[3].ToString();
                //srtCodCentroP = parametros[4].ToString();

                //for (int i = 0; i < parametros.Length; i++)
                //{
                //    MessageBox.Show("Parámetro " + parametros[i]);
                //}

                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = Parametros.Key;
                objCrypto.IV = Parametros.IV;

                string _password = objCrypto.CifrarCadena(srtClave);
                UsuarioBE objE_Usuario = new UsuarioBL().LogOnUser(srtUsuario.Trim(), _password);
                if (objE_Usuario != null)
                {
                    UnidadMineraBE objE_UnidadMinera = null;
                    objE_UnidadMinera = new UnidadMineraBL().SeleccionaParametros(srtCodUnidadP, srtCodCentroP);
                    if (objE_UnidadMinera != null)
                    {
                        List<UsuarioUnidadMineraBE> lstUsuarioUnidadMinera = null;
                        lstUsuarioUnidadMinera = new UsuarioUnidadMineraBL().ListaEmpresaUnidadUusuario(objE_UnidadMinera.IdEmpresa, objE_UnidadMinera.IdUnidadMinera, objE_Usuario.IdUser);
                        if (lstUsuarioUnidadMinera.Count == 0)
                        {
                            XtraMessageBox.Show("El usuario no tiene permiso para ver la unidad seleccionada", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        Parametros.intPerfilId = objE_Usuario.IdPerfil;
                        Parametros.strNomPerfil = objE_Usuario.DescPerfil;
                        Parametros.intEmpresaId = objE_UnidadMinera.IdEmpresa;
                        Parametros.intUnidadMineraId = objE_UnidadMinera.IdUnidadMinera;
                        Parametros.strEmpresaNombre = objE_UnidadMinera.RazonSocial;
                        Parametros.strUnidadNombre = objE_UnidadMinera.DescUnidadMinera;
                        Parametros.intUsuarioId = objE_Usuario.IdUser;
                        Parametros.strUsuarioLogin = objE_Usuario.Usuario;
                        Parametros.strUsuarioNombres = objE_Usuario.Descripcion;

                        //Obtenemos todos los permisos del usuario logueado
                        Parametros.pListaPermisoAcceso = new AccesoUsuarioBL().SeleccionaPermisoAcceso(objE_Usuario.Usuario, objE_Usuario.IdPerfil).ToList();

                    }

                }
                else
                {
                    //Crear el usuario
                    Encrypt objCryptoUsuario = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                    objCryptoUsuario.Key = Parametros.Key;
                    objCryptoUsuario.IV = Parametros.IV;
                    string Password = "";
                    Password = objCryptoUsuario.CifrarCadena(srtClave);

                    UsuarioBL objBL_Usuario = new UsuarioBL();
                    UsuarioBE objUsuario = new UsuarioBE();

                    UnidadMineraBE objE_UnidadMinera = null;
                    objE_UnidadMinera = new UnidadMineraBL().SeleccionaParametros(srtCodUnidadP, srtCodCentroP);

                    objUsuario.IdEmpresa = objE_UnidadMinera.IdEmpresa;
                    objUsuario.IdPerfil = 3;
                    objUsuario.Descripcion = srtNombre;
                    objUsuario.Usuario = srtUsuario;
                    objUsuario.Password = Password;
                    objUsuario.FlagMaster = false;
                    objUsuario.FlagEstado = true;
                    objUsuario.UsuarioCrea = "master";
                    objUsuario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objUsuario.IdEmpresa = objE_UnidadMinera.IdEmpresa;

                    //traemos los acceso del perfil de solo lectura
                    List<AccesoBE> pListaAcceso = new List<AccesoBE>();
                    List<AccesoUsuarioBE> pListaAccesoUsuario = new List<AccesoUsuarioBE>();
                    List<UsuarioUnidadMineraBE> pListaUsuarioUnidadMinera = new List<UsuarioUnidadMineraBE>();

                    pListaAcceso = new AccesoBL().SeleccionaPerfil(3);

                    foreach (AccesoBE item in pListaAcceso)
                    {
                        AccesoUsuarioBE accesousuario = null;
                        accesousuario = new AccesoUsuarioBE();
                        accesousuario.IdUser = 0;
                        accesousuario.IdPerfil = 3;
                        accesousuario.IdMenu = item.IdMenu;
                        accesousuario.FlagLectura = item.FlagLectura;
                        accesousuario.FlagAdicion = item.FlagAdicion;
                        accesousuario.FlagActualizacion = item.FlagActualizacion;
                        accesousuario.FlagEliminacion = item.FlagEliminacion;
                        accesousuario.FlagImpresion = item.FlagImpresion;
                        accesousuario.FlagEstado = item.FlagEstado;
                        accesousuario.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                        pListaAccesoUsuario.Add(accesousuario);
                    }

                    //Acceso de lectura a todas las unidades de la empresa
                    List<UnidadMineraBE> lstUnidadMinera = null;
                    lstUnidadMinera = new UnidadMineraBL().ListaTodosActivo(0);

                    foreach (var item in lstUnidadMinera)
	                {
		                UsuarioUnidadMineraBE objE_UsuarioUnidadMinera = null;
                        objE_UsuarioUnidadMinera = new UsuarioUnidadMineraBE();
                        objE_UsuarioUnidadMinera.IdUsuarioUnidadMinera = 0;
                        objE_UsuarioUnidadMinera.IdEmpresa = item.IdEmpresa;
                        objE_UsuarioUnidadMinera.IdUser = 0;
                        objE_UsuarioUnidadMinera.IdUnidadMinera = item.IdUnidadMinera;
                        objE_UsuarioUnidadMinera.FlagEstado = true;
                        objE_UsuarioUnidadMinera.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                        pListaUsuarioUnidadMinera.Add(objE_UsuarioUnidadMinera);
	                }

                    objBL_Usuario.Inserta(objUsuario, pListaAccesoUsuario, pListaUsuarioUnidadMinera);

                    UsuarioBE objE_UsuarioLogueado = null;
                    objE_UsuarioLogueado = new UsuarioBL().SeleccionaUsuario(srtUsuario);
                    {

                        Parametros.intPerfilId = objE_UsuarioLogueado.IdPerfil;
                        Parametros.strNomPerfil = objE_UsuarioLogueado.DescPerfil;
                        Parametros.intEmpresaId = objE_UnidadMinera.IdEmpresa;
                        Parametros.intUnidadMineraId = objE_UnidadMinera.IdUnidadMinera;
                        Parametros.strEmpresaNombre = objE_UnidadMinera.RazonSocial;
                        Parametros.strUnidadNombre = objE_UnidadMinera.DescUnidadMinera;
                        Parametros.intUsuarioId = objE_UsuarioLogueado.IdUser;
                        Parametros.strUsuarioLogin = objE_UsuarioLogueado.Usuario;
                        Parametros.strUsuarioNombres = objE_UsuarioLogueado.Descripcion;

                        //Obtenemos todos los permisos del usuario logueado
                        Parametros.pListaPermisoAcceso = new AccesoUsuarioBL().SeleccionaPermisoAcceso(objE_UsuarioLogueado.Usuario, objE_UsuarioLogueado.IdPerfil).ToList();
                    }
                }

                //Aqui se carga los menus del usuario en el Control Ribbon
                _ribbon = new Ribbon(this.ribbon, new AccesoUsuarioBL().SeleccionaUser(Parametros.intUsuarioId).ToList());
                _ribbon.Fill();
                _ribbon.RibbonClick += new Ribbon.delegateRibbonClick(_ribbon_RibbonClick);

                //Carga el Status Bar
                BarButtonItem stbButtonEmpresa = new DevExpress.XtraBars.BarButtonItem();
                stbButtonEmpresa.Caption = Parametros.strEmpresaNombre;

                BarButtonItem stbButtonTienda = new DevExpress.XtraBars.BarButtonItem();
                stbButtonTienda.Caption = "  UNIDAD : " + Parametros.strUnidadNombre;
                stbButtonTienda.Alignment = BarItemLinkAlignment.Left;

                BarButtonItem stbButtonUsuario = new DevExpress.XtraBars.BarButtonItem();
                stbButtonUsuario.Caption = "USUARIO : " + Parametros.strUsuarioNombres;
                stbButtonUsuario.Alignment = BarItemLinkAlignment.Right;

                ribbonStatusBar.ItemLinks.Add(stbButtonEmpresa);
                ribbonStatusBar.ItemLinks.Add(stbButtonTienda);
                ribbonStatusBar.ItemLinks.Add(stbButtonUsuario);

                if (Parametros.intPerfilId == 3)
                {
                    Cursor = Cursors.WaitCursor;
                    XtraForm form = new XtraForm();
                    form = (XtraForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("SSOMA.Presentacion.Modulos.SSOMABase.Registros.frmRegPlanilla");
                    form.MdiParent = this;
                    form.Text = "SSOMA-Base";
                    form.Tag = "SSOMA.Presentacion.Modulos.SSOMABase.Registros.frmRegPlanilla";
                    form.Show();
                    Cursor = Cursors.Default;

                }
            }
            else
            {
                //MessageBox.Show("No se han pasado parámetros, sólo el de defecto: " +
                //Environment.NewLine + Environment.NewLine +
                //Environment.GetCommandLineArgs()[0], "Parámetros en C#",
                //MessageBoxButtons.OK, MessageBoxIcon.Information);

                tmr_ExintorPorVencer.Enabled = true;
                tmr_ExintorPorVencer.Start();

                //Cargamos el Login
                Application.DoEvents();
                frmLogin fLogin = new frmLogin();
                fLogin.Owner = this;
                fLogin.ShowDialog();
                if (fLogin.DialogResult == DialogResult.Yes)
                {


                    //Aqui se carga los menus del usuario en el Control Ribbon
                    _ribbon = new Ribbon(this.ribbon, new AccesoUsuarioBL().SeleccionaUser(Parametros.intUsuarioId).ToList());
                    _ribbon.Fill();
                    _ribbon.RibbonClick += new Ribbon.delegateRibbonClick(_ribbon_RibbonClick);

                    //Carga el Status Bar
                    BarButtonItem stbButtonEmpresa = new DevExpress.XtraBars.BarButtonItem();
                    stbButtonEmpresa.Caption = Parametros.strEmpresaNombre;

                    BarButtonItem stbButtonTienda = new DevExpress.XtraBars.BarButtonItem();
                    stbButtonTienda.Caption = "  UNIDAD : " + Parametros.strUnidadNombre;
                    stbButtonTienda.Alignment = BarItemLinkAlignment.Left;

                    BarButtonItem stbButtonUsuario = new DevExpress.XtraBars.BarButtonItem();
                    stbButtonUsuario.Caption = "USUARIO : " + Parametros.strUsuarioNombres;
                    stbButtonUsuario.Alignment = BarItemLinkAlignment.Right;

                    ribbonStatusBar.ItemLinks.Add(stbButtonEmpresa);
                    ribbonStatusBar.ItemLinks.Add(stbButtonTienda);
                    ribbonStatusBar.ItemLinks.Add(stbButtonUsuario);

                    //-------------------------------------------------------------------------------------------------------------------------------
                    fLogin.Close();
                    fLogin.Dispose();

                    //SOLAMENTE A EJECUCIÓN DE LOS ADMINISTRADORES
                    if (Parametros.intPerfilId == 1)
                    {
                        ActualizaPersonal();

                    }

                }
                else
                { Application.Exit(); };
            } 
            
        }

        public bool FormCheched(string titulo)
        {
            bool valor = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text == titulo)
                    valor = true;
                else
                    valor = false;
            }

            return valor;
        }

        private void frmIDE_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tmr_ExintorPorVencer_Tick(object sender, EventArgs e)
        {
            if ("10:00" == DateTime.Now.ToString("hh:mm") && Parametros.intPerfilId == 1)
            {
                if (bEnviarCorreoAccionCorrectiva)
                {
                    EnviarCorreoExtintorPorVencer();
                    EnviarCorreoAccionesCorrectivasVencidas();
                }
            }

            if ("05:05" == DateTime.Now.ToString("hh:mm") && Parametros.intPerfilId == 1)
            {
                if (bEnviarCorreoAccionCorrectiva)
                {
                    EnviarCorreoExtintorPorVencer();
                    EnviarCorreoAccionesCorrectivasVencidas();
                }
            }

            if ("06:00" == DateTime.Now.ToString("hh:mm") && Parametros.intPerfilId == 1)
            {
                if (bEnviarCorreoAccionCorrectiva)
                {
                    EnviarCorreoExtintorPorVencer();
                    EnviarCorreoAccionesCorrectivasVencidas();
                }
            }

        }

        private void EnviarCorreoExtintorPorVencer()
        {
            List<ExtintorBE> mLista = new List<ExtintorBE>();
            mLista = new ExtintorBL().ListaPorVencer(0, 0, 5);

            if (mLista.Count > 0)
            {
                StringBuilder strMensaje = new StringBuilder();
                strMensaje.Append("********************************************************************************************************************************************************************************\n\n");
                strMensaje.Append("Extintores Por Vencer en 5 dias " + "\n\n");

                foreach (var item in mLista)
                {
                    strMensaje.Append(item.RazonSocial + " - " + item.DescUnidadMinera + " - " + item.Codigo + " - " + item.Serie + " - " + item.Ubicacion + "\n");
                }
                strMensaje.Append("Emitido Por el Area de Seguridad y Salud en el Trabajo" + "\n\n");
                strMensaje.Append("********************************************************************************************************************************************************************************\n\n");

                string strMailTO = "";
                strMailTO = "jvillanueva@crosland.com.pe ; jmorillo@crosland.com.pe";

                BSUtils.EmailSend(strMailTO, "Control de Vencimientos de Extintores", strMensaje.ToString(), "","", "", "");
            }
        }

        private void EnviarCorreoAccionesCorrectivasVencidas()
        {
            try
            {
                List<ReporteAccidenteBE> mLista = null;
                mLista = new ReporteAccidenteBL().ListadoAccionCorrectivaVencida();

                if (mLista.Count > 0)
                {

                    var QueryDniResponsable =
                    from Cuotas in mLista
                    group Cuotas by Cuotas.DniResponsableAccionCorrectiva into newCuotas
                    orderby newCuotas.Key
                    select newCuotas;

                    foreach (var NumCap in QueryDniResponsable)
                    {

                        string strMail = "";
                        PersonaBE objE_Persona = null;
                        objE_Persona = new PersonaBL().SeleccionaNumeroDocumento(0,NumCap.Key);
                        if (objE_Persona != null)
                        {
                            strMail = objE_Persona.Email;
                        }

                        List<ReporteAccidenteBE> lstAccionCorrectivaVencidaResponsable = null;
                        lstAccionCorrectivaVencidaResponsable = new ReporteAccidenteBL().ListadoAccionCorrectivaVencidaResponsable(NumCap.Key);
                        if (lstAccionCorrectivaVencidaResponsable.Count > 0)
                        {
                            //GENERAR EL REPORTE EN PDF
                            rptAccidenteAccionCorrectivaVencida objReporte = new rptAccidenteAccionCorrectivaVencida();
                            objReporte.SetDataSource(lstAccionCorrectivaVencidaResponsable);
                            objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, @"D:\AccionesCorrectivasVencidas_" + NumCap.Key + ".pdf");

                            StringBuilder strMensaje = new StringBuilder();
                            strMensaje.Append("**************************************************************************************************************************\n\n");
                            strMensaje.Append("Se adjunta las Acciones Correctivas Vencidas Pendientes " + "\n\n");
                            strMensaje.Append("Comunicarse con el Area de Seguridad y Salud en el Trabajo" + "\n\n");
                            strMensaje.Append("**************************************************************************************************************************\n\n");

                            string strMailTO = "";
                            strMailTO = strMail;

                            BSUtils.EmailSend(strMailTO, "Acciones Correctivas Vencidas de Accidentes/Incidentes", strMensaje.ToString(), @"D:\AccionesCorrectivasVencidas_" + NumCap.Key + ".pdf","", "", "");
                        }
                    }

                    bEnviarCorreoAccionCorrectiva = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ActualizaPersonal()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<PersonaAdryanBE> lstPersonaAdrian = null;
                lstPersonaAdrian = new PersonaAdryanBL().ListaTodosActivo();

                List<PersonaBE> lstPersona = new List<PersonaBE>();

                foreach (var item in lstPersonaAdrian)
                {
                    
                    int intIdPersona = 0;
                    string strRuc = "";
                    string strRazonSocial = "";
                    int intIdEmpresa = 0;
                    string strDescNegocio = "";
                    int intIdNegocio = 0;
                    string strDescUnidadMinera = "";
                    int intIdUnidadMinera = 0;
                    string strDescArea = "";
                    int intIdArea = 0;
                    string strDni = "";
                    string strApeNom = "";
                    DateTime FechaNacimiento = new DateTime(2010, 1, 1);
                    string strEdad = "";
                    DateTime FechaIngreso = new DateTime(2000, 1, 1);
                    DateTime? FechaCese = null;
                    string strCargo = "";
                    string strSexo = "";
                    string strDescTipoContrato = "Incremento Actividad";
                    int intIdTipoContrato = 0;
                    string strDescEstadoCivil = "";
                    int intIdEstadoCivil = 0;
                    string strEmail = "";
                    int intIdSituacion = 0;

                    strRuc = item.RUC_EMPRESA;
                    EmpresaBE objE_Empresa = null;
                    objE_Empresa = new EmpresaBL().SeleccionaRuc(strRuc);
                    if (objE_Empresa != null)
                    {
                        intIdEmpresa = objE_Empresa.IdEmpresa;
                        strRazonSocial = objE_Empresa.RazonSocial;
                        strDescNegocio = item.UNIDAD;
                        NegocioBE objE_Negocio = null;
                        objE_Negocio = new NegocioBL().SeleccionaDescripcion(intIdEmpresa, strDescNegocio);
                        if (objE_Negocio != null)
                        {
                            intIdNegocio = objE_Negocio.IdNegocio;
                        }
                        else
                        {
                            intIdNegocio = Parametros.intPeriodo;
                        }

                        strDescUnidadMinera = item.UNIDAD;
                        if (strDescUnidadMinera.Trim() == "San Isidro")
                        {
                            strDescUnidadMinera = "SAN ISIDRO";
                        }

                        if (strDescUnidadMinera.Trim() == "Lima")
                        {
                            strDescUnidadMinera = "SAN ISIDRO";
                        }

                        if (strDescUnidadMinera.Trim() == "Callao")
                        {
                            strDescUnidadMinera = "CALLAO";
                        }

                        if (strDescUnidadMinera.Trim() == "Ancón")
                        {
                            strDescUnidadMinera = "ANCON";
                        }

                        if (strDescUnidadMinera.Trim() == "Oficina Cusco" || strDescUnidadMinera.Trim() == "Cusco")
                        {
                            strDescUnidadMinera = "CUZCO";
                        }

                        if (strDescUnidadMinera.Trim() == "Oficina Ollantaytambo" || strDescUnidadMinera.Trim() == "Ollantaytambo")
                        {
                            strDescUnidadMinera = "OLLANTAYTAMBO";
                        }

                        if (strDescUnidadMinera.Trim() == "Oficina Machu Picchu")
                        {
                            strDescUnidadMinera = "MACHU PICCHU";
                        }

                        if (strDescUnidadMinera.Trim() == "Oficina Aeropuerto LAP")
                        {
                            strDescUnidadMinera = "AEROPUERTO LAP";
                        }

                        UnidadMineraBE objE_UnidadMinera = null;
                        objE_UnidadMinera = new UnidadMineraBL().SeleccionaDescripcion(intIdEmpresa, strDescUnidadMinera);
                        if (objE_UnidadMinera != null)
                        {
                            intIdUnidadMinera = objE_UnidadMinera.IdUnidadMinera;
                        }
                        else
                        {
                            XtraMessageBox.Show("N° Secuencia : " + item.SECUENCIA.ToString() + "\n Unidad Minera: " + strDescUnidadMinera, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Cursor = Cursors.Default;
                            return;
                        }

                        strDescArea = item.AREA;

                        if (strDescArea == "")
                        {
                            strDescArea = "NINGUNO";
                        }

                        AreaBE objE_Area = null;
                        objE_Area = new AreaBL().SeleccionaDescripcion(intIdEmpresa, intIdUnidadMinera, strDescArea);
                        if (objE_Area != null)
                        {
                            intIdArea = objE_Area.IdArea;
                        }
                        else
                        {
                            XtraMessageBox.Show("N° Secuencia : " + item.SECUENCIA.ToString() + "\n Empresa: " + strRazonSocial + "\n Sede: " + strDescUnidadMinera + "\n Area: " + strDescArea, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Cursor = Cursors.Default;
                            return;
                        }

                        strDni = item.DNI;
                        strApeNom = item.APENOM;
                        FechaNacimiento = item.FECHA_NACIMIENTO;
                        strEdad = item.EDAD.ToString();
                        FechaIngreso = item.FECHA_INGRESO;
                        FechaCese = item.FECHA_RETIRO;
                        strCargo = item.PUESTO;

                        if (item.SEXO.Trim() == "F")
                            strSexo = "FEMENINO";
                        else
                            strSexo = "MASCULINO";

                        strDescTipoContrato = item.TIPO_CONTRATO;
                        TablaElementoBE objE_TablaElemento = null;
                        objE_TablaElemento = new TablaElementoBL().SeleccionaDescripcion(Parametros.intTblTipoContrato, strDescTipoContrato);
                        if (objE_TablaElemento != null)
                        {
                            intIdTipoContrato = objE_TablaElemento.IdTablaElemento;
                        }
                        else
                        {
                            XtraMessageBox.Show("N° Secuencia : " + item.SECUENCIA.ToString() + "\n Tipo de Contrato: " + strDescTipoContrato, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Cursor = Cursors.Default;
                            return;
                        }

                        strDescEstadoCivil = item.ESTADO_CIVIL;
                        string strTempEstadoCivil = "";
                        if (strDescEstadoCivil == "sol." || strDescEstadoCivil == "div.")
                        {
                            strTempEstadoCivil = "SOLTERO (A)";
                        }
                        if (strDescEstadoCivil == "cas.")
                        {
                            strTempEstadoCivil = "CASADO (A)";
                        }
                        if (strDescEstadoCivil == "Concu.")
                        {
                            strTempEstadoCivil = "CONVIVIENTE";
                        }
                        TablaElementoBE objE_TablaElementoCivil = null;
                        objE_TablaElementoCivil = new TablaElementoBL().SeleccionaDescripcion(Parametros.intTblEstadoCivil, strTempEstadoCivil);
                        if (objE_TablaElementoCivil != null)
                        {
                            intIdEstadoCivil = objE_TablaElementoCivil.IdTablaElemento;
                        }
                        else
                        {
                            XtraMessageBox.Show("N° Secuencia : " + item.SECUENCIA.ToString() + "\n Estado Civil: " + strDescEstadoCivil, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Cursor = Cursors.Default;
                            return;
                        }

                        strEmail = item.EMAIL_TRABAJO;

                        if (item.SITUACION.Trim() == "ACTIVO")
                            intIdSituacion = Parametros.intSPActivo;
                        else
                            intIdSituacion = Parametros.intSPCesado;


                        PersonaBE objE_Persona = new PersonaBE();
                        objE_Persona.IdPersona = intIdPersona;
                        objE_Persona.IdEmpresa = intIdEmpresa;
                        objE_Persona.IdNegocio = intIdNegocio;
                        objE_Persona.IdUnidadMinera = intIdUnidadMinera;
                        objE_Persona.IdArea = intIdArea;
                        objE_Persona.Dni = strDni;
                        objE_Persona.ApeNom = strApeNom;
                        objE_Persona.FechaNacimiento = FechaNacimiento;
                        objE_Persona.Edad = Convert.ToInt32(strEdad);
                        objE_Persona.FechaIngreso = FechaIngreso;
                        objE_Persona.FechaCese = FechaCese;
                        objE_Persona.Cargo = strCargo;
                        objE_Persona.Sexo = strSexo;
                        objE_Persona.IdTipoContrato = intIdTipoContrato;
                        objE_Persona.IdEstadoCivil = intIdEstadoCivil;
                        objE_Persona.Email = strEmail;
                        objE_Persona.IdSituacion = intIdSituacion;
                        objE_Persona.FlagEstado = true;
                        objE_Persona.Usuario = Parametros.strUsuarioLogin;
                        objE_Persona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        lstPersona.Add(objE_Persona);
                    }
                }
                    
                PersonaBL objBL_Persona = new PersonaBL();
                objBL_Persona.InsertaMasivo(lstPersona);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizaPersonalCesado()
        {
            try
            {
                List<PersonaAdryanBE> lstPersonaAdrian = null;
                lstPersonaAdrian = new PersonaAdryanBL().ListaTodosActivo();

                List<PersonaBE> lstPersona = new List<PersonaBE>();

                foreach (var item in lstPersonaAdrian)
                {
                    if (item.SITUACION == "CESADO")
                    {
                        int IdEmpresa = 0;
                        string strRuc = "";
                        string strDni = "";
                        DateTime FechaIngreso = new DateTime(2000, 1, 1);

                        strRuc = item.RUC_EMPRESA;
                        FechaIngreso = item.FECHA_INGRESO;
                        EmpresaBE objE_Empresa = null;
                        objE_Empresa = new EmpresaBL().SeleccionaRuc(strRuc);
                        if (objE_Empresa != null)
                        {
                            IdEmpresa = objE_Empresa.IdEmpresa;
                            strDni = item.DNI.Trim();
                            PersonaBE objE_Persona = null;
                            objE_Persona = new PersonaBL().SeleccionaNumeroDocumento(IdEmpresa, strDni);
                            if (objE_Persona != null)
                            {
                                PersonaBL objBL_Persona = new PersonaBL();
                                objBL_Persona.ActualizaSituacion(IdEmpresa,objE_Persona.Dni, Parametros.intSPCesado, FechaIngreso);
                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}