using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace RoutesManagement
{
    [Serializable]
    public class Option
    {
        public string m_content;
        public UnityEvent m_resultTo;
    }
}