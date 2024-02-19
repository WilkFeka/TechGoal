using CapaDatos.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Security.Cryptography;
using System.Data;

namespace CapaControladora
{
    public class CC_Usuario
    {
        public static CC_Usuario instance = null;


        // -------------------- SINGLETON ---------------------

        public static CC_Usuario getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Usuario();
                return instance;
            }
        }

        // ---------------------- OBTENER TODOS LOS USUARIOS --------------------

        public List<Usuario> Listar()
        {
            List<Usuario> listaUsuarios = new CD_Usuario().Listar();

            return listaUsuarios;
            
        }

        // ---------------------- ENCONTRAR USUARIO EN LA LISTA POR CREDENCIALES OBTENIDAS--------------------

        public Usuario EncontrarUsuarioLogin (string Correo, string Clave)
        {
            //Filtrar usuarios por email y clave proporcionados
            Usuario usuarioIniciando = new CC_Usuario().Listar().Where(u => u.email == Correo && u.clave == Clave).FirstOrDefault();

            if (usuarioIniciando != null)
            {
                return usuarioIniciando;
            }
            else
            {
                return usuarioIniciando;
            }


        }

        // -------------------- ENCONTRAR SI EL CORREO YA ESTA EN USO ----------------

        public Usuario EncontrarUsuarioCorreo (string txtCorreo)
        {

            Usuario buscandoUsuario = new CC_Usuario().Listar().Where(u => u.email == txtCorreo).FirstOrDefault();

            if (buscandoUsuario != null)
            {
                return buscandoUsuario;
            }
            else
            {
                return buscandoUsuario;
            }


        }


        // ---------------- ENCONTRAR SI EL DNI YA ESTA EN USO -------------------------
        public Usuario EncontrarUsuarioDNI(string txtDNI)
        {

            Usuario buscandoUsuario = new CC_Usuario().Listar().Where(u => u.dni == txtDNI).FirstOrDefault();

            if (buscandoUsuario != null)
            {
                return buscandoUsuario;
            }
            else
            {
                return buscandoUsuario;
            }


        }

        // ----------------- ENCONTRAR USUARIO POR ID -----------------

        public Usuario EncontrarUsuarioID(int id)
        {

            Usuario buscandoUsuario = new CC_Usuario().Listar().Where(u => u.id_usuario == id).FirstOrDefault();

            if (buscandoUsuario != null)
            {
                return buscandoUsuario;
            }
            else
            {
                return buscandoUsuario;
            }


        }




        // ----------------- ENCRIPTACION DE CLAVE -----------------

        public string EncriptarClave(string clave)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(clave));
            string hashString = BitConverter.ToString(hashValue).Replace("-", "");
            return hashString;
        }


        // ---------------------- CARGAR TABLA DE USUARIOS --------------------------
        public DataTable CargarTablaUsuarios(DataTable tablaUsuarios, string correoP, string nombreP, string dniP, object rolP, string estadoP)
        {
            tablaUsuarios = new CD_Usuario().CargarTablaUsuarios(tablaUsuarios, correoP, nombreP, dniP, rolP, estadoP);
            return tablaUsuarios;

        }

        // ----------------------- AGREGAR UN NUEVO USUARIO ----------------------------

        public bool AgregarUsuario(Usuario nuevoUsuario)
        {
            if (nuevoUsuario != null)
            {
                if (CD_Usuario.AgregarUsuario(nuevoUsuario))
                {
                    return true;

                }
                else return false;

            } else
            {
                return false;
            }

            
        }

        // ----------------------- MODIFICAR UN USUARIO ----------------------------

        public bool ModificarUsuario(Usuario usuarioModificar)
        {
            if (usuarioModificar != null)
            {
                if (CD_Usuario.ModificarUsuario(usuarioModificar))
                {
                    return true;

                }
                else return false;

            }
            else
            {
                return false;
            }

        }

        public bool EliminarUsuario(int id)
        {
            if (id != 0)
            {
                if (CD_Usuario.EliminarUsuario(id))
                {
                    return true;

                }
                else return false;

            }
            else
            {
                return false;
            }

        }

        public bool NuevaClave(Usuario usuarioModificar)
        {

            if (usuarioModificar != null)
            {
                if (CD_Usuario.NuevaClave(usuarioModificar))
                {
                    return true;

                }
                else return false;

            }
            else
            {
                return false;
            }


        }

    }

}
