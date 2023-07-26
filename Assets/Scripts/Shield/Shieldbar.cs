using UnityEngine;
using UnityEngine.UI;

public class Shieldbar : MonoBehaviour
{
    public Health playerHealth;
    public Image totalShieldbar;
    public Image currentShieldbar;

    private void Start()
    {
        totalShieldbar.fillAmount = 0;
    }

    private void Update()
    {
        currentShieldbar.fillAmount = (playerHealth.currentHealth - 1) / 10;
    }
}
