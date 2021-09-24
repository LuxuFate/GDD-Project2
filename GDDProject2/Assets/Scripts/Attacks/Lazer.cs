using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : AttackInfo
{
    // Start is called before the first frame update
    void Update() {
        Use(transform.position);
    }
    public override void Use(Vector3 spawnPos) {
        RaycastHit[] hits = Physics.SphereCastAll(spawnPos, 1f, Input.mousePosition - transform.position, (Input.mousePosition - transform.position).magnitude);
        foreach(RaycastHit n in hits) {
            if (n.collider.CompareTag("Enemy")) {
                n.collider.GetComponent<EnemyController>().DecreaseHealth(Damage);
            }
        }
    }
}
