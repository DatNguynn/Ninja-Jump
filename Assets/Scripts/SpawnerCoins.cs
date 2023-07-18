using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    public GameObject coin;
    public float spawnRate;
    public Vector3 Height;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject coins = Instantiate(coin, transform.position, Quaternion.identity);
        coins.transform.position += Height;
    }
}
