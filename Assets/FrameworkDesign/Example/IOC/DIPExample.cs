#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class DIPExample : MonoBehaviour
    {
        // 1.設計模塊接口
        public interface IStorage
        {
            void SaveString(string key,string value);
            string LoadString(string key,string defaultValue="");
        }

        //2.實現接口
        //運行時存儲
        public class PlayerPrefsStorage : IStorage
        {
            

            public void SaveString(string key, string value)
            {
               PlayerPrefs.SetString(key, value);
            }

            public string LoadString(string key, string defaultValue = "")
            {
              return PlayerPrefs.GetString(key, defaultValue);
            }
        }


        //3.實現接口
        //編輯器存儲
        public class EditorPrefsStorage : IStorage
        {

            public void SaveString(string key, string value)
            {
#if UNITY_EDITOR
                EditorPrefs.SetString(key, value);
#endif
            }

            public string LoadString(string key, string defaultValue = "")
            {
#if UNITY_EDITOR
                return EditorPrefs.GetString(key, defaultValue);
#else
return ""
#endif
            }

           
        }


        //4.使用
        private void Start()
        {
            //創建一個IOC容器
            var container=new IOCContainer();

            //注冊運行時模塊的
            container.Register<IStorage>(new PlayerPrefsStorage());

            var storage = container.Get<IStorage>();

            storage.SaveString("name", "運行時存儲");

            Debug.Log(storage.LoadString("name"));

           //切換實現
           container.Register<IStorage>(new EditorPrefsStorage());

            storage=container.Get<IStorage>();

            Debug.Log(storage.LoadString("name"));
        }

    }

}
