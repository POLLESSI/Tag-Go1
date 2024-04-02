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
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;

        public MapService(IMapRepository mapRepository)
        {
            _mapRepository = mapRepository;
        }

        public bool Create(Map map)
        {
            try
            {
                return _mapRepository.Create(map);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating map : {ex.ToString}");
            }
            return false;
        }

        public void CreateMap(Map map)
        {
            try
            {
                _mapRepository.CreateMap(map);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateMap : {ex.ToString}");
            }
        }

        public Map? Delete(int map_Id)
        {
            try
            {
                return _mapRepository.Delete(map_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting map : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Map?> GetAll()
        {
            return _mapRepository.GetAll();
        }

        public Map? GetById(int map_Id)
        {
            try
            {
                return _mapRepository.GetById(map_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting map : {ex.ToString}");
            }
            return null;
        }

        public Map? Update(int map_Id, DateTime dateCreation, string mapUrl, string description)
        {
            try
            {
                var updateMap = _mapRepository.Update(map_Id, dateCreation, mapUrl, description);
                return updateMap;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating map : {ex}");
            }
            return new Map();
        }
    }
}
