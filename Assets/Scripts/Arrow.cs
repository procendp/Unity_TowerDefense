using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Wall")
        {
            Destroy(gameObject, 1);
        }
    }
}
