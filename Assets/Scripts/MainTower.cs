using UnityEngine;

public class MainTower : MonoBehaviour
{

    public float Health = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
            Lose();
    }

    public void Lose()
    {
        GameManager.Instance.canSpawn = false;
        GameManager.Instance.SetGameState(GameManager.GameState.EndGame);    
    }
}
