using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LookMoveTo : MonoBehaviour {

    public GameObject ground;
    public Transform infoBubble;

    private Text infoText;

	// Use this for initialization
	void Start () {
	    if(infoBubble != null)
        {
            infoText = infoBubble.Find("Text").GetComponent<Text>();
        }
	}
	
	// Update is called once per frame
	void Update () { 
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100f); // 카메라가 보는 광선을 그려줌

        ray = new Ray(camera.position, camera.rotation * Vector3.forward * 100f); // 카메라가 보는 광선 

        hits = Physics.RaycastAll(ray); //광선과 충돌한 오브젝트 배열
        for (int i = 0; i < hits.Length; i++) // 하나씩 검사
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;



            if (hitObject == ground) //땅과 충돌할 경우
            {
                if (infoBubble != null) //정보풍선에 x,z축 텍스트 입력
                {
                    infoText.text = "x:" + hit.point.x.ToString("F2") + ",z:" +
                        hit.point.z.ToString("F2");
                    infoBubble.LookAt(camera.position);
                    infoBubble.Rotate(0f, 180f, 0f);
                    
                }
                transform.position = hit.point; //카메라가 보는방향으로 이동

            }

        }
	}
}
