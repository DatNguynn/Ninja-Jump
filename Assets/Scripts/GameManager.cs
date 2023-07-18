using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    public Text gameOverText;
    public Button restartButton;
    public GameObject gameOverScreen;
    
    private PlayerMovement player;
    private Spawner spawner;
    private SpawnerCoins coins;

    private float score;
    private float coin;

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    private void OnDestroy()
    {
        if(Instance == this)
            Instance = null;
    } 

    private void Start()
    {
        
        player = FindObjectOfType<PlayerMovement>();
        spawner = FindObjectOfType<Spawner>();
        coins = FindObjectOfType<SpawnerCoins>();

        NewGame();
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        coins.gameObject.SetActive(true);

        /*gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);*/
        gameOverScreen.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        coins.gameObject.SetActive(false);

        /*gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);*/
        gameOverScreen.gameObject.SetActive(true);

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
