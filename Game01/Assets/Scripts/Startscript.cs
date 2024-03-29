using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startscript : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    AudioClip clip;


    public GameObject Readygo;//テキストオブジェクトの格納
    public bool ready;//bool代数
    public Text ready_text;//テキスト格納
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = Readygo.GetComponent<Animator>();
        ready = false;
        StartCoroutine("Corou1");
        ready_text = Readygo.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Corou1() //コルーチン関数の名前
        {
        //コルーチンの内容
        
        Debug.Log("スタート");
            yield return new WaitForSeconds(2.0f);
        
        ready_text.text = "GO!!!";
        yield return new WaitForSeconds(3.0f);
        anim.Play("Animetor/Ready Animation", 0, 0.8f);
        Readygo.gameObject.SetActive(false);
        ready = true;
        soundManager.PlayBgm(clip);
        Debug.Log("スタートから5秒後");
        }
}
