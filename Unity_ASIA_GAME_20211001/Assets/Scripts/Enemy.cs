using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("檢查追蹤區域大小與位移")]
    public Vector3 v3TrackSive = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("移動速度")]
    public float speed = 1.5f;
    [Header("目標圖層")]
    public LayerMask layerTarget;
    [Header("動畫參數")]
    public string parameterWalk = "走路開關";
    [Header("面相目標物件")]
    public Transform target;


    private float angle;
    private Rigidbody2D rig;
    private Animator ani;

    

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSive);
        
    }

    private void Update()
    {
        checkTargetInArea();
    }

    private void checkTargetInArea()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSive , 0, layerTarget);

        //if (hit) rig.velocity = new Vector2(-speed, rig.velocity.y);
        if (hit) Move();
    }

    private void Move()
    {

        angle = target.position.x > transform.position.x ? 180 : 0 ; 

        rig.velocity = new Vector2(-speed, rig.velocity.y);
        ani.SetBool(parameterWalk, true);
    }
}
