using UnityEngine;
using UnityEngine.UI;

public class PickStrength : MonoBehaviour
{
    [SerializeField]
    private Image m_StrengthBar;

    private float m_StrokeForce = 1f;
    private float m_MaxStrokeForce = 15f;
    private float m_FillDirection = 1;
    private float m_FillSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        m_StrengthBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_StrengthBar.fillAmount = m_StrokeForce / m_MaxStrokeForce;
    }

    public float StrokeForceMeter()
    {
        m_StrokeForce += (m_FillDirection * m_FillSpeed) * Time.deltaTime;
        
        //fill Bar going down
        if (m_StrokeForce > m_MaxStrokeForce)
        {
            m_StrokeForce = m_MaxStrokeForce;
            m_FillDirection = -1;
        }

        //fill Bar going up
        else if (m_StrokeForce < 0)
        {
            m_StrokeForce = 1f;
            m_FillDirection = 1;
        }

        //change colors according to fillamount
        m_StrengthBar.color = Color.green;
        if (m_StrengthBar.fillAmount > 0.3f && m_StrengthBar.fillAmount < 0.6f)
        {
            m_StrengthBar.color = Color.yellow;
        }
        else if (m_StrengthBar.fillAmount > 0.6f && m_StrengthBar.fillAmount < 0.8f)
        {
            m_StrengthBar.color = new Color(252, 88, 0);

        }
        else if (m_StrengthBar.fillAmount > 0.8f)

        {
            m_StrengthBar.color = Color.red;

        }

        return m_StrokeForce;
    }

}
