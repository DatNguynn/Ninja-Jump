using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)] 
        public float spawnChance;
    }

    public SpawnableObject[] objects;

    public float SpawnRate = 5f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), SpawnRate, SpawnRate); 
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        float spawnChance = Random.value;

        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }
            spawnChance -= obj.spawnChance;
        }
        /*InvokeRepeating(nameof(Spawn), SpawnRate, SpawnRate);*/
    }
}
