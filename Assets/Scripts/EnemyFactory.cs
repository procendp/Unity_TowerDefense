using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject EFactory1;    //에너미 생성소

    public GameObject BossFactory;  //보스 생성소

    public int skeletonNum;
    public int bossNum;
    private int skeletonMaxNum;
    private int bossMaxNum;

    int delayTime = 0;
    public int summonTime;

    Transform enemy;

    enum Stage
    {
        None,
        Stage1,
        BossStage
    }

    Stage stage;

    void Start()
    {
        stage = Stage.None;
        skeletonMaxNum = skeletonNum;
        bossMaxNum = bossNum;
    }

    void StartStage1()
    {
        if (skeletonNum <= 0)
        {
            stage = Stage.None;
            delayTime = 0;
            return;
        }

        delayTime++;
        
        if (delayTime > summonTime)
        {
            delayTime = 0;
            skeletonNum -= 1;
            GameObject skeleton = Instantiate(EFactory1);
            skeleton.transform.position = transform.position;
        }
    }

    void StartBoss()
    {
        if (bossNum <= 0)
        {
            stage = Stage.None;
            delayTime = 0;
            return;
        }

        delayTime++;
        
        if (delayTime > summonTime)
        {
            delayTime = 0;
            bossNum -= 1;
            GameObject boss = Instantiate(BossFactory);
            boss.transform.position = transform.position;
        }
    }

    void Update()
    {
        if (GameManager.gm.gState == GameManager.GameState.RoundOne)
        {
            stage = Stage.Stage1;
            
            if (GameManager.gm.enemyCount == skeletonMaxNum)
            {
                stage = Stage.None;
                delayTime = 0;
                GameManager.gm.gState = GameManager.GameState.Ready;
                GameManager.gm.roundCount = 1;
            }
        }

        if (GameManager.gm.gState == GameManager.GameState.RoundTwo)
        {
            stage = Stage.BossStage;
        }

        
        switch (stage)
        {
            case Stage.None:

            break;
            
            case Stage.Stage1:
                StartStage1();
            break;

            case Stage.BossStage:
                StartBoss();
            break;
        }
    }
}
