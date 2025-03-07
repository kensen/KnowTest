﻿namespace KnowTest.Pages.BaseData;

/// <summary>
/// 企业信息页面。
/// </summary>
[StreamRendering]
[Route("/bds/company")]
public class CompanyForm : BaseTabPage
{
    protected override async Task OnPageInitAsync()
    {
        await base.OnPageInitAsync();
        Tab.AddTab("BasicInfo", b => b.Component<CompanyBaseInfo>().Build());
    }
}

class CompanyBaseInfo : BaseEditForm<CompanyInfo>
{
    private ICompanyService companyService;

    protected override async Task OnInitFormAsync()
    {
        await base.OnInitFormAsync();
        companyService = await CreateServiceAsync<ICompanyService>();

        var json = await companyService.GetCompanyAsync();
        var data = Utils.FromJson<CompanyInfo>(json);
        Model = new FormModel<CompanyInfo>(this, true) { IsView = true, Data = data };
    }

    protected override Task<Result> OnSaveAsync(CompanyInfo model)
    {
        return companyService.SaveCompanyAsync(model);
    }
}