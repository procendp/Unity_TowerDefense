using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject readyUI;
    public GameObject roundOneUI;
    [SerializeField] Timer ReadyTimer;

    public int ReadyTime;

    private int roundCount = 0;

    private bool isRound = false;

    private void Awake() 
    {
        if (gm == null) gm = this;
    }

    public enum GameState
    {
        Ready,
        RoundOne,
        RoundTwo,
        GameOver,
        Win
    }

    public GameState gState;

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Ready;
    }

    void Ready()
    {
        if (!readyUI.activeSelf)
        {
            readyUI.SetActive(true);
            ReadyTimer.SetDuration(ReadyTime).Begin();
            StartCoroutine(TimeEndToRound());
        }
    }

    private IEnumerator TimeEndToRound()
    {
        yield return new WaitForSeconds(ReadyTime + 1f);

        readyUI.SetActive(false);

        if (roundCount == 0)
        {
            gState = GameState.RoundOne;
            yield break;
        }

        else if (roundCount == 1)
        {
            gState = GameState.RoundTwo;
            yield break;
        }
    }

    void RoundOne()
    {
        if (!roundOneUI.activeSelf && !isRound)
        {
            roundOneUI.SetActive(true);
            StartCoroutine(UIEnd());
            isRound = true;
        }
    }

    private IEnumerator UIEnd()
    {
        yield return new WaitForSeconds(4f);

        roundOneUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (gState)
        {
            case GameState.Ready:
            Ready();
            break;

            case GameState.RoundOne:
            RoundOne();
            break;

            case GameState.RoundTwo:
            break;

            case GameState.GameOver:
            break;

            case GameState.Win:
            break;
        }
    }
}
