using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    //MainCamera�I�u�W�F�N�g���擾
    private GameObject mainCameraObj;
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        //�J�����I�u�W�F�N�g�̎擾
        mainCameraObj = GameObject.Find("Main Camera");
        cam = mainCameraObj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //��ʊO�̃I�u�W�F�N�g��j������
      if (gameObject.transform.position.z < mainCameraObj.transform.position.z)
      {
            Debug.Log("DESTROY " + this.gameObject.name);
            Destroy(this.gameObject);
       }
    }
}
