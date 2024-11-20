using BepInEx.Logging;
using RoR2Vapor.Implementation;
using System.Security;
using System.Security.Permissions;
using UnityEngine.SceneManagement;
using Path = System.IO.Path;

[module: UnverifiableCode]
#pragma warning disable CS0618 // Type or member is obsolete
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618 // Type or member is obsolete
[assembly: HG.Reflection.SearchableAttribute.OptIn]

namespace RoR2Vapor;

[BepInPlugin(GUID, NAME, VERSION)]
public class RoR2VaporPlugin : BaseUnityPlugin
{
    public const string
            GUID = "groovesalad." + NAME,
            NAME = "RoR2Vapor",
            VERSION = "1.0.1";

    public static new ManualLogSource Logger { get; private set; }

    protected void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo("Hello!");

        string directoryName = Path.GetDirectoryName(Info.Location);

        RoR2VaporAssets.assetsPath = Path.Combine(directoryName, "AssetBundles", "ror2vaporassets");
        RoR2VaporAssets.ModInit();

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        CameraRigController.onCameraEnableGlobal += CameraRigController_onCameraEnableGlobal;
    }

    private void SceneManager_activeSceneChanged(Scene oldScene, Scene newScene)
    {
        Light sun = RenderSettings.sun;
        if (sun && !sun.GetComponent<VaporLight>())
        {
            sun.gameObject.AddComponent<VaporLight>();
        }
    }

    private void CameraRigController_onCameraEnableGlobal(CameraRigController cameraRigController)
    {
        if (cameraRigController.sceneCam && !cameraRigController.sceneCam.GetComponent<Vapor>())
        {
            Vapor vapor = cameraRigController.sceneCam.gameObject.AddComponent<Vapor>();
        }
    }
}
