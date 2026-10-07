using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    public Transform BulletPoint;
    public GameObject BulletPrefab;

    public List<GameObject> Bullets;

    public bool TestShoot;

    private void Awake() 
    {
        PopulateBullets();
    }

    void PopulateBullets() 
    {
        Bullets = new List<GameObject>();

        for (int i = 0; i < 100; i++) 
        {
            var t = Instantiate(BulletPrefab, BulletPoint.position, Quaternion.identity);
            Bullets.Add(t);
            t.SetActive(false);
        }
    }
    private void Update() 
    {
        if (TestShoot) 
        {   
            Shoot();
            TestShoot = false;
        }
    }
    public void Shoot() 
    {
        //var t = Instantiate(BulletPrefab, BulletPoint.position, Quaternion.identity);
        //t.GetComponent<Bullet>().Aim();
        //Debug.Log($"BANG");

        foreach (GameObject Bullet in Bullets) 
        {
            if (!Bullet.activeInHierarchy) 
            {
                Bullet.transform.position = BulletPoint.position;
                Bullet.SetActive(true);
                Debug.Log("BANGBANG");
                break;
            }
        }

    }
}
