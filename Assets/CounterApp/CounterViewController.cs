using FrameworkDesign;
using UnityEngine;
using UnityEngine.UI;


namespace CounterApp
{
    public class CounterViewController : MonoBehaviour,IController
    {
        private ICounterModel mCounterModel;

        void Start()
        {
            //获取
            mCounterModel = CounterApp.Get<ICounterModel>();

            // 註冊
            mCounterModel.Count.OnValueChanged += OnCountChanged;

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

            OnCountChanged(mCounterModel.Count.Value);
        }

        //表現邏輯
        private void OnCountChanged(int newValue)
        {
            transform.Find("CountText").GetComponent<Text>().text = newValue.ToString();
        }

        private void OnDestroy()
        {
            //註銷
            mCounterModel.Count.OnValueChanged -= OnCountChanged;

            mCounterModel = null;
        }

        public IArchitecture Architecture { get; set; } = CounterApp.Interface;
    }

    public interface ICounterModel : IModel
    {
        BindableProperty<int> Count { get; }
    }


    public class CounterModel : ICounterModel
    {
        public void Init()
        {
            //通过Architrecture 获取
            var storage = Architecture.GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += count => { storage.SaveInt("COUNTER_COUNT", count); };
        }

        public BindableProperty<int> Count { get; } = new BindableProperty<int>() {Value = 0};
        public IArchitecture Architecture { get; set; }
    }
}