/*
 * ��ɐ������ԂƃX�R�A�̏������s���ۂ̃X�N���v�g
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Scorenum
{
    public static int score_num = 0;
    
}




public class Counter : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;//�T�E���h�}�l�[�W���[�i�[
    [SerializeField]
    AudioClip clip;//���ʉ��i�[
    [SerializeField]
    AudioClip clip2;


    public GameObject score_object;//�X�R�AUI
    public GameObject time_object;//��������UI
   

   
    public float countdown = 60.0f;//��������(60�b�Őݒ�)
   

    public GameObject startObject;//�X�^�[�g�I�u�W�F�N�g
    Startscript startscript;//�X�^�[�g�X�N���v�g
    public GameObject resultObject;//���U���g�I�u�W�F�N�g
    GameManager s1;//�Q�[���}�l�[�W���[
    Animator anim;//�A�j���[�^�[�i�[
    Text time_text;//�������ԃe�L�X�g
    Text score_text;//�X�R�A�e�L�X�g


    // Start is called before the first frame update
    void Start()
    {
        Scorenum.score_num = 0;//�X�R�A�������l��
        s1 = this.GetComponent<GameManager>();//�V�[���}�l�[�W���[�i�[
        time_text = time_object.GetComponent<Text>();//�������ԃe�L�X�g�i�[
        score_text = score_object.GetComponent<Text>();//�X�R�A�e�L�X�g�i�[
        startscript = startObject.GetComponent<Startscript>();//�X�^�[�g�X�N���v�g�i�[
        anim = startscript.Readygo.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //���t���[�����ƂɃJ�E���g�_�E���ƃX�R�A�̍X�V
       
        if (startscript.ready != false)//�Q�[�����J�n���Ă����
        {
            
            
            score_text.text = "Score:" + Scorenum.score_num;

            countdown -= Time.deltaTime;

            time_text.text = countdown.ToString("f1") + "�b";

            //countdown��0�ȉ��ɂȂ����Ƃ�
            if (countdown <= 0)
            {
                //�R���[�`���֐��ɔ��
                StartCoroutine("End");
                
                

            }
        }
    }

    IEnumerator End() //�R���[�`���֐��̖��O
    {
        //�������Ԃ�0�b�ɂȂ������̏���

        Text result_text = resultObject.GetComponent<Text>();//���U���g�e�L�X�g�̊i�[
        startscript.ready = false;//�Q�[���̑�����~�߂�
        

        soundManager.StopBgm(clip);//�T�E���h�Đ�
        result_text.text = "�I���I!!";//�I���̃e�L�X�g�\��
        yield return new WaitForSeconds(3.0f);
        s1.LoadScene("Result");//���U���g�V�[���ɔ��
        

    }
}
