using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damagescript : MonoBehaviour
{
    private float[] maxHP= new float[5];//enemy���Ƃ̍ő�HP
    private float[] currentHp= new float[5];//enemy���Ƃ̎c��HP

    int i = 0;

    private Slider[] slider= new Slider[5];//enemy���Ƃ�HP�o�[



    void Start()
    {
        //�Senemy��HP�̏����ݒ�
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
        //�_���[�W�֐�
        i = 0;
        for (i = 1; i < 5; i++)
        {
            //HP����_���[�W��������
            currentHp[i] = currentHp[i] - damage;
            Debug.Log("After currentHp : " + currentHp[i]);

            //�X���C�_�[(�̗̓Q�[�W)�̏�������
            slider[i].value = currentHp[i] / maxHP[i];
            Debug.Log("slider.value : " + slider[i].value);
        }

    }
}
