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

    [SerializeField]
    [Tooltip("Max Health")]
    private float m_MaxHealth;

    #region Private Variables
    private float c_Health;
    #endregion

    #region Unity_functions
    private void Awake(){
    	EnemyRB = GetComponent<Rigidbody2D>();
        c_Health = m_MaxHealth;
        relic = GameObject.FindGameObjectsWithTag("Relic")[0].transform;
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

    #region Health methods
    public void DecreaseHealth(float amount) {
        c_Health -= amount;
        Debug.Log("Decreasing health");
        if (c_Health <= 0) {
            Die();
            // play animations?
        }
    }

    #endregion

    private void Die(){
        Destroy(this.gameObject);
    }
}
