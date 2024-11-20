namespace RoR2Vapor;

public static class RoR2VaporAssets
{
    public static string assetsPath;
    private static AssetBundleCreateRequest assetBundleCreateRequest;
    private static AssetBundle assetBundle;

    public static AssetBundle Bundle
    {
        get
        {
            if (!assetBundle)
            {
                assetBundle = assetBundleCreateRequest?.assetBundle;
            }
            return assetBundle;
        }
    }

    public static void ModInit()
    {
        assetBundle = AssetBundle.LoadFromFile(assetsPath);
        //assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(assetsPath);
    }
}
