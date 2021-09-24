using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerAttackInfo
{
    // Start is called before the first frame update    #region Editor Variables
    [SerializeField]
    [Tooltip("A name for thsi attack")]
    private string m_name;
    public string AttackName
    {
        get
        {
            return m_name;
        }
    }

    [SerializeField]
    [Tooltip("The button to press that will use this attack, This button must be in input settings")]
    private string m_Button;
    public string Button
    {
        get{
            return m_Button;
        }
    }

    [SerializeField]
    [Tooltip("The trigger string to use to activate this attack in the animator")]
    private string m_TriggerName;
    public string TriggerName
    {
        get
        {
            return m_TriggerName;
        }
    }

    [SerializeField]
    [Tooltip("The prefab of the game object representing the ability")]
    private GameObject m_AbilityGO;
    public GameObject AbilityGO
    {
        get
        {
            return m_AbilityGO;
        }
    }

    [SerializeField]
    [Tooltip("Where to spawn the ability game object with respect to the player")]
    private Vector3 m_Offset;
    public Vector3 Offset
    {
        get
        {
            return m_Offset;
        }
    }



    [SerializeField]
    [Tooltip("How long to wait before the player can use this ability again")]
    private float m_Cooldown;


    [SerializeField]
    [Tooltip("The duration of the ability")]

    private float m_Duration;



    public float Cooldown 
    {
        get;
        set;
    }

    public float Duration
    {
        get;
        set;
    }

    public void ResetCooldown() 
    {
        Cooldown = m_Cooldown;
    }

    public bool isReady() {
        return Cooldown <= 0;
    }

    public bool ended() {
        return Duration <= 0;
    }

    public void ResetDuration() {
        Duration = m_Duration;
    }
}
