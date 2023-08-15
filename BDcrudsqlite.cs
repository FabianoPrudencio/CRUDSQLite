using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSQLite
{
    public class BDcrudsqlite
    {
        public static string BDcrud = Directory.GetCurrentDirectory() + "\\BDcrudsaqlite.sqlite";
        private static SQLiteConnection SQLiteConnection;

        private static SQLiteConnection DBconnection()
        {
            SQLiteConnection = new SQLiteConnection("data source=" + BDcrud);
            SQLiteConnection.Open();
            return SQLiteConnection;
        }

        public static void CriarBancoSQLite()
        {
            try
            {
                if (File.Exists(BDcrud) == false)
                {
                    SQLiteConnection.CreateFile(BDcrud);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CriarTabelaSQLite()
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS CUDSQLite(ID int, NOME Varchar(130), EMAIL Varchar(130))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetID(int ID)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM CUDSQLite where ID like '%" + ID + "%'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DBconnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Add(GScrudsqlite gScrudsqlite)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO CUDSQLite(ID, NOME, EMAIL)values(@Id, @Nome, @Email)";
                    cmd.Parameters.AddWithValue("@Id", gScrudsqlite.ID);
                    cmd.Parameters.AddWithValue("@Nome", gScrudsqlite.NOME);
                    cmd.Parameters.AddWithValue("@Email", gScrudsqlite.EMAIL);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(GScrudsqlite gScrudsqlite)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "UPDATE CUDSQLite SET NOME=@Nome, EMAIL=@Email WHERE ID=@Id";
                    cmd.Parameters.AddWithValue("@Id", gScrudsqlite.ID);
                    cmd.Parameters.AddWithValue("@Nome", gScrudsqlite.NOME);
                    cmd.Parameters.AddWithValue("@Email", gScrudsqlite.EMAIL);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteId(int Id)
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM CUDSQLite Where ID=@Id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
