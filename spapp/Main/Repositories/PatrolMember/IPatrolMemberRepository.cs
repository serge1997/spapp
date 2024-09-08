using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.PatrolMember
{
    public interface IPatrolMemberRepository
    {

        void Create(PatrolRequest request, PatrolModel patrol);
    }
}
