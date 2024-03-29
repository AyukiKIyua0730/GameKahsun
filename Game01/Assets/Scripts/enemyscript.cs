/*
 * 処理をエネミー全体に同時に処理を与える場合のスクリプト
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class enemyscript : MonoBehaviour
{
   

    [SerializeField]
    SoundManager soundManager;//効果音
    [SerializeField]
    AudioClip clip;


 
    public Sprite[] ofsImage;//キャラの立ち絵を格納
    public Sprite[] animImage;//キャラのくしゃみ

    [SerializeField]
    private GameObject[] enemyobj;//エネミーのobj格納

    private enemy[] e =new enemy[5];//enemy.csを格納
    int i = 0;


   
    public GameObject CounterObject;//Counter.cs格納オブジェクト
    public GameObject CounterObject2;//制限時間テキストオブジェクト
    public GameObject AddtimeObject;//時間加算テキストオブジェクト
    private Animator anim;//時間加算アニメーション
    private Animator anim2;//スコア増加アニメーション


    private Text addtime_text;//時間加算テキスト
    Counter counter;//Counter.cs
  
    int c = 0;
    
    float b = 0.0f;




 
    void Start()
    {
        //コンポーネント取得
        addtime_text = AddtimeObject.GetComponent<Text>();
        anim = AddtimeObject.GetComponent<Animator>();
        anim2 = CounterObject2.GetComponent<Animator>();
        counter = CounterObject.GetComponent<Counter>();

    }
    void Update()
    {
        //アニメーションを開始待機状態にしておく
        anim.SetBool("add", false);
        anim2.SetBool("count", false);
        

    }
    public void damage(float damage)
    {
        //Meterからの処理をenemyに格納する処理
        for(int i=0;i<5;i++)
        {
            e[i] = enemyobj[i].GetComponent<enemy>();
            e[i].damage(damage);
        }
        

    }

    public void addscore()
    {
        c++;//加算するスコアを計算
        b += 3.0f;
        Scorenum.score_num += 1;//スコア加算
        soundManager.PlaySe(clip);
        anim2.SetBool("count", true);//スコアアニメーション
        if(c >= 1)
        {
            //加算時間が重複したときもまとめて表示
            addtime_text.text = "+" + b.ToString("f1");
            anim.SetBool("add", true);//時間加算アニメーション

            counter.countdown += b;//制限時間に加算
            b = 0.0f;//加算時間をリセット
            c = 0;//重複分をリセット
        }

       
    }

        
        

    

    


    

    



}
