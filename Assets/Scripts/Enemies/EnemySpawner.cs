using System.Collections;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameManager GM;
    public GameState State;
    public GameObject ZombiePrefab;
    public Transform[] SpawnPoints;
    public TextMeshProUGUI CountdownText;
    public float SpawnDelay;

    private void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    public void SpawnZombie()
    {
        int rand = Random.Range(0, SpawnPoints.Length);
        Transform t = SpawnPoints[rand];
        GameObject g = Instantiate(ZombiePrefab, t.position, Quaternion.identity);
        g.GetComponent<ZombieScript>().Player = GM.Player;
    }
    public IEnumerator SpawnZombies() 
    {
        CountdownText.text = "5";
        yield return new WaitForSeconds(1);
        CountdownText.text = "4";
        yield return new WaitForSeconds(1);
        CountdownText.text = "3";
        yield return new WaitForSeconds(1);
        CountdownText.text = "2";
        yield return new WaitForSeconds(1);
        CountdownText.text = "1";
        yield return new WaitForSeconds(1);
        CountdownText.text = "Burgertime";
        yield return new WaitForSeconds(1);
        CountdownText.gameObject.SetActive(false);
        State = GameState.Running;

        while (State == GameState.Running) 
        {
            SpawnZombie();
            yield return new WaitForSeconds(SpawnDelay);
        }
    }

}