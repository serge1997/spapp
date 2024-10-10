namespace spapp.Helpers
{
    public class ServiceHttpMultipleDataResponseHandle<T> where T : class
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public List<T>? Data { get; set; }
    }
}
