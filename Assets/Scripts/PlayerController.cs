using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    public float turnSpeed = 10.0f;
    private Rigidbody playerRb;
    private Animator playerAnim;

    public GameObject centerOfMass;
    public bool isOnGround = true;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;

        playerAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // playerRb.
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        // transform.Translate(Vector3.up * speed * Time.deltaTime * horizontalInput);


        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up,  Time.deltaTime * turnSpeed * horizontalInput);

        if(verticalInput > 0){
            playerAnim.SetBool("Running_b", true);
        }else{
            playerAnim.SetBool("Running_b", false);
        }
        // transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        if(Input.GetKeyDown(KeyCode.Space)){
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;

            Debug.Log(jumpForce);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // transform.Rotat
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            isOnGround = true;
            Debug.Log("On Ground");
        }
    }
}
