using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    SphereCollider sphereCollider;
    GameObject enemy;
    Status status;
    // Start is called before the first frame update
    void Start()
    {
        enemy=transform.root.gameObject;
        status=enemy.GetComponent<Status>();
    }

    void OnTriggerEnter(Collider col){
        if(col.tag=="clystal"){
            col.GetComponentInParent<Status>().Damage(status.power);
        }
    }

}
