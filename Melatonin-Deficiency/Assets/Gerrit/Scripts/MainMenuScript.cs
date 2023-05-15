using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void GoToScene(string stringName)
    {
        SceneManager.LoadScene(stringName);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
