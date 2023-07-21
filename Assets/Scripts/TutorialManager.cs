using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpsIndex;
    public GameObject spawnerGround;
    public GameObject spawnerWall;
    public GameObject spawnerCoins;

    private void Start()
    {
        spawnerGround.SetActive(false);
        spawnerWall.SetActive(false);
        spawnerCoins.SetActive(false);
    }

    private void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpsIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpsIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                popUpsIndex++;
            }
        }
        else if (popUpsIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                popUpsIndex++;
            }
        }
        else if (popUpsIndex == 2)
        {
            spawnerGround.SetActive(true);
            spawnerWall.SetActive(true);
            spawnerCoins.SetActive(true);
        }
    }
}
