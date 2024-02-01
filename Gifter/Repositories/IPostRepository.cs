using Gifter.Models;

namespace Gifter.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Delete(int id);
        List<Post> GetAll();
        List<Post> GetAllWithComments();
        Post GetById(int id);
        Post GetPostByIdWithComments(int id);
        List<Post> Search(string criterion, bool sortDescending);
        List<Post> SearchHottest(string criterion, bool sortDescending);
        void Update(Post post);
    }
}