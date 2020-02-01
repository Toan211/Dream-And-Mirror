using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogManament;
using RoutesManagement;
public class GameManager : MonoBehaviour
{
    static public GameManager m_Singleton;

    public PlayerControl m_playerControlScript;
    public PlayerMotor m_playerMotorScript;

    private void Awake()
    {
        if(!m_Singleton)
        {
            m_Singleton = this;
        }
    }

    //Make user can't control character anymore
    public void disableCharacterController()
    {
        m_playerControlScript.enabled = false;
        m_playerMotorScript.enabled = false;
    }

    public void enableCharacterController()
    {
        m_playerControlScript.enabled = true;
        m_playerMotorScript.enabled = true;
    }

}
