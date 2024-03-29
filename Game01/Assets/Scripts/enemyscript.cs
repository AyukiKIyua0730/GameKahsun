/*
 * �������G�l�~�[�S�̂ɓ����ɏ�����^����ꍇ�̃X�N���v�g
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class enemyscript : MonoBehaviour
{
   

    [SerializeField]
    SoundManager soundManager;//���ʉ�
    [SerializeField]
    AudioClip clip;


 
    public Sprite[] ofsImage;//�L�����̗����G���i�[
    public Sprite[] animImage;//�L�����̂������

    [SerializeField]
    private GameObject[] enemyobj;//�G�l�~�[��obj�i�[

    private enemy[] e =new enemy[5];//enemy.cs���i�[
    int i = 0;


   
    public GameObject CounterObject;//Counter.cs�i�[�I�u�W�F�N�g
    public GameObject CounterObject2;//�������ԃe�L�X�g�I�u�W�F�N�g
    public GameObject AddtimeObject;//���ԉ��Z�e�L�X�g�I�u�W�F�N�g
    private Animator anim;//���ԉ��Z�A�j���[�V����
    private Animator anim2;//�X�R�A�����A�j���[�V����


    private Text addtime_text;//���ԉ��Z�e�L�X�g
    Counter counter;//Counter.cs
  
    int c = 0;
    
    float b = 0.0f;




 
    void Start()
    {
        //�R���|�[�l���g�擾
        addtime_text = AddtimeObject.GetComponent<Text>();
        anim = AddtimeObject.GetComponent<Animator>();
        anim2 = CounterObject2.GetComponent<Animator>();
        counter = CounterObject.GetComponent<Counter>();

    }
    void Update()
    {
        //�A�j���[�V�������J�n�ҋ@��Ԃɂ��Ă���
        anim.SetBool("add", false);
        anim2.SetBool("count", false);
        

    }
    public void damage(float damage)
    {
        //Meter����̏�����enemy�Ɋi�[���鏈��
        for(int i=0;i<5;i++)
        {
            e[i] = enemyobj[i].GetComponent<enemy>();
            e[i].damage(damage);
        }
        

    }

    public void addscore()
    {
        c++;//���Z����X�R�A���v�Z
        b += 3.0f;
        Scorenum.score_num += 1;//�X�R�A���Z
        soundManager.PlaySe(clip);
        anim2.SetBool("count", true);//�X�R�A�A�j���[�V����
        if(c >= 1)
        {
            //���Z���Ԃ��d�������Ƃ����܂Ƃ߂ĕ\��
            addtime_text.text = "+" + b.ToString("f1");
            anim.SetBool("add", true);//���ԉ��Z�A�j���[�V����

            counter.countdown += b;//�������Ԃɉ��Z
            b = 0.0f;//���Z���Ԃ����Z�b�g
            c = 0;//�d���������Z�b�g
        }

       
    }

        
        

    

    


    

    



}
