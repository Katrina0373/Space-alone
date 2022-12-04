using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public void LoadScene (string sceneToLoad)
	{
		SceneManager.LoadScene(sceneToLoad);
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
}
