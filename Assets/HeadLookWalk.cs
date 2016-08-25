using UnityEngine;
using System.Collections;

public class HeadLookWalk : MonoBehaviour {

    //카메라가 보는 방향으로 움직이기
    public float velocity = 0.7f; // 보통인간이 1초에 1.4미터 이동 , 그에 반으로 이동하자

    private CharacterController controller;
	// Use this for initialization
	void Start () {

        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        //Vector3 moveDirection = Camera.main.transform.forward;
        //moveDirection *= velocity * Time.deltaTime;
        //moveDirection.y = 0.0f;
        //controller.Move(moveDirection);
        //같은표현, 대신 중력을 적용
        controller.SimpleMove(Camera.main.transform.forward * velocity);
      
	}
}
