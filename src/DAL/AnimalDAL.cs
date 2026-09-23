using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Entidades;

namespace DAL
{
    public class AnimalDAL
    {
        private Conexion conexion = new Conexion();

        // INSERTAR
        public void Insertar(AnimalPerdido animal)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("InsertarAnimal", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", animal.Nombre);
                    cmd.Parameters.AddWithValue("@Especie", animal.Especie);
                    cmd.Parameters.AddWithValue("@Raza", animal.Raza);
                    cmd.Parameters.AddWithValue("@Color", animal.Color);
                    cmd.Parameters.AddWithValue("@Descripcion", animal.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaPerdida", animal.FechaPerdida);
                    cmd.Parameters.AddWithValue("@LugarPerdida", animal.LugarPerdida);
                    cmd.Parameters.AddWithValue("@Estado", animal.Estado);
                    cmd.Parameters.AddWithValue("@IdPersona", animal.IdPersona);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // CONSULTAR
        public DataTable Listar()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("ListarAnimales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        // ACTUALIZAR
        public void Actualizar(AnimalPerdido animal)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarAnimal", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
                    cmd.Parameters.AddWithValue("@Nombre", animal.Nombre);
                    cmd.Parameters.AddWithValue("@Especie", animal.Especie);
                    cmd.Parameters.AddWithValue("@Raza", animal.Raza);
                    cmd.Parameters.AddWithValue("@Color", animal.Color);
                    cmd.Parameters.AddWithValue("@Descripcion", animal.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaPerdida", animal.FechaPerdida);
                    cmd.Parameters.AddWithValue("@LugarPerdida", animal.LugarPerdida);
                    cmd.Parameters.AddWithValue("@Estado", animal.Estado);
                    cmd.Parameters.AddWithValue("@IdPersona", animal.IdPersona);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ELIMINAR
        public void Eliminar(int idAnimal)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("EliminarAnimal", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}