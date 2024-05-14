using Tag_Go.BLL.Interfaces;
using Tag_Go.DAL.Entities;
using Tag_Go.DAL.Interfaces;
using Tag_Go.DAL.Repositories;
using Tag_Go.BLL;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Client;

namespace Tag_Go.BLL.Services
{
    public class RecompenseService : IRecompenseService
    {
        private readonly IRecompenseRepository _recompenseRepository;

        public RecompenseService(IRecompenseRepository recompenseRepository)
        {
            _recompenseRepository = recompenseRepository;
        }

        public bool Create(Recompense recompense)
        {
            try
            {
                return _recompenseRepository.Create(recompense);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating recompense : {ex.ToString}");
            }
            return false;
        }

        public void CreateRecompense(Recompense recompense)
        {
            try
            {
                _recompenseRepository.CreateRecompense(recompense);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error createRecompense : {ex.ToString}");
            }
        }

        public Recompense? Delete(int recompense_Id)
        {
            try
            {
                return _recompenseRepository.Delete(recompense_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting recompense : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Recompense?> GetAll()
        {
            return _recompenseRepository.GetAll();
        }

        public Recompense? GetById(int recompense_Id)
        {
            try
            {
                return _recompenseRepository.GetById(recompense_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting event : {ex.ToString}");
            }
            return null;
        }

        public Recompense? Update(string definition, string point, string implication, string granted, int recompense_Id)
        {
            try
            {
                var UpdateRecompense = _recompenseRepository.Update(definition, point, implication, granted, recompense_Id);
                return UpdateRecompense;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating recompense : {ex}");
            }
            return new Recompense();
        }
    }
}
