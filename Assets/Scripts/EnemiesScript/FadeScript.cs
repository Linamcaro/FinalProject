using UnityEngine;
using DG.Tweening;

public class FadeScript : MonoBehaviour

{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Material mat = GetComponent<SkinnedMeshRenderer>().material;

        mat.DOFade(1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}





