using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    public void RestartButton()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
