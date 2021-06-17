using System.IO;
using UnityEditor;
using UnityEngine;

namespace SleepyApe
{
    public class SleepyApeSetting : ScriptableObject
    {
#if UNITY_EDITOR
        [SerializeField] private string _defaultSettingDirectory = "SleepyApe/Settings/";

        public string DefaultSettingDirectory => _defaultSettingDirectory;
#endif

        public static SleepyApeSetting GetInstance()
        {
            var setting = Resources.Load<SleepyApeSetting>("SleepyApe");
#if UNITY_EDITOR
            if (setting == null)
            {
                string path = "Assets/Resources/";
                string file = $"{path}SleepyApe.asset";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                setting = ScriptableObject.CreateInstance<SleepyApeSetting>();
                AssetDatabase.CreateAsset(setting, file);

                Debug.Log($"[SleepyApe Framework] : SleepyApeSetting asset is created in {file}, "
                    + "if you want to move the configuration file make sure the file is under \"Resources\" folder with the name \"SleepyApe\"");
            }
#endif
            return setting;
        }
    }
}