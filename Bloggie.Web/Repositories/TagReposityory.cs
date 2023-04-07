using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public class TagReposityory : ITagInterface
    {
        private readonly BloggieDbContext bloggieDbContext;

        public TagReposityory(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<Tag?> AddAsync(Tag tag)
        {
            await bloggieDbContext.Tags.AddAsync(tag);
            await bloggieDbContext.SaveChangesAsync();
            return tag;
        }

        public Task<Tag> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetASync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> UpdateAsync(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
