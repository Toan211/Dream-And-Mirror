using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    static public DialogManager m_Singleton;

    public GameObject m_canvas;
    public TextMeshProUGUI m_name;
    public TextMeshProUGUI m_contents;
    private void Awake()
    {
        if(m_Singleton == null)
        {
            m_Singleton = this;
        }
    }

    public void setDialog(string name, string contents)
    {
        this.m_name.text = name;
        this.m_contents.text = contents;

        this.m_canvas.SetActive(true);
    }

    public void closeDialog()
    {
        this.m_canvas.SetActive(false);
    }
}
