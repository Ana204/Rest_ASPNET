using IMPLEMENTAÇÃO_VERBOS.Model;
using System.Collections.Generic;

namespace IMPLEMENTAÇÃO_VERBOS.Services
{
    public interface IPersonService
    {
        Person Create(Person person);

        Person FindByID(long id);

        List<Person> FindAll();

        Person Update(Person person);
        
        void Delete(long id);

    }
}