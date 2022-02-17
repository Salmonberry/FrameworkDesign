using UnityEngine;

namespace FrameworkDesign.Example
{
public class Enemy : MonoBehaviour
{

        /// <summary>
        /// 点击自己则销毁
        /// </summary>
     private void OnMouseDown() {
        Destroy(gameObject);

            KilledOneEnemyEvent.Trigger();

        }
    }    
}

