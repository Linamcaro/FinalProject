using UnityEngine;
using DG.Tweening;

public class MapRotation : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), 20f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
}
