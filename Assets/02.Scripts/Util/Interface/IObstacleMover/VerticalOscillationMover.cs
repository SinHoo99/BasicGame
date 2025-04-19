using DG.Tweening;
using UnityEngine;

public class VerticalOscillationMover : IObstacleMover
{
    private Tween tween;

    public void Move(Transform target)
    {
        tween = target.DOMoveY(target.position.y + 1f, 50f)
                      .SetLoops(-1, LoopType.Yoyo)
                      .SetEase(Ease.InOutSine);
    }

    public void Stop()
    {
        tween?.Kill();
    }
}
