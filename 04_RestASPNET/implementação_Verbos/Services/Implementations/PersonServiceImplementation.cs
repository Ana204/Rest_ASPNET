using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using implementação_Verbos.model.Context;
using IMPLEMENTAÇÃO_VERBOS.Model;
using IMPLEMENTAÇÃO_VERBOS.Services;

namespace implementação_Verbos.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
           return person;
        }

        public void Delete(long id){}

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindByID(long id)
        {
           return new Person
           {
               Id = 1,
               FirstName = "Ana",
               LastName = "Gomes",
               Address = "São Paulo - SP - Brasil",
               Gender = "Male",
           };
        }

        public Person Update(Person person)
        {
            return person;
        }

    }
}