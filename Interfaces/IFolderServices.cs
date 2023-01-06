using AppTest.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTest.Interfaces
{
    public interface IFolderServices
    {
        Task<IEnumerable<Folder>> Get(int? Id);
        Task ImportFile(byte[] file);
        
    }
}
