﻿namespace KnowTest.Pages.BizApply;

/// <summary>
/// 业务查询列表页面。
/// </summary>
[StreamRendering]
[Route("/bas/queries")]
public class BaQueryList : BaseTablePage<TbApply>
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

    //重新申请
    public void Reapply() => Table.SelectRows(async rows => await this.RepeatFlowAsync(rows));
    //导出列表
    public Task Export() => Table.ExportDataAsync();
    //打印
    public Task Print(TbApply row) => JS.PrintAsync<ApplyPrint>(f => f.Set(c => c.Model, row));
}

class ApplyPrint : ComponentBase
{
    [Parameter] public TbApply Model { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        BuildStyle(builder);
        BuildForm(builder);
    }

    private static void BuildStyle(RenderTreeBuilder builder)
    {
        builder.Markup(@"<style>
.demo-print {position:relative;}
.demo-print canvas {position:absolute;top:0;right:0;width:180px;height:40px;}
.demo-print .txt-right {text-align:right;}
.demo-print .field {display:grid;grid-template-columns:repeat(auto-fit,minmax(0%,1fr));grid-column-gap:10px;margin:10px 0;}
.demo-print .title {font-size:1.5rem;font-weight:bold;text-align:center;}
.demo-print .content {height:100px;border-top:2px solid #ccc;;border-bottom:1px solid #ccc;padding:10px;}
</style>");
    }

    private void BuildForm(RenderTreeBuilder builder)
    {
        builder.Div("demo-print", () =>
        {
            //TODO：打印不支持JSRuntime问题
            //builder.Component<Barcode>().Set(c => c.Id, "bcBizNo").Set(c => c.Value, Model.BizNo).Build();
            builder.Div("title", "XXX公司申请单");
            builder.Div("field", () =>
            {
                builder.Div("", $"申请单号：{Model.BizNo}");
                builder.Div("txt-right", $"申请日期：{Model.ApplyTime:yyyy-MM-dd}");
            });
            builder.Div("content", Model.BizContent);
            builder.Div("field", () =>
            {
                builder.Div("", $"申请人：{Model.ApplyBy}");
                builder.Div("", $"审核人：{Model.VerifyBy}");
                builder.Div("", $"审核日期：{Model.VerifyTime:yyyy-MM-dd}");
            });
        });
    }
}