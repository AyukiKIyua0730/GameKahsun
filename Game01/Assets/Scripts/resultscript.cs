/*
 * ���U���g���ʂɉ����ĕ\����ς���X�N���v�g
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultscript : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;//�T�E���h�}�l�[�W���[�̊i�[
    [SerializeField]
    AudioClip clip;//�I�[�f�B�I�\�[�X�̊i�[
    [SerializeField]
    AudioClip clip2;
    public Text result_text;//���U���g�e�L�X�g�̊i�[
    public Text result2_text;//���U���g�e�L�X�g2�̊i�[
    public GameObject Result;//���U���g�I�u�W�F�N�g�̊i�[
    // Start is called before the first frame update
    void Start()
    {

        result_text.text = "Score:" + Scorenum.score_num;

        //�Q�[���̌��ʂɂ���ĕ\������e�L�X�g��ύX
        if(result.resulttri==-1)
        {
            soundManager.PlaySe(clip);
            result2_text.text = "GameOver" ;
            Result.SetActive(true);//�؂��܂ꂽ�摜��\��
        }
        else
        {
            soundManager.PlaySe(clip2);
            result2_text.text = "TimeUP";

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
