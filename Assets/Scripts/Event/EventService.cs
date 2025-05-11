using Singleton;

namespace Event
{
    //Custom event service.
    public class EventService : GenericMonoSingleton<EventService>
    {
        public EventController OnPlayerDeathEvent { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            OnPlayerDeathEvent = new EventController();
        }
    }
}