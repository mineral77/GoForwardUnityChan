using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    //Cubeの衝突音
    AudioSource audiosource;
    //InspectorでCubeの衝突音を格納
    [SerializeField]
    AudioClip sound;

    // Use this for initialization
    void Start()
    {
        //CubeのAudioSourceを取得
        audiosource = this.gameObject.GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //あらかじめCubeとgroundにそれぞれTagをつけておく
        //Cubeに接触したオブジェクトがCubeまたは地面の場合
        if(collision.gameObject.tag == "Cube" ||collision.gameObject.tag == "Ground")
        {
            audiosource.PlayOneShot(sound);
        }
    }
    
}