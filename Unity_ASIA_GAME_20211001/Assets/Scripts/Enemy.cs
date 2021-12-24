using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("�ˬd�l�ܰϰ�j�p�P�첾")]
    public Vector3 v3TrackSive = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("���ʳt��")]
    public float speed = 1.5f;
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;

    private Rigidbody2D rig;

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

        if (hit) rig.velocity = new Vector2(-speed, rig.velocity.y);
    }

}
