public class PlayerScoreUpEvent
{
    public int CurrentScore;
    public PlayerScoreUpEvent(int score)
    {
        CurrentScore = score;
    }
}
# region �� �̺�Ʈ�� �ܼ��� �߻� ��ȣ�̸�, ���õ� �����ʹ� �ʿ����� ����. �̺�Ʈ �����ڴ� �� ��ȣ�� ���� �ʿ��� ������ �����ϸ� ��.
public class GameOverEvent {  }
public class PauseEvent { }
public class ResumeEvent { }
public class GameClearEvent { }

#endregion