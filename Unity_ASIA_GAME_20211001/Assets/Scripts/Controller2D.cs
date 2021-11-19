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
    #endregion
    /// <summary>
    /// 剛體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig ;

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
    }
    #endregion
}