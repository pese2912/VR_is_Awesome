using UnityEngine;
using System.Collections;

public class HeadGesture : MonoBehaviour {

    public bool isFacingDown = false;
    public bool isMovingDown = false;
    private float sweepRate = 100.0f;
    private float previousCameraAngle;
    

	// Use this for initialization
	void Start () {

        previousCameraAngle = CameraAngleFromGround();

	}
	
	// Update is called once per frame
	void Update () {

        isFacingDown = DetectFacingDown();
        isMovingDown = DetectMovinggDown();
	}
    private bool DetectFacingDown() // 카메라 각도가 수직 아래 방향을 기준으로 60도 안에 있는지 체크
    {
        return (CameraAngleFromGround() < 60.0f);
    }

    private bool DetectMovinggDown() //
    {
        float angle = CameraAngleFromGround(); // 카메라의 x회전각도를 얻고
        float deltaAngle = previousCameraAngle - angle; // 이전프레임의 각도와 비교
        float rate = deltaAngle / Time.deltaTime; // 1초동안의 각도변화를 계산
        previousCameraAngle = angle;
        return (rate >= sweepRate); // 회전속도가 기준 값 이상인지 확인
    }


    private float CameraAngleFromGround()// 머리에서바로 아래 방향을 기준으로 현재 카메라의 상대적인 각도를 얻는다.
    {
        return Vector3.Angle(Vector3.down, Camera.main.transform.rotation * Vector3.forward);
    }


}
