using System;
using System.Collections.Generic;

public static class EventBus
{
    private static readonly Dictionary<Type, Action<object>> _events = new();

    // �ݹ�� ���� ���۸� ��Ī ���� (Unsubscribe ���)
    private static readonly Dictionary<Delegate, Action<object>> _delegateLookup = new();

    // ����
    public static void Subscribe<T>(Action<T> callback)
    {
        Action<object> wrapper = (obj) => callback((T)obj);
        _delegateLookup[callback] = wrapper;

        if (_events.TryGetValue(typeof(T), out var existing))
            _events[typeof(T)] += wrapper;
        else
            _events[typeof(T)] = wrapper;
    }
    //��������
    public static void Unsubscribe<T>(Action<T> callback)
    {
        if (_delegateLookup.TryGetValue(callback, out var wrapper))
        {
            if (_events.TryGetValue(typeof(T), out var existing))
                _events[typeof(T)] -= wrapper;

            _delegateLookup.Remove(callback);
        }
    }
    // �̺�Ʈ ����
    public static void Publish<T>(T evt)
    {
        if (_events.TryGetValue(typeof(T), out var action))
            action?.Invoke(evt);
    }
}

