using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Language : Entity
    {
        public string Name { get; set; }
        public Language()
        {

        }
        public Language(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
