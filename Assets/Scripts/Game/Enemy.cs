using UnityEngine;

namespace FrameworkDesign.Example
{
public class Enemy : MonoBehaviour
{

        /// <summary>
        /// ����Լ�������
        /// </summary>
     private void OnMouseDown() {
        Destroy(gameObject);

            GameModel.KillCount++;

            KilledOneEnemyEvent.Trigger();

        }
    }    
}
