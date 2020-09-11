using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignCamera : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    [SerializeField]
    private Vector3 deltaPosition;


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            Player.position + new Vector3(
                -transform.forward.x * deltaPosition.x,
                deltaPosition.y,
                -transform.forward.z * deltaPosition.z), Time.deltaTime);
    }
}
