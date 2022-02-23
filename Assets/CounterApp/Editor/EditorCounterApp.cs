using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CounterApp
{
    public class EditorCounterApp : EditorWindow
    {
        /// <summary>
        /// �򿪴���
        /// </summary>
        [MenuItem("EditorCounterApp/Open")]
       static void Open() { 
            var editorCounterApp=GetWindow<EditorCounterApp>();
            editorCounterApp.name=nameof(EditorCounterApp);
            editorCounterApp.position = new Rect(100, 100, 400, 600);
            editorCounterApp.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                new AddCountCommand().Execute();
            }

            //����ʵʱˢ�� ����ֱ�Ӿ���Ⱦ���ݼ���
            GUILayout.Label(CounterApp.Get<CounterModel>().Count.Value.ToString());

            if (GUILayout.Button("-"))
            {
                new SubCountCommand().Execute();
            }
        }
    }
}
