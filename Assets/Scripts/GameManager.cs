using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform Player;
    public void GameOver() 
    {
        //call ui make u dieded prompt blahblah

        SceneManager.LoadScene("MenuScreen");
        SceneManager.UnloadSceneAsync("GameScene");
    }

}
public enum GameState
{
    Waiting, Running
}
