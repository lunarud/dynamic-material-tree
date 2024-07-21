public sealed class EventInfo<TSource, TEventHandler>
    {
        public EventInfo(Action<TSource, TEventHandler> fnAddHandler,
            Action<TSource, TEventHandler> fnRemoveHandler)
        {
            m_fnAddHandler = fnAddHandler;
            m_fnRemoveHandler = fnRemoveHandler;
        }
        public void AddHandler(TSource source, TEventHandler handler)
        {
            m_fnAddHandler(source, handler);
        }
        public void RemoveHandler(TSource source, TEventHandler handler)
        {
            m_fnRemoveHandler(source, handler);
        }
        public Scope Subscribe(TSource source, TEventHandler handler)
        {
            AddHandler(source, handler);
            return Scope.Create(() => RemoveHandler(source, handler));
        }
        readonly Action<TSource, TEventHandler> m_fnAddHandler;
        readonly Action<TSource, TEventHandler> m_fnRemoveHandler;
    }
