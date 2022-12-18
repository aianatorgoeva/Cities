using Cities.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cities.DAL
{
    /// <summary>
    /// https://metanit.com/sharp/articles/mvc/11.php for reference
    /// </summary>
    public class GameRepository : IDisposable
    {
        private GameContext _context;
        public GameRepository()
        {
            _context = new GameContext();
        }
        public IEnumerable<City> GetCitiesList() => _context.Cities;
        public IEnumerable<User> GetUsersList() => _context.Users;
        public User GetUser(string username) => _context.Users.FirstOrDefault(x => x.Name == username);
        public void CreateUser(User user) => _context.Users.Add(user);
        public void Save() => _context.SaveChanges();
        public void UpdateUser(User user) => _context.Entry(user).State = EntityState.Modified;

        public IEnumerable<User> GetLeaderBord(int pagination)
            => _context.Users.OrderByDescending(x => x.Record).Take(pagination);

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
