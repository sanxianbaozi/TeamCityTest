using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class BuildProject
{
    [MenuItem("Build/BuildApk")]
    public static void BuildApk()
    {
        var outdir = System.Environment.CurrentDirectory + "/BuildOutPutPath/Android";
        var outputPath = Path.Combine(outdir, Application.productName + ".apk");
        //文件夹处理
        if (!Directory.Exists(outdir)) Directory.CreateDirectory(outdir);
        if (File.Exists(outputPath)) File.Delete(outputPath);

        //开始项目一键打包
        string[] scenes = new[] {"Assets/Scenes/SampleScene.unity"};
        UnityEditor.BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.Android, BuildOptions.None);
        if (File.Exists(outputPath))
        {
            Debug.Log("Build Success :" + outputPath);
        }
        else
        {
            Debug.LogException(new Exception("Build Fail! Please Check the log! "));
        }
    }
}
