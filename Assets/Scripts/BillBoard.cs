using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    //hp바를 항상 카메라쪽으로 보이게 끔 할 계획
    public Transform target;

    void Update()
    {
        transform.forward = target.forward;    
    }
}
