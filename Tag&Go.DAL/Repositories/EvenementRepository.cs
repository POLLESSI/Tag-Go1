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
    public class EvenementRepository : IEvenementRepository
    {
        private readonly SqlConnection _connection;

        public EvenementRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(Evenement evenement)
        {
            try
            {
                string sql = "INSERT INTO Evenement (EvenementDate, EvenementName, EvenementDescription, PosLat, PosLong, Positif, Organisateur_Id, Icon_Id, Recompense_Id, Bonus_Id, MediaItem_Id) VALUES " +
                    "(@EvenementDate, @EvenementName, @EvenementDesciption, @PosLat, @PosLong, @Positif, @Organisateur_Id, @Icon_Id, @Recompense_Id, @Bonus_Id, @MediaItem_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EvenementDate", evenement.EvenementDate);
                parameters.Add("@EvenementName", evenement.EvenementName);
                parameters.Add("@EvenementDescription", evenement.EvenementDescription);
                parameters.Add("@PosLat", evenement.PosLat);
                parameters.Add("@PosLong", evenement.PosLong);
                parameters.Add("@Positif", evenement.Positif);
                parameters.Add("@Organisateur_Id", evenement.Organisateur_Id);
                parameters.Add("@Icon_Id", evenement.Icon_Id);
                parameters.Add("@Recompense_Id", evenement.Recompense_Id);
                parameters.Add("@Bonus_Id", evenement.Bonus_Id);
                parameters.Add("@MediaItem_Id", evenement.MediaItem_Id);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error enconding Event : {ex.ToString}");
            }
            return false;
        }

        public void CreateEvenement(Evenement evenement)
        {
            try
            {
                string sql = "INSERT INTO Evenement (EvenementDate, EvenementName, EvenementDescription, PosLat, PosLong, Positif, Organisateur_Id, Icon_Id, Recompense_Id, Bonus_Id, MediaItem_Id)" +
                    "VALUES (@evenementDate, @evenementName, @evenementDescription, @posLat, @posLong, @positif, @organisateur_Id, @icon_Id, @recompense_Id, @bonus_id, @mediaItem_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@evenementDate", evenement.EvenementDate);
                parameters.Add("@evenementName", evenement.EvenementName);
                parameters.Add("@evenementDescription", evenement.EvenementDescription);
                parameters.Add("@posLat", evenement.PosLat);
                parameters.Add("@posLong", evenement.PosLong);
                parameters.Add("@positif", evenement.Positif);
                parameters.Add("@organisateur_Id", evenement.Organisateur_Id);
                parameters.Add("@icon_Id", evenement.Icon_Id);
                parameters.Add("@recompense_Id", evenement.Recompense_Id);
                parameters.Add("@bonus_Id", evenement.Bonus_Id);
                parameters.Add("@mediaItem", evenement.MediaItem_Id);
                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateEvent : {ex.ToString}");
            }
        }

        public Evenement? Delete(int evenement_Id)
        {
            try
            {
                string sql = "DELETE FROM Evenement WHERE Evenement_Id = @evenement_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@evenement_Id", evenement_Id);
                return _connection.QueryFirst<Evenement?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting evenement : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Evenement?> GetAll()
        {
            string sql = "SELECT * FROM Evenement";
            return _connection.Query<Evenement?>(sql);
        }

        public Evenement? GetById(int evenement_Id)
        {
            try
            {
                string sql = "SELECT * FROM Evenement WHERE Evenement_Id = @evenement_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@evenement_Id", evenement_Id);
                return _connection.QueryFirst<Evenement?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Event : {ex.ToString}");
            }
            return null;
        }

        public Evenement? Update(int evenement_Id, DateTime evenementDate, string evenementDescription, string posLat, string posLong, string positif, int organisateur_Id, int icon_Id, int recompense_Id, int bonus_Id, int mediaItem_Id)
        {
            try
            {
                string sql = "UPDATE Evenement SET EvenementDate = @evenementDate, EvenementDescription = @evenementDescription, PosLat = @posLat, PosLong = @posLong, Positif = @positif, Organisateur_Id = @organisateur_Id, Icon_Id = @icon_Id, Recompense_Id = @recompense_Id, Bonus_Id = @bonus_Id, MediaItem_Id = @mediaItem_Id WHERE Evenement_Id = @evenement_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@evenementDate", evenementDate);
                parameters.Add("@evenementDescription", evenementDescription);
                parameters.Add("@posLat", posLat);
                parameters.Add("@posLong", posLong);
                parameters.Add("@positif", positif);
                parameters.Add("@organisateur_Id", organisateur_Id);
                parameters.Add("@icon_Id", icon_Id);
                parameters.Add("@recompense_Id", recompense_Id);
                parameters.Add("@bonus_Id", bonus_Id);
                parameters.Add("@mediaItem", mediaItem_Id);
                parameters.Add("@evenement_Id", evenement_Id);
                return _connection.QueryFirst<Evenement?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating event : {ex}");
            }
            return new Evenement();
        }
    }
}
