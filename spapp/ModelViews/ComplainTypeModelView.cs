using spapp.Enums;
using spapp.Main.Repositories.ComplainType;
using spapp.Main.Repositories.ComplainTypeCategory;
using spapp.Models;
using System.ComponentModel.DataAnnotations;

namespace spapp.ModelViews
{
    public class ComplainTypeModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nom é obligatoire")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Categorie é obligatoire")]
        public int ComplaintTypeCategoryId { get; set; }
        public bool IsActive { get; set; } = true;
        [Required(ErrorMessage = "Prioritée é obligatoire")]
        public PriorityEnum Priority { get; set; }
        public string? PenalCode { get; set; }
        public List<ComplainTypeCategoryModel> ComplainTypeCategories { get; set; } = [];
        

        public async Task SetComplainTypeCategory(IComplainTypeCategoryRepository complainTypeCategoryRepository)
        {
            List<ComplainTypeCategoryModel> categories = await complainTypeCategoryRepository
                .GetAllAsync();


            foreach (ComplainTypeCategoryModel category in categories)
            {
                ComplainTypeCategories.Add(category);
            }
        }
    }
}
