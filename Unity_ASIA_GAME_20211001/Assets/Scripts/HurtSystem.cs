using UnityEngine;
using UnityEngine.UI;

public class HurtSystem : MonoBehaviour
{
    [Header("���")]
    public Image imgHpbar;
    [Header("��q")]
    public float hp = 100;

    public float hpMax;

    [Header("�ʵe�Ѽ�")]
    public string parameterDead = "Ĳ�o���`";

    private Animator ani;


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
    }
}
