using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hms.Domain.Entities
{

    public class Branch
    {
        public int BranchID { get; set; }

        public string? BranchName { get; set; }

        public string? BranchCity { get; set; }

        public string? BranchAddress { get; set; }


    }
}
