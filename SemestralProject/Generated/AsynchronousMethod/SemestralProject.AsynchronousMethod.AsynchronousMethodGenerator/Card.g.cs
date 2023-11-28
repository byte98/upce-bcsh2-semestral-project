using System.Threading.Tasks;
namespace SemestralProject.Model.Entities
{
    public partial class Card
    {
        
        public static System.Threading.Tasks.Task<SemestralProject.Model.Entities.Card> CreateAsync(int number, System.DateTime issued, System.DateTime validity, bool allowed, SemestralProject.Model.Entities.Employee holder)
        {
            return Task<SemestralProject.Model.Entities.Card>.Run(() => {
                return Card.Create(number, issued, validity, allowed, holder);
            });
        }

    }
}
