using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.Complain
{
    public interface IComplainRepository
    {

        Task<ComplaintModel> CreateWebAgentComplain(ComplainRequest complainRequest);
    }
}
