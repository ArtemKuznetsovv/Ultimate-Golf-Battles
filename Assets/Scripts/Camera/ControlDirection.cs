using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDirection : MonoBehaviour
{
    [SerializeField]
    private Transform m_BallTransform;
    private Vector3 m_lastMousePos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = m_BallTransform.position;
        transform.RotateAround(transform.position, transform.up, (Input.mousePosition - m_lastMousePos).x * 0.5f);
        m_lastMousePos = Input.mousePosition;
    }
}
