using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    private Transform camTrans;
    private float camHeight = 0.3f;
    private Vector3 camAng;
    void Start()
    {
        mTrans = transform;
        distanceVec = (mTrans.position - player.position);

        camTrans = Camera.main.transform;

        Vector3 startPos = transform.position;

        startPos.y += camHeight;

        camTrans.position = startPos;

        camTrans.rotation = transform.rotation;

        camAng = camTrans.eulerAngles;
        // camTrans.position=new Vector3(transform.position.x,0.3f,transform.position.z);
    }
    private float x = 0, y = 0;

    public float rotateSpeed = 5f;

    private Transform mTrans;

    private Vector3 distanceVec;

    public Transform player;
    private void MOVE()
    {
        x += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        y = Mathf.Clamp(y, -60, 80);
        //根据人物位置确定摄像机的位置，这里用四元数进行了旋转 
        Quaternion camPosRotation = Quaternion.Euler(y, x, 0);
        // mTrans.rotation = camPosRotation;
       
        mTrans.position = Vector3.Lerp(mTrans.position, (camPosRotation * distanceVec + player.position), Time.deltaTime * 5f);
        //camPosRotation* distanceVec返回一个Vector3朝向你的四元数的方向headRotation。
        //Quaternion作用于Vector3的右乘操作（*）返回一个将向量做旋转操作后的向量.
        //得到一个朝向你所要旋转方向的一个向量
        //Debug.Log(mTrans.position + "+" + camPosRotation * distanceVec + "+" + camPosRotation * distanceVec +player.position + "playerpos=" + player.position);
        mTrans.LookAt(player.position);
    }
    void Update()
    {
        // cameraView();
        MOVE();
        //float h = Input.GetAxis("Vertical");
        //float v = Input.GetAxis("Horizontal");
        //if (h != 0 || v != 0)
        //{
        //    transform.Translate(new Vector3(v*Time.deltaTime*50f, 0, h*Time.deltaTime*50f));
        //    //transform.Translate(new Vector3(h, 0, v) * Time.deltaTime, Space.World);
        //}
    }

    private void cameraView()
    {
        float y = Input.GetAxis("Mouse X");

        float x = Input.GetAxis("Mouse Y");

        camAng.x -= x;

        camAng.y += y;

        camTrans.eulerAngles = camAng;

        float camy = camAng.y;

        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, camy, this.transform.eulerAngles.z);

        // Vector3 startPos = transform.position;

        //startPos.y += camHeight;

        //camTrans.position = startPos;
    }
}
