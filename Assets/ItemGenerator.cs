using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 30;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //unityちゃんオブジェクトを取得
    private GameObject unityChan;
    //unityちゃんとアイテムの生成距離
    public int itemDistance = 20;
    //アイテム間の生成一定距離
    public int itemInterval = 15;
    //前回アイテム生成した位置
    public int lastItemPosition;
 


    // Start is called before the first frame update
    void Start()
    {
        unityChan = GameObject.Find("unitychan");
        //最初のアイテム生成位置を指定
        this.lastItemPosition = startPos + itemDistance;
    }
    

    // Update is called once per frame
    void Update()
    {
        //スタート位置から一定距離先かつゴール位置から一定距離手前にUnityちゃんがいるときのみアイテムが生成される
        if (startPos < unityChan.transform.position.z && unityChan.transform.position.z < goalPos - itemDistance)
        {
            //unityちゃんが前回アイテム生成したときにいた座標を超えたとき新規アイテム生成に入る
            if (lastItemPosition <= unityChan.transform.position.z)
            {
                //Unityちゃんから一定距離先にアイテムを配置
                CreateItem(unityChan.transform.position.z + itemDistance + itemInterval);
                //前回生成位置の更新
                this.lastItemPosition += this.itemInterval;
            }            
        }
    }

    void CreateItem(float distance)
    {
        //一定の距離ごとにアイテムを生成
        //for (int i = startPos; i < goalPos; i += this.itemInterval)
        // {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, distance);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    //int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, distance);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, distance);
                    }
                }
            }  
　   }
}