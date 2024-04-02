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
    public class OrganisateurService : IOrganisateurService
    {
        private readonly IOrganisateurRepository _organisateurRepository;

        public OrganisateurService(IOrganisateurRepository organisateurRepository)
        {
            _organisateurRepository = organisateurRepository;
        }

        public bool Create(Organisateur organisateur)
        {
            try
            {
                return _organisateurRepository.Create(organisateur);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating organisateur : {ex.ToString}");
            }
            return false;
        }

        public void CreateOrganisateur(Organisateur organisateur)
        {
            try
            {
                _organisateurRepository.CreateOrganisateur(organisateur);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error createOrganisateur : {ex.ToString}");
            }
        }

        public Organisateur? Delete(int organisateur_Id)
        {
            try
            {
                return _organisateurRepository.Delete(organisateur_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting organisator : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Organisateur?> GetAll()
        {
            return _organisateurRepository.GetAll();
        }

        public Organisateur? GetById(int organisateur_Id)
        {
            try
            {
                return _organisateurRepository.GetById(organisateur_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting organisator : {ex.ToString}");
            }
            return null;
        }

        public Organisateur? Update(int organisateur_Id, string companyName, string businessNumber, int nUser_Id, string point)
        {
            try
            {
                var UpdateOrganisateur = _organisateurRepository.Update(organisateur_Id, companyName, businessNumber, nUser_Id, point);
                return UpdateOrganisateur;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating organisator : {ex}");
            }
            return new Organisateur();
        }
    }
}
