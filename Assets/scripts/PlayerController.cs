using UnityEngine;
using System.Collections;
using System.Linq;

// Ensure the component is present on the gameobject the script is attached to
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // Local rigidbody variable to hold a reference to the attached Rigidbody2D componentRigidbody2D body;

    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    private Vector2 mousePos;

    private float angle;
    public Transform shootPoint;

    public GameObject bullet;

    public float shootSpeed;

    public bool canShoot = true;

    public GameObject GameOverScreen;

    private void Awake(){
        canShoot = true;
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if((Input.GetKeyDown("space") || Input.GetKey(KeyCode.Mouse0)) && canShoot){
            StartCoroutine(shootGun());
        }

        mousePos = Input.mousePosition;

        Vector3 objectPOs = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x -= objectPOs.x;
        mousePos.y -= objectPOs.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        shootPoint.rotation = Quaternion.Euler(new Vector3(0,0,angle));

    }

    public IEnumerator shootGun(){
        canShoot = false;
        GameObject bulletCreated = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D bulletRigidbody = bulletCreated.GetComponent<Rigidbody2D>();

        bulletRigidbody.AddForce(shootPoint.right * shootSpeed);

        Destroy(bulletCreated, 5);
        yield return new WaitForSeconds(1);
        canShoot = true;
    }

       private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            GameOverScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

}