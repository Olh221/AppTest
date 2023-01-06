using Microsoft.EntityFrameworkCore;

namespace AppTest.DataAccess.Entities
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Folder> Children { get; set; }
        public Folder Parent { get; set; }
    }
}
