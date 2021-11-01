using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]  //유니티 인스펙터 창에서 이쁘게 정리하자

    public float range = 3f;   //포 공격 범위

    public float fireRate = 1f; //발사 속도
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform PartToRotate;
    public float turnSpeed = 10f;   //포 돌리는 모션 속도

    public GameObject bulletPrefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;    //rayCast 시에 길이 제한 없이 하기 위함
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else target = null; 
        //이렇게 해야 에너미가 range 안 일 때만 인식하고 이후엔 none 처리
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = lookRotation.eulerAngles;
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //Quaternion.Lerp => 두 개의 회전 값 정하고 float 비율 만큼 적당하게 회전하게끔 
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);  //적 따라 y축만 로테이트

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        //Debug.Log("SHOOT!!!!");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);   //포 범위 색 정해준 것 뿐
    }
}
