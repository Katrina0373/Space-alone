using UnityEngine.UI;
using UnityEngine;

public class pause_menu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject DeathScreenUI;
    public GameObject SuccessScreenUI;
    public Sprite on;
    public Sprite off;
    public Button sound;
    private bool isPlaying = true;
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

    public void SoundChange()
    {
        if (isPlaying)
        {
            isPlaying = false;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
            sound.GetComponent<Image>().sprite = off;
        }
        else
        {
            isPlaying = true;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
            sound.GetComponent<Image>().sprite = on;
        }
    }
}
