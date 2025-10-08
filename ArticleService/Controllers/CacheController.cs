using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CacheController : ControllerBase
{
    private readonly CacheStats _stats;

    public CacheController(CacheStats stats)
    {
        _stats = stats;
    }

    [HttpGet("stats")]
    public IActionResult GetStats()
    {
        return Ok(new
        {
            cacheHits = _stats.CacheHits,
            cacheMisses = _stats.CacheMisses,
            hitRatio = $"{_stats.HitRatio:F1}%"
        });
    }
}
