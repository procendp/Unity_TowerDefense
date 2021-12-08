using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform dPoint;   //도착지점

    Transform player;

    public int moneyGain = 50;

    enum EnemyState
    {
        Idle,
        Move,
        Die
    }

    EnemyState eState;

    public int maxHP;
    public int currentHP;

    CharacterController cc;

    public Slider hpSlider;


    Animator anim;
    
    private void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();    

        player = GameObject.Find("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        eState = EnemyState.Idle;

        cc = GetComponent<CharacterController>();

        anim = transform.GetComponentInChildren<Animator>();
    }

    void Idle()
    {
        if(Vector3.Distance(transform.position, dPoint.position) > 0.1f)
        {
            eState = EnemyState.Move;

            anim.SetTrigger("IdleToMove");
        }
    }

    void Move()
    {
        agent.SetDestination(dPoint.position);
    }

    //에너미 체력 빠지는 곳
    public void HitEnemy(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0) 
        {
            eState = EnemyState.Die;
            Die();
            GameStats.Money += moneyGain;
        }
    }

    void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;
        agent.enabled = false;
        anim.SetTrigger("MoveToIdle");

        yield return new WaitForSeconds(0);  //죽고 사라지는 속도

        Destroy(gameObject);
        
        GameManager.gm.enemyCount++;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("DPoint"))
        {
            Destroy(gameObject);
            GameManager.gm.enemyCount++;
            //도착하는대로 라이브즈 깎이게 장치해두자
            GameStats.Lives--;
            //EndPath();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Arrow"))
        {
            int ArrowDamage = player.GetComponent<PlayerFire>().arrowPower;
            HitEnemy(ArrowDamage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameProcessManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        hpSlider.value = (float)currentHP / (float)maxHP;   // 15/15

        switch (eState)
        {
            case EnemyState.Idle:
                Idle();
            break;
            case EnemyState.Move:
                Move();
            break;
            case EnemyState.Die:
            
            break;
        }
    }
}
