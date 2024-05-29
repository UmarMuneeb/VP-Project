using Vp_Project.Shared;

namespace Vp_Project.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public List<Category> Categories { get; set; } = new List<Category>();

        public void LoadCategories()
        {
            Categories = new List<Category>
            {
                new Category{Id=1, Name="Books", Url="books", Icon="book" ,ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTOoekYU9CbJH8pn-tZPRAsY0blotmtLUdhSw&usqp=CAU"},
                new Category{Id=2, Name="Electronics", Url="electronics", Icon="camera-slr", ImageUrl="https://i.pcmag.com/imagery/lineups/067nHL7x7FLjB28RuLvKFzS-1.fit_lim.size_350x250.v_1569470817.jpg"},
                new Category{Id=3, Name="Video Games", Url="video-games", Icon="aperture",ImageUrl="https://www.cyberpowerpc.com/blog/w/wp-content/uploads/2024/04/SteamBackground-915x515.jpg"}
            };
        }
    }
}
