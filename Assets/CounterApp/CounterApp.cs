using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            RegisterSystem<IAchievementSystem>(new AchievementSystem());
            
            RegisterModel<ICounterModel>(new CounterModel());
        
            RegisterUtility<IStorage>(new PlayerPrefsStorage());
        }
    }
}