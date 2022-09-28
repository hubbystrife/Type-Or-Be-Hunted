using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    
    private bool running = false;

    /*public CharacterController TP;
    Vector3 moveDirection;
    public float PS;
    public float JS;
    public float Gravity;*/

    private void Start()
    {
        rb= GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 500))
            {
                navMeshAgent.destination = hit.point;
            }
        }

        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            running = false;
            walksound.instance.StopWalk();
        }
        else
        {
            running = true;
            walksound.instance.Walk();
        }

        animator.SetBool("run", running);

        /*if(TP.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Vertical"),0,Input.GetAxis("Horizontal"));
            moveDirection *= PS;
            if(Input.GetButton("Jump") ) 
            {
                moveDirection.y=JS;
            }
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
        animator.SetBool("run", running);*/
        
    }

    private void OnTriggerEnter(Collider hit)
    {
        
    }
}