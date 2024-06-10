using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;  // 동전 프리팹
    public int numberOfCoins = 10;  // 생성할 동전의 개수
    public Vector3 spawnAreaMin;  // 생성 영역의 최소 좌표
    public Vector3 spawnAreaMax;  // 생성 영역의 최대 좌표
    public float spawnInterval = 1.0f;  // 동전 생성 간격

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.SetTotalCoins(numberOfCoins);
        }
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            Instantiate(coinPrefab, randomPosition, Quaternion.identity);
            
            // spawnInterval 초 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}