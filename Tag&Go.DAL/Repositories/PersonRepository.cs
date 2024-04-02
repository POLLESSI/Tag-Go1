using Tag_Go.DAL.Entities;
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
    public class PersonRepository : IPersonRepository
    {
        private readonly SqlConnection _connection;

        public PersonRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(Person person)
        {
            try
            {
                string sql = "INSERT INTO Person (Lastname, Firstname, Email, Address_Street, Address_Nbr, PostalCode, Address_City, Address_Country, Telephone, Gsm) VALUES " +
                    "(@Lastname, @Firstname, @Email, @Address_Street, @Address_Nbr, @PostalCode, @Address_City, @Address_Country, @Telephone, @Gsm)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Lastname", person.Lastname);
                parameters.Add("@Firstname", person.Firstname);
                parameters.Add("@Email", person.Email);
                parameters.Add("@Address_Street", person.Address_Street);
                parameters.Add("@Address_Nbr", person.Address_Nbr);
                parameters.Add("@PostalCode", person.PostalCode);
                parameters.Add("@Address_City", person.Address_City);
                parameters.Add("@Address_Country", person.Address_Country);
                parameters.Add("@Telephone", person.Telephone);
                parameters.Add("@Gsm", person.Gsm);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding New Person : {ex.ToString}");
            }
            return false;
        }

        public void CreatePerson(Person person)
        {
            try
            {
                string sql = "INSERT INTO Person (Lastname, Firstname, Email, Address_Street, Address_Nbr, PostalCode, Address_City, Address_Country, Telephone, Gsm) " +
                    "VALUES (@lastname, @firstname, @email, @address_Street, @address_Nbr, @postalCode, @address_City, @address_Country, @telephone, @gsm)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@lastname", person.Lastname);
                parameters.Add("@firstname", person.Firstname);
                parameters.Add("@email", person.Email);
                parameters.Add("@address_Street", person.Address_Street);
                parameters.Add("@address_Nbr", person.Address_Nbr);
                parameters.Add("@postalCode", person.PostalCode);
                parameters.Add("@address_City", person.Address_City);
                parameters.Add("@address_Country", person.Address_Country);
                parameters.Add("@telephone", person.Telephone);
                parameters.Add("@gsm", person.Gsm);
                _connection.Query<Person?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating New Person : {ex.ToString}");
            }
        }

        public Person? Delete(int person_Id)
        {
            try
            {
                string sql = "DELETE FROM Person WHERE Person_Id = @person_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@person_Id", person_Id);
                return _connection.QueryFirst<Person?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Person : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Person?> GetAll()
        {
            string sql = "SELECT * FROM Person";
            return _connection.Query<Person?>(sql);
        }

        public Person? GetById(int person_Id)
        {
            try
            {
                string sql = "SELECT * FROM Person WHERE Person_Id = @person_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@person_Id", person_Id);
                return _connection.QueryFirst<Person?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Person : {ex.ToString}");
            }
            return null;
        }

        public Person? Update(int person_Id, string lastname, string firstname, string email, string address_Street, string address_Nbr, string postalCode, string address_City, string address_Country, string telephone, string gsm)
        {
            try
            {
                string sql = "Update Person SET Lastname = @lastname, Firstname = @firstname, Email = @email, Address_Street = @address_Street, Address_Nbr = @address_Nbr, PostalCode = @postalCode, Address_City = @address_City, Address_Country = @address_Country, Telephone = @telephone, Gsm = @gsm WHERE Person_Id = @person_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@person_Id", person_Id);
                parameters.Add("@lastname", lastname);
                parameters.Add("@firstname", firstname);
                parameters.Add("@email", email);
                parameters.Add("@address_Street", address_Street);
                parameters.Add("@address_Nbr", address_Nbr);
                parameters.Add("@postalCode", postalCode);
                parameters.Add("@address_City", address_City);
                parameters.Add("@address_Country", address_Country);
                parameters.Add("@telephone", telephone);
                parameters.Add("@gsm", gsm);
                return _connection.QueryFirst<Person?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Person : {ex}");
            }
            return new Person();
        }
    }
}
