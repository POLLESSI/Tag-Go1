using Tag_Go.BLL;
using Tag_Go.DAL.Entities;
using Tag_Go.DAL.Repositories;
using Tag_Go.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Client;
using Tag_Go.BLL.Interfaces;


namespace Tag_Go.BLL.Services
{
    public class BonusService : IBonusService
    {
        private readonly IBonusRepository _bonusRepository;

        public BonusService(IBonusRepository blogRepository)
        {
            _bonusRepository = blogRepository;
        }

        public bool Create(Bonus bonus)
        {
            try
            {
                return _bonusRepository.Create(bonus);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating bonus : {ex.ToString}");
            }
            return false;
        }

        public void CreateBonus(Bonus bonus)
        {
            try
            {
                _bonusRepository.CreateBonus(bonus);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateBonus : {ex.ToString}");
            }
        }

        public Bonus? Delete(int bonus_Id)
        {
            try
            {
                return _bonusRepository.Delete(bonus_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting bonus : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Bonus?> GetAll()
        {
            return _bonusRepository.GetAll();
        }

        public Bonus? GetById(int bonus_Id)
        {
            try
            {
                return _bonusRepository.GetById(bonus_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting bonus : {ex.ToString}");
            }
            return null;
        }

        public Bonus? Update(int bonus_Id, string bonusType, string bonusDescription, string application, string granted)
        {
            try
            {
                var UpdateBonus = _bonusRepository.Update(bonus_Id, bonusType, bonusDescription, application, granted);
                return UpdateBonus;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating bonus : {ex}");
            }
            return new Bonus();
        }
    }
}
