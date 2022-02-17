using FrameworkDesign;
using UnityEngine;

namespace CounterApp
{
    public struct SubCountCommand : ICommand
    {
        public void Execute()
        {
            CounterModel.Count.Value--;
        }
    }    
}

