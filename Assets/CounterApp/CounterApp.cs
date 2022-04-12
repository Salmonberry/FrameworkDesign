using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp
{
    public class CounterApp:Architecture<CounterApp>
    {

        //����ע��ģ��
        protected override void Init()
        {
            Register<ICounterModel>(new CounterModel());
            Register<IStorage>(new PlayerPrefsStorage());
        }

    }
}

