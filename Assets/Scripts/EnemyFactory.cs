using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject EFactory1;    //에너미 생성소

    public GameObject BossFactory;  //보스 생성소

    public int skeletonNum;
    public int bossNum;

    int delayTime = 0;
    public int summonTime;

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
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stage = Stage.Stage1;
        }

        switch (stage)
        {
            case Stage.None:

            break;
            
            case Stage.Stage1:
                StartStage1();
            break;

            case Stage.BossStage:

            break;
        }
    }
}
