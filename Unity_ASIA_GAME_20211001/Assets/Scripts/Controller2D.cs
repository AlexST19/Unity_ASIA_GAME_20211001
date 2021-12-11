using UnityEngine;
/// <summary>
/// 2D ｾ鈐Vｨbｪｩ･ｻ
/// </summary>
public class Controller2D : MonoBehaviour
{
    #region ﾄ讎・､ｽｶ}

    [Header("ｲｾｰﾊｳtｫﾗ"), Range(0, 150)]
    public float speed = 3.5f;
    [Header("ｸDｰｪｫﾗ"), Range(0, 1500)]
    public float jump = 300f;
    [Header("ｽTｻ{ｦaｪO､ﾘ､oｻPｦ・ｾ")]
    [Range(0, 1)]
    public float CheckGroundReidend = 0.1f;
    public Vector3 CheckGroundOffect;
    [Header("ｸDｫ莉P･iｸDｹﾏｼh")]
    public KeyCode KeyJump = KeyCode.Space;
    public LayerMask canJumpLayer;
    [Header("ｰﾊｵeｰﾑｼﾆ:ｨｫｸPｸD")]
    public string parameterwalk = "ｨｫｸ}ﾃ・";
    public string parameterJump = "ｸDｶ}ﾃ・";

    #endregion

    #region ﾄ讎・ｨp､H

    /// <summary>
    /// ｭ霰鬢ｸ･・Rigidbody 2D
    /// </summary>
    private Animator ani;
    private Rigidbody2D rig ;
    [SerializeField]
    private bool isGrounded;
    

    #endregion

    #region ｨﾆ･・

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

    #region ､隱k

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        //print("ｪｱｮaｫ莨ﾆｭﾈ" + h );

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

        print("ｸIｼｲ･ﾘｼﾐｵｲｪG:" + hit.name);
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
