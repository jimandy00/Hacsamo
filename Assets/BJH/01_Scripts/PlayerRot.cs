using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// 마우스 회전으로 플레이어가 회전한다.
public class PlayerRot : MonoBehaviourPun
{
    private Vector3 dir = Vector3.zero;

    private void Update()
    {
        // 내 플레이어 가 아니면 걷지 않는다.
        if (!photonView.IsMine)
        {
            return;
        }

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        if (dir != Vector3.zero)
        {
            transform.forward = dir;
        }
    }
}
