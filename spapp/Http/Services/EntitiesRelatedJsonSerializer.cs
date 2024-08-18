using System.Text.Json;
namespace spapp.Http.Services
{
    public class EntitiesRelatedJsonSerializer
    {

        public static JsonSerializerOptions RelatedToSerialize()
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                WriteIndented = true // Opcional, mas ajuda a formatar o JSON
            };

            return options;
        }
    }
}
