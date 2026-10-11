using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    public Transform BulletPoint;
    public GameObject BulletPrefab;
    public List<GameObject> Bullets;

    public bool TestShoot;
    public float FireCooldown = 0.2f;
    private float NextFireTime;

    private void Awake() 
    {
        PopulateBullets();
        gameObject.SetActive(false);
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
        if (!isActiveAndEnabled || Time.time < NextFireTime)
            return;

        else NextFireTime = Time.time + FireCooldown;

        foreach (GameObject Bullet in Bullets) 
        {
            if (!Bullet.activeInHierarchy) 
            {
                Bullet.transform.position = BulletPoint.position;
                Bullet.SetActive(true);
                break;
            }
        }

    }
}
