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
            // 註冊
            CounterModel.Count.OnValueChanged += OnCountChanged;

            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //交互邏輯
                new AddCountCommand().Execute();
            });

            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                //交互邏輯
                new SubCountCommand().Execute();
            });

            OnCountChanged(CounterModel.Count.Value);
        }

        //表現邏輯
        private void OnCountChanged(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }

        private void OnDestroy()
        {
            //註銷
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