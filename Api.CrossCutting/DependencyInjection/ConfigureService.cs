using Api.Domain.Interfaces.Services.Categories;
using Api.Domain.Interfaces.Services.Comments;
using Api.Domain.Interfaces.Services.PostsTags;
using Api.Domain.Interfaces.Services.Tags;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<ICommentServices, CommentService>();
            serviceCollection.AddTransient<ITagServices, TagsService>();
            serviceCollection.AddTransient<IPostTagService, PostsTagsService>();
        }
    }
}