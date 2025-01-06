namespace KnowTest;

/// <summary>
/// 系统配置类。
/// </summary>
public static class AppConfig
{
    private static readonly List<MenuInfo> AppMenus =
    [
        new MenuInfo { Id = "Home", Name = "首页", Icon = "home", Target = "Tab", Url = "/app" },
        new MenuInfo { Id = "Mine", Name = "我的", Icon = "user", Target = "Tab", Url = "/app/mine" },
        new MenuInfo { Id = "Test", Name = "测试模块", Icon = "form", Target = "Menu", Color = "#1890ff", Url = "/app/test" },
        new MenuInfo { Id = "Add", Name = "功能待加", Icon = "plus", Target = "Menu", Color = "#4fa624" }
    ];

    /// <summary>
    /// 取得系统ID。
    /// </summary>
    public static string AppId => "KnowTest";
    
    /// <summary>
    /// 取得系统名称。
    /// </summary>
    public static string AppName => "KnowTest管理系统";

    /// <summary>
    /// 添加系统配置模块。
    /// </summary>
    /// <param name="services"></param>
    public static void AddApp(this IServiceCollection services)
    {
        Console.WriteLine(AppName);
        Config.AppMenus = AppMenus;

        var assembly = typeof(AppConfig).Assembly;
        services.AddKnown(info =>
        {
            //项目ID、名称、类型、程序集
            info.Id = AppId;
            info.Name = AppName;
            info.IsSize = true;
            info.IsLanguage = true;
            info.IsTheme = true;
            info.Assembly = assembly;
            //JS路径，通过JS.InvokeAppVoidAsync调用JS方法
            //info.JsPath = "./script.js";
        });
        services.AddKnownAntDesign(option =>
        {
            //option.Footer = b => b.Component<Foot>().Build();
        });

        //添加模块
        Config.AddModule(assembly);
    }
}