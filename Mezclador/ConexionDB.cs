
using Mezclador.Models;
using Mezclador.ViewModels;
using MySql.Data.MySqlClient;
using System.Text;
using static Mezclador.Users.Usuario;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;

namespace Mezclador
{
    public static class ConexionDB
    {
        public enum CrudType { None, Create, Update }
        static readonly string ConnectionString = "Server=127.0.0.1;database=db_mezclador;user=root;password=AtkAdm4rv1zu";

        public static List<ProductoModel> GetProductos()
        {
            List<ProductoModel> listaDatos = new();
            try
            {
                string Query = "Select * From Productos WHERE Producto not like '%(Eliminado)%' order by producto asc;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProductoModel datos = new()
                    {
                        Id = (int)reader["Id"],
                        Producto = reader["Producto"].ToString(),
                        Nombre = reader["Nombre"].ToString()
                    };
                    //datos.RutaImagen = Image.FromFile(reader["RutaImagen"].ToString());

                    string rutaImagen = reader["RutaImagen"].ToString();
                    if (!string.IsNullOrEmpty(rutaImagen))
                    {
                        //datos.Imagen = Image.FromFile(rutaImagen);
                    }
                    else
                    {
                        // Puedes asignar una imagen predeterminada o manejar la situación de alguna otra manera
                        //datos.RutaImagen = ObtenerImagenPredeterminada();
                    }
                    // Si hay otros campos, asígnalos también

                    listaDatos.Add(datos);
                }
                //DataTable Dato_Tabla = new();
                //dataTable.Clear();
                //Adapter.Fill(dataTable);
                //dgvPesaje.Refresh();
                //dgvPesaje.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return listaDatos;
        }

        public static void DeleteProduct(int id)
        {
            UsuarioModel usuario = new();
            try
            {
                string Query = "UPDATE productos SET Producto = CONCAT(Producto,'(Eliminado)') Where id = @id";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void RestoreDeletedProduct(int id)
        {
            UsuarioModel usuario = new();
            try
            {
                string Query = "UPDATE productos SET Producto = REPLACE(Producto, '(Eliminado)', '') Where id = @id";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void CreateColumn()
        {
            //string query = "ALTER TABLE instrucciones ADD COLUMN ligera TINYINT(1) DEFAULT 1;ALTER TABLE instrucciones ADD COLUMN pesada TINYINT(1) DEFAULT 0;";
            string query = "ALTER TABLE calidad ADD COLUMN comentario VARCHAR(200);ALTER TABLE materiales ADD COLUMN esAceite TINYINT(1) DEFAULT 0;ALTER TABLE materiales ADD COLUMN factor FLOAT DEFAULT 0.868;";

            using MySqlConnection connection = new(ConnectionString);

            try
            {
                connection.Open();
                using MySqlCommand command = new(query, connection);
                command.ExecuteNonQuery();
                //MessageBox.Show("Columnas agregadas exitosamente a la tabla 'instrucciones'.");
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
            }

        }
        public static ProductoModel Get1Producto(int id)
        {
            ProductoModel producto = new();
            try
            {
                string Query = "Select * From productos Where id = @id LIMIT 1;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                command.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    producto.Id = Convert.ToInt32(reader["id"]);
                    producto.Producto = reader["Producto"].ToString();
                    producto.Nombre = reader["Nombre"].ToString();
                    //producto.Escaneable = reader["Escaneable"].ToString();
                    //producto.Codigo = reader["Codigo"].ToString();
                    //string rutaImagen = reader["RutaImagen"].ToString();
                    //if (!string.IsNullOrEmpty(rutaImagen))
                    //{
                    //	if (File.Exists(rutaImagen))
                    //		producto.Imagen = Image.FromFile(rutaImagen);
                    //}
                    //else
                    //{
                    //	// Puedes asignar una imagen predeterminada o manejar la situación de alguna otra manera
                    //	//datos.RutaImagen = ObtenerImagenPredeterminada();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return producto;
        }
        public static int SearchDeletedProducto(string producto)
        {
            int id = 0;
            try
            {
                string Query = "Select id From productos Where Producto LIKE @producto && Producto LIKE '%(Eliminado)%' LIMIT 1;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                command.Parameters.AddWithValue("@producto", $"%{producto}%");
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return id;
        }
        public static List<MaterialViewModel> GetMateriales()
        {
            List<MaterialViewModel> listaDatos = new();
            try
            {
                string Query = "Select * From Materiales order by Material asc;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MaterialViewModel datos = new();
                    datos.Id = Convert.ToInt32(reader["ID"]);
                    datos.Material = reader["Material"].ToString();
                    datos.Nombre = reader["Nombre"].ToString();
                    //datos.RutaImagen = Image.FromFile(reader["RutaImagen"].ToString());

                    string rutaImagen = reader["RutaImagen"].ToString();
                    if (!string.IsNullOrEmpty(rutaImagen))
                    {
                        if (File.Exists(rutaImagen))
                        {
                            datos.Imagen = Image.FromFile(rutaImagen);
                        }
                    }
                    else
                    {
                        // Puedes asignar una imagen predeterminada o manejar la situación de alguna otra manera
                        //datos.RutaImagen = ObtenerImagenPredeterminada();
                    }
                    // Si hay otros campos, asígnalos también
                    listaDatos.Add(datos);
                }

                //DataTable Dato_Tabla = new();
                //dataTable.Clear();
                //Adapter.Fill(dataTable);
                //dgvPesaje.Refresh();
                //dgvPesaje.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return listaDatos;
        }
        public static MaterialModel Get1Material(int id)
        {
            MaterialModel material = new();
            try
            {
                string Query = "Select * From Materiales Where id = @id LIMIT 1;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                command.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //producto. = Convert.ToInt32(reader["id"]);
                    material.Material = reader["Material"].ToString();
                    material.Nombre = reader["Nombre"].ToString();
                    material.Escaneable = Convert.ToBoolean(reader["Escaneable"]);
                    material.Codigo = reader["Codigo"].ToString();
                    material.Saco = Convert.ToBoolean(reader["Saco"]);
                    material.PesoSaco = reader["PesoSaco"].ToString();
                    material.esAceite = Convert.ToBoolean(reader["esAceite"]);
                    var factor = Math.Round(Convert.ToDouble(reader["Factor"]), 3);
                    material.Factor = factor;
                    string rutaImagen = reader["RutaImagen"].ToString();


                    if (!string.IsNullOrEmpty(rutaImagen))
                    {
                        if (File.Exists(rutaImagen))
                            material.Imagen = Image.FromFile(rutaImagen);
                    }
                    else
                    {
                        // Puedes asignar una imagen predeterminada o manejar la situación de alguna otra manera
                        //datos.RutaImagen = ObtenerImagenPredeterminada();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return material;
        }
        public static List<InstruccionDataModel> GetInstructionsList(string SelectedProducto, int? id = 0)
        {
            int paso = 0;
            List<InstruccionDataModel> listaDatos = new();
            try
            {
                string query = "Select Mat.*, I.Cantidad, I.Habilitado, I.id AS idInstruccion, I.paso, I.ligera,I.pesada" +
                    " From instrucciones I join Materiales Mat ON I.id_material = Mat.id " +
                    "join Productos Prod ON I.id_producto = Prod.ID WHERE ";

                if (id > 0)
                {
                    query += "Prod.ID = @Id order by I.paso asc;";
                }
                else
                {
                    query += "Prod.Producto = @Producto order by I.paso asc;";
                }

                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(query, connection);
                if (id == 0)
                    command.Parameters.AddWithValue("@Producto", SelectedProducto);
                else
                    command.Parameters.AddWithValue("@Id", id);
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    paso++;
                    InstruccionDataModel datos = new();
                    datos.IdInstruccion = Convert.ToInt32(reader["idInstruccion"]);
                    datos.IdMaterial = Convert.ToInt32(reader["id"]);
                    datos.Material = reader["Material"].ToString();
                    datos.Nombre = reader["Nombre"].ToString();
                    datos.Cantidad = Convert.ToDouble(reader["Cantidad"]);
                    datos.Escaneable = Convert.ToBoolean(reader["Escaneable"]);
                    datos.Codigo = reader["Codigo"].ToString();
                    datos.Saco = Convert.ToBoolean(reader["Saco"]);
                    datos.esAceite = Convert.ToBoolean(reader["esAceite"]);
                    datos.Ligera = Convert.ToBoolean(reader["ligera"]);
                    datos.Pesada = Convert.ToBoolean(reader["pesada"]);

                    if (Convert.ToInt32(reader["paso"]) == 0)
                        datos.Paso = paso;
                    else
                        datos.Paso = Convert.ToInt32(reader["paso"]);

                    if (!string.IsNullOrEmpty(reader["PesoSaco"].ToString()))
                        datos.PesoSaco = Convert.ToDouble(reader["PesoSaco"]);

                    var factor = Math.Round(Convert.ToDouble(reader["Factor"]), 3);
                    datos.Factor = factor;

                    datos.Habilitado = Convert.ToBoolean(reader["Habilitado"]);
                    //datos.RutaImagen = Image.FromFile(reader["RutaImagen"].ToString());

                    string rutaImagen = reader["RutaImagen"].ToString();
                    if (!string.IsNullOrEmpty(rutaImagen))
                    {
                        if (File.Exists(rutaImagen))
                            datos.Imagen = Image.FromFile(rutaImagen);
                    }
                    else
                    {
                        // Puedes asignar una imagen predeterminada o manejar la situación de alguna otra manera
                        //datos.RutaImagen = ObtenerImagenPredeterminada();
                    }
                    // Si hay otros campos, asígnalos también

                    listaDatos.Add(datos);
                }
                //DataTable Dato_Tabla = new();
                //dataTable.Clear();
                //Adapter.Fill(dataTable);
                //dgvPesaje.Refresh();
                //dgvPesaje.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return listaDatos;
        }

        public static bool SaveMaterial(CrudType crudType, string Material, string Nombre, bool Escaneable, string Codigo, bool Saco, string pesoSaco, bool esAceite, double factor, string RutaImagen, int id = 0)
        {
            try
            {
                string Query = string.Empty;
                if (crudType == CrudType.Create)
                    Query = "Insert into Materiales (Material,Nombre,Escaneable,Codigo,Saco,PesoSaco,esAceite,factor,RutaImagen) values(@Material,@Nombre,@Escaneable,@Codigo,@Saco,@PesoSaco,@esAceite,@factor,@RutaImagen)";
                if (crudType == CrudType.Update)
                    Query = "Update Materiales SET Material = @Material,Nombre= @Nombre,Escaneable = @Escaneable,Codigo = @Codigo,Saco=@Saco,PesoSaco=@PesoSaco,esAceite=@esAceite,factor=@factor,RutaImagen = @RutaImagen Where Id = @Id;";

                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand mySqlCommand = new(Query, connection);

                mySqlCommand.Parameters.AddWithValue("@Material", Material);
                mySqlCommand.Parameters.AddWithValue("@Nombre", Nombre);
                mySqlCommand.Parameters.AddWithValue("@Escaneable", Escaneable);
                mySqlCommand.Parameters.AddWithValue("@Codigo", Codigo);
                mySqlCommand.Parameters.AddWithValue("@Saco", Saco);
                mySqlCommand.Parameters.AddWithValue("@PesoSaco", pesoSaco);
                mySqlCommand.Parameters.AddWithValue("@esAceite", esAceite);
                mySqlCommand.Parameters.AddWithValue("@factor", factor);
                mySqlCommand.Parameters.AddWithValue("@RutaImagen", RutaImagen);

                if (crudType == CrudType.Update)
                    mySqlCommand.Parameters.AddWithValue("@Id", id);

                if (mySqlCommand.ExecuteNonQuery() > 0)
                {
                    if (crudType == CrudType.Update)
                        MessageBox.Show("Material actualizado correctamente");
                    if (crudType == CrudType.Create)
                        MessageBox.Show("Material creado correctamente");
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static bool SaveProducto(CrudType crudType, string Producto, string Nombre, List<MaterialViewModel> materiales, List<MaterialParaProducto> materialesParaProducto, string cantidad, int? id = null)
        {
            try
            {
                string Query = string.Empty;
                if (crudType == CrudType.Create)
                    Query = "Insert into productos (Producto, Nombre) values(@Producto, @Nombre); SELECT LAST_INSERT_ID();";
                if (crudType == CrudType.Update)
                    Query = "UPDATE productos SET Producto = @Producto, Nombre = @Nombre WHERE id = @id";

                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand mySqlCommand = new(Query, connection);
                mySqlCommand.Parameters.AddWithValue("@Producto", Producto);
                mySqlCommand.Parameters.AddWithValue("@Nombre", Nombre);
                if (crudType == CrudType.Update)
                    mySqlCommand.Parameters.AddWithValue("@id", id);
                //mySqlCommand.Parameters.AddWithValue("@Escaneable", Escaneable);
                //mySqlCommand.Parameters.AddWithValue("@Codigo", Codigo);
                //mySqlCommand.Parameters.AddWithValue("@RutaImagen", RutaImagen);
                int idGenerado = Convert.ToInt32(mySqlCommand.ExecuteScalar());

                if (crudType == CrudType.Create)
                {
                    if (idGenerado > 0)
                    {
                        SaveInstructions(idGenerado, materiales, materialesParaProducto);//, cantidad);
                        MessageBox.Show("Producto creado correctamente");
                        return true;
                    }
                    else
                        return false;
                }

                if (crudType == CrudType.Update)
                {
                    SaveInstructions(id, materiales, materialesParaProducto);//, cantidad);
                    MessageBox.Show("Producto editado correctamente");
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static bool SaveInstructions(int? idProducto, List<MaterialViewModel> materiales, List<MaterialParaProducto> materialesParaProducto)
        {
            try
            {
                var instructions = GetInstructionsList(string.Empty, idProducto);// Crear un HashSet con los materiales de las instrucciones

                var instructionsToDisable = instructions.Where(i => !materialesParaProducto.Select(i => i.IdInstruccion).ToList().Contains(i.IdInstruccion)).ToList();
                foreach (var instructionToDisable in instructionsToDisable)
                {
                    UpdateInstruction(instructionToDisable.IdInstruccion, cantidad: "0", paso: 0, habilitado: false, ligera: true, pesada: false);
                }

                string Query = string.Empty;
                //if (crudType == CrudType.Create)
                Query = "INSERT INTO instrucciones (id_producto,id_material,cantidad,paso,ligera,pesada) VALUES (@id_producto,@id_material,@cantidad, @paso,@ligera,@pesada)";
                //if (crudType == CrudType.Update)
                //	Query = "";


                using MySqlConnection connection = new(ConnectionString);
                connection.Open();


                foreach (MaterialParaProducto material in materialesParaProducto)
                {
                    var idMaterial = materiales.FirstOrDefault(c => c.Material == material.Material).Id;

                    var existInstruction = instructions.FirstOrDefault(c => c.IdMaterial == idMaterial);
                    if (existInstruction == null)//si no existe se agrega
                    {
                        using MySqlCommand mySqlCommand = new(Query, connection);
                        mySqlCommand.Parameters.AddWithValue("@id_producto", idProducto);
                        mySqlCommand.Parameters.AddWithValue("@id_material", idMaterial);
                        mySqlCommand.Parameters.AddWithValue("@cantidad", material.Cantidad);
                        mySqlCommand.Parameters.AddWithValue("@paso", material.Paso);
                        mySqlCommand.Parameters.AddWithValue("@ligera", material.Ligera);
                        mySqlCommand.Parameters.AddWithValue("@pesada", material.Pesada);
                        if (mySqlCommand.ExecuteNonQuery() > 0)
                        {
                        }
                    }
                    else
                    {
                        //si existe en db por lo que solo se va a actualizar
                        UpdateInstruction(existInstruction.IdInstruccion, material.Cantidad, material.Paso, habilitado: true, material.Ligera, material.Pesada);
                    }
                }
                //MessageBox.Show("Producto creado correctamente");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static bool UpdateInstruction(int? idInstruccion, string cantidad, int paso, bool habilitado, bool ligera, bool pesada)
        {
            try
            {
                string Query = string.Empty;
                //if (crudType == CrudType.Create)
                Query = "UPDATE instrucciones SET habilitado = @habilitado,cantidad = @cantidad, paso = @paso, ligera = @ligera, pesada = @pesada WHERE id = @id_instruccion;";
                //if (crudType == CrudType.Update)
                //	Query = "";


                using MySqlConnection connection = new(ConnectionString);
                connection.Open();

                using MySqlCommand mySqlCommand = new(Query, connection);
                mySqlCommand.Parameters.AddWithValue("@id_instruccion", idInstruccion);
                mySqlCommand.Parameters.AddWithValue("@habilitado", habilitado);
                //mySqlCommand.Parameters.AddWithValue("@id_material", idproducto);
                mySqlCommand.Parameters.AddWithValue("@cantidad", cantidad);
                mySqlCommand.Parameters.AddWithValue("@paso", paso);
                mySqlCommand.Parameters.AddWithValue("@ligera", ligera);
                mySqlCommand.Parameters.AddWithValue("@pesada", pesada);
                if (mySqlCommand.ExecuteNonQuery() > 0)
                {
                }
                //MessageBox.Show("Producto creado correctamente");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static bool CheckUserExist(string Nombre)
        {
            try
            {
                string Query = "SELECT EXISTS (SELECT 1 FROM usuarios WHERE nombre = @Nombre);";
                using MySqlConnection mySqlConnection = new(ConnectionString);
                mySqlConnection.Open();
                using MySqlCommand mySqlCommand = new(Query, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@Nombre", Nombre);

                return Convert.ToBoolean(mySqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static UsuarioModel? GetUserWithPass(string Pass)
        {
            try
            {
                string Query = "SELECT * FROM usuarios WHERE pass = @Pass AND permisos != 'Eliminado' LIMIT 1;";
                using MySqlConnection mySqlConnection = new(ConnectionString);
                mySqlConnection.Open();
                using MySqlCommand mySqlCommand = new(Query, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@Pass", Pass);
                using MySqlDataReader reader = mySqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    UsuarioModel usuario = new()
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre"),
                        Permisos = reader.GetString("Permisos")
                    };
                    return usuario;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        public static List<UsersViewModel> GetUsersList()
        {
            List<UsersViewModel> listaDatos = new();
            try
            {
                //string Query = "Select * From usuarios order by Nombre asc;";
                string Query = "SELECT * FROM usuarios WHERE permisos != 'Eliminado' ORDER BY Nombre ASC;";
                //string Query =  "Select ID, Nombre, Permiso From usuarios INNER JOIN permisos ON permisos.ID = usuarios.permisos order by Nombre asc;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UsersViewModel datos = new()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Nombre = reader["Nombre"].ToString(),
                        Permisos = reader["Permisos"].ToString(),
                    };

                    listaDatos.Add(datos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return listaDatos;
        }
        public static UsuarioModel GetUserById(int id)
        {
            UsuarioModel usuario = new();
            try
            {
                string Query = "Select * From usuarios Where id = @id LIMIT 1;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                command.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.Permisos = reader["Permisos"].ToString();
                    usuario.Nombre = reader["Nombre"].ToString();
                    usuario.Pass = reader["Pass"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return usuario;
        }
        public static void DeleteUser(int id)
        {
            UsuarioModel usuario = new();
            try
            {
                //string Query = "Delete From usuarios Where id = @id";
                string Query = "UPDATE usuarios SET permisos = 'Eliminado' WHERE id = @id";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                GetAllFingers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static bool UpdateUser(int id, string nombre, string pass, string permisos, byte[] huella_1, byte[] huella_2)
        {
            try
            {
                string query = string.Empty;
                if (huella_1 != null && huella_2 != null)
                    query = $"UPDATE usuarios SET Nombre = @Nombre, Pass = @Pass, Permisos = @Permisos, Huella_1 = @Huella_1, Huella_2 = @Huella_2 WHERE id = @id";
                if (huella_1 != null)
                    query = $"UPDATE usuarios SET Nombre = @Nombre, Pass = @Pass, Permisos = @Permisos, Huella_1 = @Huella_1 WHERE id = @id";
                if (huella_2 != null)
                    query = $"UPDATE usuarios SET Nombre = @Nombre, Pass = @Pass, Permisos = @Permisos, Huella_2 = @Huella_2 WHERE id = @id";
                if (huella_1 == null && huella_2 == null)
                    query = $"UPDATE usuarios SET Nombre = @Nombre, Pass = @Pass, Permisos = @Permisos WHERE id = @id";

                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand mySqlCommand = new(query, connection);
                mySqlCommand.Parameters.AddWithValue("@id", id);
                mySqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                mySqlCommand.Parameters.AddWithValue("@Pass", pass);
                mySqlCommand.Parameters.AddWithValue("@Permisos", permisos);
                mySqlCommand.Parameters.AddWithValue("@Huella_1", huella_1);
                mySqlCommand.Parameters.AddWithValue("@Huella_2", huella_2);

                int idGenerado = Convert.ToInt32(mySqlCommand.ExecuteScalar());
                GetAllFingers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }

        public static bool SaveUser(string nombre, string pass, string permisos, byte[] huella_1, byte[] huella_2)
        {
            try
            {
                string Query = $"INSERT INTO usuarios SET Nombre = @Nombre, Pass = @Pass, Permisos = @Permisos, Huella_1 = @Huella_1, Huella_2 = @Huella_2";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand sqlCommand = new(Query, connection);
                sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                sqlCommand.Parameters.AddWithValue("@Pass", pass);
                sqlCommand.Parameters.AddWithValue("@Permisos", permisos);
                sqlCommand.Parameters.AddWithValue("@Huella_1", huella_1);
                sqlCommand.Parameters.AddWithValue("@Huella_2", huella_2);
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    GetAllFingers();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static void GetAllFingers()
        {
            Huellas.ListHuellas.Clear();
            try
            {
                string Query = "SELECT * FROM usuarios WHERE permisos != 'Eliminado'";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand command = new(Query, connection);
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Guardar valores de las columnas comunes
                    int id = (int)reader["id"];
                    string? nombre = reader["Nombre"].ToString();
                    string? permisos = reader["Permisos"].ToString();

                    // Verificar y leer la primera huella
                    if (!reader.IsDBNull(reader.GetOrdinal("Huella_1")))
                    {
                        byte[] huella1 = ReadBinaryData(reader, "Huella_1");
                        Huellas.ListHuellas.Add(new()
                        {
                            Id = id,
                            Nombre = nombre,
                            Permisos = permisos,
                            Huella = huella1,
                            //HuellaStr = res.ToString()

                        });
                    }

                    // Verificar y leer la segunda huella
                    if (!reader.IsDBNull(reader.GetOrdinal("Huella_2")))
                    {
                        byte[] huella2 = ReadBinaryData(reader, "Huella_2");

                        Huellas.ListHuellas.Add(new()
                        {
                            Id = id,
                            Nombre = nombre,
                            Permisos = permisos,
                            Huella = huella2,
                            //HuellaStr = res.ToString()

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        // Función para leer datos binarios de una columna dada
        private static byte[] ReadBinaryData(MySqlDataReader reader, string columnName)
        {
            long bytesLength = reader.GetBytes(reader.GetOrdinal(columnName), 0, null, 0, 0);
            byte[] buffer = new byte[bytesLength];
            if (bytesLength > 0)
            {
                reader.GetBytes(reader.GetOrdinal(columnName), 0, buffer, 0, (int)bytesLength);
            }
            return buffer;
        }

        #region Ordenes
        public static OrdenModel? CheckOrderExist(string Order)
        {
            try
            {
                //string Query = "SELECT * FROM ordenes WHERE orden = @Orden LIMIT 1;";
                string Query = "SELECT ordenes.*, productos.Producto AS ProductoCode, productos.Nombre FROM ordenes LEFT JOIN productos ON ordenes.Producto = productos.ID WHERE ordenes.orden = @Orden LIMIT 1";
                using MySqlConnection mySqlConnection = new(ConnectionString);
                mySqlConnection.Open();
                using MySqlCommand mySqlCommand = new(Query, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@Orden", Order);
                using MySqlDataReader reader = mySqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    OrdenModel ordenModel = new()
                    {
                        Id = reader.GetInt32("Id"),
                        Orden = reader.GetString("Orden"),
                        IdProducto = reader.GetInt32("Producto"),
                        CantidadRequerida = reader.GetInt32("CantidadRequerida"),
                        ProductosRequeridos = reader.GetInt32("ProductosRequeridos"),
                        Status = reader.GetString("Status"),
                        ProductoNavigation = new()
                        {
                            Producto = reader.GetString("ProductoCode"),
                            Nombre = reader.GetString("Nombre")
                        }

                    };
                    return ordenModel;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public static List<OrdenViewModel> GetOrdenes()
        {
            List<OrdenViewModel> listaDatos = new();
            try
            {
                //string Query = "SELECT ord.*, u.nombre AS NombreUsuario, prod.Producto AS NombreProducto FROM Ordenes ord LEFT JOIN usuarios u ON ord.Usuario = u.id LEFT JOIN productos prod ON prod.Producto = prod.id ORDER BY ord.id DESC;";
                string Query = "SELECT Cargas.*, u.nombre AS NombreUsuario,  prod.Producto AS NombreProducto, ORD.Orden AS NombreOrden FROM Cargas LEFT JOIN usuarios u ON Cargas.idUsuario = u.id LEFT JOIN ordenes ORD ON ORD.id = cargas.idOrden LEFT JOIN productos prod ON ORD.Producto = prod.id WHERE Cancelled = 0 ORDER BY Cargas.id DESC;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrdenViewModel datos = new()
                    {
                        Orden = reader["NombreOrden"].ToString(),
                        Producto = reader["NombreProducto"].ToString(),
                        Usuario = reader["NombreUsuario"].ToString(),
                        Inicio = reader["Inicio"].ToString(),
                        Fin = reader["Fin"].ToString()
                    };

                    listaDatos.Add(datos);
                }
                //DataTable Dato_Tabla = new();
                //dataTable.Clear();
                //Adapter.Fill(dataTable);
                //dgvPesaje.Refresh();
                //dgvPesaje.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return listaDatos;
        }
        public static int CreateOrder(CrudType crudType, string orden, string cantidadRequerida, int productosRequeridos, int idProducto)
        {
            try
            {
                string Query = string.Empty;
                if (crudType == CrudType.Create)
                    Query = "Insert into ordenes (Orden,Producto,CantidadRequerida,ProductosRequeridos) " +
                                         "values(@Orden,@Producto,@CantidadRequerida,@ProductosRequeridos); SELECT LAST_INSERT_ID();";
                //if (crudType == CrudType.Update)
                //    Query = "Update production Set Fin = @Fin WHERE";//Query = "Insert into produccion (Receta, Usuario, Inicio, Fin) values(@Receta, @Usuario, @Inicio, @Fin)";

                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand mySqlCommand = new(Query, connection);
                mySqlCommand.Parameters.AddWithValue("@Orden", orden);
                mySqlCommand.Parameters.AddWithValue("@Producto", idProducto);
                mySqlCommand.Parameters.AddWithValue("@CantidadRequerida", cantidadRequerida);
                mySqlCommand.Parameters.AddWithValue("@ProductosRequeridos", productosRequeridos);
                //mySqlCommand.Parameters.AddWithValue("@Usuario", idUsuario);
                //mySqlCommand.Parameters.AddWithValue("@Inicio", DateTime.Now);
                //mySqlCommand.Parameters.AddWithValue("@Fin", "");
                int idGenerado = Convert.ToInt32(mySqlCommand.ExecuteScalar());
                return idGenerado;
                //if (mySqlCommand.ExecuteNonQuery() > 0)
                //{
                //    //MessageBox.Show("Produccion creada correctamente");
                //    return true;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
        }

        public static bool UpdateOrderStatus(int idOrden, OrderStatus status)
        {
            try
            {
                string Query = string.Empty;
                Query = "Update ordenes Set status = @status WHERE id = @id";//Query = "Insert into produccion (Receta, Usuario, Inicio, Fin) values(@Receta, @Usuario, @Inicio, @Fin)";

                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand mySqlCommand = new(Query, connection);
                mySqlCommand.Parameters.AddWithValue("@id", idOrden);
                mySqlCommand.Parameters.AddWithValue("@status", status.ToString());
                if (mySqlCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static bool UpdateOrderAmount(int idOrden, string cantidadRequerida, int productosRequeridos, string status)
        {
            try
            {
                string Query = string.Empty;
                //Query = "Update ordenes Set cantidadRequerida = @cantidad, productosRequeridos = @productos, Status = CASE WHEN Status = 'Completed' THEN 'InProcess' ELSE Status END WHERE id = @id";
                Query = "Update ordenes Set cantidadRequerida = @cantidad, productosRequeridos = @productos, Status = @status WHERE id = @id";

                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand mySqlCommand = new(Query, connection);
                mySqlCommand.Parameters.AddWithValue("@id", idOrden);
                mySqlCommand.Parameters.AddWithValue("@cantidad", cantidadRequerida);
                mySqlCommand.Parameters.AddWithValue("@productos", productosRequeridos);
                mySqlCommand.Parameters.AddWithValue("@status", status);

                if (mySqlCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static int CreateCarga(CrudType crudType, int idOrden, int idUsuario)
        {
            try
            {
                string Query = string.Empty;
                if (crudType == CrudType.Create)
                    Query = "Insert into Cargas (idOrden, idUsuario, Inicio) " +
                                         "values(@idOrden, @idUsuario, @Inicio); SELECT LAST_INSERT_ID();";
                //if (crudType == CrudType.Update)
                //    Query = "Update production Set Fin = @Fin WHERE";//Query = "Insert into produccion (Receta, Usuario, Inicio, Fin) values(@Receta, @Usuario, @Inicio, @Fin)";

                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand mySqlCommand = new(Query, connection);
                mySqlCommand.Parameters.AddWithValue("@idOrden", idOrden);
                mySqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                mySqlCommand.Parameters.AddWithValue("@Inicio", DateTime.Now);
                //mySqlCommand.Parameters.AddWithValue("@Fin", "");
                int idGenerado = Convert.ToInt32(mySqlCommand.ExecuteScalar());
                return idGenerado;
                //if (mySqlCommand.ExecuteNonQuery() > 0)
                //{
                //    //MessageBox.Show("Produccion creada correctamente");
                //    return true;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
        }
        public static List<OrdenViewModel> GetCargas(int idOrden)
        {
            List<OrdenViewModel> listaDatos = new();
            try
            {
                //string Query = "SELECT ord.*, u.nombre AS NombreUsuario, prod.Producto AS NombreProducto FROM Ordenes ord LEFT JOIN usuarios u ON ord.Usuario = u.id LEFT JOIN productos prod ON prod.Producto = prod.id ORDER BY ord.id DESC;";
                string Query = "SELECT Cargas.*, u.nombre AS NombreUsuario,  prod.Producto AS NombreProducto, ORD.Orden AS NombreOrden FROM Cargas LEFT JOIN usuarios u ON Cargas.idUsuario = u.id LEFT JOIN ordenes ORD ON ORD.id = cargas.idOrden LEFT JOIN productos prod ON ORD.Producto = prod.id WHERE cargas.idOrden = @idOrden AND Cancelled = 0 ORDER BY Cargas.id DESC;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                command.Parameters.AddWithValue("@idOrden", idOrden);

                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrdenViewModel datos = new()
                    {
                        Id = reader.GetInt32("id"),
                        Orden = reader["NombreOrden"].ToString(),
                        Producto = reader["NombreProducto"].ToString(),
                        Usuario = reader["NombreUsuario"].ToString(),
                        Inicio = reader["Inicio"].ToString(),
                        Fin = reader["Fin"].ToString()
                    };

                    listaDatos.Add(datos);
                }
                //DataTable Dato_Tabla = new();
                //dataTable.Clear();
                //Adapter.Fill(dataTable);
                //dgvPesaje.Refresh();
                //dgvPesaje.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return listaDatos;
        }
        public static bool UpdateCarga(int idCarga)
        {
            try
            {
                string Query = string.Empty;
                Query = "Update Cargas Set Fin = @Fin WHERE id = @id";

                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand mySqlCommand = new(Query, connection);
                mySqlCommand.Parameters.AddWithValue("@id", idCarga);
                mySqlCommand.Parameters.AddWithValue("@Fin", DateTime.Now);
                if (mySqlCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //use this function if know the consequences 
        public static void CancelCargas()
        {
            try
            {
                string Query = string.Empty;
                Query = "Update Cargas Set Cancelled = 1 WHERE Fin IS NULL AND Cancelled = 0";

                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand mySqlCommand = new(Query, connection);
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //use this function if know the consequences 
        public static void DeleteCargas(int idOrden)
        {
            try
            {
                string Query = "DELETE FROM Cargas WHERE idOrden = @id;DELETE FROM consumo WHERE idOrden = @id";

                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand mySqlCommand = new(Query, connection);
                mySqlCommand.Parameters.AddWithValue("@id", idOrden);
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        #region Material Consumption
        public static List<ConsumoViewModel> GetConsumptionSum()
        {
            List<ConsumoViewModel> listaDatos = new();
            try
            {
                string Query = //"SELECT id_material, SUM(Cantidad) AS TotalCantidad, materiales.* FROM consumo LEFT JOIN materiales ON materiales.id = consumo.id_material GROUP BY id_material";
                 "SELECT id_material, SUM(TotalReal) AS TotalReal, SUM(TotalPlan) AS TotalPlan, materiales.* FROM (SELECT id_material,SUM(Cantidad) AS TotalReal,0 AS TotalPlan FROM consumo WHERE fecha >= @Fecha GROUP BY id_material UNION ALL SELECT id_material,0 AS TotalReal,  Cantidad*ordenes.ProductosRequeridos AS TotalPlan FROM instrucciones LEFT JOIN ordenes ON ordenes.Producto = instrucciones.id_Producto WHERE ordenes.fecha >= @Fecha GROUP BY id_material) AS combined LEFT JOIN materiales ON materiales.ID = combined.id_material GROUP BY id_material;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                command.Parameters.AddWithValue("@Fecha", DateTime.Now.Date);

                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    double.TryParse(reader["TotalPlan"].ToString(), out double totalPlan);
                    double.TryParse(reader["TotalReal"].ToString(), out double totalReal);

                    ConsumoViewModel datos = new()
                    {
                        //Id = reader.GetInt32("id"),
                        Material = reader["Material"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Total_Real = totalReal.ToString("0.###"),
                        Total_Plan = totalPlan.ToString("0.###"),

                        //Total_Plan = reader["TotalPlan"].ToString()
                    };

                    listaDatos.Add(datos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return listaDatos;
        }
        public static List<ConsumoSinPlanVM> GetConsumptionList(DateTime dateStart, DateTime dateEnd)
        {
            List<ConsumoSinPlanVM> listaDatos = new();
            try
            {
                string Query =
                 " SELECT consumo.*, materiales.Material, materiales.Nombre, ordenes.Orden, productos.Producto, productos.Nombre as pNombre FROM consumo left JOIN ordenes ON ordenes.id = consumo.idorden LEFT JOIN productos ON productos.ID = ordenes.Producto left JOIN materiales ON materiales.id = consumo.Id_material WHERE consumo.fecha >= @DateStart AND consumo.fecha <= @DateEnd ORDER BY consumo.fecha DESC ;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                command.Parameters.AddWithValue("@DateStart", dateStart);
                command.Parameters.AddWithValue("@DateEnd", dateEnd);

                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ConsumoSinPlanVM datos = new()
                    {
                        //Id = reader.GetInt32("id"),
                        Orden = reader["Orden"].ToString(),
                        Producto = $"{reader["Producto"]} {reader["pNombre"]}",

                        Material = $"{reader["Material"]} {reader["Nombre"]}",
                        //Nombre = reader["Nombre"].ToString(),
                        Cantidad = reader["Cantidad"].ToString(),
                        Fecha = reader["Fecha"].ToString()
                    };

                    listaDatos.Add(datos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return listaDatos;
        }
        public static List<ConsumoSinPlanVM> GetConsumListByOrder(int idOrder)
        {
            List<ConsumoSinPlanVM> listaDatos = new();
            try
            {
                string Query =
                 " SELECT consumo.*, materiales.*, ordenes.*,productos.nombre AS pNombre, productos.Producto AS pProd FROM consumo left JOIN materiales ON materiales.id = consumo.Id_material left JOIN ordenes ON ordenes.id = consumo.idOrden left JOIN productos ON ordenes.Producto = productos.id WHERE idOrden = @idOrden;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                command.Parameters.AddWithValue("@idOrden", idOrder);
                //command.Parameters.AddWithValue("@DateEnd", dateEnd);

                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ConsumoSinPlanVM datos = new()
                    {
                        //Id = reader.GetInt32("id"),
                        Material = reader["Material"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Cantidad = reader["Cantidad"].ToString(),
                        Fecha = reader["Fecha"].ToString(),
                        Orden = reader["Orden"].ToString(),
                        Producto = reader["pProd"].ToString(),
                        NombreProd = reader["pNombre"].ToString()
                    };

                    listaDatos.Add(datos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return listaDatos;
        }
        public static bool RegisterConsumption(List<InstruccionDataModel> materials, int idOrden)
        {
            if (materials is null || materials.Count <= 0) return false;

            try
            {
                StringBuilder queryBuilder = new("INSERT INTO consumo (ID_Material,idOrden, Cantidad) VALUES ");

                for (int i = 0; i < materials.Count; i++)
                {
                    queryBuilder.Append($"(@idMaterial{i}, @idOrden{i}, @Cantidad{i})");
                    if (i < materials.Count - 1)
                    {
                        queryBuilder.Append(", ");
                    }
                }
                string query = queryBuilder.ToString();
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand sqlCommand = new(query, connection);

                for (int i = 0; i < materials.Count; i++)
                {
                    sqlCommand.Parameters.AddWithValue($"@idMaterial{i}", materials[i].IdMaterial);
                    sqlCommand.Parameters.AddWithValue($"@idOrden{i}", idOrden);
                    sqlCommand.Parameters.AddWithValue($"@Cantidad{i}", materials[i].Cantidad);
                }
                //qlCommand.Parameters.AddWithValue("@idUsuario", idUser);
                return sqlCommand.ExecuteNonQuery() == materials.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }


        #endregion

        #region Calidad
        public static bool QualityRegister(int idUser, string comentario)
        {
            try
            {
                int maxLength;
                using MySqlConnection connectionPre = new(ConnectionString);
                connectionPre.Open();
                using MySqlCommand command = new MySqlCommand("SELECT CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'calidad' AND COLUMN_NAME = 'comentario'", connectionPre);
                maxLength = Convert.ToInt32(command.ExecuteScalar());

                // Recortar el comentario si es necesario
                if (comentario.Length > maxLength)
                {
                    comentario = comentario.Substring(0, maxLength);
                }

                string Query = $"INSERT INTO calidad SET ID_Usuario = @idUsuario, comentario = @Comentario";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                using MySqlCommand sqlCommand = new(Query, connection);
                sqlCommand.Parameters.AddWithValue("@idUsuario", idUser);
                sqlCommand.Parameters.AddWithValue("@comentario", comentario);
                //if (
                sqlCommand.ExecuteNonQuery();
                //    > 0)
                //{
                return true;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static List<CalidadViewModel> GetQualityList()
        {
            List<CalidadViewModel> listaDatos = new();
            try
            {
                string Query = "SELECT Calidad.*, usuarios.nombre FROM Calidad LEFT JOIN usuarios ON Calidad.id_Usuario = usuarios.id OrDER BY fecha DESC;";
                using MySqlConnection connection = new(ConnectionString);
                connection.Open();
                MySqlCommand command = new(Query, connection);
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CalidadViewModel datos = new()
                    {
                        Id = reader["Id"].ToString(),
                        Usuario = reader["Nombre"].ToString(),
                        Fecha = reader["Fecha"].ToString(),
                        Comentario = reader["Comentario"].ToString()
                    };

                    listaDatos.Add(datos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return listaDatos;
        }

        #endregion

    }
}
