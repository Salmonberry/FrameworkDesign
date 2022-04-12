using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp
{
    public class CounterApp:Architecture<CounterApp>
    {

        //ÕâÀï×¢²áÄ£¿é
        protected override void Init()
        {
            Register<ICounterModel>(new CounterModel());
            Register<IStorage>(new PlayerPrefsStorage());
        }

    }
}

