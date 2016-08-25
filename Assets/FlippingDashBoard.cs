using UnityEngine;
using System.Collections;

public class FlippingDashBoard : MonoBehaviour {

    private HeadGesture gesture;
    private GameObject dashboard;
    private bool isOpen = true;
    private Vector3 startRotation;
    private float timer = 0.0f;
    private float timeReset = 2.0f;



    //반응형 오브젝트 UI
	// Use this for initialization
	void Start () {

        gesture = GetComponent<HeadGesture>();
        dashboard = GameObject.Find("DashBoard");
        startRotation = dashboard.transform.eulerAngles;

        CloseDashboard();
	}
	
	// Update is called once per frame
	void Update () {

        if (gesture.isMovingDown) // 아래방향볼때
        {
            OpenDashboard();// 대쉬보드 열기
        }
        else if (!gesture.isFacingDown)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                CloseDashboard();
            }
        }
        else
        {
            timer = timeReset;
        }
        
	}
    private void CloseDashboard()
    {
        if (isOpen)
        {
            dashboard.transform.eulerAngles = new Vector3(180.0f, startRotation.y, startRotation.z);
            isOpen = false;
        }
    }
    private void OpenDashboard()
    {
        if (!isOpen)
        {
            dashboard.transform.eulerAngles = startRotation;
            isOpen = true;
        }
    }
}
