using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMovement : MonoBehaviour
{
    private Camera camera;
    private Animator animator;

    private bool isMove;
    private Vector3 destination;

    private void Awake() 
    {
        camera = Camera.main;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameProcessManager.GameIsOver)  //게임오버면 플레이어 행동 멈춤
        {
            this.enabled = false;
            return;
        }

        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }

        Move();
    }

    private void SetDestination(Vector3 dest)
    {
        destination = new Vector3(dest.x, dest.y + 3, dest.z);
        isMove = true;
        animator.SetBool("isMove", true);
    }

    private void Move()
    {
        if (isMove)
        {
            var dir = destination - transform.position;
            animator.transform.forward = dir;
            transform.position += dir.normalized * Time.deltaTime * 6f;
        }

        if (Vector3.Distance(transform.position, destination) <= 0.1f)
        {
            isMove = false;
            animator.SetBool("isMove", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            isMove = false;
            animator.SetBool("isMove", false);
            animator.SetTrigger("ShotToIdle");
        }
    }
}
