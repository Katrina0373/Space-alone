using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public string sceneToLoad = "level1";


	public void LoadScene (string sceneToLoad)
	{
		SceneManager.LoadScene(sceneToLoad);
	}

	public void ExitPressed()
    {
		Application.Quit();
		Debug.Log("Exit");
    }
}
