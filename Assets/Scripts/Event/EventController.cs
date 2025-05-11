using System;

namespace Event
{
    public class EventController
    {
        public Action BaseEvent;
        public void Addlistener(Action listener) => BaseEvent += listener;
        public void InvokeEvent() => BaseEvent?.Invoke();
        public void RemoveListener(Action listener) => BaseEvent -= listener;
    }
}