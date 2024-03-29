/*
 * �^�񒆂̃��[�^�[�Ɩ؂̉摜�\���̏���
 * ���암���̏���������
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class result//���U���g�̌��ʂ����U���g�V�[���Ɋi�[���邽�߁B-1�Ŏ��s
{
    public static int resulttri = 0;

}




public class Meter : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;//�T�E���h�}�l�[�W���[
    [SerializeField]
    AudioClip clip;//���ʉ�
    [SerializeField]
    AudioClip clip2;//���ʉ�


    float maxHp = 5000;//���[�^�[��MAX
    float currentHp;//���[�^�[�̌��ݒl
    float damage = 1.0f;//1�t���[�����̈ړ���
    //Slider������
    public Slider slider;//�X���C�_�[�i�[
    public GameObject damageObject;//�_���[�W��^����Ƃ��̃_���[�W�V�X�e���i�[
    public GameObject triggerObject;//���I�u�W�F�N�g�i�[
    public GameObject startObject;//StartScript�i�[
    public GameObject rotateObject;//���̖؊i�[�I�u�W�F�N�g
    private SpriteRenderer spriteRenderer;//�X�v���C�g���i�[
    private bool damagetrigger;//�_���[�W�g���K�[��bool�㐔

    Startscript startscript;//�X�^�[�g�X�N���v�g�i�[
    Vector2 v;//���ړ��p
    GameManager s1;//�V�[���J�ڗp
    Transform tTransform;//���transform
    enemyscript d1;//�_���[�W�X�N���v�g�i�[
    [SerializeField] private Sprite standard;//�ؒʏ�i�[
    [SerializeField] private Sprite rightsprite;//�E�X�؊i�[
    [SerializeField] private Sprite rightspriteb;//�E�X�ܖ؊i�[
    [SerializeField] private Sprite leftsprite;//���X�؊i�[
    [SerializeField] private Sprite leftspriteb;//���X�ܖ؊i�[



    void Start()
    {
        result.resulttri = 0;//���U���g�ϐ��͏����l��
        damagetrigger = false;
        startscript = startObject.GetComponent<Startscript>();//�X�^�[�g�X�N���v�g�i�[
        d1 = damageObject.GetComponent<enemyscript>();//�G�l�~�[�X�N���v�g�i�[
        tTransform= triggerObject.transform;//���I�u�W�F�N�g��Transform�i�[
        v = tTransform.position;//����ړ��p�Ɋi�[
        s1 = this.GetComponent<GameManager>();//�V�[���}�l�[�W���[�i�[
        spriteRenderer = rotateObject.GetComponent<SpriteRenderer>();//���̖؃I�u�W�F�N�g�i�[

        slider.value = 0f;//���[�^�[��^�񒆂�

        currentHp = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //���암���̏���

        if(startscript.ready != false)//�Q�[�����J�n���Ă����
        {
            rotateObject.transform.position = new Vector3(0f, 0.12f, -1f);//���̖؂�^�񒆂�
            spriteRenderer.sprite = standard;//�ؒʏ�X�v���C�g��

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //���L�[���������Ƃ�
               
                damage *= 1.01f;//���[�^�[����i�X����
               
               
                spriteRenderer.sprite = leftsprite;//���X�؃X�v���C�g��
                currentHp = currentHp - damage;
                if (damagetrigger == false)//��󂪍��ɂ���Ƃ�
                {

                    if (currentHp <= -2500.0f)//���𒴂����Ƃ�
                    {
                        //�L�����N�^�[�Ƀ_���[�W��^���Ė����E��
                        v = new Vector2(1.5f, -2.5f);
                        tTransform.position = v;
                        d1.damage(10f);
                        damagetrigger = true;
                    }
                }
           
                slider.value = (float)currentHp / (float)maxHp; //�X���C�_�[�̍X�V

                if ((slider.value >= 1) || (slider.value <= -1))//���[�^�[�����[�ɍs�����Ƃ�
                {
                    //�R���[�`���֐��ɔ��
                    StartCoroutine("End");


                }

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //�E�L�[���������Ƃ�
                damage *= 1.01f;//���[�^�[����i�X����

                spriteRenderer.sprite = rightsprite;//�E�X�؃X�v���C�g��
                currentHp = currentHp + damage;
                if (damagetrigger == true)//��󂪉E�ɂ���Ƃ�
                {
                    if (currentHp >= 2500.0f)//���𒴂����Ƃ�
                    {
                        //�L�����N�^�[�Ƀ_���[�W��^���Ė�������
                        v = new Vector2(-1.5f, -2.5f);
                        tTransform.position = v;
                        d1.damage(10f);
                        damagetrigger = false;
                    }
                }
               


                slider.value = (float)currentHp / (float)maxHp;//�X���C�_�[�̍X�V

                if ((slider.value >= 1) || (slider.value <= -1))//���[�^�[���E�[�ɍs�����Ƃ�
                {
                    //�R���[�`���֐��ɔ��
                    StartCoroutine("End");


                }
            }
            else//�������삵�Ă��Ȃ��Ƃ�
            {
                //���[�^�[��i�X�^�񒆂ɖ߂�����
                if (currentHp <= 0)
                {
                    if (damage > 1.0f)
                    {

                        damage *= 0.99f;
                    }
                    currentHp = currentHp + damage;



                }
                else if (currentHp >= 0)
                {
                    if (damage > 1.0f)
                    {
                    
                        damage *= 0.99f;
                    }
                    currentHp = currentHp - damage;
                   


                }


                slider.value = (float)currentHp / (float)maxHp;

            

            }
        }
        
    }

    IEnumerator End() //�R���[�`���֐��̖��O
    {
        //�؂��܂ꂽ�Ƃ�(���[�^�[���[�܂œ��B�����Ƃ�)�̏���

        //�X���Ă�������ɂ���Đ܂ꂽ�X�v���C�g��ύX
        if(spriteRenderer.sprite == rightsprite)
        {
            spriteRenderer.sprite = rightspriteb;
        }
        else
        {
            spriteRenderer.sprite = leftspriteb;
        }
        //�؂��܂ꂽ����BGM�̒�~
        soundManager.PlaySe(clip2);
        soundManager.StopBgm(clip);

        startscript.ready = false;
 //�^�񒆂̃e�L�X�g�𓧖���
        startscript.ready_text.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        result.resulttri = -1;

        startscript.ready_text.text = "�I���I!!";
        yield return new WaitForSeconds(3.0f);
        s1.LoadScene("Result");//���U���g�V�[���ɔ��


    }
}
