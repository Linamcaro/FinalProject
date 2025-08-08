using System.Collections.Generic;
using UnityEngine;

public class FlechaPool : MonoBehaviour
{
    public static FlechaPool Instance;
    public GameObject flechaPrefab;
    public int tamañoPool = 20;

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;
        for (int i = 0; i < tamañoPool; i++)
        {
            GameObject f = Instantiate(flechaPrefab);
            f.SetActive(false);
            pool.Enqueue(f);
        }
    }

    public GameObject ObtenerFlecha()
    {
        if (pool.Count > 0)
        {
            var flecha = pool.Dequeue();
            flecha.SetActive(true);
            return flecha;
        }
        else
        {
            GameObject f = Instantiate(flechaPrefab);
            return f;
        }
    }

    public void DevolverFlecha(GameObject flecha)
    {
        flecha.SetActive(false);
        pool.Enqueue(flecha);
    }
}
