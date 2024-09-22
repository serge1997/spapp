using spapp.Http.Requests;

namespace spapp.Main.ModelsBuilder.ComplainModelBuilder
{
    public interface IComplainModelBuilder
    {

        IComplainModelBuilder AddApplicant(UserRequest userRequest);
    }
}
