﻿using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface ITagInterface
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag> GetASync(Guid id);
        Task<Tag> AddAsync(Tag tag);
        Task<Tag> UpdateAsync(Tag tag);
        Task<Tag> DeleteAsync(Guid id);
    }
}
