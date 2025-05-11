using System;
using System.Collections.Generic;

namespace ObjectPool
{
    public abstract class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> _pooledItems = new List<PooledItem<T>>();

        //If the item already exists in the scene and it's not being used, we simple activate that item and return it.
        //Else we create a new item, add it to the pool and return it.
        protected T GetItem()
        {
            if(_pooledItems.Count > 0)
            {
                PooledItem<T> item = _pooledItems.Find(item => !item.IsBeingUsed);
                if(item != null)
                {
                    item.IsBeingUsed = true;
                    return item.Item;
                }
            }

            return CreateNewPooledItem();
        }

        private T CreateNewPooledItem()
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.Item = CreateItem();
            newItem.IsBeingUsed = true;
            _pooledItems.Add(newItem);

            return newItem.Item;
        }

        //Whoever is inheriting from this class, will have to implement this method.
        protected abstract T CreateItem();

        //We return the item to the pool when its work is done, making it available to reuse.
        public void ReturnItem(T item)
        {
            PooledItem<T> pooledItem = _pooledItems.Find(itm => itm.Item.Equals(item));
            pooledItem.IsBeingUsed = false;
        }

        public class PooledItem<T>
        {
            public T Item;
            public bool IsBeingUsed;
        }
    }
}