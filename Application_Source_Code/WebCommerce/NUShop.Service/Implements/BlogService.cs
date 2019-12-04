using AutoMapper;
using NUShop.Data.Entities;
using NUShop.Data.Enums;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Interfaces;
using NUShop.Utilities.Constants;
using NUShop.Utilities.DTOs;
using NUShop.Utilities.Helpers;
using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.Service.Implements
{
    public class BlogService : IBlogService
    {
        #region Injections

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Blog, int> _blogRepository;
        private readonly IRepository<BlogTag, int> _blogTagRepository;
        private readonly IRepository<Tag, string> _tagRepository;

        public BlogService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<Blog, int> blogRepository,
            IRepository<BlogTag, int> blogTagRepository,
            IRepository<Tag, string> tagRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blogRepository = blogRepository;
            _blogTagRepository = blogTagRepository;
            _tagRepository = tagRepository;
        }

        #endregion Injections

        #region C

        public async Task<BlogViewModel> AddAsync(BlogViewModel blogViewModel)
        {
            var blog = _mapper.Map<Blog>(blogViewModel);

            // if blog has tags
            if (!string.IsNullOrEmpty(blog.Tags))
            {
                var tags = blog.Tags.Split(",");
                foreach (var item in tags)
                {
                    var tagId = TextHelper.ToUnsignString(item);
                    // if tag not-exists in database => add a new tag
                    if (!_tagRepository.GetAll(x => x.Id == tagId).Any())
                    {
                        var tag = new Tag
                        {
                            Id = tagId,
                            Name = item,
                            Type = CommonConstants.BlogTag
                        };

                        _tagRepository.Add(tag);
                    }
                    var blogTag = new BlogTag { TagId = tagId };
                    blog.BlogTags.Add(blogTag);
                }
            }
            // add and commit
            _blogRepository.Add(blog);
            await _unitOfWork.CommitAsync();
            return blogViewModel;
        }

        #endregion C

        #region R

        public List<BlogViewModel> GetAll()
        {
            var blogs = _blogRepository.GetAll();
            var blogsViewModel = _mapper.Map<List<BlogViewModel>>(blogs);
            return blogsViewModel;
        }

        public PagedResult<BlogViewModel> GetAllPaging(string keyword, int pageSize = 10, int pageIndex = 1)
        {
            var blogs = _blogRepository.GetAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                blogs = blogs.Where(x => x.Name.Contains(keyword));
            }

            var totalRow = blogs.Count();
            blogs = blogs.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var blogsViewModel = _mapper.Map<List<BlogViewModel>>(blogs);

            var paginationSet = new PagedResult<BlogViewModel>
            {
                Results = blogsViewModel,
                RowCount = totalRow,
                PageSize = pageSize,
                CurrentPage = pageIndex
            };
            return paginationSet;
        }

        public BlogViewModel GetById(int id)
        {
            var blog = _blogRepository.GetById(id);
            var blogViewModel = _mapper.Map<BlogViewModel>(blog);
            return blogViewModel;
        }

        public List<BlogViewModel> GetHotProduct(int top)
        {
            var blogs = _blogRepository.GetAll(x => x.HotFlag == true && x.Status == Status.Active).Take(top);
            var blogsViewModel = _mapper.Map<List<BlogViewModel>>(blogs);
            return blogsViewModel;
        }

        public List<BlogViewModel> GetLastest(int top)
        {
            var blogs = _blogRepository.GetAll(x => x.Status == Status.Active).OrderByDescending(x => x.DateModified);
            var blogsViewModel = _mapper.Map<List<BlogViewModel>>(blogs);
            return blogsViewModel;
        }

        public List<BlogViewModel> GetList(string keyword)
        {
            IQueryable<Blog> blogs;
            if (!string.IsNullOrEmpty(keyword))
            {
                blogs = _blogRepository.GetAll(x => x.Name.Contains(keyword));
            }
            else
            {
                blogs = _blogRepository.GetAll();
            }
            var blogsViewModel = _mapper.Map<List<BlogViewModel>>(blogs);
            return blogsViewModel;
        }

        public List<string> GetListByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<BlogViewModel> GetListByTag(string tagId, out int totalRow, int pageIndex = 1, int pageSize = 10)
        {
            var blogs = from p in _blogRepository.GetAll()
                        join pt in _blogTagRepository.GetAll()
                        on p.Id equals pt.BlogId
                        where pt.TagId == tagId && p.Status == Status.Active
                        orderby p.DateCreated descending
                        select p;

            totalRow = blogs.Count();
            blogs = blogs.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var blogsViewModel = _mapper.Map<List<BlogViewModel>>(blogs);
            return blogsViewModel;
        }

        public List<BlogViewModel> GetListPaging(string sort, out int totalRow, int pageIndex = 1, int pageSize = 10)
        {
            var blogs = _blogRepository.GetAll(x => x.Status == Status.Active);

            switch (sort)
            {
                case "popular":
                    blogs = blogs.OrderByDescending(x => x.ViewCount);
                    break;

                default:
                    blogs = blogs.OrderByDescending(x => x.DateCreated);
                    break;
            }

            totalRow = blogs.Count();
            blogs = blogs.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var blogsViewModel = _mapper.Map<List<BlogViewModel>>(blogs);
            return blogsViewModel;
        }

        public List<TagViewModel> GetListTag(string searchText)
        {
            var tags = _tagRepository.GetAll(x => x.Name.Contains(searchText) && x.Type == CommonConstants.ProductTag);
            var tagsViewModel = _mapper.Map<List<TagViewModel>>(tags);
            return tagsViewModel;
        }

        public List<TagViewModel> GetListTagByBlogTagId(int blogTagId)
        {
            // Get blog and select tags of blog
            var tags = _blogTagRepository.GetAll(x => x.BlogId == blogTagId, y => y.Tag).Select(z => z.Tag);
            var tagsViewModel = _mapper.Map<List<TagViewModel>>(tags);
            return tagsViewModel;
        }

        public List<BlogViewModel> GetReatedBlogs(int id, int top)
        {
            var blogs = _blogRepository.GetAll(x => x.Status == Status.Active && x.Id != id).OrderByDescending(x => x.DateCreated).Take(top);
            var blogsViewModel = _mapper.Map<List<BlogViewModel>>(blogs);
            return blogsViewModel;
        }

        public TagViewModel GetTag(string tagId)
        {
            var tag = _tagRepository.GetSingle(x => x.Id == tagId);
            var tagViewModel = _mapper.Map<TagViewModel>(tag);
            return tagViewModel;
        }

        public List<BlogViewModel> Search(string keyword, string sort, out int totalRow, int pageIndex = 1, int pageSize = 10)
        {
            var blogs = _blogRepository.GetAll(x => x.Status == Status.Active && x.Name.Contains(keyword));

            switch (sort)
            {
                case "popular":
                    blogs = blogs.OrderByDescending(x => x.ViewCount);
                    break;

                default:
                    blogs = blogs.OrderByDescending(x => x.DateCreated);
                    break;
            }

            totalRow = blogs.Count();
            blogs = blogs.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var blogsViewModel = _mapper.Map<List<BlogViewModel>>(blogs);

            return blogsViewModel;
        }

        #endregion R

        #region U

        public async Task UpdateAsync(BlogViewModel blogViewModel)
        {
            var blog = _mapper.Map<Blog>(blogViewModel);
            var dateTimeNow = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);
            blog.DateCreated = dateTimeNow;
            blog.DateModified = dateTimeNow;

            _blogRepository.Update(blog);

            if (!string.IsNullOrEmpty(blog.Tags))
            {
                string[] tags = blog.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.GetAll(x => x.Id == tagId).Any())
                    {
                        var tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                    }
                    _blogTagRepository.RemoveMultiple(_blogTagRepository.GetAll(x => x.Id == blog.Id).ToList());

                    var blogTag = new BlogTag
                    {
                        BlogId = blog.Id,
                        TagId = tagId
                    };
                    _blogTagRepository.Add(blogTag);
                }
            }
            await _unitOfWork.CommitAsync();
        }

        public async Task IncreaseView(int id)
        {
            var blog = _blogRepository.GetById(id);
            if (!blog.ViewCount.HasValue)
            {
                blog.ViewCount = 1;
            }
            else
            {
                blog.ViewCount++;
            }
            _blogRepository.Update(blog);
            await _unitOfWork.CommitAsync();
        }

        #endregion U

        #region D

        public async Task DeleteAsync(int id)
        {
            _blogRepository.Remove(id);
            await _unitOfWork.CommitAsync();
        }

        #endregion D
    }
}