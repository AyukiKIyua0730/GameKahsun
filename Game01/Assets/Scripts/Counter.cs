/*
 * 主に制限時間とスコアの処理を行う際のスクリプト
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
    SoundManager soundManager;//サウンドマネージャー格納
    [SerializeField]
    AudioClip clip;//効果音格納
    [SerializeField]
    AudioClip clip2;


    public GameObject score_object;//スコアUI
    public GameObject time_object;//制限時間UI
   

   
    public float countdown = 60.0f;//制限時間(60秒で設定)
   

    public GameObject startObject;//スタートオブジェクト
    Startscript startscript;//スタートスクリプト
    public GameObject resultObject;//リザルトオブジェクト
    GameManager s1;//ゲームマネージャー
    Animator anim;//アニメーター格納
    Text time_text;//制限時間テキスト
    Text score_text;//スコアテキスト


    // Start is called before the first frame update
    void Start()
    {
        Scorenum.score_num = 0;//スコアを初期値に
        s1 = this.GetComponent<GameManager>();//シーンマネージャー格納
        time_text = time_object.GetComponent<Text>();//制限時間テキスト格納
        score_text = score_object.GetComponent<Text>();//スコアテキスト格納
        startscript = startObject.GetComponent<Startscript>();//スタートスクリプト格納
        anim = startscript.Readygo.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //毎フレームごとにカウントダウンとスコアの更新
       
        if (startscript.ready != false)//ゲームが開始していれば
        {
            
            
            score_text.text = "Score:" + Scorenum.score_num;

            countdown -= Time.deltaTime;

            time_text.text = countdown.ToString("f1") + "秒";

            //countdownが0以下になったとき
            if (countdown <= 0)
            {
                //コルーチン関数に飛ぶ
                StartCoroutine("End");
                
                

            }
        }
    }

    IEnumerator End() //コルーチン関数の名前
    {
        //制限時間が0秒になった時の処理

        Text result_text = resultObject.GetComponent<Text>();//リザルトテキストの格納
        startscript.ready = false;//ゲームの操作を止める
        

        soundManager.StopBgm(clip);//サウンド再生
        result_text.text = "終了！!!";//終了のテキスト表示
        yield return new WaitForSeconds(3.0f);
        s1.LoadScene("Result");//リザルトシーンに飛ぶ
        

    }
}
