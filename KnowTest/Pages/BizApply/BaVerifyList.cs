namespace KnowTest.Pages.BizApply;

/// <summary>
/// 业务审核列表页面。
/// </summary>
[StreamRendering]
[Route("/bas/verifies")]
public class BaVerifyList : BaseTablePage<TbApply>
{
    private IApplyService Service;

    protected override async Task OnPageInitAsync()
    {
        await base.OnPageInitAsync();
        Service = await CreateServiceAsync<IApplyService>();

        Table.FormType = typeof(ApplyForm);
        Table.OnQuery = criteria => Service.QueryApplysAsync(criteria);
		Table.Column(c => c.BizStatus).Template((b, r) => b.Tag(r.BizStatus));
    }

	//审核操作
    public void Verify(TbApply row) => this.VerifyFlow(row);
}