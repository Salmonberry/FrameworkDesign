namespace FrameworkDesign
{
    /// <summary>
    /// �ܹ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Architecture<T> where T : Architecture<T>, new()
    {
        #region ���Ƶ���ģʽ ���ǽ����ڲ��ɷ���
        private static T mArchitecture = null;

        // ȷ�� Container ����ʵ����
        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();
            }
        }
        #endregion

        private IOCContainer mContainer = new IOCContainer();

        // ��������ע��ģ��
        protected abstract void Init();

        // �ṩһ��ע��ģ��� API
        public void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }

        // �ṩһ����ȡģ��� API
        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }
    }
}