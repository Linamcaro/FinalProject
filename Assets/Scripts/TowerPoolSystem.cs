using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPoolSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> towerPrefabs;
    [SerializeField] private float spawnTime;
    [SerializeField] private int maxQueueSize;

    private Queue<GameObject> towerQueue = new Queue<GameObject>();
    private Queue<Sprite> towerImagesQueue = new Queue<Sprite>();

    [SerializeField] GameObject towersPanel;
    [SerializeField] Sprite[] towersImages;
    [SerializeField] Image[] towerSlots;

    private void Start()
    {
        StartCoroutine(GenerateTowerQueue());
    }

    private IEnumerator GenerateTowerQueue()
    {
        while (true)
        {
            if (GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
            {
                if (towerQueue.Count < maxQueueSize)
                {
                    int randomIndex = Random.Range(0, towerPrefabs.Count);

                    towerQueue.Enqueue(towerPrefabs[randomIndex]);
                    towerImagesQueue.Enqueue(towersImages[randomIndex]);

                    UpdateQueueUI();
                }

                yield return new WaitForSeconds(spawnTime);
            }

            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.EndGame || GameManager.Instance.CurrentGameState == GameManager.GameState.WinGame)
        {
            StopAllCoroutines();
        }

        if (GameManager.Instance.CurrentGameState == GameManager.GameState.Playing) towersPanel.SetActive(true);
        else towersPanel.SetActive(false);
    }

    public GameObject GetNextTower()
    {
        if (towerQueue.Count > 0)
        {
            towerImagesQueue.Dequeue();

            return towerQueue.Dequeue();
        }

        return null;
    }

    public void UpdateQueueUI()
    {
        Sprite[] imagesArray = towerImagesQueue.ToArray();

        for (int i = 0; i < towerSlots.Length; i++)
        {
            if (i < imagesArray.Length)
            {
                towerSlots[i].sprite = imagesArray[i];
                towerSlots[i].enabled = true;
                towerSlots[i].gameObject.SetActive(true);
            }
            else
            {
                towerSlots[i].enabled = false;
                towerSlots[i].gameObject.SetActive(false);
            }
        }
    }
}