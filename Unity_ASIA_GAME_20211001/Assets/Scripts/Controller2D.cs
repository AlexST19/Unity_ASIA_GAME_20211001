using UnityEngine;
/// <summary>
/// 2D 氅懣卷軸版本
/// </summary>
public class Controller2D : MonoBehaviour
{
    #region 欄?E公開

    [Header("移動速度"), Range(0, 150)]
    public float speed = 3.5f;
    [Header("跳躍高度"), Range(0, 1500)]
    public float jump = 300f;
    [Header("確認地板尺寸與?E?")]
    [Range(0, 1)]
    public float CheckGroundReidend = 0.1f;
    public Vector3 CheckGroundOffect;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode KeyJump = KeyCode.Space;
    public LayerMask canJumpLayer;
    [Header("動畫參數:走路與跳躍")]
    public string parameterwalk = "走路開?E";
    public string parameterJump = "跳躍開?E";

    #endregion

    #region 欄?E私人

    /// <summary>
    /// 剛體元?ERigidbody 2D
    /// </summary>
    private Animator ani;
    private Rigidbody2D rig ;
    [SerializeField]
    private bool isGrounded;
    

    #endregion

    #region 事?E

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color (0, 0, 0.2f, 0.3f);
        Gizmos.DrawSphere(transform.position + 
            transform.TransformDirection(CheckGroundOffect), CheckGroundReidend);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Flips();
        CheckGround();
        Jump();
    }

    private void Start()
    {
        rig = GetComponent <Rigidbody2D>();
        ani = GetComponent <Animator>();
    }


    #endregion

    #region 方法

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        //print("玩家按鍵數值" + h );

        rig.velocity = new Vector2(h * speed , rig.velocity.y);
        ani.SetBool(parameterwalk, h != 0);
    }

    private void Flips()
    {
        float h = Input.GetAxis("Horizontal");
        if ( h < 0 )
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if ( h > 0 )
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
    }
    
    private void CheckGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
            transform.TransformDirection(CheckGroundOffect), CheckGroundReidend);

        print("碰撞目標結果:" + hit.name);
        isGrounded = hit;
    }
    
    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyJump))
        {
            rig.AddForce(new Vector2( 0, jump));
        }
        ani.SetBool(parameterJump, !isGrounded);
    }

    #endregion
}
