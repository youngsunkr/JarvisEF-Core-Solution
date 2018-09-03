using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.Service
{
    public interface ICacheProvider
    {
        object Get(string key);
        void Set(string key, object data);
        void Set(string key, object data, double cacheMinute);
        bool IsSet(string key);
        void Invalidate(string key);
    }
}
