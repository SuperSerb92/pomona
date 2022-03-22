using AutoMapper;
using DBModel.Interfaces;
using Pomona.Interfaces;
using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository buyerRepository;
        private readonly IMapper mapper;
        public BuyerService(IBuyerRepository buyerRepository,IMapper mapper)
        {
            this.buyerRepository = buyerRepository;
            this.mapper = mapper;
        }
        public void AddBuyer(Buyer buyer)
        {
            var buyerDB = mapper.Map<DBModel.Models.Buyer>(buyer);
            buyerRepository.Add(buyerDB);
        }

        public void DeleteBuyer(Buyer buyer)
        {
            var buyerDB = mapper.Map<DBModel.Models.Buyer>(buyer);
            buyerRepository.Delete(buyerDB);
        }

        public List<Buyer> GetBuyers()
        {
            var buyers = buyerRepository.GetBuyers();
            var buyersDto = mapper.Map<IEnumerable<Models.Buyer>>(buyers);
            return buyersDto.OrderBy(x => x.BuyerId).ToList();
        }

        public void SaveChanges()
        {
           buyerRepository.SaveChanges();
        }

        public void UpdateBuyer(Buyer buyer)
        {
            var buyerDB = mapper.Map<DBModel.Models.Buyer>(buyer);
            buyerRepository.Update(buyerDB);
        }
    }
}
