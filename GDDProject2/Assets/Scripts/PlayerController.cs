using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    float x_input;
    float y_input;
    #endregion

    #region Physics_components
    Rigidbody2D PlayerRB;
    #endregion

    #region Attack_variables
    public float Damage;
    public float attackspeed = 1;
    float attackTimer;
    Vector2 currDirection;
    #endregion

    #region Health_variables
    public float maxHealth;
    float currHealth;
    #endregion

	#region Unity_functions
    private void Awake(){
        PlayerRB = GetComponent<Rigidbody2D>();
        attackTimer = 0;
        currHealth = maxHealth;
    }
    private void Update(){
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        Move();
    }
    #endregion

    #region Movement_functions
    private void Move(){
        //WASD to Move Around
        if (x_input > 0){
            PlayerRB.velocity = Vector2.right * movespeed;
            currDirection = Vector2.right;
        } else if (x_input < 0){
            PlayerRB.velocity = Vector2.left * movespeed;
            currDirection = Vector2.left;
        }else if (y_input > 0){
            PlayerRB.velocity = Vector2.up * movespeed;
            currDirection = Vector2.up;
        } else if (y_input < 0){
            PlayerRB.velocity = Vector2.down * movespeed;
            currDirection = Vector2.down;
        } else {
            PlayerRB.velocity = Vector2.zero;
        }
    }
    #endregion

    #region Attack_functions
    private void Attack(){
        attackTimer = attackspeed;
        //StartCoroutine(AttackRoutine());
    }

    //IEnumerator AttackRoutine(){
        //Arrows keys to shoot
    //}

    #endregion

    #region Health_functions
    public void TakeDamage(float value){
        currHealth -= value;
        if (currHealth <= 0) {
            Die();
        }
    }

    private void Die(){
        Destroy(this.gameObject);
        GameObject gm = GameObject.FindWithTag("GameController");
        gm.GetComponent<GameManager>().LoseGame();
    }
    #endregion

}