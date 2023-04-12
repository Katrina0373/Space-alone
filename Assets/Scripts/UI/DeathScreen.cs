using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] GameObject text;
    

    public void PlayerDeath(string reason)
    {
        this.enabled = true;
        Time.timeScale = 0f;
        enabled = true;
        text.GetComponent<Text>().text = reason; 
    }
}
