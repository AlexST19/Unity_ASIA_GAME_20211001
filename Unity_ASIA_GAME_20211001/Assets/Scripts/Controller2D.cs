using UnityEngine;
/// <summary>
/// 2D ��V���b����
/// </summary>
public class Controller2D : MonoBehaviour
{
    #region ���:���}

    [Header("���ʳt��"), Range(0, 150)]
    public float speed = 3.5f;
    [Header("���D����"), Range(0, 1500)]
    public float jump = 300f;
    [Header("�T�{�a�O�ؤo�P�첾")]
    [Range(0, 1)]
    public float CheckGroundReidend = 0.1f;
    public Vector3 CheckGroundOffect;
    [Header("���D����P�i���D�ϼh")]
    public KeyCode KeyJump = KeyCode.Space;
    public LayerMask canJumpLayer;
    [Header("�ʵe�Ѽ�:�����P���D"]
    public string parameterwalk = "�}������";
    public string parameterJump = "�}�����D";

    #endregion

    #region ���:�p�H

    /// <summary>
    /// ���餸�� Rigidbody 2D
    /// </summary>
    private Animator ani;
    private Rigidbody2D rig ;
    [SerializeField]
    private bool isGrounded;
    

    #endregion

    #region �ƥ�

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

    #region ��k

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        //print("���a����ƭ�" + h );

        rig.velocity = new Vector2(h * speed , rig.velocity.y);
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

        print("�I���ؼе��G:" + hit.name);
        isGrounded = hit;
    }
    
    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyJump))
        {
            rig.AddForce(new Vector2( 0, jump));
        }
    }

    #endregion
}
