using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	   StartCoroutine(RepositionWithDelay());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator RepositionWithDelay()
    {
        while (true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(5f);
        }
    }
    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        transform.position = new Vector3(x,0.0f,z);
    }
}
