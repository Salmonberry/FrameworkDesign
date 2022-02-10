using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                CounterModel.Count++;

                //±íÏÖÂß¼­
                UpdateView();
            });

            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                CounterModel.Count--;
                UpdateView();
            });

        }

        void UpdateView()
        {
            transform.Find("CountText").GetComponent<Text>().text =CounterModel.Count.ToString();
        }
    }

    public static class CounterModel
    {
        public static int Count = 0;
    }
}

