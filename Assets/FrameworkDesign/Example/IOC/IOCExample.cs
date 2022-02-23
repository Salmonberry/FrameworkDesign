using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class IOCExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //����һ��IOC����
            var container = new IOCContainer();

            //ע��һ��������������ʵ��
            container.Register(new BluetoothManager());

            //�������ͻ�ȡ������������ʵ��
            var bluetoothManager = container.Get<BluetoothManager>();

            //��������
            bluetoothManager.Connect();
        }


        public class BluetoothManager
        {
            public void Connect()
            {
                Debug.Log("�������ӳɹ�");
            }
        }
    }

}
