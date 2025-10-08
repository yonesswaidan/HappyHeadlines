public class CacheStats
{
    public int CacheHits { get; private set; }
    public int CacheMisses { get; private set; }

    public void RecordHit() => CacheHits++;
    public void RecordMiss() => CacheMisses++;

    public double HitRatio => CacheHits + CacheMisses == 0
        ? 0
        : (double)CacheHits / (CacheHits + CacheMisses) * 100;
}
