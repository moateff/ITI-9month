using CarAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAPI.Repositories_DAL
{
    // Abstraction should not depend on implementation. Implementation should depend on abstraction
    public class OwnersRepository : IOwnersRepository
    {

        private readonly InMemoryContext _context;

        public OwnersRepository(InMemoryContext inMemoryContext)
        {
            _context = inMemoryContext;
        }

        public List<Owner> GetAllOwners()
        {
            return _context.Owners;
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.FirstOrDefault(o => o.Id == id);
        }

        public bool AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            return true;
        }

    }
}