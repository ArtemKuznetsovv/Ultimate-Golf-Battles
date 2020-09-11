using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeManager : MonoBehaviour
{
    [SerializeField]
    private PickStrength m_StrengthPicker;

    [SerializeField]
    private Ball m_playerBall;

    [SerializeField]
    private DirectionArrow m_3DArrow;

    [SerializeField]
    private UI_Manager m_UIManager;

    [SerializeField]
    private AudioManager m_AudioManager;


    private float m_ShootFactor;
    private Transform m_ShootAngleTransform;
    private Vector3 m_ShootAngle;

    public int m_NumberOfStrokes = 0;
    public int m_BestOfStrokes;


    private bool m_IsReadyToShoot = false;
    private eStrokeMode m_CurrentMode = eStrokeMode.ReadyToShoot;





    private enum eStrokeMode
    {
        ReadyToShoot,
        Aiming,
        PickingStrength,
        BallShot
    };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_CurrentMode)
        {
            case eStrokeMode.ReadyToShoot: When_ReadyToShot(); break;
            case eStrokeMode.Aiming: When_Aiming(); break;
            case eStrokeMode.PickingStrength: When_PickingStrength(); break;
        }
        prepareTheBall();
        

        
    }

    private void prepareTheBall()
    {
        if (m_playerBall.GetComponent<Rigidbody>().IsSleeping() && m_CurrentMode == eStrokeMode.BallShot)
        {
            m_CurrentMode = eStrokeMode.ReadyToShoot;
            m_playerBall.UpdateLastPosition();
        }
    }

    

    private void When_ReadyToShot()
    {
        if (isClicked())
        {
            m_3DArrow.Show(true);
            m_CurrentMode = eStrokeMode.Aiming;
        }
    }

    private void When_Aiming()
    {
        if (isClicked())
        {
            m_3DArrow.Show(false);
            m_CurrentMode = eStrokeMode.PickingStrength;
            m_StrengthPicker.gameObject.transform.parent.gameObject.SetActive(true);
            m_ShootAngle = m_3DArrow.transform.parent.transform.localEulerAngles;
        }
    }

    private void When_PickingStrength()
    {
        m_ShootFactor = m_StrengthPicker.StrokeForceMeter();
      
        if (isClicked())
        {
            m_IsReadyToShoot = true;
            m_StrengthPicker.gameObject.transform.parent.gameObject.SetActive(false);

        }
    }

    void FixedUpdate()
    {
        if(m_IsReadyToShoot == true)
        {

            m_IsReadyToShoot = false;
            m_CurrentMode= eStrokeMode.BallShot;

            // shoot according to m_ShootFactor ->
            Vector3 forceVector = new Vector3(m_ShootFactor, 0, 0);
            m_playerBall.GetComponent<Rigidbody>().AddForce(
                Quaternion.Euler(0, m_ShootAngle.y - 90, 0) * forceVector,
                ForceMode.Impulse);
            m_AudioManager.Play("Swing");
            m_NumberOfStrokes++;
            m_UIManager.UpdateCurrentScore(m_NumberOfStrokes);
        }
    }

    
    private bool isClicked()
    {
        return Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
    }
}
