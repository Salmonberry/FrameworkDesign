using System;
using System.Collections.Generic;

namespace FrameworkDesign
{

    public interface IArchitecture
    {
        /// <summary>
        /// 注册系统
        /// </summary>
        void RegisterSystem<T>(T instance) where T : ISystem; // 新增
    
        /// <summary>
        /// 注册 Model
        /// </summary>
        void RegisterModel<T>(T instance) where T : IModel;

        /// <summary>
        /// 注册 Utility
        /// </summary>
        void RegisterUtility<T>(T instance);

        /// <summary>
        /// 获取 Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetModel<T>() where T : class, IModel;
    
        /// <summary>
        /// 获取工具
        /// </summary>
        T GetUtility<T>() where T : class;
    }
  
    /// <summary>
    /// 架构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        /// <summary>
        /// 是否已经初始化完成
        /// </summary>
        private bool mInited = false;

        /// <summary>
        /// 用于初始化的 Systems 的缓存
        /// </summary>
        private List<ISystem> mSystems = new List<ISystem>(); // 新增
    
        // 提供一个注册 Model 的 API
        public void RegisterSystem<T>(T instance) where T : ISystem // 新增
        {
            // 需要给 Model 赋值一下
            instance.Architecture = this;
            mContainer.Register<T>(instance);
        
            // 如果初始化过了
            if (mInited)
            {
                instance.Init();
            }
            else
            {
                // 添加到 Model 缓存中，用于初始化
                mSystems.Add(instance);
            }
        }
    
        /// <summary>
        /// 用于初始化的 Models 的缓存
        /// </summary>
        private List<IModel> mModels = new List<IModel>();

        public void RegisterModel<T>(T instance) where T : IModel
        {
            // 需要给 Model 赋值一下
            instance.Architecture = this;
            mContainer.Register<T>(instance);
        
            // 如果初始化过了
            if (mInited)
            {
                instance.Init();
            }
            else
            {
                // 添加到 Model 缓存中，用于初始化
                mModels.Add(instance);
            }
        }
    
        #region 类似单例模式 但是仅在内部课访问

        /// <summary>
        /// 注册补丁
        /// </summary>
        public static Action<T> OnRegisterPatch = architecture=> { };
    
        private static T mArchitecture = null;

        public static IArchitecture Interface
        {
            get
            {
                if (mArchitecture == null)
                {
                    MakeSureArchitecture();
                }

                return mArchitecture;
            }
        }
    
        // 确保 Container 是有实例的
        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                // 调用
                OnRegisterPatch?.Invoke(mArchitecture);
            
                // 初始化 Model
                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.Init();
                }

                // 清空 Model
                mArchitecture.mModels.Clear();
            
                // 初始化 System

                foreach (var architectureSystem in mArchitecture.mSystems) // 新增
                {
                    architectureSystem.Init();
                }
            
                // 清空 System
                mArchitecture.mSystems.Clear(); // 新增
            
                mArchitecture.mInited = true;
            }
        }

        #endregion

        private IOCContainer mContainer = new IOCContainer();

        // 留给子类注册模块
        protected abstract void Init();

        // 提供一个注册模块的 API
        public static void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }
    
        public void RegisterUtility<T>(T instance)
        {
            mContainer.Register<T>(instance);
        }


        public T GetModel<T>() where T : class, IModel
        {
            return mContainer.Get<T>();
        }
    
        public T GetUtility<T>() where T : class
        {
            return mContainer.Get<T>();
        }

        // 提供一个获取模块的 API
        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }
    }
}