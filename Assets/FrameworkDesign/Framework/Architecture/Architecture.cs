namespace FrameworkDesign
{
    /// <summary>
    /// 架构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Architecture<T> where T : Architecture<T>, new()
    {
        #region 类似单例模式 但是仅在内部可访问
        private static T mArchitecture = null;

        // 确保 Container 是有实例的
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

        // 留给子类注册模块
        protected abstract void Init();

        // 提供一个注册模块的 API
        public void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }

        // 提供一个获取模块的 API
        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }
    }
}