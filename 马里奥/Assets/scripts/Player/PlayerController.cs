
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
    //private bool canDoubleJump;                             //���������

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

    //private void HandleCollision()      //������ײ��������Ͷ��������ã�
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
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);//x,y�����ƶ������ٶȵķ�ʽ
        //Debug.Log(inputDirection.x);
        //Debug.Log(speed);
        //���﷭ת
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
            //Debug.Log($"��һ��{i}");
            i++;
            //Debug.Log($"�ڶ���{i}");
        }
        //else if (i > 1)
        // canJump = false;

    }



    //private void DoubleJump(InputAction.CallbackContext obj)           //������
    //{
    //  if(canDoubleJump=true)
    //        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

    //        canDoubleJump = false;




   

}
