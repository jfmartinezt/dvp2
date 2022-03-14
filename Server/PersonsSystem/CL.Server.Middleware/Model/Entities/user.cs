using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Server.Middleware.Model.Entities
{
  public class user
  {
    public long user_id { get; set; }
    public string login { get; set; }
    public string pass { get; set; }
    public DateTime creation { get; set; }
  }
}
