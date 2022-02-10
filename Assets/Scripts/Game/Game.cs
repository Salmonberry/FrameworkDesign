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
            GameModel.KillCount++;

            //ʮ��ȫ����������ʾͨ�ؽ���
            if(GameModel.KillCount == 10)
            {
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

