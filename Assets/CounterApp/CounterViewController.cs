using FrameworkDesign;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
       

       
        void Start()
        {

            //ע��
            CounterModel.Count.OnValueChanged += OnCountChanged;

            // Start is called before the first frame update
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //�����߼�
                CounterModel.Count.Value++;
            });

            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                CounterModel.Count.Value--;
            });

            OnCountChanged(CounterModel.Count.Value);
        }

        //�����߼�
        private void OnCountChanged(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }

        private void OnDestroy()
        {
            //ע��
            CounterModel.Count.OnValueChanged -= OnCountChanged;
        }

    }

    public static class CounterModel
    {
        public static BindableProperty<int> Count = new BindableProperty<int>()
        {
            Value = 0,
        };

    }
}

