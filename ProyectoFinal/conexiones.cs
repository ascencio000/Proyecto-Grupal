using MySql.Data.MySqlClient;
using System;
using MySql.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    internal class conexiones
    {
        /* DATOS DE CONEXION
         * database => proyectojp_grupo6
         * usuario => proyectojp_usuario6
         * Password => caKl%nwQQOhV
         * Data Source => proyectojp.site      
        */

        private string conexion = "database=proyectojp_grupo6; Data Source=proyectojp.site; User ID=proyectojp_usuario6; Password=caKl%nwQQOhV;";

        public void entrarbd() //conexion de base de datos???
        {
            try
            {
                MySqlConnection conectar = new MySqlConnection(conexion);
                conectar.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.Message);
            }
        }

        #region BdProductos 

        public List<Productos> MostrarProductos() //Listado de productos
        {
            List<Productos> Ver = new List<Productos>();
            string Consulta = "select * from Productos";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand consultaCommand = new MySqlCommand(Consulta, conectar);
                try
                {
                    conectar.Open();
                    MySqlDataReader Lec = consultaCommand.ExecuteReader();


                    while (Lec.Read())
                    {
                        Productos Mos = new Productos();
                        Mos.IdProducto = Lec.GetInt32(0);
                        Mos.IdSucursal = Lec.GetInt32(1);
                        Mos.IdCategoria = Lec.GetInt32(2);
                        Mos.Nombre = Lec.GetString(3);
                        Mos.PrecioCompra = Lec.GetDouble(4);
                        Mos.PrecioVenta = Lec.GetDouble(5);
                        Mos.Cantidad = Lec.GetInt32(6);
                        Ver.Add(Mos);

                    }


                    Lec.Close();
                    conectar.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hubo un error: " + ex.Message);
                }
            }
            return Ver;
        }

        public List<Productos> BuscarProducto(int id) //BUSCAR PRODCUTO POR ID
        {
            string consulta = "select * from Productos" + " where idproducto=@id";
            List<Productos> Ver = new List<Productos>();
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@id", id);
                try
                {

                    conectar.Open();
                    MySqlDataReader Lec = comando.ExecuteReader();
                    Lec.Read();

                    //IdProducto,
                    //Nombre y Cantidad son nombres de campos de la tabla, revisar el coso del perfil hasta abajo, el numero indica el número de campo a revisar
                    Productos Mos = new Productos();
                    Mos.IdProducto = Lec.GetInt32(0);
                    Mos.IdSucursal = Lec.GetInt32(1);
                    Mos.IdCategoria = Lec.GetInt32(2);
                    Mos.Nombre = Lec.GetString(3);
                    Mos.PrecioCompra = Lec.GetDouble(4);
                    Mos.PrecioVenta = Lec.GetDouble(5);
                    Mos.Cantidad = Lec.GetInt32(6);


                    Lec.Close();
                    conectar.Close();
                    Ver.Add(Mos);

                }
                catch (Exception)
                {

                    MessageBox.Show("El ID ingresado no existe, por favor pruebe otra vez", "ERROR DE ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                return Ver;
            }
        }

        public void CrearProcuto(int idS, int idC, string nombre, double precioC, double precioV, int cantidad) //CREAR productos
        {
            //Nombre y Cantidad son los nombres de los campos
            string consulta = "insert into Productos (idsucursal,idcategoria,nombre,preciocompra,precioventa,cantidad) values" + "(@idsu, @idca, @nom, @precioC, @precioV, @cantidad)";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@idsu", idS);
                comando.Parameters.AddWithValue("@idca", idC);
                comando.Parameters.AddWithValue("@nom", nombre);
                comando.Parameters.AddWithValue("@precioC", precioC);
                comando.Parameters.AddWithValue("@precioV", precioV);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                try
                {
                    conectar.Open();
                    int hecho = comando.ExecuteNonQuery();
                    if (hecho > 0)
                    {
                        MessageBox.Show("Producto Creado Correctamente", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conectar.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error" + ex.Message);
                }
            }
        }

        public void EditarProductos(int idS, int idC, string nombre, double precioC, double precioV, int cantidad, int id)//EDITAR PRODUCTO
        {
            string consulta = "update Productos set idsucursal=@idS, idcategoria=@idC, nombre=@nombre,preciocompra=@precioC, precioventa=@precioV, cantidad=@cantidad" + " where idproducto=@id";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@idS", idS);
                comando.Parameters.AddWithValue("@idC", idC);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@precioC", precioC);
                comando.Parameters.AddWithValue("@precioV", precioV);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                catch (Exception ex) { throw new Exception("Hay un error" + ex.Message); }
            }
        }

        public void EliminarProducto(int id) //ELIMINAR UN PRODUCTO CON ID
        {
            string consulta = "delete from Productos" + " where idproducto=@id";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("El ID ingresado no existe, por favor pruebe otra vez", "ERROR DE ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }


        public void actualizartablaproductos(int idproducto)
        {

            string consulta =
            "START TRANSACTION; " +
                  "UPDATE Categoria " +
                  "INNER JOIN Productos ON Categoria.idcategoria = Productos.idcategoria " +
                  "SET Categoria.stock = Categoria.stock - Productos.cantidad " +
                  "WHERE Productos.idproducto = @id; " +
                  "COMMIT;";

            using (MySqlConnection conectando = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectando);
                comando.Parameters.AddWithValue("@id", idproducto);
                try
                {
                    try
                    {
                        conectando.Open();
                        comando.ExecuteNonQuery();
                        conectando.Close();


                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Hay un error " + ex.Message);
                    }
                }
                catch (Exception Rollback)
                {
                    MessageBox.Show("Hay un error en tú código", Rollback.Message);
                }

            }
        }



        public List<Productos2> MostrarProductosJun() //PRODUCTOS COMBINADOS
        {

            List<Productos2> listado = new List<Productos2>();
            string consulta = "SELECT Productos.idproducto, Sucursal.nombre AS nombreSU, Categoria.nombre AS nombreCA, Productos.nombre AS nombrePro, Productos.preciocompra, Productos.precioventa, Productos.cantidad " +
                 "FROM Productos " +
            "INNER JOIN Sucursal ON Productos.idsucursal = Sucursal.idsucursal " +
            "INNER JOIN Categoria ON Productos.idcategoria = Categoria.idcategoria";



            using (MySqlConnection conecperfil = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conecperfil);
                try
                {

                    conecperfil.Open();
                    MySqlDataReader lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        Productos2 listando = new Productos2();
                        listando.IdProducto = lector.GetInt32(0);
                        listando.NombreDeSucursal = lector.GetString(1);
                        listando.NombreDeCategoria = lector.GetString(2);
                        listando.Nombre = lector.GetString(3);
                        listando.PrecioDeCompra = lector.GetDouble(4);
                        listando.PrecioDeVenta = lector.GetDouble(5);
                        listando.Cantidad = lector.GetInt32(6);

                        listado.Add(listando);

                    }
                    lector.Close();
                    conecperfil.Close();

                }
                catch (Exception ex)
                {

                    throw new Exception("Hay un error" + ex.Message);

                }

            }
            return listado;

        }



        #endregion

        #region BdCATEGORIA

        public List<Categoria> MostrarCategoria() //Listado de las categorias
        {
            List<Categoria> Ver = new List<Categoria>();
            string Consulta = "select * from Categoria";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand consultaCommand = new MySqlCommand(Consulta, conectar);
                try
                {
                    conectar.Open();
                    MySqlDataReader Lec = consultaCommand.ExecuteReader();


                    while (Lec.Read())
                    {
                        Categoria Mos = new Categoria();
                        Mos.IdCategoria = Lec.GetInt32(0);
                        Mos.Nombre = Lec.GetString(1);
                        Mos.Stock = Lec.GetInt32(2);

                        Ver.Add(Mos);

                    }


                    Lec.Close();
                    conectar.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hubo un error: " + ex.Message);
                }
            }
            return Ver;
        }

        public List<Categoria> BuscarCategoria(int id) //BUSCAR CATEGORIA POR ID
        {
            string consulta = "select * from Categoria" + " where idcategoria=@id";
            List<Categoria> Ver = new List<Categoria>();
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    MySqlDataReader Lec = comando.ExecuteReader();
                    Lec.Read();

                    //IdProducto,
                    //Nombre y Cantidad son nombres de campos de la tabla, revisar el coso del perfil hasta abajo, el numero indica el número de campo a revisar
                    Categoria Mos = new Categoria();
                    Mos.IdCategoria = Lec.GetInt32(0);
                    Mos.Nombre = Lec.GetString(1);
                    Mos.Stock = Lec.GetInt32(2);
                    Lec.Close();
                    conectar.Close();
                    Ver.Add(Mos);



                }
                catch (Exception)
                {

                    MessageBox.Show("El ID ingresado no existe, por favor pruebe otra vez", "ERROR DE ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                return Ver;
            }
        }

        public void CrearCategoria(string nombre, int stock) //CREAR UNA CATEGORIA
        {
            string consulta = "insert into Categoria(nombre, stock) Values" + "(@Nombre, @Stock)";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Stock", stock);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Clone();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public void EditarCategoria(string nombre, int stock, int id) //EDITAR UNA CATEROGIA
        {
            string consulta = "update Categoria set nombre=@nombre, stock=@stock" + " where idcategoria=@id";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);

                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@stock", stock);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                catch (Exception ex) { throw new Exception("Hay un error" + ex.Message); }
            }

        }

        public void EditarStock(int stock, int id) //SUMAR AL STOCK AL CREAR PRODUCTO
        {
            string consulta = "update Categoria set stock=@stock" + " where idcategoria=@id";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);


                comando.Parameters.AddWithValue("@stock", stock);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                catch (Exception ex) { throw new Exception("Hay un error" + ex.Message); }
            }

        }

        public void EliminarCategoria(int id) //ELIMINAR UNA CATEGORIA CON ID
        {
            string consulta = "delete from Categoria" + " where idcategoria=@id";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error" + ex.Message);
                }
            }
        }

        #endregion

        #region BdVENDEDOR
        public List<Vendedor> MostrarVendedores() // Listado de vendedores
        {
            List<Vendedor> Ver = new List<Vendedor>();
            string Consulta = "select * from Vendedores";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand consultaCommand = new MySqlCommand(Consulta, conectar);
                try
                {
                    conectar.Open();
                    MySqlDataReader Lec = consultaCommand.ExecuteReader();

                    while (Lec.Read())
                    {
                        Vendedor Mos = new Vendedor();
                        Mos.IdVendedor = Lec.GetInt32(0);
                        Mos.Nombre = Lec.GetString(1);
                        Mos.Apellido = Lec.GetString(2);
                        Mos.DUI = Lec.GetString(3);
                        Mos.Telefono = Lec.GetString(4);
                        Mos.Email = Lec.GetString(5);
                        Mos.Direccion = Lec.GetString(6);


                        Ver.Add(Mos);
                    }

                    Lec.Close();
                    conectar.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error: " + ex.Message);
                }
            }
            return Ver;
        }

        public List<Vendedor> BuscarVendedor(int id) // BUSCAR VENDEDOR POR ID
        {
            string consulta = "select * from Vendedores" + " where idvendedor=@id";
            List<Vendedor> Ver = new List<Vendedor>();
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    MySqlDataReader Lec = comando.ExecuteReader();
                    Lec.Read();


                    Vendedor Mos = new Vendedor();
                    Mos.IdVendedor = Lec.GetInt32(0);
                    Mos.Nombre = Lec.GetString(1);
                    Mos.Apellido = Lec.GetString(2);
                    Mos.DUI = Lec.GetString(3);
                    Mos.Telefono = Lec.GetString(4);
                    Mos.Email = Lec.GetString(5);
                    Mos.Direccion = Lec.GetString(6);
                    Lec.Close();
                    conectar.Close();
                    Ver.Add(Mos);
                }
                catch (Exception)
                {

                    MessageBox.Show("El ID ingresado no existe, por favor pruebe otra vez", "ERROR DE ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                return Ver;
            }
        }

        public void CrearVendedor(string nombre, string apellido, string dui, string telefono, string email, string direccion) //CREAR UN VENDEDOR
        {
            //Nombre y Cantidad son los nombres de los campos
            string consulta = "insert into Vendedores (nombre,apellido,DUI,telefono,email,direccion) values" + "(@nombreV, @apellidoV, @DUI, @telefono, @email, @direccion)";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@nombreV", nombre);
                comando.Parameters.AddWithValue("@apellidoV", apellido);
                comando.Parameters.AddWithValue("@DUI", dui);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@direccion", direccion);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error" + ex.Message);
                }
            }
        }

        public void EditarVendedor(string nombre, string apellido, string dui, string telefono, string email, string direccion, int id) //EDITAR VENDEDOR
        {
            //Nombre y Cantidad son los nombres de los campos
            string consulta = "update Vendedores set nombre=@nombreV, apellido=@apellidoV, DUI=@DUI, telefono=@telefono, email=@email, direccion=@direccion" + " where idvendedor=@id";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@nombreV", nombre);
                comando.Parameters.AddWithValue("@apellidoV", apellido);
                comando.Parameters.AddWithValue("@DUI", dui);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@direccion", direccion);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error" + ex.Message);
                }
            }
        }

        public void EliminarVendedor(int id) //ELIMINAR UN VENDEDOR CON ID
        {
            string consulta = "delete from Vendedores" + " where idvendedor=@id";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error" + ex.Message);
                }
            }
        }


        #endregion

        #region BdSucursales
        public List<Sucursales> MostrarSucursales() //Listado de las sucursales
        {
            List<Sucursales> Ver = new List<Sucursales>();
            string Consulta = "select * from Sucursal";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand consultaCommand = new MySqlCommand(Consulta, conectar);
                try
                {
                    conectar.Open();
                    MySqlDataReader Lec = consultaCommand.ExecuteReader();


                    while (Lec.Read())
                    {
                        Sucursales Mos = new Sucursales();
                        Mos.IdSucursal = Lec.GetInt32(0);
                        Mos.Nombre = Lec.GetString(1);
                        Mos.Direccion = Lec.GetString(2);

                        Ver.Add(Mos);

                    }


                    Lec.Close();
                    conectar.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hubo un error: " + ex.Message);
                }
            }
            return Ver;
        }

        public List<Sucursales> BuscarSucursal(int id) //BUSCAR sucursal POR ID
        {
            string consulta = "select * from Sucursal" + " where idsucursal=@id";
            List<Sucursales> Ver = new List<Sucursales>();
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    MySqlDataReader Lec = comando.ExecuteReader();
                    Lec.Read();


                    Sucursales Mos = new Sucursales();
                    Mos.IdSucursal = Lec.GetInt32(0);
                    Mos.Nombre = Lec.GetString(1);
                    Mos.Direccion = Lec.GetString(2);
                    Lec.Close();
                    conectar.Close();
                    Ver.Add(Mos);



                }
                catch (Exception)
                {

                    MessageBox.Show("El ID ingresado no existe, por favor pruebe otra vez", "ERROR DE ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                return Ver;
            }
        }

        public void CrearSucursal(string nombre, string direccion) //CREAR UNA SUCURSAL
        {
            string consulta = "insert into Sucursal(nombre, direccion) Values" + "(@Nombre, @Direccion)";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Direccion", direccion);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Clone();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        public void EditarSucursal(string nombre, string direccion, int id) //EDITAR UNA CATEROGIA
        {
            string consulta = "update Sucursal set nombre=@nombre, direccion=@direccion" + " where idsucursal=@id";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);

                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@direccion", direccion);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                catch (Exception ex) { throw new Exception("Hay un error" + ex.Message); }
            }

        }

        public void EliminarSucursal(int id) //ELIMINAR UNA SUCURSAL CON ID
        {
            string consulta = "delete from Sucursal" + " where idsucursal=@id";
            using (MySqlConnection conectar = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectar);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error" + ex.Message);
                }
            }
        }

        #endregion

        #region Factura

        // mostrar listado

        public List<listfact> mostrarfactu()
        {

            List<listfact> listado = new List<listfact>();
            string consulta = "select Factura.idfactura,Vendedores.nombre,Factura.total,Factura.fecha,Detallefactura.idproducto,Detallefactura.cantidad,Detallefactura.precio " +
                "from Factura " +
                "inner join Detallefactura on Factura.idfactura = Detallefactura.idfactura " +
                "inner join Vendedores on Factura.idvendedor = Vendedores.idvendedor";

            using (MySqlConnection conecperfil = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conecperfil);
                try
                {

                    conecperfil.Open();
                    MySqlDataReader lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        listfact listando = new listfact();
                        listando.idfactura = lector.GetInt32(0);
                        listando.Vendedor = lector.GetString(1);
                        listando.total = lector.GetDouble(2);
                        listando.fecha = lector.GetDateTime(3);
                        listando.idproducto = lector.GetInt32(4);
                        listando.cantidad = lector.GetInt32(5);
                        listando.precio = lector.GetDouble(6);
                        listado.Add(listando);

                    }
                    lector.Close();
                    conecperfil.Close();

                }
                catch (Exception ex)
                {

                    throw new Exception("Hay un error" + ex.Message);

                }

            }
            return listado;

        }


        public List<detalle> mostrardetalle(int id)
        {

            List<detalle> listado = new List<detalle>();
            string consulta = "select * from Detallefactura" + " where idfactura=@id";
            using (MySqlConnection conecperfil = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conecperfil);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conecperfil.Open();
                    MySqlDataReader lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        detalle listando = new detalle();
                        listando.iddetalle = lector.GetInt32(0);
                        listando.idproducto = lector.GetInt32(2);
                        listando.cantidad = lector.GetInt32(3);
                        listado.Add(listando);
                    }
                    lector.Close();
                    conecperfil.Close();

                }
                catch (Exception ex)
                {

                    throw new Exception("Hay un error" + ex.Message);

                }

            }
            return listado;

        }


        public factura mostrarfactura(int id)
        {
            string consulta = "select * from Factura" + " where idfactura=@id";
            using (MySqlConnection conecperfil = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conecperfil);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conecperfil.Open();
                    MySqlDataReader lector = comando.ExecuteReader();
                    lector.Read();
                    factura listando = new factura();

                    listando.idvendedor = lector.GetInt32(2);
                    listando.total = lector.GetDouble(3);
                    lector.Close();
                    conecperfil.Close();
                    return listando;
                }
                catch (Exception ex)
                {

                    throw new Exception("Hay un error" + ex.Message);

                }

            }


        }






















        // crear


        /*Declaramos dos variables, una "intento" la cual se encarga de detectar que la primera vez que se agregue
         un producto a la factura, esta se cree con un ID, y al ser mayor que 0, este intento nos redirige a un else 
        en donde va creando Detalles de factura, con respecto a ese mismo idfactura creado inicialmente
         
        La otra variable es para tomar ese iddetalle que nos interesa de el primer insert
         */

        int intento = 0;
        int id = 0;

        public void insertando(int idvendedor, double total, DateTime fecha, int idfactura, int idproducto, int cantidad, double precio)
        {
            if (intento == 0)
            {
                string clave = " ";
                clave = "Detallefactura";
                int insertarID = proximoid(clave);
                MySqlConnection conectando = new MySqlConnection(conexion);
                try
                {
                    conectando.Open();
                    MySqlTransaction transaccion = conectando.BeginTransaction(); // inicio transaccion
                    try
                    {

                        string consulta1 = "INSERT INTO Factura (iddetalle, idvendedor, total, fecha) VALUES (@iddetalle,@idvendedor,@total,@fecha)";
                        MySqlCommand comando1 = new MySqlCommand(consulta1, conectando);
                        comando1.Parameters.AddWithValue("@iddetalle", insertarID);
                        comando1.Parameters.AddWithValue("@idvendedor", idvendedor);
                        comando1.Parameters.AddWithValue("@total", total);
                        comando1.Parameters.AddWithValue("@fecha", fecha);
                        comando1.ExecuteNonQuery();

                        long tomando = comando1.LastInsertedId;
                        id = Convert.ToInt32(tomando);
                        idfactura = Convert.ToInt32(tomando);
                        string consultaTabla2 = "INSERT INTO Detallefactura (idfactura, idproducto, cantidad, precio) VALUES (@idfactura,@idproducto,@cantidad,@precio)";
                        MySqlCommand comandoTabla2 = new MySqlCommand(consultaTabla2, conectando);
                        comandoTabla2.Parameters.AddWithValue("@idproducto", idproducto);
                        comandoTabla2.Parameters.AddWithValue("@cantidad", cantidad);
                        comandoTabla2.Parameters.AddWithValue("@precio", precio);
                        comandoTabla2.Parameters.AddWithValue("@idfactura", idfactura);
                        comandoTabla2.ExecuteNonQuery();
                        transaccion.Commit();// guardar cambios realizados desde el inicio de la transaccion
                        MessageBox.Show("La factura ha sido creada exitosamente", "Aviso", MessageBoxButtons.OK);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hay un error al insertar registros" + ex.Message);
                        transaccion.Rollback();// revertir transacciones no confirmadas
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hay un error en la base de datos" + ex.Message);

                }
                finally
                {
                    conectando.Close();

                }
                intento++;

            }
            else
            {




                MySqlConnection conectando = new MySqlConnection(conexion);
                try
                {
                    conectando.Open();
                    MySqlTransaction transaccion = conectando.BeginTransaction(); // inicio transaccion
                    try
                    {

                        string consultaTabla2 = "INSERT INTO Detallefactura (idfactura, idproducto, cantidad, precio) VALUES (@idfactura,@idproducto,@cantidad,@precio)";
                        MySqlCommand comandoTabla2 = new MySqlCommand(consultaTabla2, conectando);
                        comandoTabla2.Parameters.AddWithValue("@idproducto", idproducto);
                        comandoTabla2.Parameters.AddWithValue("@cantidad", cantidad);
                        comandoTabla2.Parameters.AddWithValue("@precio", precio);
                        comandoTabla2.Parameters.AddWithValue("@idfactura", id);
                        comandoTabla2.ExecuteNonQuery();

                        transaccion.Commit();// guardar cambios realizados desde el inicio de la transaccion


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hay un error al insertar registros" + ex.Message);
                        transaccion.Rollback();// revertir transacciones no confirmadas
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hay un error en la base de datos" + ex.Message);

                }
                finally
                {
                    conectando.Close();

                }









            }

        }



        private int ultimoidinsertado()
        {
            int ultimoId = 0;

            using (MySqlConnection conecperfil = new MySqlConnection(conexion))
            {
                string consulta = "SELECT LAST_INSERT_ID()";
                MySqlCommand getLastInsertIdCmd = new MySqlCommand(consulta, conecperfil);

                try
                {
                    conecperfil.Open();
                    ultimoId = Convert.ToInt32(getLastInsertIdCmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el último ID insertado: " + ex.Message);
                }
            }

            return ultimoId;
        }

        public int proximoid(string nombreTabla)
        {
            int proximoID = 0;


            using (MySqlConnection conectando = new MySqlConnection(conexion))

            // esta consulta nos permite visualizar el ultimo ID de nuestra tabla
            // particularmente el ultimo ID de la columna autoincremental
            // por ello solo es especifico el nombre de tabla en el método "insertando"

            {
                string consulta = $"SHOW TABLE STATUS LIKE '{nombreTabla}'";

                using (MySqlCommand comando = new MySqlCommand(consulta, conectando))
                {
                    try
                    {
                        conectando.Open();
                        MySqlDataReader reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                proximoID = Convert.ToInt32(reader["Auto_increment"]);
                            }
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener el próximo ID autoincremental: " + ex.Message);
                    }
                }
            }

            return proximoID;
        }






        // actualizando productos y stock
        // mediante un iddetalle que será el último insertado

        public void actualizartabla()
        {
            int idinsertado = ultimoidinsertado();
            string consulta = "UPDATE Productos " +
                              "INNER JOIN Detallefactura ON Productos.idproducto = Detallefactura.idproducto " +
                              "SET Productos.cantidad = Productos.cantidad - Detallefactura.cantidad " +
                              "WHERE Detallefactura.iddetalle = @iddetalle";

            using (MySqlConnection conectando = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectando);
                comando.Parameters.AddWithValue("@iddetalle", idinsertado);

                try
                {
                    conectando.Open();
                    comando.ExecuteNonQuery();
                    conectando.Close();


                }
                catch (Exception ex)
                {

                    throw new Exception("Hay un error " + ex.Message);
                }
            }
        }


        public void actualizartabla2()
        {
            int idinsertado = ultimoidinsertado();
            string consulta =
                "UPDATE Categoria " +
                      "INNER JOIN Productos on Categoria.idcategoria = Productos.idcategoria " +
                      "INNER JOIN Detallefactura ON Productos.idproducto = Detallefactura.idproducto " +
                      "SET Categoria.stock = Categoria.stock - Detallefactura.cantidad " +
                      "WHERE Detallefactura.iddetalle = @iddetalle";

            using (MySqlConnection conectando = new MySqlConnection(conexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conectando);
                comando.Parameters.AddWithValue("@iddetalle", idinsertado);

                try
                {
                    conectando.Open();
                    comando.ExecuteNonQuery();
                    conectando.Close();


                }
                catch (Exception ex)
                {

                    throw new Exception("Hay un error " + ex.Message);
                }
            }
        }




























        #endregion

    }


    public class Facturando
    {
        public int idvendedor { get; set; }
        public double total { get; set; }
        public DateTime fecha { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }

    }


    public class Detallefactura
    {
        public int iddetalle { get; set; }
        public int idfactura { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }

    }
    public class Productos //MODELO PRODUCTOS
    {
        public int IdProducto { get; set; }
        public int IdSucursal { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public int Cantidad { get; set; }

    }
    public class Productos2 //modelo de productos listado
    {
        public int IdProducto { get; set; }
        public string NombreDeSucursal { get; set; }
        public string NombreDeCategoria { get; set; }
        public string Nombre { get; set; }
        public double PrecioDeCompra { get; set; }
        public double PrecioDeVenta { get; set; }
        public int Cantidad { get; set; }
    }
    public class Categoria //MODELO CATEGORIA
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
    }

    public class Vendedor //MODELO VENDEDOR
    {
        public int IdVendedor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DUI { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

    }

    public class Sucursales //MODELO SUCURSALES
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

    }

    public class detalle
    {
        public int iddetalle { get; set; }
        public int idfactura { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }

    }

    public class listaid
    {
        public int iddetalle { get; set; }
        public int idvendedor { get; set; }
        public double total { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }

    }


    public class factura
    {
        public int idfactura { get; set; }
        public int iddetalle { get; set; }
        public int idvendedor { get; set; }
        public double total { get; set; }
        public DateTime fecha { get; set; }

    }

    public class inventario
    {
        public int cantidad { get; set; }
        public int idcategoria { get; set; }
        public int stock { get; set; }
    }

    public class inventario2
    {
        public int cantidad { get; set; }
        public int idproducto { get; set; }
        public int cantidad2 { get; set; }
    }
    public class listafinal
    {
        public int idfactura { get; set; }
        public int iddetalle { get; set; }
        public int idvendedor { get; set; }
        public double total { get; set; }
        public DateTime fecha { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
    }

    public class listfact
    {
        public int idfactura { get; set; }
        public string Vendedor { get; set; }
        public double total { get; set; }
        public DateTime fecha { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
    }








}