using Tag_Go.DAL.Entities;
using Tag_Go.DAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Tag_Go.DAL.Repositories
{
    public class IconRepository : IIconRepository
    {
        private readonly SqlConnection _connection;

        public IconRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(Icon icon)
        {
            try
            {
                string sql = "INSERT INTO Icon (IconName, IconDescription, IConUrl) VALUES" +
                    "(@IconName, @IconDescription, @IconUrl)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IconName", icon.IconName);
                parameters.Add("@IconDescription", icon.IconDescription);
                parameters.Add("@IconUrl", icon.IconUrl);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating Icon : {ex.ToString}");
            }
            return false;
        }

        public void CreateIcon(Icon icon)
        {
            try
            {
                string sql = "INSERT INTO Icon (IconName, IconDescription, IconUrl)" +
                    "VALUES (@iconName, @iconDescription, @iconUrl)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@iconName", icon.IconName);
                parameters.Add("@iconDescription", icon.IconDescription);
                parameters.Add("@iconUrl", icon.IconUrl);
                _connection.Query<Icon?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating new Icon : {ex.ToString}");
            }
        }

        public Icon? Delete(int icon_Id)
        {
            try
            {
                string sql = "DELETE FROM Icon WHERE Icon_Id = @icon_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@icon_Id", icon_Id);
                return _connection.QueryFirst<Icon?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Icon : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Icon?> GetAll()
        {
            string sql = "SELECT * FROM Icon";
            return _connection.Query<Icon?>(sql);
        }

        public Icon? GetById(int icon_Id)
        {
            try
            {
                string sql = "SELECT * FROM Icon WHERE Icon_Id = @icon_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@icon_Id", icon_Id);
                return _connection.QueryFirst<Icon?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Icon : {ex.ToString}");
            }
            return null;
        }

        public Icon? Update(int icon_Id, string iconName, string iconDescription, string iconUrl)
        {
            try
            {
                string sql = "UPDATE Icon SET IconName = @iconName, IconDescription = @iconDescription, IconUrl = @iconUrl WHERE Icon_Id = @icon_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@iconName", iconName);
                parameters.Add("@iconDescription", iconDescription);
                parameters.Add("@iconUrl", iconUrl);
                parameters.Add("@icon_Id", icon_Id);
                return _connection.QueryFirst<Icon?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Updating Icon : {ex}");
            }
            return new Icon();
        }
    }
}
