/*
     * �L�����N�^�[�X�ɏ������s���ۂ̃X�N���v�g
     */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    
    public GameObject obj2;//�ԕ�prefab
    public GameObject slider;//�q�X���C�_�[

    public Slider sliderdata;//�X���C�_�[�R���|�[�l���g
    public Animator anim3;//�ԕ���������A�j���[�V����
    public GameObject enemyObject;//enemyscript
    Sprite Image;//enemy�̃X�v���C�g
    Sprite animImage;//������݂����Ƃ��̃X�v���C�g
    private float maxHP=30f;//maxHP
    private float currentHp=30f;//HP
    enemyscript e;//enemyscript�i�[�p
    [SerializeField]private Vector2 v;//�w��ʒu
    private float speed = 15.0f;//�ړ�

    
    // Start is called before the first frame update
    void Start()
    {
        sliderdata = slider.GetComponent<Slider>();//�X���C�_�[�̃R���|�[�l���g���i�[
        e = enemyObject.GetComponent<enemyscript>();//enemyscript�i�[
        Imagechange();//�����_���ɃX�v���C�g�ύX
        spawn();//�����ʒu����ʊO��
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, v, speed * Time.deltaTime);//�w��ʒu�Ɉړ�
    }

    public void damage(float damage)
    {
        //�_���[�W���󂯂��Ƃ��̊֐�
        anim3.SetBool("FPbool", true);//�ԕ��A�j���[�V�����J�n
        gameObject.GetComponent<SpriteRenderer>().sprite = animImage;//�����G��������ݏ�Ԃ�
        currentHp = currentHp - damage;//�_���[�W��^����
        sliderdata.value = currentHp / maxHP;//�X���C�_�[�̍X�V
        if (currentHp <= 0)
        {
            //HP��0�ɂȂ����Ƃ�
            Imagechange();//�L�����ύX
            e.addscore();//�X�R�A�X�N���v�g
            delete();//HP�̕ύX
            spawn();//��ʊO�Ɉړ�

        }
        Invoke(nameof(DelayMethod), 1.5f);
    }
    void DelayMethod()
    {
        //���Ԍo�ߌ�ɃA�j���[�V�������I��������֐�
        anim3.SetBool("FPbool", false);//�ԕ��A�j���[�V�������I��
        

    }

    public void delete()
    {
        //HP��0�ɂȂ����Ƃ��V����HP�̍Đݒ�����܂��B���̍ۂɑ̗͂͑O���荂���Ȃ�悤��

        //����HP*0.5�`1.5f
        float r = Random.Range(1.0f, 1.5f);
        
        maxHP = maxHP * r;//
        currentHp =maxHP;
        sliderdata.value = currentHp / maxHP;//�X���C�_�[�̍X�V
       
    }
    public void Imagechange()
    {
        //�L�����N�^�[�̗����G�������_���ɕύX���܂��B��ɃQ�[���J�n����HP��0�ɂȂ����Ƃ�
        this.gameObject.GetComponent<SpriteRenderer>().sprite = e.ofsImage[Random.Range(0, 5)];//�i�[����X�v���C�g�������_���Ɏw��
        //�i�[�����X�v���C�g�Ɠ��������G�̂�����݂̃X�v���C�g���ꏏ�Ɋi�[
        for (int i=0;i<5;i++)
        {
            if(this.gameObject.GetComponent<SpriteRenderer>().sprite == e.ofsImage[i])
            {
                animImage = e.animImage[i];
            }
        }
        
        

    }
    void spawn()
    {
        //��ʊO�������ė���悤�Ɍ����邽�߉�ʊO�ɃL�����N�^�[��o�ꂳ���Ă܂��BUodate�Ŏw��̈ʒu�Ɉړ�
        Vector2 pos = this.transform.position;
        if (this.transform.position.x >= 0f)
        {
            pos.x += 8.0f;
            
        }
        else
        {
            pos.x -= 8.0f;
        }
        this.transform.position = pos;
    }
}
