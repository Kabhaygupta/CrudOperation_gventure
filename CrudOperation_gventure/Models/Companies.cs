using System.ComponentModel.DataAnnotations;

namespace CrudOperation_gventure.Models
{
    public class Companies
    {
        [Key]
        public int C_Id { get; set; }
        public string C_Name { get; set; }        
        public string C_Address { get; set;}

    }
}
