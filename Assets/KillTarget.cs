using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillTarget : MonoBehaviour {


    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public int score;
    public Text scoreText;
    private float countDown;

	// Use this for initialization
	void Start () {
        score = 0;
        countDown = timeToSelect;
        hitEffect.enableEmission = false;
        scoreText.text = "Score : 0";

    }
	
	// Update is called once per frame
	void Update () {

        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray ,out hit) && (hit.collider.gameObject == target))
        {
            if(countDown > 0.0f)
                //에단이 조준되었을 때
            {
                countDown -= Time.deltaTime;
                hitEffect.transform.position = hit.point;
                hitEffect.enableEmission = true;
            }else // 에단이 죽었을 때
            {
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                score += 1;
                scoreText.text = "Score : "+score;
                countDown = timeToSelect;
                SetRandomPosition();
            }
        }else
        {
            //리셋
            countDown = timeToSelect;
            hitEffect.enableEmission = false;
        }
	}
    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0, z);
    }
}
