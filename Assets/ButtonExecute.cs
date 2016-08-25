using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonExecute : MonoBehaviour {

    public float timeToSelected = 2.0f;
    private float countDown;
    private GameObject currentButton;
  
    //버튼을 보면 강조
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation*Vector3.forward);
        RaycastHit hit;
        GameObject hitButton = null;
        PointerEventData data = new PointerEventData(EventSystem.current);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Button") //카메라와 버튼태그 충돌시
            {
                hitButton = hit.transform.parent.gameObject;//구체의 부모오브젝트를 할당
            }
        }
        if (currentButton != hitButton)
        {
            if (currentButton != null) { //하이라이트 끄기
                ExecuteEvents.Execute<IPointerExitHandler>(currentButton,data,ExecuteEvents.pointerExitHandler);
            }
            currentButton = hitButton;
            if(currentButton != null) // 하이라이트
            {
                ExecuteEvents.Execute<IPointerEnterHandler>(currentButton, data, ExecuteEvents.pointerEnterHandler);
                countDown = timeToSelected;
            }
        }
        if (currentButton != null)
        {
            countDown -= Time.deltaTime;
            if (countDown < 0.0f) // 응시
            {
                ExecuteEvents.Execute<IPointerClickHandler>(currentButton, data, ExecuteEvents.pointerClickHandler);
                countDown = timeToSelected;
            }
        }
	}
}
