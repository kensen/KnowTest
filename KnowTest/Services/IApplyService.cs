namespace KnowTest.Services;

/// <summary>
/// 系统业务申请模块服务接口。
/// </summary>
public interface IApplyService : IService
{
    /// <summary>
    /// 分页查询申请单信息。
    /// </summary>
    /// <param name="criteria"></param>
    /// <returns></returns>
    Task<PagingResult<TbApply>> QueryApplysAsync(PagingCriteria criteria);

    /// <summary>
    /// 根据业务类型获取默认申请单信息。
    /// </summary>
    /// <param name="bizType"></param>
    /// <returns></returns>
    Task<TbApply> GetDefaultApplyAsync(string bizType);

    /// <summary>
    /// 批量删除申请单信息。
    /// </summary>
    /// <param name="models"></param>
    /// <returns></returns>
    Task<Result> DeleteApplysAsync(List<TbApply> models);

    /// <summary>
    /// 保存申请单信息。
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    Task<Result> SaveApplyAsync(UploadInfo<TbApply> info);

    /// <summary>
    /// 分页查询申请单表体信息。
    /// </summary>
    /// <param name="criteria"></param>
    /// <returns></returns>
    Task<PagingResult<TbApplyList>> QueryApplyListsAsync(PagingCriteria criteria);

    /// <summary>
    /// 批量删除申请单表体信息。
    /// </summary>
    /// <param name="models"></param>
    /// <returns></returns>
    Task<Result> DeleteApplyListsAsync(List<TbApplyList> models);

    /// <summary>
    /// 保存申请单表体信息。
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<Result> SaveApplyListAsync(TbApplyList model);
}