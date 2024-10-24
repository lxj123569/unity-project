
using Unity.Mathematics;
using UnityEngine;  
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    public Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    float faceDirction;

    public Vector2 inputDirection;
    public float speed;
    public float jumpForce;
    //private bool canJump;
    //private bool canDoubleJump;                             //二段跳检测

    // Start is called before the first frame update


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        inputControl = new PlayerInputControl();
        inputControl.Gameplay.Jump.started += Jump;
        faceDirction=transform.localScale.x;
        //  inputControl.Gameplay.DoubleJump.started += DoubleJump;

    }


    private void OnEnable()
    {
        inputControl.Enable();
    }
    //private void OnDisable()
    //{
    //    inputControl.Disable();
    //}
    private int i;
    private void Update()
    {

        if (physicsCheck.isGround)
            i = 0;
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();

    }

    //private void HandleCollision()      //处理碰撞（地面检测和二段跳重置）
    //{
    //    //isGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    //    if (physicsCheck.isGround)



    //    else
    //        canDoubleJump = true;
    //}


    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);//x,y坐标移动，以速度的方式
        //Debug.Log(inputDirection.x);
        //Debug.Log(speed);
        //人物翻转
        if (inputDirection.x > 0)
            
            faceDirction = math.abs(transform.localScale.x);
        
        if (inputDirection.x < 0)
        {
            faceDirction = -1* math.abs(transform.localScale.x);

        }
        transform.localScale = new Vector3(faceDirction, transform.localScale.y, transform.localScale.z);

    }

    private void Jump(InputAction.CallbackContext obj)
    {

        if (i < 1)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            //Debug.Log($"第一次{i}");
            i++;
            //Debug.Log($"第二次{i}");
        }
        //else if (i > 1)
        // canJump = false;

    }



    //private void DoubleJump(InputAction.CallbackContext obj)           //二段跳
    //{
    //  if(canDoubleJump=true)
    //        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

    //        canDoubleJump = false;




   

}
