using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class EventBus
{
    private static readonly Dictionary<Type, Action<object>> _events = new();

    // 콜백과 람다 래퍼를 매칭 저장 (Unsubscribe 대비)
    private static readonly Dictionary<Delegate, Action<object>> _delegateLookup = new();

    // 구독
    public static void Subscribe<T>(Action<T> callback)
    {
        Action<object> wrapper = (obj) => callback((T)obj);
        _delegateLookup[callback] = wrapper;

        if (_events.TryGetValue(typeof(T), out var existing))
            _events[typeof(T)] += wrapper;
        else
            _events[typeof(T)] = wrapper;
    }
    //구독해제
    public static void Unsubscribe<T>(Action<T> callback)
    {
        if (_delegateLookup.TryGetValue(callback, out var wrapper))
        {
            if (_events.TryGetValue(typeof(T), out var existing))
                _events[typeof(T)] -= wrapper;

            _delegateLookup.Remove(callback);
        }
    }
    // 이벤트 발행
    public static void Publish<T>(T evt)
    {
        if (_events.TryGetValue(typeof(T), out var action))
            action?.Invoke(evt);
    }
}
# region 이벤트 버스 사용예시
// 1. 이벤트 데이터 타입 정의
// 이벤트 발생시 전달할 데이터 구조 만들어야됨
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
    // 이벤트 발행
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
    // 이벤트 구독
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
        Debug.Log("플레이어 사망" + e.playerName);
        gameOverPanel.SetActive(true);
    }
}

#endregion

#region 이벤트 버스활용 컴포넌트 독립화 과정 만들어보기
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
        Debug.Log("플레이어 사망" + e.playerName);
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
        Debug.Log("플레이어 사망" + e.playerName);
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
        Debug.Log("플레이어 사망" + e.playerName);
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