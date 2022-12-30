using Core.Data;
using System;
using System.Collections.Generic;


namespace View.Pool
{
    public class ObjectPool<T>
    {
        private readonly Func<T> create;
        private readonly Action<T> postPop;
        private readonly Action<T> prePush;
        private readonly Stack<T> cached = new();


        public ObjectPool(Func<T> create, Action<T> postPop, Action<T> prePush)
        {
            this.create = create;
            this.postPop = postPop;
            this.prePush = prePush;
        }


        public T Pop()
        {
            var t = cached.TryPop(out var value)
                ? value
                : create();
            postPop(t);
            return t;
        }


        public void Push(T value)
        {
            prePush(value);
            cached.Push(value);
        }
    }
}