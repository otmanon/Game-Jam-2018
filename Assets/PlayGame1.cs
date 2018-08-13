using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame1 : MonoBehaviour
{
    public virtual void Next_Scene()
    {
        SceneManager.LoadScene("GamePlay");
    }
}