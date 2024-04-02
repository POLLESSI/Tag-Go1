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
    public class IconService : IIconService
    {
        private readonly IIconRepository _iconRepository;

        public IconService(IIconRepository iconRepository)
        {
            _iconRepository = iconRepository;
        }

        public bool Create(Icon icon)
        {
            try
            {
                return _iconRepository.Create(icon);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating Icon : {ex.ToString}");
            }
            return false;
        }

        public void CreateIcon(Icon icon)
        {
            try
            {
                _iconRepository.CreateIcon(icon);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error createIcon : {ex.ToString}");
            }
        }

        public Icon? Delete(int icon_Id)
        {
            try
            {
                return _iconRepository.Delete(icon_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Icon : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Icon?> GetAll()
        {
            return _iconRepository.GetAll();
        }

        public Icon? GetById(int icon_Id)
        {
            try
            {
                return _iconRepository.GetById(icon_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Icon : {ex.ToString}");
            }
            return null;
        }

        public Icon? Update(int icon_Id, string iconName, string iconDescription, string iconUrl)
        {
            try
            {
                var UpdateIcon = _iconRepository.Update(icon_Id, iconName, iconDescription, iconUrl);
                return UpdateIcon;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating icon : {ex}");
            }
            return new Icon();
        }
    }
}
