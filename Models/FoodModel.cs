using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace CrepesWaffelsPOS.Models
{
    public enum FoodCategory
    {
        Burger,
        Crepe,
        Waffle,
        Soup,
        Pizza
    }
    public class FoodModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; } = "Default";
        public double Price { get; set; } = 0;
        public FoodCategory Category { get; set; } = FoodCategory.Burger;
    }
}
