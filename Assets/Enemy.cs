using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
            Death();
    }

    public void RecibirDano(float damage)
    {
        Health -= damage;
    }

    public void Death()
    {
        gameObject.SetActive(false);
    }
}
