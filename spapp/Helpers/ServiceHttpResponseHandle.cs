namespace spapp.Helpers
{
    public class ServiceHttpResponseHandle<T> where T : class
    {
        public string Message { get; set; }
        public string Status {  get; set; }
        public T? Data { get; set; }


        public override string ToString()
        {
            return $"Message: {Message}, status: {Status}, data: {Data}";
        }
    }
}
