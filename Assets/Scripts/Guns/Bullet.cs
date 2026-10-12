using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float Timer;
    public float TimeLimit;

    private void OnEnable() 
    {
        Timer = 0;
        Aim();
    }

    private void OnDisable()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        //if (!other.transform.CompareTag("Player") || !other.transform.CompareTag("Bullet"))
        if(other.CompareTag("Player") || other.CompareTag("Bullet"))
        {
            return;
        }

        if(!other.CompareTag("Player") || !other.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Rubble") || other.CompareTag("Enemy"))
        {
            other.attachedRigidbody.AddExplosionForce(450f, this.transform.position, 50f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Player") || !collision.transform.CompareTag("Bullet"))
        {
            Debug.Log($"BULLETONCOLLISION {collision.transform.name}");
            gameObject.SetActive(false);
        }
    }

    public void Aim() 
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        Vector3 target = Physics.Raycast(ray, out RaycastHit hit, 1000f)
            ? hit.point
            : ray.GetPoint(1000f);

        transform.LookAt(target);
    }

    void DeactivateTimer() 
    {
        Timer += Time.deltaTime;

        if(Timer >= TimeLimit)
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);   
        DeactivateTimer();
    }
}
