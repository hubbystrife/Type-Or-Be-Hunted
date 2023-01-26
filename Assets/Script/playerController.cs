using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    private Animator animator;
    public GameObject[] MCs;
    public GameObject MC;
    private NavMeshAgent navMeshAgent;
    public float FallingThreshold = -10f;  //Adjust in inspector to appropriate value for the speed you want to trigger detecting a fall, probably by just testing
    [HideInInspector]
    public bool Falling = false;  //Other scripts can check this value to see if currently falling
 
    
    private bool running = false;

    public CharacterController TP;
    Vector3 moveDirection;
    public float PS;
    public float JS;
    public float Gravity;
    GameManager gameManager;

    private void Start()
    {
        MCs = GameObject.FindGameObjectsWithTag("Camera");
        MC = MCs[0];
        rb= GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {


        if (rb.velocity.y < FallingThreshold)
        {
            Falling = true;
        }
        else
        {
            Falling = false;
        }
 
        if (Falling)
        {
            GameData.instance.Score += GameManager.instance.score;
            SceneManager.LoadScene("Lose Scene");
            Destroy(MC);
            Destroy(gameObject);
        }

        if (TP.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Vertical"),0,Input.GetAxis("Horizontal"));
            moveDirection *= PS;

            if(Input.GetButton("Jump") ) 
            {
                moveDirection.y=JS;
            }
        }

        if ( TP.transform.position.y <= 2)
        {
            gameManager.TakeDamage(30);
        }

        moveDirection.y -= Gravity*Time.deltaTime;
        TP.Move(moveDirection*Time.deltaTime);
        
        
        if (Input.GetKey("up") )
        {
            TP.transform.rotation = Quaternion.Euler(0,-280,0);
            running = true;
        }
        else if (Input.GetKey("down"))
        {
            TP.transform.rotation = Quaternion.Euler(0,-90,0);
            running = true;
        }
        else if (Input.GetKey("left"))
        {
            TP.transform.rotation = Quaternion.Euler(0,-10,0);
            running = true;
        }
        else if (Input.GetKey("right"))
        {
            TP.transform.rotation = Quaternion.Euler(0,-180,0);
            running = true;
        }
        else
        {
            running = false;
        }
        animator.SetBool("run", running);
        
    }

    private void OnTriggerEnter(Collider hit)
    {
        
    }
}