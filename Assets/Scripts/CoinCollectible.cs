using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

        }
    }
}
