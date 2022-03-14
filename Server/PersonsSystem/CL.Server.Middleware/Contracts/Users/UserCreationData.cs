using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Server.Middleware.Contracts.Users
{
  public class UserCreationData
  {
    public string Login { get; set; }
    public string Pass { get; set; }
    public bool Created { get; set; }
    public long Person_id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Document_number { get; set; }
    public string Document_type { get; set; }
    public string Email { get; set; }
    public string Name_full { get; set; }
    public string Document_full { get; set; }
    public DateTime Creation { get; set; }
  }
}
