using System;

namespace Event
{
    public class EventController
    {
        public Action BaseEvent;
        public void AddListener(Action listener) => BaseEvent += listener;
        public void InvokeEvent() => BaseEvent?.Invoke();
        public void RemoveListener(Action listener) => BaseEvent -= listener;
    }

    public class EventController<T>
    {
        public Action<T> BaseEvent;
        public void AddListener(Action<T> listener) => BaseEvent += listener;
        public void InvokeEvent(T parameter) => BaseEvent?.Invoke(parameter);
        public void RemoveListener(Action<T> listener) => BaseEvent -= listener;
    }
}