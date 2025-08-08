using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float velocidad = 10f;
    private Transform objetivo;
    private float damage;

    public void Inicializar(Transform _objetivo, float _damage)
    {
        objetivo = _objetivo;
        damage = _damage;
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (objetivo == null)
        {
            gameObject.SetActive(false); // o volver al pool
            return;
        }

        Vector3 dir = objetivo.position - transform.position;
        transform.Translate(dir.normalized * velocidad * Time.deltaTime, Space.World);

        if (dir.magnitude < 0.2f)
        {
            objetivo.GetComponent<Enemy>()?.RecibirDano(damage);
            gameObject.SetActive(false); // volver al pool
        }
    }
}
