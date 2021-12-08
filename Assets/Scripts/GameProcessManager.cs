using System.Collections;
using UnityEngine;

public class GameProcessManager : MonoBehaviour
{

    public static bool GameIsOver;
    public static bool GameIsWin;

    public GameObject gameOverUI;
    public GameObject gameWinnerUI;

    EnemyFactory ef = new EnemyFactory();
    Timer tm = new Timer();

    void Start()
    {
        GameIsOver = false;
        GameIsWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver) return;
        if (GameIsWin) return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (GameStats.Lives <= 0)
        {
            EndGame();
        }

        if (tm.timeCount == 1 && GameStats.Lives > 0)
        {
            WinGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        //Debug.Log("Game Over!");

        gameOverUI.SetActive(true);
    }

    void WinGame()
    {
        GameIsWin = true;
        gameWinnerUI.SetActive(true);
    }

    //void WinGame(Transform _bossNum)
    //{
    //    EnemyFactory ef = _bossNum.GetComponent<EnemyFactory>();

    //    GameIsOver = true;
    //    gameOverUI.SetActive(true);
    //}

    // void Damage(Transform enemy)
    // {
    //     EnemyFSM e = enemy.GetComponent<EnemyFSM>();

    //     if (e != null)
    //     {
    //         e.HitEnemy(bulletPower);
    //     }
    // }
}
