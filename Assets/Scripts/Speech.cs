using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogManament
{
	[System.Serializable]
	public class Speech
	{
		public string m_speaker;
		[TextArea(3, 5)] public string m_speech;
	}
}