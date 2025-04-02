using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
# region �̺�Ʈ ���� ��뿹��
// 1. �̺�Ʈ ������ Ÿ�� ����
// �̺�Ʈ �߻��� ������ ������ ���� �����ߵ�
public class PlayerDieEvent
{
    public string playerName;
    public PlayerDieEvent(string name)
    {
        playerName = name;
    }
}

public class Player : MonoBehaviour
{
    private float HP;
    // �̺�Ʈ ����
    void Die()
    {
        if (HP < 0)
            EventBus.Publish(new PlayerDieEvent("Player1"));
    }
}

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject gameOverPanel;
    protected override void Awake()
    {
        base.Awake();
    }
    // �̺�Ʈ ����
    private void OnEnable()
    {
        EventBus.Subscribe<PlayerDieEvent>(OnPlayerDied);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<PlayerDieEvent>(OnPlayerDied);
    }

    void OnPlayerDied(PlayerDieEvent e)
    {
        Debug.Log("�÷��̾� ���" + e.playerName);
        gameOverPanel.SetActive(true);
    }
}

#endregion

#region �̺�Ʈ ����Ȱ�� ������Ʈ ����ȭ ���� ������
public class AObject : MonoBehaviour
{
    public GameObject AObj;
    public Text AObjTxt;

    private void OnEnable()
    {
        EventBus.Subscribe<AObjectEvent>(OnAobjectEvent);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<AObjectEvent>(OnAobjectEvent);
    }

    void OnAobjectEvent(AObjectEvent e)
    {
        Debug.Log("�÷��̾� ���" + e.playerName);
        AObjTxt.text = e.playerName;
        AObj.SetActive(true);
    }
}
public class BObject : MonoBehaviour
{
    public GameObject BObj;
    public Text BObjTxt;

    private void OnEnable()
    {
        EventBus.Subscribe<BObjectEvent>(OnBobjectEvent);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<BObjectEvent>(OnBobjectEvent);
    }

    void OnBobjectEvent(BObjectEvent e)
    {
        Debug.Log("�÷��̾� ���" + e.playerName);
        BObjTxt.text = e.playerName;
        BObj.SetActive(true);
    }
}
public class CObject : MonoBehaviour
{
    public GameObject CObj;
    public Text CObjTxt;

    private void OnEnable()
    {
        EventBus.Subscribe<CObjectEvent>(OnCobjectEvent);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<CObjectEvent>(OnCobjectEvent);
    }

    void OnCobjectEvent(CObjectEvent e)
    {
        Debug.Log("�÷��̾� ���" + e.playerName);
        CObjTxt.text = e.playerName;
        CObj.SetActive(true);
    }
}


public class AObjectEvent
{
    public string playerName;
    public AObjectEvent(string name)
    {
        playerName = name;
    }
}

public class BObjectEvent
{
    public string playerName;
    public BObjectEvent(string name)
    {
        playerName = name;
    }
}

public class CObjectEvent
{
    public string playerName;
    public CObjectEvent(string name)
    {
        playerName = name;
    }
}
#endregion