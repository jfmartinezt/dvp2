using CL.Server.Domain.Persons;
using CL.Server.Domain.Users.Data;
using CL.Server.Middleware.Contracts.Persons;
using CL.Server.Middleware.Contracts.Users;
using CL.Server.Middleware.Error;
using CL.Server.Middleware.Model.Entities;
using System;

namespace CL.Server.Domain.Users
{
  public class UsersManager
  {
    private readonly PersonsManager personsManager;
    private readonly UsersRepository usersRepository;

    public UsersManager()
    {
      personsManager = new();
      usersRepository = new();
    }

    public UserCreationData AddUser(UserCreationData userData)
    {
      using var context = usersRepository.GetRepContext();
      using var tx = context.Database.BeginTransaction();

      userData.Person_id = personsManager.AddPerson(userData, context);

      if (string.IsNullOrEmpty(userData.Login))
      {
        throw new CustomException("User login can not be empty.");
      }

      if (string.IsNullOrEmpty(userData.Pass))
      {
        throw new CustomException("User pass can not be empty.");
      }

      user duplicated = usersRepository.GetUserByLogin(userData.Login);

      if (duplicated != null)
      {
        throw new CustomException("User login already exists.");
      }

      user u = new();

      u.user_id = userData.Person_id;
      u.login = userData.Login;
      u.pass = userData.Pass;
      u.creation = DateTime.Now;

      usersRepository.AddUser(u, context);

      tx.Commit();

      userData.Created = true;
      userData.Creation = u.creation;

      return userData;
    }

    public PersonData UserInfoData(UserLoginData user)
    {
      user u = usersRepository.GetUserByCredentials(user.Login, user.Pass);

      if (u == null)
      {
        throw new CustomException("Login or password is invalid.");
      }

      return personsManager.GetPersonInfo(u.user_id);
    }
  }
}
