using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class FpsPlayer : MonoBehaviour
{
    public float MouseSens, pitch, yaw, MoveSpeed;
    public Transform View;
    public Weapon CurrentWeapon = Weapon.None; //overwritten by inspector
    public BulletGun BG;
    public float JumpHeight = 1.5f;
    public LaserGun LG;
    public Rigidbody RB;
    public bool TouchingGround;
    public float GroundedHeight;
    public GameObject InventoryPanel;
    public bool LaserGunPickedUp, BulletGunPickedUp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    void Controls() 
    {
        Look();
        Shoot();
        //Move2();
        //Jump();
       //ToggleInventory();
        ToggleWeapon();
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
                BG.Shoot();
            if (CurrentWeapon == Weapon.LaserGun)
                LG.Fire();
            else
                return;
        }
    }

    void ToggleWeapon() 
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            if(!BulletGunPickedUp && !LaserGunPickedUp)
                return;

            if(BulletGunPickedUp && LaserGunPickedUp)
            {
                if(CurrentWeapon == Weapon.BulletGun)
                {
                    CurrentWeapon = Weapon.LaserGun;
                    return;
                }
                if(CurrentWeapon == Weapon.LaserGun)
                {
                    CurrentWeapon = Weapon.BulletGun;
                    return;
                }
            }
            EquipWeapon();

        }
    }

    public void EquipWeapon()
    {
        if(CurrentWeapon == Weapon.BulletGun)
        {
            BG.gameObject.SetActive(true);
            LG.gameObject.SetActive(false);
        }
        if (CurrentWeapon == Weapon.LaserGun)
        {
            LG.gameObject.SetActive(true);
            BG.gameObject.SetActive(false);
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

    void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        if (RB.linearVelocity.y > 0.1f || RB.linearVelocity.y < -0.1f)
            return;
        
        Vector3 velocity = RB.linearVelocity;
        velocity.y = Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y) * JumpHeight);
        RB.linearVelocity = velocity;
        
    }

    void ToggleInventory() 
    {
        if(Input.GetKeyDown(KeyCode.I))
            InventoryPanel.SetActive(!InventoryPanel.activeInHierarchy);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "Ground")
    //        TouchingGround = true;

    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if(collision.transform.tag == "Ground")
    //        TouchingGround = false;
    //}
}

public enum Weapon 
{
    BulletGun, LaserGun, None
}