using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CounterApp
{
    public class EditorCounterApp : EditorWindow
    {
        /// <summary>
        /// 打开窗口
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

            //由于实时刷新 所以直接就渲染数据即可
            GUILayout.Label(CounterApp.Get<CounterModel>().Count.Value.ToString());

            if (GUILayout.Button("-"))
            {
                new SubCountCommand().Execute();
            }
        }
    }
}

