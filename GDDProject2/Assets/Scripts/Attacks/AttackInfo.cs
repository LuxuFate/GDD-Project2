using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfo
{
    // Start is called before the first frame update
    [SerializeField]
    [Tooltip("Duration of the attack")]
    private float m_Duration;
    [SerializeField]
    [Tooltip("cooldown of the attack")]
    private float m_Cooldown;
    [SerializeField]
    [Tooltip("damage of the attack")]
    private int damage;

    public float Duration {
        get {
            return m_Duration;
        }
    }

    public float Cooldown {
        get {
            return m_Cooldown;
        }
    }
}
