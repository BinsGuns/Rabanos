using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalMoveSpeed;
    public float forwardSpeed;
    private Rigidbody playerRigidBody;
    public float jumpVelocity;
    public float gravity;
    private bool isOnGround = true;
    private float minXLimit;
    private float maxXlimit;

    private AudioSource audioSource;
    public List<AudioClip> audioClips;

    public  bool isGameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        Physics.gravity *= gravity;
        minXLimit = transform.position.x - 1;
        maxXlimit = transform.position.x + 2;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver){
          
          if(Input.GetKeyDown(KeyCode.Space) && isOnGround) {
         
            isOnGround = false;
            playerRigidBody.AddForce(Vector3.up * gravity * jumpVelocity,ForceMode.Impulse);
          }
            //limit position
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,minXLimit,maxXlimit),transform.position.y,transform.position.z);
        

            float horizontalInput = Input.GetAxis("Horizontal");
            
            if(horizontalInput != 0 && !audioSource.isPlaying ) {

                audioSource.PlayOneShot(audioClips[Random.Range(0,audioClips.Count)]);

            }

            transform.Translate(Vector3.right * horizontalInput * horizontalMoveSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision other) {
        
        if(other.collider.CompareTag("Obstacles")){
            isGameOver = true;
        } else {
            isOnGround = true;
        }
    }

}
