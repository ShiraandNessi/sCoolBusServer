namespace DL
{
    public interface IAuthorizationFuncs
    {
        public bool isAthorized(int id);
        public string GenerateSalt(int nSalt);
        public string HashPassword(string password, string salt, int nIterations, int nHash);
       
    }
}