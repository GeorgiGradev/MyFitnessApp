using MyFitnessApp.Data.Common.Models;

namespace MyFitnessApp.Data.Models
{
    public class Foods : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
