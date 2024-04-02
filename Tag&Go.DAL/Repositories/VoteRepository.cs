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
    public class VoteRepository : IVoteRepository
    {
        private readonly SqlConnection _connection;

        public VoteRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(Vote vote)
        {
            try
            {
                string sql = "INSERT INTO Vote (Evenement_Id, FunOrNot, Comment) VALUES " +
                    "(@Evenement_Id, @FunOrNot, @Comment)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Evenement_Id", vote.Evenement_Id);
                parameters.Add("@FunOrNot", vote.FunOrNot);
                parameters.Add("@Comment", vote.Comment);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding Vote : {ex.ToString}");
            }
            return false;
        }

        public void CreateVote(Vote vote)
        {
            try
            {
                string sql = "INSERT INTO Vote (Evenement_Id, FunOrNot, Comment) " +
                    "VALUES (@evenement_Id, @funOrNot, @comment)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@evenement_Id", vote.Evenement_Id);
                parameters.Add("@funOrNot", vote.FunOrNot);
                parameters.Add("@comment", vote.Comment);
                _connection.Query<Vote?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating new Vote : {ex.ToString}");
            }
        }

        public Vote? Delete(int vote_Id)
        {
            try
            {
                string sql = "DELETE FROM Vote WHERE Vote_Id = @vote_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@vote_Id", vote_Id);
                return _connection.QueryFirst<Vote?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting vote : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Vote?> GetAll()
        {
            string sql = "SELECT * FROM Vote";
            return _connection.Query<Vote?>(sql);
        }

        public Vote? GetById(int vote_Id)
        {
            try
            {
                string sql = "SELECT * FROM Vote WHERE Vote_Id = @vote_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@vote_Id", vote_Id);
                return _connection.QueryFirst<Vote?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Vote : {ex.ToString}");
            }
            return null;
        }
    }
}
