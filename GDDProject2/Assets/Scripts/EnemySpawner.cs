using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The bounds of the spawner")]
    private Vector3 m_bounds;
    [SerializeField]
    [Tooltip("Maximum Bounds")]
    private Vector3 m_MaxBounds;

    [SerializeField]
    [Tooltip("A list of all enemies that can be spawned and their information")]
    private EnemySpawnInfo[] m_Enemies;
    #endregion

    #region private Variables
    public int m_NumberKilled;
    #endregion

    #region Cached Foreign
    private GameObject cr_GM;
    #endregion

    #region Initialization
    private void Awake() {
        cr_GM = GameObject.FindGameObjectWithTag("GameController");
        StartSpawning();
    }
    #endregion

    #region Spawn Methods
    public void StartSpawning() {
        for (int i = 0; i < m_Enemies.Length;  i+= 1)
        {
            StartCoroutine(Spawn(i));
        }
    }
    private IEnumerator Spawn(int enemyID)
    {
            if (m_NumberKilled >= 50) {
                cr_GM.GetComponent<GameManager>().WinGame();
            }
            EnemySpawnInfo info = m_Enemies[enemyID];
            int i = 0;
            bool alwaysSpawn = false;
            if (info.NumberToSpawn == 0)
            {
                alwaysSpawn = true;
            }
            while (alwaysSpawn || i < info.NumberToSpawn)
            {
                yield return new WaitForSeconds(info.TimeToNextSpawn);
                float xVal = m_bounds.x / 2;
                float yVal = m_bounds.y / 2;
                float xVal1 = m_MaxBounds.x / 2;
                float yVal1 = m_MaxBounds.y / 2;
                float k = 0;
                float z = 0;
                if (Random.Range(0, 10) > 5) {
                    k = Random.Range(xVal, xVal1);
                } else {
                    k = Random.Range(-xVal, -xVal1);
                }
                if (Random.Range(0, 10) > 5) {
                    z = Random.Range(yVal, yVal1);
                } else {
                    z = Random.Range(-yVal, -yVal1);
                }
                Vector3 spawnPos = new Vector3(
                    k,
                    z,
                    0
                );

                spawnPos += transform.position;
                Instantiate(info.EnemyGO, spawnPos, Quaternion.identity);

                if (!alwaysSpawn)
                {
                    i++;
                }
            }
    }

    public void kills() {
        m_NumberKilled += 1;
    }
    #endregion
}
