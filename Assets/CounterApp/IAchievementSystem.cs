using System.Collections;
using System.Collections.Generic;
using CounterApp;
using UnityEngine;

namespace FrameworkDesign
{
    public interface IAchievementSystem : ISystem
    {
    }

    public class AchievementSystem : IAchievementSystem
    {
        public IArchitecture Architecture { get; set; }

        public void Init()
        {
            var counterModel = Architecture.GetModel<ICounterModel>();
            var previousCount = counterModel.Count.Value;

            counterModel.Count.OnValueChanged += newCount =>
            {
                if (newCount >= 10 && previousCount < 10)
                {
                    Debug.Log("解锁 10 次点击成就");
                }
                else if (newCount >= 20 && previousCount < 20)
                {
                    Debug.Log("解锁 20 次点击成就");
                }

                previousCount = newCount;
            };
        }
    }
}