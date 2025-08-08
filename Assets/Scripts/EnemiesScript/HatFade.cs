using UnityEngine;
using DG.Tweening;

public class HatFade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Material mat = GetComponent<MeshRenderer>().material;

        mat.DOFade(1f, 0.3f);
    }
}
