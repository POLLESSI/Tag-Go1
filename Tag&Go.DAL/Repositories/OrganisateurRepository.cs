﻿using Tag_Go.DAL.Entities;
using Tag_Go.DAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tag_Go.DAL.Repositories
{
    public class OrganisateurRepository : IOrganisateurRepository
    {
        private readonly SqlConnection _connection;

        public OrganisateurRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(Organisateur organisateur)
        {
            try
            {
                string sql = "INSERT INTO Organisateur (CompanyName, BusinessNumber, NUser_Id, Point) VALUES " +
                    "(@CompanyName, @BusinessNumber, @NUser_Id, @Point)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyName", organisateur.CompanyName);
                parameters.Add("@BusinessNumber", organisateur.BusinessNumber);
                parameters.Add("@NUser_Id", organisateur.NUser_Id);
                parameters.Add("@Point", organisateur.Point);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding Organisator : {ex.ToString}");
            }
            return false;
        }

        public void CreateOrganisateur(Organisateur organisateur)
        {
            try
            {
                string sql = "INSERT INTO Organisateur (CompanyName, BusinessNumber, NUser_Id, Point)" +
                    "VALUES (@companyName, @businessNumber, @nUser_Id, @point)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyName", organisateur.CompanyName);
                parameters.Add("@businessNumber", organisateur.BusinessNumber);
                parameters.Add("@nUser_Id", organisateur.NUser_Id);
                parameters.Add("@point", organisateur.Point);
                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error createOrganisator : {ex.ToString}");
            }
        }

        public Organisateur? Delete(int organisateur_Id)
        {
            try
            {
                string sql = "DELETE FROM Organisateur WHERE Organisateur_Id = @organisateur_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@organisateur_Id", organisateur_Id);
                return _connection.QueryFirst<Organisateur?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Organisateur : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Organisateur?> GetAll()
        {
            string sql = "SELECT * FROM Organisateur";
            return _connection.Query<Organisateur?>(sql);
        }

        public Organisateur? GetById(int organisateur_Id)
        {
            try
            {
                string sql = "SELECT * FROM Organisateur WHERE Organisateur_Id = @organisateur_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@organisateur_Id", organisateur_Id);
                return _connection.QueryFirst<Organisateur?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Organisator : {ex.ToString}");
            }
            return null;
        }

        public Organisateur? Update(int organisateur_Id, string companyName, string businessNumber, int nUser_Id, string point)
        {
            try
            {
                string sql = "UPDATE Organisateur SET CompanyName = @companyName, BusinessNumber = @businessNumber, NUser_Id = @nUser_Id, Point = @point WHERE Organisateur_Id = @organisateur_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyName", companyName);
                parameters.Add("@businessNumber", businessNumber);
                parameters.Add("@nUser_Id", nUser_Id);
                parameters.Add("@point", point);
                parameters.Add("@organisateur_Id", organisateur_Id);
                return _connection.QueryFirst<Organisateur?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Organisator : {ex}");
            }
            return new Organisateur();
        }
    }
}
