using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    private void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            popUps[popUpIndex].SetActive(false);
        }
    }
}
