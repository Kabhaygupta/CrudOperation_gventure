using System.ComponentModel.DataAnnotations;

namespace CrudOperation_gventure.Models
{
    public class Products
    {
        [Key]
        public int P_Id { get; set; }
        public string P_Name { get; set; }
        public string P_Model { get; set; }
        public decimal P_Price { get; set;}
        public int Comp_Id { get; set;}

    }
}
