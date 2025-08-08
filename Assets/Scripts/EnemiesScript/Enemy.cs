using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Health;
    public float towerDamage = 20;
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
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destino"))
        {
            MainTower mainTower = collision.gameObject.GetComponent<MainTower>();
            mainTower.Health -= towerDamage;

            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
