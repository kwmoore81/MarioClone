using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public float Health = 6;
    }

    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -20;

    void Update()
    {
        if (transform.position.y <= fallBoundary)
        {
            DamagePlayer(Mathf.Infinity);
        }
    }
    public void DamagePlayer (float damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <=0)
        {
            GameMaster.KillPlayer(this);
        }
    }
}
