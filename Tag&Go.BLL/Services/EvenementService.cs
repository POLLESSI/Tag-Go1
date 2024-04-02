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
    public class EvenementService : IEvenementService
    {
        private readonly IEvenementRepository _evenementRepository;

        public EvenementService(IEvenementRepository evenementRepository)
        {
            _evenementRepository = evenementRepository;
        }

        public bool Create(Evenement evenement)
        {
            try
            {
                return _evenementRepository.Create(evenement);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating Event : {ex.ToString}");
            }
            return false;
        }

        public void CreateEvenement(Evenement evenement)
        {
            try
            {
                _evenementRepository.CreateEvenement(evenement);
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
                return _evenementRepository.Delete(evenement_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting event : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Evenement?> GetAll()
        {
            return _evenementRepository.GetAll();
        }

        public Evenement? GetById(int evenement_Id)
        {
            try
            {
                return _evenementRepository.GetById(evenement_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting event : {ex.ToString}");
            }
            return null;
        }

        public Evenement? Update(int evenement_Id, DateTime evenementDate, string evenementName, string evenementDescription, string posLat, string posLong, string positif, int organisateur_Id, int icon_Id, int recompense_Id, int bonus_Id, int mediaItem_Id)
        {
            try
            {
                var UpdateEvenement = _evenementRepository.Update(evenement_Id, evenementDate, evenementDescription, posLat, posLong, positif, organisateur_Id, icon_Id, recompense_Id, bonus_Id, mediaItem_Id);
                return UpdateEvenement;
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
