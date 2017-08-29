using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentScaleManager : MonoBehaviour {

	public delegate void ContentScaleChanged(Vector3 newScale, Vector3 prevScale); 
	public static ContentScaleChanged ContentScaleChangedEvent;

	[SerializeField]
	private Vector3 m_ContentScale = Vector3.one;

	private Touch m_TouchZoom0;
	private Touch m_TouchZoom1;
	private float m_LastTouchDistance;
	public float m_ZoomSpeed = 0.5f;

	void Start()
	{
		Vector3 prevScale = gameObject.transform.localScale;
		gameObject.transform.localScale = m_ContentScale;
		if (ContentScaleChangedEvent != null)
			ContentScaleChangedEvent(m_ContentScale, prevScale);
	}
	
	public Vector3 ContentScale {
		get { return m_ContentScale; }
		set { 
			if (value != m_ContentScale)
			{
				Vector3 prevScale = m_ContentScale;
				m_ContentScale = new Vector3(Mathf.Clamp(value.x, 1.0f, 100.0f), Mathf.Clamp(value.y, 1.0f, 100.0f), Mathf.Clamp(value.z, 1.0f, 100.0f));
				gameObject.transform.localScale = value;
				if (ContentScaleChangedEvent != null)
				{
					ContentScaleChangedEvent(m_ContentScale, prevScale);
				}
			}
		}
	}
}
