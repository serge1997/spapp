using spapp.Enums;

namespace spapp.Helpers
{
    public static class MaritalStatus
    {

        public static string Marital(this MaritalStatusEnum marital) =>
            marital switch
            {
                MaritalStatusEnum.Single => "Célibataire",
                MaritalStatusEnum.Maried => "Marié",
                MaritalStatusEnum.Widow => "Veuve(f)",
                MaritalStatusEnum.SingleParent => "Parent célibataire"
            };
        
    }
}
