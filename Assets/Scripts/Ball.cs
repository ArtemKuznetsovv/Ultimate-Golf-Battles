using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_PlayerLastPosition;

    private Rigidbody m_RigidBody;
    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = this.GetComponent<Rigidbody>();
        m_RigidBody.sleepThreshold = 0.9f; // Default is 0.005
        m_RigidBody.maxAngularVelocity = Mathf.Infinity;
    }

    // Update is called once per frame

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided");
        if(other.gameObject.tag == "Terrain")
        {
            RestoreToLastPosition();
            m_RigidBody.Sleep();
        }
    }

    public void RestoreToLastPosition()
    {
        transform.position = m_PlayerLastPosition;
    }

    public void UpdateLastPosition()
    {
        m_PlayerLastPosition = transform.position;
    }
}
