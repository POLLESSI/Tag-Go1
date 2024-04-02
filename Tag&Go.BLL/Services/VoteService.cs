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
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;

        public VoteService(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }

        public bool Create(Vote vote)
        {
            try
            {
                return _voteRepository.Create(vote);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating Event : {ex.ToString}");
            }
            return false;
        }

        public void CreateVote(Vote vote)
        {
            try
            {
                _voteRepository.CreateVote(vote);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateEvent : {ex.ToString}");
            }
        }

        public Vote? Delete(int vote_Id)
        {
            try
            {
                return _voteRepository.Delete(vote_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting vote : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Vote?> GetAll()
        {
            return _voteRepository.GetAll();
        }

        public Vote? GetById(int vote_Id)
        {
            try
            {
                return _voteRepository.GetById(vote_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting vote : {ex.ToString}");
            }
            return null;
        }
    }
}
