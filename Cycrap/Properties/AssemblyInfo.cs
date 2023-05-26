using MelonLoader;

[assembly: System.Reflection.AssemblyTitle(ClientsInfo.Description)]
[assembly: System.Reflection.AssemblyDescription(ClientsInfo.Description)]
[assembly: System.Reflection.AssemblyCompany(ClientsInfo.Company)]
[assembly: System.Reflection.AssemblyProduct(ClientsInfo.Name)]
[assembly: System.Reflection.AssemblyCopyright(ClientsInfo.Author)]
[assembly: System.Reflection.AssemblyTrademark(ClientsInfo.Company)]
[assembly: System.Reflection.AssemblyVersion(ClientsInfo.Version)]
[assembly: System.Reflection.AssemblyFileVersion(ClientsInfo.Version)]
[assembly: MelonLoader.MelonInfo(typeof(VSinksModMenu.Main), ClientsInfo.Name, ClientsInfo.Version, ClientsInfo.Author, ClientsInfo.DownloadLink)]

[assembly: MelonColor(System.ConsoleColor.Cyan)]
[assembly: MelonLoader.MelonGame("VRChat")]

public static class ClientsInfo
{
    public const string Name = "VSinkTweaks";
    public const string Description = "A basic Port of the beat saber mod AnyTweaks";
    public const string Author = "VSink";
    public const string Company = "????????";
    public const string Version = "1.0.0";
    public const string DownloadLink = "Die";
}