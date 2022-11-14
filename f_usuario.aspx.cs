using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using System.Data.OleDb;              //Acceso a bd Access
//using System.MySql.Data;              //Acceso a bd MySQL
//using System.MySql.Data.MySqlClient;  //Acceso a bd MySQL

using System.Data;             //Acceso a bd SQLServer
using System.Data.SqlClient;   //Acceso a bd SQLServer

namespace Semana16_SitioWebCRUDUsuario
{
    public partial class f_usuario : System.Web.UI.Page
    {
        //Cadena de conexion para pc laboratorio
        //public string cadena_conexion = "Data Source=DESKTOP-J6D5H3A\\MSSQLSERVER2019;Initial Catalog=bibloteca;Integrated Security=True";

        //Cadena de conexion para laptop
        public string cadena_conexion = "Data Source=LEMUR;Initial Catalog=login;Integrated Security=True";
        
        //Estas variables pueden ir en el boton que corresponde
        //Pero es mas efectivo que sean publicas globales
        public string usuario_modificar;
        public string usuario_eliminar;

        ////Actualizacion de GridView1
        //using (SqlConnection conn = new SqlConnection("cadena_conexion"))
        //{
        //    DataTable dt = new DataTable();
        //    string consulta = "select * from usuarios";
        //    SqlCommand cmd = new SqlCommand(consulta, myConnection);
        //    SqlDataAdapter adap = new SqlDataAdapter(cmd);
        //    adap.Fill(dt);
        //    GridView1.DataSource = dt;
        //}

        //================================================
        //================================================
        //Evento cuando inicia la página
        protected void Page_Load(object sender, EventArgs e)
        {
            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            bnuevo.Visible = true;
            bguardar.Visible = false;
            bmodificar.Visible = true;
            bactualizar.Visible = false;

            try
            {
                lblmensaje.Text = "en línea";

                //string consulta = "select * from usuarios";
                //SqlConnection conexion = new SqlConnection(cadena_conexion);
                //SqlDataAdapter comando = new SqlDataAdapter(consulta, conexion);

                //System.Data.DataSet ds = new System.Data.DataSet();
                //comando.Fill(ds, "login");
                //GridView1.DataSource = ds;
                //GridView1.DataMember = "login";
                GridView1.DataBind();
            }
            catch (SqlException)
            {
                lblmensaje.Text = "Error de conexion";
            }
        } //Cierre de evento Load


        //================================================
        //================================================
        protected void bnuevo_Click(object sender, EventArgs e)
        {
            //CODIGO PARA NUEVO USUARIO
            //El boton nuevo solo habilita el formulario para actualizar el registro actual
            //para agregar un nuevo registro
            txtusuario.Enabled = true;
            txtclave.Enabled = true;
            lstnivel.Enabled = true;
            txtusuario.Text = "";
            txtclave.Text = "";
            //lstnivel.Text = "1";
            txtusuario.Focus();
            bnuevo.Visible = false;
            bguardar.Visible = true;
        }


        //================================================
        //================================================
        protected void bguardar_Click(object sender, EventArgs e)
        {
            //CODIGO PARA GUARDAR USUARIO
            //Guardamos el nuevo registro con INSER INTO
           
                SqlConnection myConnection = new SqlConnection(cadena_conexion);
                myConnection.Open();

                string myInsertQuery = "INSERT INTO usuarios(nombre,clave,nivel) Values(@nombre,@clave,@nivel)";
                SqlCommand myCommand = new SqlCommand(myInsertQuery);

            //myCommand.Parameters.Add("?nombre", SqlDbType.VarChar,75).Value = txtusuario.Text;
            //myCommand.Parameters.Add("?clave", SqlDbType.VarChar,75).Value = txtclave.Text;
            //myCommand.Parameters.Add("?nivel", SqlDbType.VarChar,50).Value = lstnivel.Text;

            myCommand.Parameters.AddWithValue("@nombre", txtusuario.Text);
                myCommand.Parameters.AddWithValue("@clave", txtclave.Text);
                myCommand.Parameters.AddWithValue("@nivel", lstnivel.Text);

            try
            {
            myCommand.Connection = myConnection;
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            //MessageBox.Show("Usuario agregado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblmensaje.Text = "Usuario agregado con éxito";

                //string consulta = "select * from usuarios";
                //SqlConnection conexion = new SqlConnection(cadena_conexion);
                //SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                //System.Data.DataSet ds = new System.Data.DataSet();
                //da.Fill(ds, "login");
                //GridView1.DataSource = ds;
                //GridView1.DataMember = "login";

                //GridView1.DataSource = MiRecurso;
                GridView1.DataBind();


            }
            catch (SqlException)                 
            {
                //MessageBox.Show("Ya existe el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblmensaje.Text = "Usuario ya existe";
            }

            bnuevo.Visible = true;
            bguardar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            bnuevo.Focus();
        }


        //================================================
        //================================================
        protected void bmodificar_Click(object sender, EventArgs e)
        {
            //CODIGO PARA ACCION DE MODIFICAR
            txtusuario.Enabled = true;
            txtclave.Enabled = true;
            lstnivel.Enabled = true;

            txtusuario.Focus();

            bmodificar.Visible = false;
            bactualizar.Visible = true;

            //usuario_modificar = txtusuario.Text.ToString();
            usuario_modificar = txtbuscar.Text.ToString();
        }


        //================================================
        //================================================
        protected void bactualizar_Click(object sender, EventArgs e)
        {
            //CODIGO PARA ACTUALIZAR USUARIO
            //Aplica los cambios realizados al registro actual
            try
            {
                SqlConnection myConnection = new SqlConnection(cadena_conexion);

                string nom = txtusuario.Text.ToString();
                string cla = txtclave.Text.ToString();
                string niv = lstnivel.Text.ToString();

                //Hay dos formas de pasar los valores

                //Primera forma de pasar los valores
                //string myInsertQuery = "UPDATE usuarios SET nombre = ?nombre, clave = ?clave, nivel = ?nivel Where nombre = " + usuario_modificar + "";
                //En caso de usar primera forma, se pasan estos parámetros.
                //myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 75).Value = txtusuario.Text;
                //myCommand.Parameters.Add("?clave", MySqlDbType.VarChar, 75).Value = txtclave.Text;
                //myCommand.Parameters.Add("?nivel", MySqlDbType.Int32, 11).Value = lstnivel.Text;

                //Segunda forma de pasar los valores, usaremos esta forma
                string myInsertQuery = "UPDATE usuarios SET nombre = '" + nom + "', clave = '" + cla + "',nivel = '" + niv + "' WHERE idusuario = '" + usuario_modificar + "'";
                SqlCommand myCommand = new SqlCommand(myInsertQuery);

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                //MessageBox.Show("Usuario modificado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblmensaje.Text = "Usuario modificado con éxito";

                //string consulta = "select * from usuarios";
                //SqlConnection conexion = new SqlConnection(cadena_conexion);
                //SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                //System.Data.DataSet ds = new System.Data.DataSet();
                //da.Fill(ds, "SqlDataSource_usuario");
                //GridView1.DataSource = ds;
                //GridView1.DataMember = "SqlDataSource_usuario";

                GridView1.DataBind();

            }
            catch (SqlException)
            {
                //MessageBox.Show("Error al modificar el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblmensaje.Text = "Error al modificar usuario";
            }

            bmodificar.Visible = true;
            bactualizar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            bmodificar.Focus();
        }

        //================================================
        //================================================
        protected void beliminar_Click(object sender, EventArgs e)
        {
            //CODIGO PARA ELIMINAR USUARIO
            try
            {
                SqlConnection myConnection = new SqlConnection(cadena_conexion);

                string myInsertQuery = "delete from usuarios Where idusuario = " + txtbuscar.Text + "";
                SqlCommand myCommand = new SqlCommand(myInsertQuery);

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                //MessageBox.Show("Usuario eliminado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblmensaje.Text = "Usuario eliminado con éxito";

                //string consulta = "select * from usuarios";
                //SqlConnection conexion = new SqlConnection(cadena_conexion);
                //SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                //System.Data.DataSet ds = new System.Data.DataSet();
                //da.Fill(ds, "login");
                //GridView1.DataSource = ds;
                ////GridView1.DataMember = "login";
                ///
                GridView1.DataBind();

            }
            catch (SqlException)
            {
                //MessageBox.Show("Error al eliminar el usuario, primero realice búsqueda del usuario y después puede eliminar.", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblmensaje.Text = "Error al eliminar el usuario, primero realice búsqueda del usuario y después puede eliminar.";
            }

            bnuevo.Visible = true;
            bguardar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            txtusuario.Text = "";
            txtclave.Text = "";
            //lstnivel.Text = "Seleccione nivel";
            txtbuscar.Focus();
        }


        //================================================
        //================================================
        protected void bbuscar_Click(object sender, EventArgs e)
        {
            //CODIGO PARA REALIZAR BUSQUEDA
            try
            {
                SqlConnection myConnection = new SqlConnection(cadena_conexion);

                string myInsertQuery = "select * from usuarios Where idusuario = " + txtbuscar.Text + "";
                SqlCommand myCommand = new SqlCommand(myInsertQuery, myConnection);

                myCommand.Connection = myConnection;
                myConnection.Open();

                SqlDataReader myConsulta;
                myConsulta = myCommand.ExecuteReader();

                if (myConsulta.Read())
                {
                    txtusuario.Text = myConsulta.GetString(1);
                    txtclave.Text = myConsulta.GetString(2);
                    lstnivel.Text = myConsulta.GetString(3);
                    //String nivel = myConsulta.GetString(3);
                    //lstnivel.Text = nivel;
                }
                else
                {
                    //MessageBox.Show("El usuario no existe", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblmensaje.Text = "El usuario ya existe";
                }

                myConsulta.Close();
                myConnection.Close();
            }
            catch (SqlException)
            {
                //MessageBox.Show("Campo de busqueda está vacío", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblmensaje.Text = "Campo de busqueda está vacío";
            }

            bnuevo.Visible = true;
            bguardar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            bmodificar.Focus();

            //Finalizada la busqueda y llenado de campos
            //guardamos el contenido de txtusuario.Text por si se quiere eliminar por medio del usuario
            //usuario_eliminar = txtusuario.Text;
        }


        //Fin de codigo, llaves principales
    }
}