using UserModelLibrary;
namespace UserDALLibrary
{
    public class UserRepository : IRepo<User, int>
    {
        UserContext context;
        public UserRepository()
        {
            context = new UserContext();
        }
        public bool Add(User item)
        {
            User user = new User();
            //user.Id = item.Id;
            user.Name = item.Name;
            user.Password = item.Password;
            user.IsAdmin = item.IsAdmin;
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            context.Users.Remove(Get(id));
            context.SaveChanges();  
            return true;
        }

        public User Get(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public ICollection<User> GetAll()
        {
            var users = context.Users.ToList();
            return users;
        }

        public bool Update(User item)
        {
            var user = Get(item.Id);
            user = item;
            return true;
        }
    }
}