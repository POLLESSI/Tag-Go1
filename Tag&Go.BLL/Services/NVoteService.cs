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
    public class NVoteService : INVoteService
    {
        private readonly INVoteRepository _nVoteRepository;

        public NVoteService(INVoteRepository nVoteRepository)
        {
            _nVoteRepository = nVoteRepository;
        }

        public bool Create(NVote nVote)
        {
            try
            {
                return _nVoteRepository.Create(nVote);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating new vote : {ex.ToString}");
            }
            return false;
        }

        public void CreateVote(NVote nVote)
        {
            try
            {
                _nVoteRepository.CreateVote(nVote);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateEvent : {ex.ToString}");
            }
        }

        public NVote? Delete(int nVote_Id)
        {
            try
            {
                return _nVoteRepository.Delete(nVote_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting vote : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<NVote?> GetAll()
        {
            return _nVoteRepository.GetAll();
        }

        public NVote? GetById(int nVote_Id)
        {
            try
            {
                return _nVoteRepository.GetById(nVote_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting vote : {ex.ToString}");
            }
            return null;
        }
    }
}
