using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame:MonoBehaviour
{
    public virtual void Next_Scene()
    {
        SceneManager.LoadScene("IntroCutScene");
    }
}