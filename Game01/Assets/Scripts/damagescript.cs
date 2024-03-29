using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damagescript : MonoBehaviour
{
    private float[] maxHP= new float[5];//enemyごとの最大HP
    private float[] currentHp= new float[5];//enemyごとの残りHP

    int i = 0;

    private Slider[] slider= new Slider[5];//enemyごとのHPバー



    void Start()
    {
        //全enemyのHPの初期設定
        for (i = 1; i < 5; i++)
        {

            maxHP[i] = 20f;
            currentHp[i] = 20f;

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void damage(float damage)
    {
        //ダメージ関数
        i = 0;
        for (i = 1; i < 5; i++)
        {
            //HPからダメージ分を引く
            currentHp[i] = currentHp[i] - damage;
            Debug.Log("After currentHp : " + currentHp[i]);

            //スライダー(体力ゲージ)の書き換え
            slider[i].value = currentHp[i] / maxHP[i];
            Debug.Log("slider.value : " + slider[i].value);
        }

    }
}
