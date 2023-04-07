using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
	public interface IBlogPostInterface
	{
		Task<IEnumerable<Tag>> GetAllAsync();
		Task<BlogPost?> GetAsync(Guid id);
		Task<BlogPost?> AddAsync(Tag tag);
		Task<BlogPost?> UpdateAsync(Tag tag);
		Task<BlogPost?> DeleteAsync(Guid id);
	}
}
