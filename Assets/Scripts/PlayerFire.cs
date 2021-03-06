using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private Camera camera;
    private Animator anim;

    public GameObject firePosition;
    public GameObject arrowFactory;
    public float throwPower;
    public int arrowPower = 1;

    private void Awake() 
    {
        camera = Camera.main;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameManager.gm.gState == GameManager.GameState.Ready) return;

            anim.SetTrigger("doShot");

            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                var dir = hit.point - transform.position;
                anim.transform.forward = dir;

                GameObject arrow = Instantiate(arrowFactory);
                arrow.transform.position = firePosition.transform.position;
                arrow.transform.forward = dir;

                Rigidbody rb = arrow.GetComponent<Rigidbody>();
                rb.AddForce(anim.transform.forward * throwPower, ForceMode.Impulse);
            }
        }
    }
}
