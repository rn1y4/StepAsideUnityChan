using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    //MainCameraオブジェクトを取得
    private GameObject mainCameraObj;
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        //カメラオブジェクトの取得
        mainCameraObj = GameObject.Find("Main Camera");
        cam = mainCameraObj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //画面外のオブジェクトを破棄する
      if (gameObject.transform.position.z < mainCameraObj.transform.position.z)
      {
            Debug.Log("DESTROY " + this.gameObject.name);
            Destroy(this.gameObject);
       }
    }
}
