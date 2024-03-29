/*
 * リザルト結果に応じて表示を変えるスクリプト
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultscript : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;//サウンドマネージャーの格納
    [SerializeField]
    AudioClip clip;//オーディオソースの格納
    [SerializeField]
    AudioClip clip2;
    public Text result_text;//リザルトテキストの格納
    public Text result2_text;//リザルトテキスト2の格納
    public GameObject Result;//リザルトオブジェクトの格納
    // Start is called before the first frame update
    void Start()
    {

        result_text.text = "Score:" + Scorenum.score_num;

        //ゲームの結果によって表示するテキストを変更
        if(result.resulttri==-1)
        {
            soundManager.PlaySe(clip);
            result2_text.text = "GameOver" ;
            Result.SetActive(true);//木が折れた画像を表示
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
