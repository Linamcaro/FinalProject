using UnityEngine;
using UnityEngine.AI;
public class MovimientoEnemigo : MonoBehaviour

{
    public GameObject puntoDestino; 

    private NavMeshAgent agente;

    void Start()
    {
        puntoDestino = GameObject.Find("Destino");
        agente = GetComponent<NavMeshAgent>();
        agente.SetDestination(puntoDestino.transform.position);
    }
}

