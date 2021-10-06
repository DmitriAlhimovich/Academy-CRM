using System.Threading.Tasks;
using AcademyCRM.Core.Models;

namespace AcademyCRM.BLL.Services
{
    public interface ITeacherService : IEntityService<Teacher>
    {
        void SavePhoto(int id, byte[] content);
    }
}