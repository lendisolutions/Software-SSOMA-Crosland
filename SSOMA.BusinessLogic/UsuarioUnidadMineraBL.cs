using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class UsuarioUnidadMineraBL
    {
        public List<UsuarioUnidadMineraBE> ListaTodosActivo(int IdEmpresa, int IdUser)
        {
            try
            {
                UsuarioUnidadMineraDL usuariounidadminera = new UsuarioUnidadMineraDL();
                return usuariounidadminera.ListaEmpresaUusuario(IdEmpresa, IdUser);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UsuarioUnidadMineraBE> ListaEmpresaUnidadUusuario(int IdEmpresa, int IdUnidadMinera, int IdUser)
        {
            try
            {
                UsuarioUnidadMineraDL usuariounidadminera = new UsuarioUnidadMineraDL();
                return usuariounidadminera.ListaEmpresaUnidadUusuario(IdEmpresa, IdUnidadMinera, IdUser);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UsuarioUnidadMineraBE> ListaUsuario(int IdUser)
        {
            try
            {
                UsuarioUnidadMineraDL usuariounidadminera = new UsuarioUnidadMineraDL();
                return usuariounidadminera.ListaUusuario(IdUser);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
