using spapp.Enums;

namespace spapp.Helpers
{
    public static class Priority
    {

        public static string PriorityFullName(this PriorityEnum priority) =>
            priority switch
            {
                PriorityEnum.Hight => "Elévé",
                PriorityEnum.Medium => "Normal",
                PriorityEnum.Low => "Bas"
            };
    }
}
