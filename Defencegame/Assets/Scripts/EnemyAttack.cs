using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    SphereCollider sphereCollider;
    GameObject enemy;
    EnemyManage enemyManage;
    // Start is called before the first frame update
    void Start()
    {
        enemy=transform.root.gameObject;
        enemyManage=enemy.GetComponent<EnemyManage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
