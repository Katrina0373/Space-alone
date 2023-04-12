using UnityEngine.UI;
using UnityEngine;

public class pause_menu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject DeathScreenUI;
    public GameObject SuccessScreenUI;
    [SerializeField] GameObject text;

    // Update is called once per frame
    private void Start()
    {
        Resume();
        DeathScreenUI.SetActive(false);
        SuccessScreenUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
                Pause();
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void PlayerDeath(string reason)
    {
        Time.timeScale = 0f;
        DeathScreenUI.SetActive(true);
        text.GetComponent<Text>().text = reason;
    }

    public void Success()
    {
        Time.timeScale = 0f;
        SuccessScreenUI.SetActive(true);
    }
}
