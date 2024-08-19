using spapp.SpappContext;

namespace spapp.Main.Repositories.ComplainType
{
    public class ComplainTypeRepository(SpappContextDb spappContextDb) : IComplainTypeRepository
    {
        private SpappContextDb _spappContextDb = spappContextDb;
    }
}
