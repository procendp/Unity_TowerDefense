using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinner : MonoBehaviour
{
    public void Retry ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(2);
    }
    public void Menu ()
    {
        //Debug.Log("Go to menu");
        SceneManager.LoadScene(0);
    }
}
