using UnityEngine;
using UnityEngine.InputSystem;

public class FpsPlayer : MonoBehaviour
{
    public float MouseSens, pitch, yaw, MoveSpeed;
    public Transform View;
    public Weapon CurrentWeapon = Weapon.BulletGun;
    public BulletGun BG;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Shoot();
        Move2();
    }


    void Look() 
    {
        yaw += Input.GetAxis("Mouse X") * MouseSens; // hämta x
        pitch += Input.GetAxis("Mouse Y") * MouseSens; // hämta y
        pitch = Mathf.Clamp(pitch, -85, 85); // begränsa y
        View.localRotation = Quaternion.Euler(-pitch, yaw, 0f); //översätt till quaternion=?
    }

    void Shoot() 
    {
        if(Input.GetButton("Fire1")) 
        {
            if (CurrentWeapon == Weapon.BulletGun)
            {
                BG.Shoot();
            }
            else
            {

            }
        }
    }

    void Move() 
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 
            0f, Input.GetAxisRaw("Vertical"));

        input = Vector3.ClampMagnitude(input, 1f);
        Quaternion heading = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
        transform.position += heading * input * MoveSpeed * Time.deltaTime;
    }

    void Move2() 
    {
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) input.z += 1f;
        if (Input.GetKey(KeyCode.S)) input.z -= 1f;
        if (Input.GetKey(KeyCode.D)) input.x += 1f;
        if (Input.GetKey(KeyCode.A)) input.x -= 1f;

        input = Vector3.ClampMagnitude(input, 1f);
        Vector3 direction = Quaternion.Euler(0f, yaw, 0f) * input;
        transform.position += direction * MoveSpeed * Time.deltaTime;

    }
}

public enum Weapon 
{
    BulletGun, LaserGun
}