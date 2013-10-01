using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

    public LayerMask mask;
    public float idleRange = 1;
    Vector3 target;
    Camera cam;

    enum MovementState { Idle, OneClick, Drag, Manual, Event };
    MovementState movementState;
    CharacterController controller;
    public float speed, maxSpeed = 3, rotateSpeed = 60, attackRadius = 5;

    Vector3 attackPos;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        movementState = MovementState.Idle;
        cam = Camera.main;
	}
    void AnimationStartCrap()
    {
        // By default loop all animations
        animation.wrapMode = WrapMode.Loop;

        // We are in full control here - don't let any other animations play when we start
        animation.Stop();

        animation["Attack"].wrapMode = WrapMode.Once;
        animation["Charge"].wrapMode = WrapMode.Once;
        animation["Halt"].wrapMode = WrapMode.Once;
        animation["Idle"].wrapMode = WrapMode.Loop;
        animation["Walk"].wrapMode = WrapMode.Loop;
    }//AnimationStartCrap()

    void OnGUI()
    {
        

        if(GUI.Button(new Rect(Screen.width/3-30,Screen.height-30,60,20),"Attack"))
            Attack();
        if(GUI.Button(new Rect(Screen.width/2-30,Screen.height-30,60,20),"Halt"))
            Halt();
        if(GUI.Button(new Rect(Screen.width*2/3-30,Screen.height-30,60,20),"Charge"))
            Charge();

        switch (Event.current.type)
        {
            case EventType.MouseDown:
                movementState = MovementState.OneClick;
                IBeCastin();
                break;
            case EventType.MouseDrag:
                movementState = MovementState.Drag;
                IBeCastin();
                break;
            case EventType.MouseUp:
                break;
            default:
                break;
        }


    }
    void Halt()
    {
        movementState = MovementState.Event;
        animation.CrossFade("Halt");
        animation.CrossFadeQueued("Idle");
    }
    void Charge()
    {
        movementState = MovementState.Event;
        animation.CrossFade("Charge");
        animation.CrossFadeQueued("Idle");
    }
	void Update () {

        //Movement(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        switch (movementState)
        {
            case MovementState.Drag:
                if(Input.GetMouseButton(0))
                    AutoMovement();
                if (Input.GetMouseButtonUp(0))
                    movementState = MovementState.Idle;
                break;
            case MovementState.Idle:
                break;
            case MovementState.OneClick:
                if (Input.GetMouseButtonUp(1))
                    Attack();
                else
                    AutoMovement();
                break;
            case MovementState.Manual:
                Movement(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
                break;
            default:
                break;
        }
        InputCheck();
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        controller.Move(-Vector3.up * 0.1f);
        
     
        //print(TouchMove.targetPosition);
	}
    void InputCheck()
    {
       if (Input.GetKeyDown(KeyCode.Space))
            Attack();
       else if (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") != 0)
           movementState = MovementState.Manual;
    }
    void Movement(Vector2 move)
    {
        if (!animation.IsPlaying("Idle"))
            animation.CrossFade("Idle");
        var targetSpeed = move.y < 0 ? move.y * maxSpeed * .5f : move.y * maxSpeed;
        speed = Mathf.Lerp(speed, targetSpeed, .03f);
        //actually move tank ;; based on calc and time (gravity is calculated with Vector3)
        controller.Move(transform.forward * speed * Time.deltaTime - Vector3.up * 0.1f);
        //actually rotate tank ;; dependant on turnSpd variable + input
        transform.Rotate(0, move.x * rotateSpeed * Time.deltaTime, 0);
        //if (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") == 0)
          //  movementState = MovementState.Idle;

    }
     void AutoMovement()
    {
        if (!animation.IsPlaying("Idle"))
            animation.CrossFade("Idle");
        var direction = (new Vector3(target.x,transform.position.y,target.z) - transform.position).normalized;
        Debug.DrawLine(target, transform.position, Color.magenta);
        

        speed = Mathf.Lerp(speed, maxSpeed, .03f);
        if ((new Vector3(target.x, transform.position.y, target.z) - transform.position).magnitude < idleRange)
            movementState = MovementState.Idle;
        else
        {
            transform.forward = (transform.forward * 0.8f) + (direction * 0.2f);
            controller.Move(transform.forward * speed * Time.deltaTime);
        }
    }
    void Attack()
    {
        movementState = MovementState.Event;
        animation.CrossFade("Attack");
        animation.CrossFadeQueued("Idle");
        attackPos = transform.position + Vector3.forward*4 + Vector3.up;
        //var enemies = GameObject.FindGameObjectsWithTag("enemy");
        //foreach (GameObject e in enemies)
        //{
            //if ((e.transform.position - transform.position).magnitude < attackRadius)
               //print("hit enemy at"+e.transform.position);
        }
   // }
    public void IBeCastin()
    {
        //Fire a ray through the scene at the mouse position and place the target where it hits
        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask))
        {
            target = hit.point;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPos, 1);
    }
}
