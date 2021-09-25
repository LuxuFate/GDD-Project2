using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPound : AttackInfo
{
    // Start is called before the first frame update
void Awake() {
        Use(transform.position);
    }
    public override void Use(Vector3 spawnPos) {
        // Vector3 n = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // n.z = 0;
        // RaycastHit2D[] hits = Physics2D.CircleCastAll(spawnPos, 0.1f, n, n.magnitude);
        // Debug.Log(hits.Length);
        // foreach(RaycastHit2D k in hits) {
        //     if (k.collider.CompareTag("Enemy")) {
        //         k.collider.GetComponent<EnemyController>().DecreaseHealth(Damage);
        //     }
        // }
        // StartCoroutine(spawnFire(n));
        Vector3 n = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        n.z = 0;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(spawnPos, 3f, Vector2.zero, 0);
        Debug.Log(hits.Length);
        foreach(RaycastHit2D k in hits) {
            if (k.collider.CompareTag("Enemy")) {
                k.collider.GetComponent<EnemyController>().DecreaseHealth(Damage);
            }
        }
    }
}
