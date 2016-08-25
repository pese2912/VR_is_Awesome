using UnityEngine;
using System.Collections;

public class DestroyTimeout : MonoBehaviour {

    public float timer = 15.0f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, timer); // 15초뒤에 제거
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
