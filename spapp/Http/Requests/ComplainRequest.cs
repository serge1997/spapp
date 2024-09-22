using spapp.Models;

namespace spapp.Http.Requests
{
    public record ComplainRequest
    (
        UserRequest applicantRequest,
        AddressRequest addressRequest
    );
}
