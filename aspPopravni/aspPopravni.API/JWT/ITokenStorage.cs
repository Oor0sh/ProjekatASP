namespace aspPopravni.API.JWT
{
    public interface ITokenStorage
    {
        void AddToken(string id);
        bool TokenExists(string id);
        void InvalidateToken(string id);
    }
}
