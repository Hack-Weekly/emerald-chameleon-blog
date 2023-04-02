namespace ApiServer.Data.EF.EntityRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly MainDbContext _context;

        public UserRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> UserExists(string username, string email)
        {
            return await _context.Users.AnyAsync(x => x.Username.ToUpper() == username.ToUpper() || (!string.IsNullOrWhiteSpace(x.Email) && x.Email == email));
        }
        public async Task<User> GetUserByUserName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username.ToUpper().Equals(username.ToUpper()));
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email.ToUpper().Equals(email.ToUpper()));
        }
    }
}
