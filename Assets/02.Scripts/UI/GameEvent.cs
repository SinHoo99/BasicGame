using UnityEngine;

public class PlayerScoreUpEvent
{
    public int CurrentScore { get; }
    public Vector3 WorldPosition { get; }

    public PlayerScoreUpEvent(int score, Vector3 worldPosition)
    {
        CurrentScore = score;
        WorldPosition = worldPosition;
    }
}
/*public class PlayerCoinUpEvent
{
    public int CurrentCoin;
    public PlayerCoinUpEvent(int score)
    {
        CurrentCoin = score;
    }
}*/

# region �� �̺�Ʈ�� �ܼ��� �߻� ��ȣ�̸�, ���õ� �����ʹ� �ʿ����� ����. �̺�Ʈ �����ڴ� �� ��ȣ�� ���� �ʿ��� ������ �����ϸ� ��.
public class GameOverUIEvent {  }
/*public class PauseEvent { }
public class ResumeEvent { }
public class GameClearEvent { }*/

public class PlayerJumpEvent { }
public class PlayerFallEvent { }
public class PlayerFlipEvent
{
    public bool isFacingLeft;

    public PlayerFlipEvent(bool isFacingLeft)
    {
        this.isFacingLeft = isFacingLeft;
    }
}

#endregion