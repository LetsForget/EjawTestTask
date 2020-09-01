using UnityEditor;
using UnityEngine;

public class AssetBundleCreator : MonoBehaviour
{
    [MenuItem("Edit/Create bundles")]
    public static void CreateAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("D:\\UnityProjects\\EJaw Test Task\\Assets\\Bundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}