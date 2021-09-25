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

    public ParticleSystem cc_PS;

    public abstract void Use(Vector3 spawnPos);
}
