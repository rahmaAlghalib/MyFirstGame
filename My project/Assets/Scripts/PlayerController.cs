using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    GameManager gameManager;
    Rigidbody rb;
    public float moveSpeed = 3.0f;
    public float jumpForce = 5.0f;
    public int collectedCoins = 0;
    private Camera mainCamera;

    public int maxHealth = 1;
    [SerializeField] int currentHealth =0;


private void Awake(){

    gameManager = FindAnyObjectByType<GameManager>();
}
    // Start is called before the first frame update
    void Start()
    {
      rb = gameObject.GetComponent<Rigidbody>();
      mainCamera = Camera.main;
      currentHealth = maxHealth;
      
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        gameManager.UpdateHealthText(currentHealth, maxHealth);
    }

    public void Movement(){

      float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");

      Vector3 cameraForward = mainCamera.transform.forward;
      Vector3 cameraRight = mainCamera.transform.right;

      cameraForward.y =0;
      cameraRight.y = 0;

      Vector3 moveDirection = cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput;

      if(moveDirection != Vector3.zero){

        transform.forward = moveDirection;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

      }
    }

    public void Jump(){

        if(Input.GetButtonDown("Jump")){

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }
    
    private void OnCollisionEnter(Collision other){
      
      if(other.gameObject.CompareTag("Damage")){

        currentHealth -= 1;

        Vector3 damageDirection = other.transform.position - transform.position;

        damageDirection.Normalize();

        rb.AddForce(-damageDirection * 2f, ForceMode.Impulse);

        gameManager.UpdateHealthText(currentHealth, maxHealth);

        if(currentHealth <= 0){
          gameManager.Restart();
        }


        

      }

    }

    private void OnTriggerEnter(Collider other){

      if(other.gameObject.CompareTag("Coin")){

        collectedCoins++;

        Destroy(other.gameObject);

        gameManager.UpdateCoinText(collectedCoins);

      }
    }


}
