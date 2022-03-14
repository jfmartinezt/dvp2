using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Server.Middleware.Model.Entities
{
  public partial class person
  {
    public long person_id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string document_number { get; set; }
    public string document_type { get; set; }
    public string email { get; set; }
    public string name_full { get; set; }
    public string document_full { get; set; }
    public DateTime creation { get; set; }
  }
}
