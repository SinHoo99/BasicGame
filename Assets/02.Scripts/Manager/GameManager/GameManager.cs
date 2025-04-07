using System;
using System.Collections;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static ScoreUI;

public class GameManager : Singleton<GameManager>
{
    public int playerCurrentScore;
    private bool isQuitting;
    protected override void Awake()
    {
        if (IsDuplicates()) return;

        base.Awake();

        // 실제 모바일 테스트 시 30, 60 비교해보기
        Application.targetFrameRate = 60;

        //DataManager.Initialize();
        SoundManager.Initializer();
    }

    private void Start()
    {
        LoadAllData();
    }

    #region 점수 관련 로직
    public void AddScore(int amount)
    {
        playerCurrentScore += amount;
        EventBus.Publish(new PlayerScoreUpEvent(playerCurrentScore));
    }

    #endregion
    

    #region 데이터 (정적데이터 (EX.CSV데이터) )
    [SerializeField] private DataManager DataManager;

    #endregion

    #region 세이브

    [SerializeField] private SaveManager SaveManager;

    public PlayerData NowPlayerData;
    public void SavePlayerData()
    {
        if (NowPlayerData.HighScore < playerCurrentScore)
        {
            NowPlayerData.HighScore = playerCurrentScore;
        }
        SaveManager.SaveData(NowPlayerData);
    }
    public bool LoadPlayerData()
    {
        if (SaveManager.TryLoadData(out PlayerData data))
        {
            NowPlayerData = data;
            return true;
        }
        else
        {
            return false;
        }
    }


    public OptionData NowOptionData;
    public void SaveOptionData()
    {
        SaveManager.SaveData(NowOptionData);
    }
    public bool LoadOptionData()
    {
        if (SaveManager.TryLoadData(out OptionData data))
        {
            NowOptionData = data;
            return true;
        }
        else
        {
            NowOptionData.BGMVolume = 0;
            NowOptionData.SFXVolume = 0;
            return false;
        }
    }

    public void SaveAllData()
    {
        SavePlayerData();
    }
    public bool LoadAllData() // todo: 수정 필요
    {
        if (LoadPlayerData())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

    #region 사운드

    [SerializeField] private SoundManager SoundManager;

    public AudioMixer GetAudioMixer()
    {
        return SoundManager.AudioMixer;
    }

    public void PlayBGM(BGM target)
    {
        //SoundManager.PlayBGM(target);
    }

    public void PlaySFX(SFX target)
    {
        //SoundManager.PlaySFX(target);
    }

    #endregion

    #region 경고 알림

    public GameObject AlertObject;
    public TextMeshProUGUI AlertText;

    public void ShowAlert(string msg)
    {
        AlertText.text = msg;
        AlertObject.SetActive(true);
        // PlaySFX(SFX.Alert);

    }
    public void HideAlert()
    {
        AlertObject.SetActive(false);
    }

    #endregion

    #region  애플리케이션 이벤트
    private void OnApplicationQuit()
    {
        isQuitting = true;
        SaveAllData();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause && !isQuitting)
        {
            SaveAllData();
        }
    }
    #endregion
}