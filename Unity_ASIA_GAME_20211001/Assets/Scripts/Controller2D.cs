using UnityEngine;
/// <summary>
/// 2D 橫向卷軸版本
/// </summary>
public class Controller2D : MonoBehaviour
{
    #region 欄位:公開
    [Header("移動速度"),Range( 0 , 150 )]
    public float speed = 3.5f;
    [Header("跳躍高度"),Range( 0 , 1500 )]
    public float jump = 300f;
    [Header("確認地板尺寸與位移46824684")]
    [Range(0, 1)]
    public float CheckGroundReidend = 0.1f;
    public Vector3 CheckGroundOffect;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode KeyJump = KeyCode.Space;
    public LayerMask canJumpLayer;


    #endregion
    /// <summary>
    /// 剛體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig ;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color (0, 0, 0.2f, 0.3f);
        Gizmos.DrawSphere(transform.position + 
            transform.TransformDirection(CheckGroundOffect), CheckGroundReidend);
    }

    private void Update()
    {
        Flips();
    }

    private void Start()
    {
        rig = GetComponent <Rigidbody2D>();
    }
    #region 方法
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        print("玩家按鍵數值" + h );

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
    #endregion
}