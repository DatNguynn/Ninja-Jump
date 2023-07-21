using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject homeScreen;
    public GameObject levelScreen;

    private void Awake()
    {
        homeScreen.SetActive(true);
        levelScreen.SetActive(false);
    }

    public void StartGame()
    {
        homeScreen.SetActive(false);
        levelScreen.SetActive(true);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
}
