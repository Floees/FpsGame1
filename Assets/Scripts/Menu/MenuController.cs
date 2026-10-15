using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameState State;
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        State = GameState.Waiting;

    }

    public void ToggleSettigns()
    {
        SettingsPanel.SetActive(!SettingsPanel.activeInHierarchy);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
