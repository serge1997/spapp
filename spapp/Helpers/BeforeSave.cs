namespace spapp.Helpers
{
    public static class BeforeSave
    {

        public static void EntityExists(this string name, string request)
        {
            if (string.Equals(name, request, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception($"{request} exists dejá dans le système");
            }
        }
    }
}
