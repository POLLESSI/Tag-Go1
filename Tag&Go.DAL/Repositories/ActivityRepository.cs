﻿using System;
using Tag_Go.DAL.Entities;
using Tag_Go.DAL.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tag_Go.DAL.Repositories
{
    public class ActivityRepository : IActivityRepository
    { 
        private readonly SqlConnection _connection;

        public ActivityRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(Activity activity)
        {
            try
            {
                string sql = "INSERT INTO Activity (ActivityName, ActivityAddress, ActivityDescription, ComplementareInformation, PosLat, PosLong, Organisateur_Id) VALUES " +
                    "(@activityName, @activityAddress, @activityDescription, @complementareInformation, @posLat, @posLong, @organisateur_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@activityName", activity.ActivityName);
                parameters.Add("@activityAddress", activity.ActivityAddress);
                parameters.Add("@activityDescription", activity.ActivityDescription);
                parameters.Add("@complementareInformation", activity.ComplementareInformation);
                parameters.Add("@posLat", activity.PosLat);
                parameters.Add("@posLong", activity.PosLong);
                parameters.Add("@organisateur_Id", activity.Organisateur_Id);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Encoding New Activity : {ex.ToString}");
            }
            return false;
            
        }

        public void CreateActivity(Activity activity)
        {
            try
            {
                string sql = "INSERT INTO Activity (ActivityName, ActivityAddress, ActivityDescription, ComplementareInformation, PosLat, PosLong, Organisateur_Id)" +
                    "VALUES (@ActivityName, @ActivityAddress, @ActivityDescription, @ComplementareInformation, @PosLat, @PosLong, @Organisateur_id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ActivityName", activity.ActivityName);
                parameters.Add("@ActivityAddress", activity.ActivityAddress);
                parameters.Add("@ComplementareInformation", activity.ComplementareInformation);
                parameters.Add("@PosLat", activity.PosLat);
                parameters.Add("@PosLong", activity.PosLong);
                parameters.Add("@Organisateur_Id", activity.Organisateur_Id);
                _connection.Execute(sql, activity);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateActivity : {ex.ToString}");
            }
        }

        public Activity? Delete(int activity_Id)
        {
            try
            {
                string sql = "DELETE FROM Activity WHERE Activity_Id = @activity_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@activity_Id", activity_Id);
                return _connection.QueryFirst<Activity?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting activity : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Activity?> GetAll()
        {
            string sql = "SELECT * FROM Activity";
            return _connection.Query<Activity?>(sql);
        }

        public Activity? GetById(int activity_Id)
        {
            try
            {
                string sql = "SELECT * FROM Activity WHERE Activity_Id = @activity_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@activity_Id", activity_Id);
                return _connection.QueryFirst<Activity?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Activity : {ex.ToString}");
            }
            return null;
        }

        public Activity? Update(int activity_Id, string activityName, string activityAddress, string activityDescription, string complementareInformation, string posLat, string posLong, int organisateur_Id)
        {
            try
            {
                string sql = "UPDATE Activity SET ActivityName = @activityName, ActivityAddress = @activityAddress, ActivityDescription = @activityDescription, ComplementareInformation = @complementareInformation, PosLat = @posLat, PosLong = @posLong, Organisateur_Id = @organisateur_Id WHERE Activity_Id = @activity_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@activityName", activityName);
                parameters.Add("@activityAddress", activityAddress);
                parameters.Add("@activityDescription", activityDescription);
                parameters.Add("@complementareInformation", complementareInformation);
                parameters.Add("@posLat", posLat);
                parameters.Add("@posLong", posLong);
                parameters.Add("@organisateur_Id", organisateur_Id);
                return _connection.QueryFirst<Activity?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating activity : {ex}");
            }
            return new Activity();
        }
    }
}
