using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    #endregion

    #region Physics Components
    Rigidbody2D EnemyRB;
    #endregion

	#region Targeting_variables
    public Transform relic;
    #endregion

    #region Attack_variables
    public float Damage;
    #endregion

    #region Unity_functions
    private void Awake(){
    	EnemyRB = GetComponent<Rigidbody2D>();
    }
    private void Update(){
    	if(relic == null) {
    		return;
    	}
    	Move();
    }
    #endregion

    #region Movement_functions
    private void Move() {
    	Vector2 direction = relic.position - transform.position;
    	EnemyRB.velocity = direction.normalized * movespeed;
    }
    #endregion

    // #region Attack_function
    // private void OnCollisionEnter2D(Collision2D collision){
    // 	if (collision.transform.CompareTag("Player")) {
    // 		collision.transform.GetComponent<PlayerController>().TakeDamage(Damage);
    // 	} else if (collision.transform.CompareTag("Relic")) {
    // 		GameObject gm = GameObject.FindWithTag("GameController");
    //     	gm.GetComponent<GameManager>().LoseGame();
    // 	}
    // 	Die();
    // }
    // #endregion

    private void Die(){
        Destroy(this.gameObject);
    }
}
