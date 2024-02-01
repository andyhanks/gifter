using Gifter.Models;

namespace Gifter.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userprofile);
        void Delete(int id);
        List<UserProfile> GetAll();
        UserProfile GetById(int id);
        void Update(UserProfile userprofile);
        UserProfile GetUserPostsByUserId(int id);
    }
}