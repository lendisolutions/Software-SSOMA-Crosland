using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Criptografia;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.BusinessLogic;
using SSOMA.BusinessEntity;

namespace SSOMA.Presentacion.Modulos.Configuracion
{
    public partial class frmManUsuariosEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        List<AccesoUsuarioBE> pListaAccesoUsuario = new List<AccesoUsuarioBE>();
        List<UsuarioUnidadMineraBE> pListaUsuarioUnidadMinera = new List<UsuarioUnidadMineraBE>();
        List<AccesoBE> pListaAcceso = new List<AccesoBE>();

        string strEmail = "";

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public UsuarioBE pUsuarioBE { get; set; }

        bool find = false;

        int _IdPerfil = 0;

        public int IdPerfil
        {
            get { return _IdPerfil; }
            set { _IdPerfil = value; }
        }

        int _IdUser = 0;

        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }

        int menuID = 0;
       
        
        #endregion

        #region "Eventos"

        public frmManUsuariosEdit()
        {
            InitializeComponent();
        }

        private void frmManUsuariosEdit_Load(object sender, EventArgs e)
        {
            PopulateMenu(0, new MenuBL().ListaTodosActivo(), null);
            CargarUnidadNegocio();
            
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0,Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboPerfil, new PerfilBL().ListaTodosActivo(), "DescPerfil", "IdPerfil", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Usuario - Nuevo";
                txtPersona.Text = "";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = Parametros.Key;
                objCrypto.IV = Parametros.IV;

                this.Text = "Usuario - Modificar";
                txtUsuario.Text = pUsuarioBE.Usuario;
                txtPersona.Text = pUsuarioBE.Descripcion;
                txtPassword.Text = objCrypto.DescifrarCadena(pUsuarioBE.Password);
                cboEmpresa.EditValue = pUsuarioBE.IdEmpresa;
                cboPerfil.EditValue = pUsuarioBE.IdPerfil;
                chkMaster.EditValue = pUsuarioBE.FlagMaster;
                chkEstado.EditValue = pUsuarioBE.FlagEstado;

                PersonaBE objE_Persona = null;
                objE_Persona = new PersonaBL().SeleccionaDescripcion(Parametros.intEmpresaId, 0, 0, pUsuarioBE.Descripcion);
                if (objE_Persona != null)
                {
                    strEmail = objE_Persona.Email;
                }


            }

            chkEstado.Checked = true;

            AccessByUserPerfilID(IdUser, IdPerfil);
            AccessByUnidadMinera(IdUser);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                    objCrypto.Key = Parametros.Key;
                    objCrypto.IV = Parametros.IV;
                    string Password = "";
                    Password = objCrypto.CifrarCadena(this.txtPassword.Text.Trim());

                    UsuarioBL objBL_Usuario = new UsuarioBL();
                    UsuarioBE objUsuario = new UsuarioBE();
                   
                    objUsuario.IdEmpresa = int.Parse(cboEmpresa.EditValue.ToString());
                    objUsuario.IdPerfil = int.Parse(cboPerfil.EditValue.ToString());
                    objUsuario.Descripcion = txtPersona.Text.Trim();
                    objUsuario.Usuario = txtUsuario.Text.Trim();
                    objUsuario.Password = Password;
                    objUsuario.FlagMaster = chkMaster.Checked;
                    objUsuario.FlagEstado = chkEstado.Checked;
                    objUsuario.UsuarioCrea = Parametros.strUsuarioLogin;
                    objUsuario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objUsuario.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Usuario.Inserta(objUsuario, pListaAccesoUsuario, pListaUsuarioUnidadMinera);
                    }
                    else if (pOperacion == Operacion.Modificar)
                    {
                        objUsuario.IdUser = pUsuarioBE.IdUser;
                        objBL_Usuario.Actualiza(objUsuario, pListaAccesoUsuario, pListaUsuarioUnidadMinera);

                    }

                    StringBuilder strMensaje = new StringBuilder();
                    strMensaje.Append("*****************************************************************************\n\n");
                    strMensaje.Append("Se su nuevo acceso al software de Gestión SSOMA : " +  "\n\n");
                    strMensaje.Append("Usuario : "  + txtUsuario.Text + "\n\n");
                    strMensaje.Append("Clave : " + txtPassword.Text + "\n\n");
                    strMensaje.Append("Emitido Por el Area de Seguridad y Salud en el Trabajo" + "\n\n");
                    strMensaje.Append("*****************************************************************************\n\n");

                    string strMailTO = "";
                    strMailTO = strEmail;

                    BSUtils.EmailSend(strMailTO, "Acceso al Software de Gestión SSOMA", strMensaje.ToString(), "", "", "", "");

                    Application.DoEvents();

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckAllNodes(TreeNodeCollection col, Boolean check)
        {
            foreach (TreeNode tN in col)
            {
                tN.Checked = check;

                this.CheckAllNodes(tN.Nodes, check);
            }
        }

        //private void CheckNotNodes(TreeNodeCollection col, Boolean check)
        //{
        //    foreach (TreeNode tN in col)
        //    {
        //        if (tN.Checked == check)
        //        {
        //            if (tN.Parent == null)
        //            {
        //                tN.Parent.Checked = false;
        //            }
        //            this.CheckNotNodes(tN.Nodes, check);
        //        }

                
        //    }
        //}

        private void CheckNodes(TreeNodeCollection col, int menuID)
        {
            foreach (TreeNode tN in col)
            {
                string[] objectString = tN.Tag.ToString().Split(new char[] { ';' });

                if (Convert.ToInt32(objectString[0]) == menuID)
                {
                    tN.Checked = true;
                    if (tN.Parent != null)
                    {
                        tN.Parent.Checked = true;
                    }
                }
                this.CheckNodes(tN.Nodes, menuID);
            }
        }

        private void CheckNodes(TreeNodeCollection col, string IdUnidadNegocio)
        {
            foreach (TreeNode tN in col)
            {
                string[] objectString = tN.Tag.ToString().Split(new char[] { ',' });
                if (objectString[0].ToString() == IdUnidadNegocio)
                {
                    tN.Checked = true;
                    if (tN.Parent != null)
                    {
                        tN.Parent.Checked = true;
                    }
                }

                this.CheckNodes(tN.Nodes, IdUnidadNegocio);
            }
        }

        private void trwMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                //Para marcar y desmarcar todos los nodos            
                foreach (TreeNode oNodo in e.Node.Nodes)
                {
                    string[] objectString = oNodo.Tag.ToString().Split(new char[] { ';' });
                    //AGREGAR EL FLAG AQUI .....
                    if (find == false)
                        oNodo.Checked = e.Node.Checked;

                    //insertar en la lista solo las ventanas que es el ultimo nivel
                    if (e.Node.Checked == true)
                    {
                        //if (objectString[1] == "4")
                        //{
                        //AGREGAR EL FLAG AQUI .....
                        if (find == false)
                            AddMenu(Convert.ToInt32(objectString[0]));
                        //}
                    }
                    if (e.Node.Checked == false)
                    {
                        RemoveMenu(Convert.ToInt32(objectString[0]));
                    }
                }

                if (e.Node.Parent != null)
                {
                    string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });
                    //e.Node.Parent.Checked=true;
                    if (!e.Node.Checked == true)
                    {
                        //Desmarco
                        e.Node.Parent.NodeFont = new Font(this.trwMenu.Font, FontStyle.Regular);
                        RemoveMenu(Convert.ToInt32(objectString[0]));

                    }
                    else
                    {
                        e.Node.Parent.NodeFont = new Font(this.trwMenu.Font, FontStyle.Bold);
                        //AGREGAR EL FLAG AQUI .....
                        if (find == false)
                            AddMenu(Convert.ToInt32(objectString[0]));
                        //Marco
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trwMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });
                this.lblMenu.Text = e.Node.Text;
                menuID = Convert.ToInt32(objectString[0]);

                if (pListaAccesoUsuario.Count > 0)
                {
                    AccesoUsuarioBE Acceso = pListaAccesoUsuario.Find(delegate(AccesoUsuarioBE _Acc)
                    {
                        if (_Acc.IdMenu == menuID)
                        {
                            return true;
                        }
                        return false;
                    });

                    if (Acceso != null)
                    {
                        //Mostrar datos en los checkbox
                        this.chkAllowRead.Checked = Acceso.FlagLectura;
                        this.chkAllowWrite.Checked = Acceso.FlagAdicion; ;
                        this.chkAllowUpdate.Checked = Acceso.FlagActualizacion; ;
                        this.chkAllowDelete.Checked = Acceso.FlagEliminacion; ;
                        this.chkAllowPrint.Checked = Acceso.FlagImpresion; ;
                    }
                    else
                    {
                        this.chkAllowRead.Checked = false;
                        this.chkAllowWrite.Checked = false;
                        this.chkAllowUpdate.Checked = false;
                        this.chkAllowDelete.Checked = false;
                        this.chkAllowPrint.Checked = false;
                    }

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAllowRead_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AccesoUsuarioBE Acceso = pListaAccesoUsuario.Find(delegate(AccesoUsuarioBE _Acc)
                {
                    if (_Acc.IdMenu == menuID)
                    {
                        return true;
                    }
                    return false;
                });

                if (Acceso != null)
                {
                    CheckBox obj = new CheckBox();
                    obj = (CheckBox)sender;

                    AccesoUsuarioBE AccesoMenu = pListaAccesoUsuario.Find(delegate(AccesoUsuarioBE _Acc)
                    {
                        if (_Acc.IdMenu == menuID)
                        {
                            return true;
                        }
                        return false;
                    });

                    switch (obj.Name)
                    {
                        case "chkAllowRead":
                            if (IdUser == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagLectura = chkAllowRead.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagLectura = chkAllowRead.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }

                            break;
                        case "chkAllowWrite":
                            if (IdUser == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagAdicion = chkAllowWrite.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagAdicion = chkAllowWrite.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }

                            break;
                        case "chkAllowUpdate":
                            if (IdUser == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagActualizacion = chkAllowUpdate.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagActualizacion = chkAllowUpdate.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        case "chkAllowDelete":
                            if (IdUser == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagEliminacion = chkAllowDelete.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagEliminacion = chkAllowDelete.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        case "chkAllowPrint":
                            if (IdUser == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagImpresion = chkAllowPrint.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagImpresion = chkAllowPrint.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPerfil_EditValueChanged(object sender, EventArgs e)
        {
            AccessByPerfilID(int.Parse(cboPerfil.GetColumnValue("IdPerfil").ToString()));
        }

        private void tvwUnidadNegocio_AfterCheck(object sender, TreeViewEventArgs e)
        {

            //Para marcar y desmarcar todos los nodos            
            foreach (TreeNode oNodo in e.Node.Nodes)
            {
                string[] objectString = oNodo.Tag.ToString().Split(new char[] { ',' });

                if (find == false)
                    oNodo.Checked = e.Node.Checked;

                //insertar en el datatable solo las ventanas que es el ultimo nivel
                if (e.Node.Checked == true)
                {
                    if (find == false)
                    {

                        AgregarUnidadMinera(oNodo.Parent.Tag.ToString(),objectString[0]);
                    }
                        
                }
                if (e.Node.Checked == false)
                {
                    EliminarUnidadMinera(oNodo.Parent.Tag.ToString(),objectString[0]);
                }
            }

            if (e.Node.Parent != null)
            {
                string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });

                if (!e.Node.Checked == true)
                {
                    //Desmarco
                    e.Node.Parent.NodeFont = new Font(this.tvwUnidadNegocio.Font, FontStyle.Regular);
                    EliminarUnidadMinera(e.Node.Parent.Tag.ToString(), objectString[0]);
                }
                else
                {
                    e.Node.Parent.NodeFont = new Font(this.tvwUnidadNegocio.Font, FontStyle.Bold);
                    if (find == false)
                        AgregarUnidadMinera(e.Node.Parent.Tag.ToString(), objectString[0]);
                }
            }
        }

        #endregion
       
        #region "Metodos"

        public void PopulateMenu(int HijoID, List<MenuBE> pMenuAccess, TreeNode nodeParent)
        {
            try
            {
                var ListMenuHijos =
                    from p in pMenuAccess
                    where p.IdMenuPadre == HijoID
                    select p;

                foreach (var HijoMenu in ListMenuHijos)
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = HijoMenu.MenuDescripcion;
                    switch (HijoMenu.IdMenuTipo)
                    {
                        case 0:
                            newNode.ImageIndex = 0;
                            newNode.SelectedImageIndex = 0;
                            break;
                        default:
                            newNode.ImageIndex = 1;
                            newNode.SelectedImageIndex = 1;
                            break;
                    }

                    newNode.Tag = HijoMenu.IdMenu.ToString() + ";" + HijoMenu.IdMenuTipo.ToString();
                    if (nodeParent == null)
                    {
                        this.trwMenu.Nodes.Add(newNode);
                    }
                    else
                    {
                        nodeParent.Nodes.Add(newNode);
                    }
                    PopulateMenu(HijoMenu.IdMenu, pMenuAccess, newNode);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void AddMenu(int IdMenu)
        {
            var Buscar = pListaAccesoUsuario.Where(oB => oB.IdMenu == IdMenu).ToList();
            if (Buscar.Count > 0)
            {

            }
            else
            {
                AccesoUsuarioBE accesousuario = null;
                accesousuario = new AccesoUsuarioBE();
                accesousuario.IdUser = IdUser;
                accesousuario.IdPerfil = IdPerfil;
                accesousuario.IdMenu = IdMenu;
                accesousuario.FlagLectura = true;
                accesousuario.FlagAdicion = true;
                accesousuario.FlagActualizacion = true;
                accesousuario.FlagEliminacion = true;
                accesousuario.FlagImpresion = true;
                accesousuario.FlagEstado = true;
                accesousuario.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                pListaAccesoUsuario.Add(accesousuario);
            }
                
        }

        void RemoveMenu(int IdMenu)
        {
            //Borrar en bloque
            AccesoUsuarioBE Acceso = pListaAccesoUsuario.Find(delegate(AccesoUsuarioBE _Acc)
            {
                if (_Acc.IdMenu == IdMenu)
                {
                    return true;
                }
                return false;
            });
            if (Acceso != null)
            {
                if (Acceso.TipoOper == Convert.ToInt32(Operacion.Nuevo))
                { Acceso.TipoOper = Convert.ToInt32(Operacion.Consultar); }
                if (Acceso.TipoOper == Convert.ToInt32(Operacion.Modificar) || Acceso.TipoOper == Convert.ToInt32(Operacion.Consultar))
                    Acceso.TipoOper = Convert.ToInt32(Operacion.Eliminar);

            }

        }

        void AccessByPerfilID(int perfilID)
        {
            try
            {
                CheckAllNodes(this.trwMenu.Nodes, false);

                pListaAcceso = new AccesoBL().SeleccionaPerfil(perfilID);

                foreach (AccesoBE item in pListaAcceso)
                {
                    //AGREGAR EL FLAG AQUI .....
                    find = true;
                    CheckNodes(this.trwMenu.Nodes, item.IdMenu);
                }
                //AGREGAR EL FLAG AQUI .....
                find = false;

                //Llenamos la Lista de AccesoUsuario de acuerdo al perfil

                foreach (AccesoBE item in pListaAcceso)
                {
                    AccesoUsuarioBE accesousuario = null;
                    accesousuario = new AccesoUsuarioBE();
                    accesousuario.IdUser = IdUser;
                    accesousuario.IdPerfil = IdPerfil;
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

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AccessByUserPerfilID(int UserID, int perfilID)
        {
            try
            {
                CheckAllNodes(this.trwMenu.Nodes, false);

                pListaAccesoUsuario = new AccesoUsuarioBL().SeleccionaUserPerfil(UserID, perfilID);

                foreach (AccesoUsuarioBE item in pListaAccesoUsuario)
                {
                    //AGREGAR EL FLAG AQUI .....
                    find = true;
                    CheckNodes(this.trwMenu.Nodes, item.IdMenu);
                }
                //AGREGAR EL FLAG AQUI .....
                find = false;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AccessByUnidadMinera(int IdUser)
        {
            try
            {
                CheckAllNodes(this.tvwUnidadNegocio.Nodes, false);

                pListaUsuarioUnidadMinera = new UsuarioUnidadMineraBL().ListaUsuario(IdUser);

                foreach (UsuarioUnidadMineraBE item in pListaUsuarioUnidadMinera)
                {
                    //AGREGAR EL FLAG AQUI .....
                    find = true;
                    CheckNodes(this.tvwUnidadNegocio.Nodes, item.IdUnidadMinera.ToString());

                    //if (pOperacion == Operacion.Modificar)
                    //    CheckNotNodes(this.tvwUnidadNegocio.Nodes, false);
                }
                //AGREGAR EL FLAG AQUI .....
                find = false;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AgregarUnidadMinera(string IdEmpresa, string IdUnidadMinera)
        {
            var Buscar = pListaUsuarioUnidadMinera.Where(oB => oB.IdEmpresa.ToString() == IdEmpresa && oB.IdUnidadMinera.ToString() == IdUnidadMinera).ToList();
            if (Buscar.Count > 0)
            {

            }
            else
            {
                UsuarioUnidadMineraBE usuariounidadminera = null;
                usuariounidadminera = new UsuarioUnidadMineraBE();
                usuariounidadminera.IdUsuarioUnidadMinera = 0;
                usuariounidadminera.IdEmpresa = Convert.ToInt32(IdEmpresa);
                usuariounidadminera.IdUser = IdUser;
                usuariounidadminera.IdUnidadMinera = Convert.ToInt32(IdUnidadMinera);
                usuariounidadminera.FlagEstado = true;
                usuariounidadminera.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                pListaUsuarioUnidadMinera.Add(usuariounidadminera);
            }

        }

        void EliminarUnidadMinera(string IdEmpresa, string IdUnidadMinera)
        {
            //Borrar en bloque
            UsuarioUnidadMineraBE Acceso = pListaUsuarioUnidadMinera.Find(delegate(UsuarioUnidadMineraBE _Acc)
            {
                if (_Acc.IdEmpresa.ToString() == IdEmpresa && _Acc.IdUnidadMinera.ToString() == IdUnidadMinera)
                {
                    return true;
                }
                return false;
            });
            if (Acceso != null)
            {
                if (Acceso.TipoOper == Convert.ToInt32(Operacion.Nuevo))
                { Acceso.TipoOper = Convert.ToInt32(Operacion.Consultar); }
                if (Acceso.TipoOper == Convert.ToInt32(Operacion.Modificar) || Acceso.TipoOper == Convert.ToInt32(Operacion.Consultar))
                    Acceso.TipoOper = Convert.ToInt32(Operacion.Eliminar);

            }

        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (string.IsNullOrEmpty(cboEmpresa.Text))
            {
                XtraMessageBox.Show("Seleccione la empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEmpresa.Select();
                flag = true;
            }

            if (string.IsNullOrEmpty(cboPerfil.Text))
            {
                XtraMessageBox.Show("Seleccione el perfil", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboPerfil.Select();
                flag = true;
            }

            if (txtPersona.Text.ToString() == "")
            {
                XtraMessageBox.Show("Seleccione descripción del Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPersona.Select();
                flag = true;
            }

            if (txtUsuario.Text.ToString() == "")
            {
                XtraMessageBox.Show("Ingrese el Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Select();
                flag = true;
            }

            if (txtPassword.Text.ToString() == "")
            {
                XtraMessageBox.Show("Ingrese la clave del usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Select();
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        private void CargarUnidadNegocio()
        {
            tvwUnidadNegocio.Nodes.Clear();

            List<EmpresaBE> lstEmpresa = null;
            lstEmpresa = new EmpresaBL().ListaTodosActivo(0, Parametros.intTECorporativo);
            foreach (var item in lstEmpresa)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = item.RazonSocial;
                nuevoNodo.ImageIndex = 0;
                nuevoNodo.SelectedImageIndex = 0;
                nuevoNodo.Tag = item.IdEmpresa.ToString();
                tvwUnidadNegocio.Nodes.Add(nuevoNodo);

                List<UnidadMineraBE> lstUnidadMinera = null;
                lstUnidadMinera = new UnidadMineraBL().ListaTodosActivo(item.IdEmpresa);
                foreach (var itemunidad in lstUnidadMinera)
                {
                    TreeNode nuevoNodoChild = new TreeNode();
                    nuevoNodoChild.ImageIndex = 1;
                    nuevoNodoChild.SelectedImageIndex = 1;
                    nuevoNodoChild.Text = itemunidad.DescUnidadMinera;
                    nuevoNodoChild.Tag = itemunidad.IdUnidadMinera.ToString();
                    nuevoNodo.Nodes.Add(nuevoNodoChild);
                }
            }

            tvwUnidadNegocio.ExpandAll();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = false;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    txtPersona.Text = frm.pPersonaBE.ApeNom;

                    String[] strSolicitante = frm.pPersonaBE.ApeNom.Split(' ');
                    string strPrimerNombre = "";
                    string strSegundoNombre = "";
                    string strApellidoPaterno = "";
                    string strApellidoMaterno = "";

                    int intContardor = 0;
                    foreach (string item in strSolicitante)
                    {
                        intContardor++;
                    }

                    if (intContardor > 3)
                    {
                        strPrimerNombre = strSolicitante[2].ToString();
                        strSegundoNombre = strSolicitante[3].ToString();
                        strApellidoMaterno = strSolicitante[1].ToString();
                        strApellidoPaterno = strSolicitante[0].ToString();
                    }
                    else
                    {
                        strPrimerNombre = strSolicitante[2].ToString();
                        strApellidoMaterno = strSolicitante[1].ToString();
                        strApellidoPaterno = strSolicitante[0].ToString();
                    }



                    txtUsuario.Text = strPrimerNombre.Substring(0, 1) + strApellidoPaterno;

                    txtPassword.Text = frm.pPersonaBE.Dni.Trim();

                    strEmail = frm.pPersonaBE.Email;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void CargarUnidadNegocio()
        //{
        //    try
        //    {
        //        TreeNode _node = new TreeNode();
        //        _node.Text = "VOLCAN COMPAÑIA MINERA S.A.A";
        //        _node.Tag = "*";
        //        _node.ImageIndex = 0;
        //        _node.StateImageIndex = 0;
        //        _node.SelectedImageIndex = 0;

        //        this.tvwUnidadNegocio.Nodes.Add(_node);

        //        List<UnidadMineraBE> lstUnidadMinera = null;
        //        lstUnidadMinera = new UnidadMineraBL().ListaTodosActivo(Parametros.intEmpresaId);

        //        foreach (var item in lstUnidadMinera)
        //        {
        //            TreeNode _nodesf = new TreeNode();
        //            _nodesf.Text = item.DescUnidadMinera.ToString();
        //            _nodesf.Tag = item.IdUnidadMinera.ToString();
        //            _nodesf.ImageIndex = 1;
        //            _nodesf.SelectedImageIndex = 1;
        //            _nodesf.StateImageIndex = 1;
        //            _node.Nodes.Add(_nodesf);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + "\nMetodo : List()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        #endregion
        
    }
}