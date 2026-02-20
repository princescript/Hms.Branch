using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hms.Domain.Entities
{

    [Table("Branch")]
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }

        public string? BranchName { get; set; }

        public string? BranchCity { get; set; }

        public string? BranchAddress { get; set; }


    }
}
