#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class DIPExample : MonoBehaviour
    {
        // 1.�OӋģ�K�ӿ�
        public interface IStorage
        {
            void SaveString(string key,string value);
            string LoadString(string key,string defaultValue="");
        }

        //2.���F�ӿ�
        //�\�Еr�惦
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


        //3.���F�ӿ�
        //��݋���惦
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


        //4.ʹ��
        private void Start()
        {
            //����һ��IOC����
            var container=new IOCContainer();

            //ע���\�Еrģ�K��
            container.Register<IStorage>(new PlayerPrefsStorage());

            var storage = container.Get<IStorage>();

            storage.SaveString("name", "�\�Еr�惦");

            Debug.Log(storage.LoadString("name"));

           //�ГQ���F
           container.Register<IStorage>(new EditorPrefsStorage());

            storage=container.Get<IStorage>();

            Debug.Log(storage.LoadString("name"));
        }

    }

}
