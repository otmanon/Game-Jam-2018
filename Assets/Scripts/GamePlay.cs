using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : UnityEngine.MonoBehaviour
{
	public StartButton()
	{
	}

	public virtual void NextScene()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
