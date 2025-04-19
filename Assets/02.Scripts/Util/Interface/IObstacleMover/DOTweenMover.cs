using DG.Tweening;
using UnityEngine;

public class DOTweenMover : IObstacleMover
{
    private Tween tween;

    public void Move(Transform target)
    {
        tween = target.DOMoveX(target.position.x + 3f, 50f).SetEase(Ease.InOutQuad);
    }

    public void Stop()
    {
        tween?.Kill();
    }
}
