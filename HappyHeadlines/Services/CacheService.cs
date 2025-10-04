using System.Collections.Concurrent;

namespace HappyHeadlines.Services
{
    public abstract class CacheService<TKey, TValue>
    {
        protected readonly ConcurrentDictionary<TKey, TValue> _cache = new();
        protected int hits = 0;
        protected int misses = 0;

        public double HitRatio => (hits + misses == 0) ? 0 : (double)hits / (hits + misses) * 100.0;

        public abstract TValue LoadItem(TKey key);

        public TValue GetItem(TKey key)
        {
            if (_cache.TryGetValue(key, out var value))
            {
                hits++;
                return value;
            }
            else
            {
                misses++;
                value = LoadItem(key);
                _cache[key] = value;
                return value;
            }
        }
    }
}
