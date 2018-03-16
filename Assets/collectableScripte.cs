using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableScripte : MonoBehaviour
{

    public Transform progress;
    public AudioSource source;
    public GameObject pcc;
    public poolManager pool;
    public string tag;
    private Transform tr;
    private CircleCollider2D cc;

    private float i = 0;
    private Vector3 initPosition;

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        initPosition = tr.position;
        cc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i > 0)
        {
            i += Time.deltaTime * 2;
            tr.position = initPosition + new Vector3(0, CustumEase(i)*2, 0);
        }

        if (i > 1 )
            pool.GiveBack(this.gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            cc.enabled = false;
            pcc.GetComponent<gameManager>().hadCollected(tag, 1);
            source.Play();
            i = Time.deltaTime;
        }
    }

    public float CustumEase(float rate)
    {
        return TweenCore.FloatTools.UniformQuadraticBSpline(rate, new float[] { 0f, 0f, 1f, 0.48f });
    }
}
