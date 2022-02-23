using FrameworkDesign.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartPanel : MonoBehaviour
{
    /// <summary>
    /// Enemy的父节点
    /// </summary>
    public GameObject Enemies;

    private void Start()
    {
        transform.Find("BtnGameStart").GetComponent<Button>().onClick.AddListener(() =>
        {
            gameObject.SetActive(false);

            // 发送 Command
            new StartGameCommand()
                .Execute();
          
        });
    }
}
