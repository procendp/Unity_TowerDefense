using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 50f;
    public GameObject impactEffect;

    public int bulletPower = 1;
    //인게임에서 탑3은 공격력 3

    //public int moneyGain = 50;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
                //이동.. 얼마나 이동할 지의 벡터, 어느 축을 기준으로 할 것인가
                //Space.Self => 내 축이 기준
                //Space.World => 월드 좌표 기준
    }

    void HitTarget()
    {
        //Debug.Log("WE HIT SOMETHING!!!");
        GameObject effectInstantiate = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstantiate, 2f);
        //Destroy(target.gameObject); //적 죽음

        Damage(target);
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        EnemyFSM e = enemy.GetComponent<EnemyFSM>();

        if (e != null)
        {
            e.HitEnemy(bulletPower);
        }
    }
}
