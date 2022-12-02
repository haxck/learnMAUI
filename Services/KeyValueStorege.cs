﻿
namespace MauiApp1.Services
{
    public class KeyValueStorege : IKeyValueStorage
    {
        public string Get(string key, string defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public void Set(string key, string value)
        {
            Preferences.Set(key, value);
        }
    }
}
