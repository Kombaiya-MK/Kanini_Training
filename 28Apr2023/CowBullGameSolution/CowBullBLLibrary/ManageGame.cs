using CowBullDALLibrary;
using CowBullModelLibrary;
namespace CowBullBLLibrary
{
    public class ManageGame : IUser<User, int>, IAttempts<Attempt, int>
    {
        IRepo<User,int> _user;
        IRepo<Attempt, int> _attempts;
        public static string GuessWord;
        public ManageGame()//Default Constructor
        { 
        }
        public ManageGame(IRepo<User, int> user , IRepo<Attempt, int> attempts)//Parametrized Constructor - Repo obj as parameters
        {
            _user = user;
            _attempts = attempts;
        }

        public int CreateAttempt(int id , string word)//Create object for Attempt class
        {
            Attempt attempt = new Attempt();
            attempt.id = id;
            attempt.Gueword = word;
            attempt.Givword = GuessWord;
            return AddAttempts(attempt);
        }

        public int AddAttempts(Attempt attempt)//Add attempt to the collection and database
        {
            return _attempts.Add(attempt);
        }

        public int AddUser(User user)//Add new user to the collection
        {
            return _user.Add(user); 
        }

        public ICollection<Attempt> GetAttempts(int key) // To get all the attempts of the certain user
        {
            return _attempts.GetAll(key).Where( x => x.id == key).ToList();
        }

        public User GetUser(int key)//Get Specific user
        {
            return _user.Get(key);
        }
        public bool GetGuessWord(string word)//Store the word to guess
        {
            if (word == null) return false;
            else if (word.Length != 4) return false;
            else if (GuessWord != null) return false;
            else GuessWord = word.ToLower();
            return true;

        }

        public bool GiveWord(string  word) //Checking whether given word and guess word is equal
        {
            if (word == null) return false;
            if(word.Length != 4) return false;
            if (CowBull(word) == true)
            return true; 
            else 
                return false;
        }

        public bool CowBull(string word) // Main logic of the Cow and Bull Game
        {
            string result = "";
            int cows = 0 , bulls = 0;
            char[] Gueword = GuessWord.ToCharArray();
            char[] Givword = word.ToCharArray();
            for(int i = 0; i < word.Length; i++) {
                if (Gueword[i] == Givword[i])
                {
                    cows++;
                    Gueword[i] = '.';
                    Givword[i] = '.';
                }
            }
            for(int i = 0; i < Gueword.Length; i++) 
            { 
                for(int j = 0; j < Givword.Length; j++)
                {
                    if ((Gueword[i] == Givword[j]) && (i != j) && (Gueword[i] != '.'))
                    {
                        bulls++;
                        Gueword[i] = '.';
                        Givword[i] = '.';
                        break;
                    }
                }
            }
            result = $"Cows : {cows}  Bulls : {bulls}";
            Console.WriteLine(result);
            if (cows == 4) {
                return true;
            }
            return false;


        }
    }
}