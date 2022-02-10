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

            //十个全部消灭再显示通关界面
            if(GameModel.KillCount == 10)
            {
                //触发游戏通关事件
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

