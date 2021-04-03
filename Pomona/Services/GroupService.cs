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
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepository;
        private readonly IMapper mapper;
        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
        }

        public void AddGroup(Group group)
        {
            var groupDB = mapper.Map<DBModel.Models.Group>(group);
            groupRepository.Add(groupDB);
        }

        public void DeleteGroup(Group group)
        {
            var groupDB = mapper.Map<DBModel.Models.Group>(group);
            groupRepository.Delete(groupDB);
        }

        public List<Group> GetGroups()
        {
            var groups = groupRepository.GetGroups();
            var groupsDto = mapper.Map<IEnumerable<Models.Group>>(groups);
            return groupsDto.ToList();
        }

        public void SaveChanges()
        {
           groupRepository.SaveChanges();
        }

        public void UpdateGroup(Group group)
        {
            var groupDB = mapper.Map<DBModel.Models.Group>(group);
            groupRepository.Update(groupDB);
        }
    }
}
