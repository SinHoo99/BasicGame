using System;
using System.Collections;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        if (IsDuplicates()) return;

        base.Awake();

        // 실제 모바일 테스트 시 30, 60 비교해보기
        Application.targetFrameRate = 60;

      //  DataManager.Initialize();
        SoundManager.Initializer();
    }


    #region 경고 알림

    public GameObject AlertObject;
    public TextMeshProUGUI AlertText;
    private Coroutine _alertCoroutine;
    public void ShowAlert(string msg)
    {
        AlertText.text = msg;
        AlertObject.SetActive(true);
       // PlaySFX(SFX.Alert);

       /* if (_alertCoroutine != null) StopCoroutine(_alertCoroutine);
        _alertCoroutine = StartCoroutine(AlertCo());*/
    }
   /* private IEnumerator AlertCo()
    {
        yield return new WaitForSecondsRealtime(2f);
        AlertObject.SetActive(false);
    }*/
    
    public void HideAlert()
    {
        AlertObject.SetActive(false);
    }

    #endregion

    #region 데이터
    [SerializeField] private DataManager DataManager;

    #endregion

    #region 세이브

    [SerializeField] private SaveManager SaveManager;

    public PlayerData NowPlayerData;
    public void SavePlayerData()
    {
        SaveManager.SaveData(NowPlayerData);
    }
    public bool LoadPlayerData()
    {
        if(SaveManager.TryLoadData(out PlayerData data))
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
        if(LoadPlayerData())
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

}