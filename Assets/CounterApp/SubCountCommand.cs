using FrameworkDesign;
using UnityEngine;

namespace CounterApp
{
    public struct SubCountCommand : ICommand
    {
        public void Execute()
        {
            CounterApp.Get<ICounterModel>().Count.Value--;
        }
    }    
}

