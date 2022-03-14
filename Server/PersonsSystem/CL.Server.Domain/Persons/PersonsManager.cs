using CL.Server.Domain.Persons.Data;
using CL.Server.Middleware.Contracts.Persons;
using CL.Server.Middleware.Contracts.Users;
using CL.Server.Middleware.Error;
using CL.Server.Middleware.Model.Context;
using CL.Server.Middleware.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Server.Domain.Persons
{
  class PersonsManager
  {
    private readonly PersonsRepository personsRepository;
    public PersonsManager()
    {
      personsRepository = new();
    }

    internal long AddPerson(UserCreationData user, PSDBContext context)
    {
      if (string.IsNullOrEmpty(user.Name))
      {
        throw new CustomException("User name can not be empty.");
      }

      if (string.IsNullOrEmpty(user.Surname))
      {
        throw new CustomException("User surname can not be empty.");
      }

      if (string.IsNullOrEmpty(user.Document_type))
      {
        throw new CustomException("User document type can not be empty.");
      }

      if (string.IsNullOrEmpty(user.Document_number))
      {
        throw new CustomException("User document number can not be empty.");
      }

      if (string.IsNullOrEmpty(user.Email))
      {
        throw new CustomException("User email can not be empty.");
      }

      if (string.IsNullOrEmpty(user.Login))
      {
        throw new CustomException("User login can not be empty.");
      }

      if (string.IsNullOrEmpty(user.Pass))
      {
        throw new CustomException("User pass can not be empty.");
      }

      person personEntity = new();

      personEntity.name = user.Name;
      personEntity.surname = user.Surname;
      personEntity.document_type = user.Document_type;
      personEntity.document_number = user.Document_number;
      personEntity.email = user.Email;
      personEntity.creation = DateTime.Now;

      return personsRepository.AddPerson(personEntity, context);
    }

    internal PersonData GetPersonInfo(long person_id)
    {
      return personsRepository.GetPersonData(person_id);
    }
  }
}
