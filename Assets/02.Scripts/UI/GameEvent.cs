public class PlayerScoreUpEvent
{
    public int CurrentScore;
    public PlayerScoreUpEvent(int score)
    {
        CurrentScore = score;
    }
}
public class PlayerCoinUpEvent
{
    public int CurrentCoin;
    public PlayerCoinUpEvent(int score)
    {
        CurrentCoin = score;
    }
}

# region 이 이벤트는 단순한 발생 신호이며, 관련된 데이터는 필요하지 않음. 이벤트 수신자는 이 신호만 보고 필요한 로직을 수행하면 됨.
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