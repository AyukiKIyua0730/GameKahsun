using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformtree : MonoBehaviour
{
    /*private Rigidbody rb;
    float speed = 1.0f;
    float radius = 3.0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.MovePosition(
            new Vector2(
                radius * Mathf.Sin(Time.time * speed),
                radius * Mathf.Cos(Time.time * speed)
             )
        );
    }*/
    public float radius = 10f;

    private Vector3 initPos;
    float speed =0f;
    private Vector2 pos;
    bool push = false;
    private float totalTime = 0f;
    private float Addforce = 0f;
    private float angularVelocity = 0f;
    private float angularAcceleration=0f;
    [SerializeField] GameObject target;

    void Start()
    {

        
        /*float phase = 0.5f * Mathf.PI;

        float xPos = radius * Mathf.Cos(phase);
        float yPos = radius * Mathf.Sin(phase);

        pos = new Vector2(xPos, yPos);
        gameObject.transform.position = pos;
        */
        initPos = gameObject.transform.position;
        
    }
    void Update()
    {
        //totalTime = Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            push = true;
            Addforce += 0.00001f;
            Addforce += Time.deltaTime;

            
            gameObject.transform.RotateAround(target.transform.position, Vector3.forward, 10f * Time.deltaTime * Addforce);
            pos = gameObject.transform.position;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            push = true;
            Addforce += 0.00001f;
            Addforce += Time.deltaTime;
          
            gameObject.transform.RotateAround(target.transform.position, Vector3.forward, -10f * Time.deltaTime * Addforce);
            pos = gameObject.transform.position;
        }
        else
        {
            push = false;
        }
        
        
        if (push == false)
        {
            
            if (pos.x > target.transform.position.x)
            {
                Debug.Log("A");
               
                
                Addforce *= 0.85f;
                angularAcceleration = Addforce;
                angularVelocity += (angularAcceleration * Time.deltaTime);
                gameObject.transform.RotateAround(target.transform.position, Vector3.forward, angularVelocity);
                pos = gameObject.transform.position;
            }
            else
            {
                Debug.Log("B");


                
                Addforce *= 0.85f;
                angularAcceleration = Addforce;
                angularVelocity -= (angularAcceleration * Time.deltaTime);
                gameObject.transform.RotateAround(target.transform.position, Vector3.forward, angularVelocity);
                pos = gameObject.transform.position;
            }
            Debug.Log(Addforce);

            /*if (initPos.x < pos.x)
            {
                Debug.Log("A");

                Addforce = 0.0000f;
                Addforce += Time.deltaTime;

                // gameObject.transform.position = pos;
                gameObject.transform.RotateAround(target.transform.position, Vector3.forward, 10f * Time.deltaTime / Addforce);
                pos = gameObject.transform.position;
                push = false;
            }
            else if (initPos.x > pos.x)
            {
                Debug.Log("B");

                Addforce = 0.0000f;
                Addforce += Time.deltaTime;

                gameObject.transform.RotateAround(target.transform.position, Vector3.forward, -10f * Time.deltaTime / Addforce);
                pos = gameObject.transform.position;
                push = false;
            }*/
        }


        
        
    }
    /// <Summary>
    /// オブジェクトの位置を計算するメソッドです。
    /// </Summary>
    /// 
    
    /*
    private float moveSpeed = 0.01f;

    private float circle_radius = 3.0f;

    private Vector2 initPosition;

    private float Addfoce;
    void Start()
    {
        Vector2 pos = transform.position;
        float rad = 1.0f * Mathf.Rad2Deg;

        pos.x = Mathf.Cos(rad) * circle_radius;

        pos.y = Mathf.Sin(rad) * circle_radius;
        transform.position = pos;
        initPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Addfoce += Time.deltaTime;
            Vector2 pos = transform.position;
            moveSpeed += 0.00001f;
            float rad = moveSpeed * Mathf.Rad2Deg * Addfoce;

            pos.x = Mathf.Cos(rad) * circle_radius;

            pos.y = Mathf.Sin(rad) * circle_radius;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Addfoce += Time.deltaTime;
            Vector2 pos = transform.position;
            moveSpeed -= 0.00001f;
            float rad = moveSpeed * Mathf.Rad2Deg * Addfoce;

            pos.x = Mathf.Cos(rad) * circle_radius;

            pos.y = Mathf.Sin(rad) * circle_radius;

            transform.position = pos;
        }
        else
        {
            
        }
        

        
    }*/
}
