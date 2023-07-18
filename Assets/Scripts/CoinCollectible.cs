using UnityEngine;

public class CollectibleCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.IncreaseCoin();
            gameObject.SetActive(false);
        }
    }
}
