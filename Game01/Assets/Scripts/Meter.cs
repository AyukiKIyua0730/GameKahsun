/*
 * 真ん中のメーターと木の画像表示の処理
 * 操作部分の処理もあり
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class result//リザルトの結果をリザルトシーンに格納するため。-1で失敗
{
    public static int resulttri = 0;

}




public class Meter : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;//サウンドマネージャー
    [SerializeField]
    AudioClip clip;//効果音
    [SerializeField]
    AudioClip clip2;//効果音


    float maxHp = 5000;//メーターのMAX
    float currentHp;//メーターの現在値
    float damage = 1.0f;//1フレーム分の移動量
    //Sliderを入れる
    public Slider slider;//スライダー格納
    public GameObject damageObject;//ダメージを与えるときのダメージシステム格納
    public GameObject triggerObject;//矢印オブジェクト格納
    public GameObject startObject;//StartScript格納
    public GameObject rotateObject;//杉の木格納オブジェクト
    private SpriteRenderer spriteRenderer;//スプライトを格納
    private bool damagetrigger;//ダメージトリガーのbool代数

    Startscript startscript;//スタートスクリプト格納
    Vector2 v;//矢印移動用
    GameManager s1;//シーン遷移用
    Transform tTransform;//矢印transform
    enemyscript d1;//ダメージスクリプト格納
    [SerializeField] private Sprite standard;//木通常格納
    [SerializeField] private Sprite rightsprite;//右傾木格納
    [SerializeField] private Sprite rightspriteb;//右傾折木格納
    [SerializeField] private Sprite leftsprite;//左傾木格納
    [SerializeField] private Sprite leftspriteb;//左傾折木格納



    void Start()
    {
        result.resulttri = 0;//リザルト変数は初期値に
        damagetrigger = false;
        startscript = startObject.GetComponent<Startscript>();//スタートスクリプト格納
        d1 = damageObject.GetComponent<enemyscript>();//エネミースクリプト格納
        tTransform= triggerObject.transform;//矢印オブジェクトのTransform格納
        v = tTransform.position;//上を移動用に格納
        s1 = this.GetComponent<GameManager>();//シーンマネージャー格納
        spriteRenderer = rotateObject.GetComponent<SpriteRenderer>();//杉の木オブジェクト格納

        slider.value = 0f;//メーターを真ん中に

        currentHp = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //操作部分の処理

        if(startscript.ready != false)//ゲームが開始していれば
        {
            rotateObject.transform.position = new Vector3(0f, 0.12f, -1f);//杉の木を真ん中に
            spriteRenderer.sprite = standard;//木通常スプライトに

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //左キーを押したとき
               
                damage *= 1.01f;//メーターをを段々加速
               
               
                spriteRenderer.sprite = leftsprite;//左傾木スプライトに
                currentHp = currentHp - damage;
                if (damagetrigger == false)//矢印が左にあるとき
                {

                    if (currentHp <= -2500.0f)//矢印を超えたとき
                    {
                        //キャラクターにダメージを与えて矢印を右に
                        v = new Vector2(1.5f, -2.5f);
                        tTransform.position = v;
                        d1.damage(10f);
                        damagetrigger = true;
                    }
                }
           
                slider.value = (float)currentHp / (float)maxHp; //スライダーの更新

                if ((slider.value >= 1) || (slider.value <= -1))//メーターが左端に行ったとき
                {
                    //コルーチン関数に飛ぶ
                    StartCoroutine("End");


                }

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //右キーを押したとき
                damage *= 1.01f;//メーターをを段々加速

                spriteRenderer.sprite = rightsprite;//右傾木スプライトに
                currentHp = currentHp + damage;
                if (damagetrigger == true)//矢印が右にあるとき
                {
                    if (currentHp >= 2500.0f)//矢印を超えたとき
                    {
                        //キャラクターにダメージを与えて矢印を左に
                        v = new Vector2(-1.5f, -2.5f);
                        tTransform.position = v;
                        d1.damage(10f);
                        damagetrigger = false;
                    }
                }
               


                slider.value = (float)currentHp / (float)maxHp;//スライダーの更新

                if ((slider.value >= 1) || (slider.value <= -1))//メーターが右端に行ったとき
                {
                    //コルーチン関数に飛ぶ
                    StartCoroutine("End");


                }
            }
            else//何も操作していないとき
            {
                //メーターを段々真ん中に戻す処理
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

    IEnumerator End() //コルーチン関数の名前
    {
        //木が折れたとき(メーターが端まで到達したとき)の処理

        //傾いている方向によって折れたスプライトを変更
        if(spriteRenderer.sprite == rightsprite)
        {
            spriteRenderer.sprite = rightspriteb;
        }
        else
        {
            spriteRenderer.sprite = leftspriteb;
        }
        //木が折れた音とBGMの停止
        soundManager.PlaySe(clip2);
        soundManager.StopBgm(clip);

        startscript.ready = false;
 //真ん中のテキストを透明に
        startscript.ready_text.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        result.resulttri = -1;

        startscript.ready_text.text = "終了！!!";
        yield return new WaitForSeconds(3.0f);
        s1.LoadScene("Result");//リザルトシーンに飛ぶ


    }
}
