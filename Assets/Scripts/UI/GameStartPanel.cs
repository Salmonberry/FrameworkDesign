using FrameworkDesign.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartPanel : MonoBehaviour
{
    /// <summary>
    /// Enemy�ĸ��ڵ�
    /// </summary>
    public GameObject Enemies;

    private void Start()
    {
        transform.Find("BtnGameStart").GetComponent<Button>().onClick.AddListener(() =>
        {
            gameObject.SetActive(false);

            // �����¼�
            GameStartEvent.Trigger();
          
        });
    }
}
