using CL.Server.Middleware.Model.Context;
using CL.Server.Middleware.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Server.Domain.Users.Data
{
  internal class UsersRepository : PSBaseRepository
  {
    internal PSDBContext GetRepContext()
    {
      return GetContext();
    }

    internal void AddUser(user u, PSDBContext context)
    {
      context.user.Add(u);
      context.SaveChanges();
    }

    internal user GetUserByCredentials(string login, string pass)
    {
      using var context = GetContext();

      return context.user.FirstOrDefault(u => u.login == login && u.pass == pass);
    }

    internal user GetUserByLogin(string login)
    {
      using var context = GetContext();

      return context.user.FirstOrDefault(u => u.login == login);
    }
  }
}
