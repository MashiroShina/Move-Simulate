using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {
        ctrl();
    }

    private void ctrl()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0)
        {
            Vector3 targetDirection = new Vector3(h, 0, v);
            float y = Camera.main.transform.rotation.eulerAngles.y;
            Debug.Log(y);
            Debug.Log(targetDirection);
            targetDirection = Quaternion.Euler(0, y, 0) * targetDirection;
            transform.Translate(targetDirection * Time.deltaTime * 3f, Space.World);
            Quaternion newQuaternion = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, newQuaternion, Time.deltaTime * 10f);

        }
    }
}
