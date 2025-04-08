using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using static DataManager;


public class GameManager : Singleton<GameManager>
{
    public GameState CurrentState { get; private set; }
    public int playerCurrentScore;
    private bool isQuitting;
    protected override void Awake()
    {
        if (IsDuplicates()) return;

        base.Awake();

        // 실제 모바일 테스트 시 30, 60 비교해보기
        Application.targetFrameRate = 60;

        DataManager.Initializer();
        SoundManager.Initializer();

    }

    private void Start()
    {
        LoadAllData();
        ResetGameState();
    }



    #region 생성 관련 로직
    private int ObstacleSpawnIndex;

    public int GetNextObstacleIndex()
    {
        return ObstacleSpawnIndex++;
    }
    #endregion
    #region 상태 관련 로직
    public void SetGameState(GameState state)
    {
        CurrentState = state;
    }
    #endregion
    #region 점수 관련 로직
    public void AddScore(int amount)
    {
        playerCurrentScore += amount;
        EventBus.Publish(new PlayerScoreUpEvent(playerCurrentScore));
    }
    public void ResetGameState()
    {
        playerCurrentScore = 0;
        CurrentState = GameState.Playing;
        ObstacleSpawnIndex = 0;
    }
    #endregion
    #region 데이터 (정적데이터 (EX.CSV데이터, SO) )
    [SerializeField] private DataManager DataManager;

    public PlayerSO GetPlayerSOData() => DataManager?.PlayerSO;

    public ColorData GetColorData(ColorID id)
    {
        return DataManager.ColorDatas[id];
    }

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
    public bool LoadAllData()
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