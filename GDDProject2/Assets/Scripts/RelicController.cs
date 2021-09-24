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

    void OnCollisionEnter() {

    }
    
}
