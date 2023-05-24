using System.Reflection.Metadata;
using UserModelLibrary;
using UserDALLibrary;

namespace UserBLLibrary
{
    public class ManageUser : IAdmin<User, int>, IUser<User, int>
    {
        IRepo<User,int> _admin;
        IRepo<User , int> _user;

        public ManageUser(IRepo<User , int> repo1 , IRepo<User , int> repo2)
        {
            _admin = repo1;
            _user = repo2;
        }

        public bool AddUser(User item)
        {
            return _admin.Add(item);
        }
        public User GetUser(int id)
        {
            return _user.Get(id);
        }

        public ICollection<User> GetUsers()
        {
            return _admin.GetAll();
        }

        public bool CheckExistingUser(int id , string password)
        {
            bool status = false;
            foreach(User item in _admin.GetAll())
            {
                //Console.WriteLine($"{item.Id}\n{item.Password} \n{item.Password.Equals(password)}" );
                if (item.Id.Equals(id) && item.Password.ToLower().Equals(password.ToLower()))
                {
                    
                    status = true;
                }
            }
            return status;
        }

    }
}