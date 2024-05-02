using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Id;

    }
}
