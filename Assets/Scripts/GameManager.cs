using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    public GameObject gameOverScreen;
    
/*    private PlayerMovement player;
    private Spawner spawner;
    private SpawnerCoins spawnerCoins;*/

    private float score;
    private float coin;

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;

        gameOverScreen.SetActive(false);
    }

    private void OnDestroy()
    {
        if(Instance == this)
            Instance = null;
    }

/*    private void Start()
    {

        player = FindObjectOfType<PlayerMovement>();
        spawner = FindObjectOfType<Spawner>();
        spawnerCoins = FindObjectOfType<SpawnerCoins>();

        NewGame();
    }*/

    public void NewGame()
    {
        /*Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        Coins[] coins = FindObjectsOfType<Coins>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        foreach (var coin in coins)
        {
            Destroy(coin.gameObject);
        }*/
        score = 0f;
        gameSpeed = initialGameSpeed;
        /*enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        spawnerCoins.gameObject.SetActive(true);

        gameOverScreen.gameObject.SetActive(false);*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        /*enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        spawnerCoins.gameObject.SetActive(false);*/

        gameOverScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;

    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
    }

    public void IncreaseCoin()
    {
        coin++;
    }
}
