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
    public string parameterAttack = "觸發攻擊";
    [Header("面相目標物件")]
    public Transform target;
    [Header("攻擊距離"),Range( 0 , 5 )]
    public float attackDistance = 1.3f;
    [Header("攻擊冷卻時間"),Range( 0 , 10 )]
    public float attackCD = 2.8f;
    [Header("檢查攻擊區域大小與位移")]
    public Vector3 v3AttackSive = Vector3.one;
    public Vector3 v3AttackOffset;


    private float angle;
    private Rigidbody2D rig;
    private Animator ani;
    private float timerAttack;

    

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSive);

        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSive);
        
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

        transform.eulerAngles = Vector3.up * angle;

        rig.velocity = transform.TransformDirection(new Vector2(-speed, rig.velocity.y));
        ani.SetBool(parameterWalk, true);

        float distance = Vector3.Distance(target.position, transform.position);
        print("與目標的距離:" + distance);

        if (distance <= attackDistance)
        {

            rig.velocity = Vector3.zero;
            Attack();
        }

    }

    [Header("攻擊力"), Range(0, 100)]
    public float attack = 35;

    private void Attack()
    {
        if(timerAttack < attackCD)
        {
            timerAttack += Time.deltaTime;
        }
        else
        {
            ani.SetTrigger(parameterAttack);
            timerAttack = 0;
        }

        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSive, 0, layerTarget);
    }
}
