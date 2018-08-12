using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public virtual void NextScene()
    {
        SceneManager.LoadScene("IntroCutScene");
    }
}