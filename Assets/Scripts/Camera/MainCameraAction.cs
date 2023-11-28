using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraAction : MonoBehaviour
{

    public GameObject Target; //ī�޶� ����ٴ� Ÿ��

    public float offsetX = 0.0f;    //ī�޶��� X��ǥ
    public float offsetY = 0.0f;    //ī�޶��� Y��ǥ
    public float offsetZ = -10.0f;   //ī�޶��� Z��ǥ

    public float CameraSpeed = 10.0f;   //ī�޶��� �ӵ�
    Vector3 TargetPos;                  //Ÿ���� ��ġ

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Ÿ���� x,y,z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = new Vector3
            (Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

        //ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
}