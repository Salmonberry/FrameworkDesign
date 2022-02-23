using UnityEngine;

namespace FrameworkDesign.Example
{
public class Enemy : MonoBehaviour
{

        /// <summary>
        /// 点击自己则烧毁
        /// </summary>
     private void OnMouseDown() {
        Destroy(gameObject);

        //用Command
        new  KillEnemyCommand().Execute();

        }
    }    
}

