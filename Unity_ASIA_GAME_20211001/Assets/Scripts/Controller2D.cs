using UnityEngine;
/// <summary>
/// 2D ���V���b����
/// </summary>
public class Controller2D : MonoBehaviour
{
    #region �榁E���}

    [Header("���ʳt��"), Range(0, 150)]
    public float speed = 3.5f;
    [Header("���D����"), Range(0, 1500)]
    public float jump = 300f;
    [Header("�T�{�a�O�ؤo�P��E�")]
    [Range(0, 1)]
    public float CheckGroundReidend = 0.1f;
    public Vector3 CheckGroundOffect;
    [Header("���D����P�i���D�ϼh")]
    public KeyCode KeyJump = KeyCode.Space;
    public LayerMask canJumpLayer;
    [Header("�ʵe�Ѽ�:�����P���D")]
    public string parameterwalk = "�����}ÁE";
    public string parameterJump = "���D�}ÁE";

    #endregion

    #region �榁E�p�H

    /// <summary>
    /// ���餸��ERigidbody 2D
    /// </summary>
    private Animator ani;
    private Rigidbody2D rig ;
    [SerializeField]
    private bool isGrounded;
    

    #endregion

    #region �ƥ�E

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

        print("�I���ؼе��G:" + hit.name);
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
