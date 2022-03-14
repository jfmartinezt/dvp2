using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Server.Middleware.Error
{
  public class CustomResult
  {
    public string Type { get; set; }
    public string Description  { get; set; }
    public DateTime TimeStamp { get; set; }   
  }
}
