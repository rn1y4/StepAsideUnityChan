using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //conePrefab������
    public GameObject conePrefab;
    //�X�^�[�g�n�_
    private int startPos = 30;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    //unity�����I�u�W�F�N�g���擾
    private GameObject unityChan;
    //unity�����ƃA�C�e���̐�������
    public int itemDistance = 20;
    //�A�C�e���Ԃ̐�����苗��
    public int itemInterval = 15;
    //�O��A�C�e�����������ʒu
    public int lastItemPosition;
 


    // Start is called before the first frame update
    void Start()
    {
        unityChan = GameObject.Find("unitychan");
        //�ŏ��̃A�C�e�������ʒu���w��
        this.lastItemPosition = startPos + itemDistance;
    }
    

    // Update is called once per frame
    void Update()
    {
        //�X�^�[�g�ʒu�����苗���悩�S�[���ʒu�����苗����O��Unity����񂪂���Ƃ��̂݃A�C�e�������������
        if (startPos < unityChan.transform.position.z && unityChan.transform.position.z < goalPos - itemDistance)
        {
            //unity����񂪑O��A�C�e�����������Ƃ��ɂ������W�𒴂����Ƃ��V�K�A�C�e�������ɓ���
            if (lastItemPosition <= unityChan.transform.position.z)
            {
                //Unity����񂩂��苗����ɃA�C�e����z�u
                CreateItem(unityChan.transform.position.z + itemDistance + itemInterval);
                //�O�񐶐��ʒu�̍X�V
                this.lastItemPosition += this.itemInterval;
            }            
        }
    }

    void CreateItem(float distance)
    {
        //���̋������ƂɃA�C�e���𐶐�
        //for (int i = startPos; i < goalPos; i += this.itemInterval)
        // {
            //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //�R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, distance);
                }
            }
            else
            {
                //���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);
                    //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    //int offsetZ = Random.Range(-5, 6);
                    //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, distance);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, distance);
                    }
                }
            }  
�@   }
}