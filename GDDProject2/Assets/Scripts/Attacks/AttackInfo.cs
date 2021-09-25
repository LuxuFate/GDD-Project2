using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackInfo : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Damage")]
    private float m_Damage;
    public float Damage {
        get {
            return m_Damage;
        }
    }
    [SerializeField]
    [Tooltip("duration of the fire")]
    private float m_fireDuration;
    
    public float FireDuration {
        get {
            return m_fireDuration;
        }
    }
    [SerializeField]
    [Tooltip("fire to spawn")]
    protected GameObject fire;

    public abstract void Use(Vector3 spawnPos);
}
