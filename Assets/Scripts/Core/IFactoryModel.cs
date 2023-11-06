using System;

namespace Demo.Scripts.FactoryMVPDemo
{
    public interface IFactoryModel<TData> : IDisposable
    {
        public TData Data { get; set; }
        public void Initialize(TData data);
    }
}