using CoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CoreDemo.Services
{
    public class CinemaMemoryService : ICinemaService
    {
        private readonly List<Cinema> _cinemas = new List<Cinema>();
        public CinemaMemoryService()
        {
            _cinemas.Add(new Cinema { 
            Name="City cinema",
            Location="Road abc,No 123",
            Capacity=1000
            });

            _cinemas.Add(new Cinema
            {
                Name="Fly cinema",
                Location="Road def, No.456",
                Capacity=500
            });
        }

        public Task<IEnumerable<Cinema>> GetllAllSync()
        {
            return Task.Run(() => _cinemas.AsEnumerable());
        }

        public Task<Cinema> GetByIdAsync(int id)
        {
            return Task.Run(() => _cinemas.FirstOrDefault(x => x.Id == id));
        }

        public Task<Sales> GetSalesAsync()
        {
            throw new NotImplementedException();
        }


        public Task AddAsync(Cinema model)
        {
            var MaxId = _cinemas.Max(x => x.Id);
            model.Id = MaxId + 1;
            _cinemas.Add(model);
            return Task.CompletedTask;
        }

        

        

        
    }
}
