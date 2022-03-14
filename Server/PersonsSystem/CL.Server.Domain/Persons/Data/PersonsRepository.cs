using CL.Server.Middleware.Contracts.Persons;
using CL.Server.Middleware.Model.Context;
using CL.Server.Middleware.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Server.Domain.Persons.Data
{
  internal class PersonsRepository : PSBaseRepository
  {
    internal long AddPerson(person personEntity, PSDBContext context)
    {
      context.person.Add(personEntity);
      context.SaveChanges();
      return personEntity.person_id;
    }

    internal PersonData GetPersonData(long person_id)
    {
      using var context = GetContext();

      return context.person
        .Where(p => p.person_id == person_id)
        .Select(p => new PersonData() 
        {
          Name = p.name,
          Surname = p.surname,
          Document_type = p.document_type,
          Document_number = p.document_number,
          Email = p.email,
          Name_full = p.name_full,
          Document_full = p.document_full,
          Creation = p.creation
        })
        .FirstOrDefault();
    }
  }
}
