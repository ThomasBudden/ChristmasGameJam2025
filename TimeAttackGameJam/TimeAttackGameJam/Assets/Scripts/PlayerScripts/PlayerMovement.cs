using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    Vector2 moveInput;

    [Header("Aiming")]
    [SerializeField] Camera mainCam;

    [Header("Shooting")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firingPoint;
    [SerializeField] Vector3 mousePos;
    public bool canShoot;
    private void Start()
    {
        EventManager.current.GameStart += onGameStart;
        EventManager.current.GameLoss += onGameLoss;
    }
    public void onGameStart()
    {
        this.transform.position = new Vector3(0, 0.5f, 0);
        canShoot = true;
    }
    public void onGameLoss()
    {
        this.transform.position = new Vector3(0, 0.5f, 0);
        canShoot = false;
    }


    private void Update()
    {
        HandleMovement();
        HandleAiming();
        HandleShooting();
        
    }


    void HandleMovement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.linearVelocity = new Vector3(moveInput.x * speed , 0 , moveInput.y * speed);
        if (this.transform.position.x >= 10.5f)
        {
            rb.linearVelocity = new Vector3(-10, 0, 0);
        }
        else if (this.transform.position.x <= -10.5f)
        {
            rb.linearVelocity = new Vector3(10, 0, 0);
        }
        else if (this.transform.position.z >= 6f)
        {
            rb.linearVelocity = new Vector3(0, 0, -10);
        }
        else if (this.transform.position.z <= -6f)
        {
            rb.linearVelocity = new Vector3(0, 0, 10);
        }
    }

    void HandleAiming()
    {
        Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));


        }
    }


    void HandleShooting()
    {

        if (Input.GetMouseButtonDown(0) && canShoot == true) 
        {
            Debug.Log("Fire");

            Instantiate(bullet, firingPoint.position, firingPoint.rotation);
        }


    }
}
