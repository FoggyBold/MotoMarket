namespace MotoVarket.Identity.Adapter.Interfaces
{
    public interface IIdentityService
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string enteredPassword, string storedHash);
    }
}
