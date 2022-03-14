using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Server.Middleware.Model.Context
{
  public class PSBaseRepository
  {
    private static string dbconnectionString;

    public static  void Configure(string _dbconnectionString)
    {
      dbconnectionString = _dbconnectionString;
    }

    public static PSDBContext GetContext()
    {
      return new PSDBContext(dbconnectionString);
    }
  }
}
