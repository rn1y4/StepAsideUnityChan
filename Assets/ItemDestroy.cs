using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��ʊO�̃I�u�W�F�N�g��j������
      if (!GetComponent<Renderer>().isVisible)
      {
            Debug.Log("DESTROY" + this.gameObject.name);
            Destroy(this.gameObject);
       }
    }

    //private void OnBecameInvisible()
    //{
    //    Debug.Log("DESTROY" + this.gameObject.name);
    //    Destroy(this.gameObject);
   // }
}
