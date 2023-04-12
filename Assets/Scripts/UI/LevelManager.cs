using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
	public void LoadScene (int sceneToLoad)
	{
		
		SceneManager.LoadScene(sceneToLoad);
	}

	public void LoadMenu()
    {
		SceneManager.LoadScene("MainMenu");
    }

	public void RestartScene()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	public void ExitPressed()
    {
		Application.Quit();
		Debug.Log("Exit");
    }

	public void NextLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
