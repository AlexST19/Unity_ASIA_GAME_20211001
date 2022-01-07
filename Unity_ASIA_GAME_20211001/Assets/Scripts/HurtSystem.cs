using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HurtSystem : MonoBehaviour
{
    [Header("血條")]
    public Image imgHpbar;
    [Header("血量")]
    public float hp = 100;

    public float hpMax;

    [Header("動畫參數")]
    public string parameterDead = "觸發死亡";

    private Animator ani;

    [Header("死亡事件")]
    public UnityEvent onDead;




    private void Awake()
    {
        hpMax = hp;
        ani = GetComponent<Animator>();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
    private void Hurt(float damage)
    {
        hp -= damage;
        imgHpbar.fillAmount = hp / hpMax;
        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        ani.SetTrigger(parameterDead);
        onDead.Invoke();
    }
}
