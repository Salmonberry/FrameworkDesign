using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameStartEvent.Register(OnGameStart);
            KilledOneEnemyEvent.Register(OnEnmeyKilled);
        }

        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }

        private void OnEnmeyKilled()
        {
            GameModel.KillCount.Value++;

            Debug.Log(GameModel.KillCount.Value);

            //ʮ��ȫ����������ʾͨ�ؽ���
            if(GameModel.KillCount.Value == 10)
            {
                Debug.Log("gamePass");
                //������Ϸͨ���¼�
                GamePassEvent.Trigger();
            }
        }


        private void OnDestroy()
        {
            GameStartEvent.UnRegister(OnGameStart);
            KilledOneEnemyEvent.UnRegister(OnEnmeyKilled);
        }
    }
}

