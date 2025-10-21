using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Main Game Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToSettingsMenu()
    {
        print("load settings");
        SceneManager.LoadScene("ControlsScreen");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}
