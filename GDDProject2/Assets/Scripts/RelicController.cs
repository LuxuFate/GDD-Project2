using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Tooltip("max Health of the relic")]
    private float m_MaxHealth;

    private float c_Health;
    void Awake()
    {
        c_Health = m_MaxHealth;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (c_Health <= 0) {
            if (coll.CompareTag("Enemy")){
                GameObject gm = GameObject.FindWithTag("GameController");
                gm.GetComponent<GameManager>().LoseGame();
            } 
        }
    }
    
}
