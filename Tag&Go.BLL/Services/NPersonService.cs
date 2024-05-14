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
    public class NPersonService : INPersonService
    {
        private readonly INPersonRepository _nPersonRepository;

        public NPersonService(INPersonRepository nPersonRepository)
        {
            _nPersonRepository = nPersonRepository;
        }

        public bool Create(NPerson nPerson)
        {
            try
            {
                return _nPersonRepository.Create(nPerson);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating new person : {ex.ToString}");
            }
            return false;
        }

        public void CreatePerson(NPerson nPerson)
        {
            try
            {
                _nPersonRepository.CreatePerson(nPerson);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreatePerson : {ex.ToString}");
            }
        }

        public NPerson? Delete(int nPerson_Id)
        {
            try
            {
                return _nPersonRepository.Delete(nPerson_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting person : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<NPerson?> GetAll()
        {
            return _nPersonRepository.GetAll();
        }

        public NPerson? GetById(int nPerson_Id)
        {
            try
            {
                return _nPersonRepository.GetById(nPerson_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting person : {ex.ToString}");
            }
            return null;
        }

        public NPerson? Update(string lastname, string firstname, string email, string address_Street, string address_Nbr, string postalCode, string address_City, string address_Country, string telephone, string gsm, int nPerson_Id)
        {
            try
            {
                var updatePerson = _nPersonRepository.Update(lastname, firstname, email, address_Street, address_Nbr, postalCode, address_City, address_Country, telephone, gsm, nPerson_Id);
                return updatePerson;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating person : {ex.Message}");
            }
            return new NPerson();
        }
    }
}
