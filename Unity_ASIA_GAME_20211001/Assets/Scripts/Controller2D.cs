using UnityEngine;
/// <summary>
/// 2D ��V���b����
/// </summary>
public class Controller2D : MonoBehaviour
{
    #region ���:���}
    [Header("���ʳt��"),Range( 0 , 150 )]
    public float speed = 3.5f;
    [Header("���D����"),Range( 0 , 1500 )]
    public float jump = 300f;
    #endregion
    /// <summary>
    /// ���餸�� Rigidbody 2d
    /// </summary>
    private Rigidbody2D rig ;

    private void Start()
    {
        rig = GetComponent <Rigidbody2D>();
    }
}