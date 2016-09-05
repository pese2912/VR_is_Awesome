using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AvatarMultiPlayer : NetworkBehaviour {

    // 로컬 플레이어가 스폰될때만 카메라를 상속받게 하기를 원하기 때문이다.
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GameObject camera = GameObject.FindWithTag("MainCamera");
        transform.parent = camera.transform;
        transform.localPosition = Vector3.zero;
    }
}
