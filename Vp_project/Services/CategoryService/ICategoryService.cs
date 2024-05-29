using Vp_Project.Shared;

namespace Vp_Project.Client.Services.CategoryService
{
     interface ICategoryService 
    {
        List <Category> Categories { get; set; }
        void LoadCategories();
    }
}
