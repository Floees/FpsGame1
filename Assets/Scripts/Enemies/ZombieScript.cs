using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieScript : MonoBehaviour
{
    public Transform Player;
    public float MoveSpeed;
    public GameManager GM; //need find component

    private void Update()
    {
        if (Player == null)
            return;

        Move();
        Look();
    }

    void Move()
    {
        Vector3 targetPos = Player.position;
        targetPos.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, MoveSpeed * Time.deltaTime);
    }

    void Look()
    {
        Vector3 direction = Player.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.0001f)
            transform.rotation = Quaternion.LookRotation(direction);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        else if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamage(5);

            if(other.GetComponent<Health>().CurrentHealth <= 0) 
            {
                GM.GameOver();
            }
        }
    }
}
