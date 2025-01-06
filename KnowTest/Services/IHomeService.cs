namespace KnowTest.Services;

/// <summary>
/// 系统首页服务接口。
/// </summary>
public interface IHomeService : IService
{
    /// <summary>
    /// 获取首页数据信息。
    /// </summary>
    /// <returns></returns>
    Task<HomeInfo> GetHomeAsync();
}