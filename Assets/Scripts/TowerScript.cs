using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public TowersSC towersSC;
    public GameObject flechaPrefab;
    public Transform puntoDisparo;
    public float tiempoEntreDisparos;
    public float damage;
    public float rango;

    public float tiempoSiguienteDisparo;

    private void Start()
    {
        damage = towersSC.SCDamage;
        tiempoEntreDisparos = towersSC.SCShootingTime;
        rango = towersSC.SCRange;
    }

    void Update()
    {
        tiempoSiguienteDisparo -= Time.deltaTime;

        if (tiempoSiguienteDisparo <= 0)
        {
            GameObject objetivo = BuscarEnemigo();
            if (objetivo != null)
            {
                Disparar(objetivo.transform);
                tiempoSiguienteDisparo = tiempoEntreDisparos;
            }
        }
    }

    GameObject BuscarEnemigo()
    {

        Collider[] enemigos = Physics.OverlapSphere(transform.position, rango);
        foreach (var col in enemigos)
        {
            if (col.CompareTag("Enemy"))
                return col.gameObject;
        }
        return null;
    }


    void Disparar(Transform objetivo)
    {
        GameObject flecha = FlechaPool.Instance.ObtenerFlecha(); // ← si usas pooling
        flecha.transform.position = puntoDisparo.position;
        Vector3 direccion = (objetivo.position - puntoDisparo.position).normalized;
        Quaternion rotacion = Quaternion.LookRotation(direccion); // Alinea Z
        flecha.transform.rotation = rotacion * Quaternion.Euler(90, 0, 0); // Corrige para usar eje Y

        flecha.GetComponent<Flecha>().Inicializar(objetivo, damage);
    }



}
