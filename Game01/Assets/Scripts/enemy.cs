/*
     * キャラクター個々に処理を行う際のスクリプト
     */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    
    public GameObject obj2;//花粉prefab
    public GameObject slider;//子スライダー

    public Slider sliderdata;//スライダーコンポーネント
    public Animator anim3;//花粉が落ちるアニメーション
    public GameObject enemyObject;//enemyscript
    Sprite Image;//enemyのスプライト
    Sprite animImage;//くしゃみしたときのスプライト
    private float maxHP=30f;//maxHP
    private float currentHp=30f;//HP
    enemyscript e;//enemyscript格納用
    [SerializeField]private Vector2 v;//指定位置
    private float speed = 15.0f;//移動

    
    // Start is called before the first frame update
    void Start()
    {
        sliderdata = slider.GetComponent<Slider>();//スライダーのコンポーネントを格納
        e = enemyObject.GetComponent<enemyscript>();//enemyscript格納
        Imagechange();//ランダムにスプライト変更
        spawn();//初期位置を画面外に
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, v, speed * Time.deltaTime);//指定位置に移動
    }

    public void damage(float damage)
    {
        //ダメージを受けたときの関数
        anim3.SetBool("FPbool", true);//花粉アニメーション開始
        gameObject.GetComponent<SpriteRenderer>().sprite = animImage;//立ち絵をくしゃみ状態に
        currentHp = currentHp - damage;//ダメージを与える
        sliderdata.value = currentHp / maxHP;//スライダーの更新
        if (currentHp <= 0)
        {
            //HPが0になったとき
            Imagechange();//キャラ変更
            e.addscore();//スコアスクリプト
            delete();//HPの変更
            spawn();//画面外に移動

        }
        Invoke(nameof(DelayMethod), 1.5f);
    }
    void DelayMethod()
    {
        //時間経過後にアニメーションを終了させる関数
        anim3.SetBool("FPbool", false);//花粉アニメーションを終了
        

    }

    public void delete()
    {
        //HPが0になったとき新しくHPの再設定をします。その際に体力は前回より高くなるように

        //元のHP*0.5～1.5f
        float r = Random.Range(1.0f, 1.5f);
        
        maxHP = maxHP * r;//
        currentHp =maxHP;
        sliderdata.value = currentHp / maxHP;//スライダーの更新
       
    }
    public void Imagechange()
    {
        //キャラクターの立ち絵をランダムに変更します。主にゲーム開始時とHPが0になったとき
        this.gameObject.GetComponent<SpriteRenderer>().sprite = e.ofsImage[Random.Range(0, 5)];//格納するスプライトをランダムに指定
        //格納したスプライトと同じ立ち絵のくしゃみのスプライトも一緒に格納
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
        //画面外からやって来るように見せるため画面外にキャラクターを登場させてます。Uodateで指定の位置に移動
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
