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

        //para listar todos as pessoas
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        //listar pelo id
        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        //criação de uma nova pessoa
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

        //editar uma pessoa pelo id
        public Person Update(Person person)
        {
            if (!Exists(person.Id))
            {
                return new Person();
            }
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }    
           return person;
        }

        //método chamado no create 
        private bool Exists(long id)
        {
           return _context.Persons.Any(p => p.Id.Equals(id));
        }

        //deletar pelo id
        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }    
        }
    }
}