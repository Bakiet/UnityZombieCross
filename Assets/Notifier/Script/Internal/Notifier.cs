using UnityEngine;

public class Notifier : MonoBehaviour {


    public string m_Title = "";
    public string m_Text = "";
    public float m_Time = 10f;
    public PlaceScreen m_Place = PlaceScreen.Middle;
    public int clip = 0;
    public GameObject m_Target = null;
	public GameObject m_Image = null;
    public string m_Method = "";
    [HideInInspector]
    public bool AlredyShow = false;
}