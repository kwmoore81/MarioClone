using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;
    private AudioSource audioSource;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    public Transform spawnPrefab;

    public IEnumerator RespawnPlayer()
    {
        audioSource.Play();
        yield return new WaitForSeconds(spawnDelay); 
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        GameObject clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Destroy(clone, 5f);

    }

	public static void KillPlayer (PlayerScript player)
    {
        Destroy (player.gameObject);
        gm.StartCoroutine (gm.RespawnPlayer());
    }
}
