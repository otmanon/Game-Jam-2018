using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("IntroCutScene");
    }
}