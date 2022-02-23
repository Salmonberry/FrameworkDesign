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
      
        }

        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }



        private void OnDestroy()
        {
            GameStartEvent.UnRegister(OnGameStart);
         
        }
    }
}

