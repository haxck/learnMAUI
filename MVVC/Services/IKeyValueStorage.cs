namespace MauiApp1.Services
{
    public interface IKeyValueStorage
    {
        string Get (string key, string defaultValue);
        void Set (string key, string value);
    }
}
