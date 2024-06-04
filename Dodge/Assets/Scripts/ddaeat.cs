using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // GameManager의 인스턴스를 찾아 CollectCoin 메서드 호출
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.CollectCoin();
            }
            // 동전 오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
