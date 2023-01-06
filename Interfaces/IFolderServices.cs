using AppTest.DataAccess.Entities;

namespace AppTest.Interfaces
{
    public interface IFolderServices
    {
        Task<IEnumerable<Folder>> Get(int? Id);
        Task Import(IEnumerable<Folder> folders);
    }
}
