using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bl_NotifierManager : MonoBehaviour {

    public bl_Notifier mNotifier = null;

    public List<Notifier> m_Notifiers = new List<Notifier>();
    [Space(5)]
    [Range(0.01f,2.0f)]
    public float Delay = 0.15f;
    //Privates
    private int m_Current = 0;
    private static bl_NotifierManager Instance_;
    private bool Avaible = true;

    /// <summary>
    /// Singleton Standar
    /// </summary>
    public static bl_NotifierManager Instance
    {
        get
        {
            if (Instance_ == null)
                Instance_ = GameObject.FindObjectOfType<bl_NotifierManager>();

            return Instance_;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (m_Notifiers.Count <= 0)
        {
            m_Current = 0;
            return;
        }
        if (!m_Notifiers[m_Current].AlredyShow && Avaible)// Sure of show only the current notifier
        {

            m_Notifiers[m_Current].AlredyShow = true;
            mNotifier.DoNotifier(m_Notifiers[m_Current].m_Title, m_Notifiers[m_Current].m_Text, m_Notifiers[m_Current].m_Place, m_Notifiers[m_Current].clip, m_Notifiers[m_Current].m_Target, m_Notifiers[m_Current].m_Method);
        }
        if (m_Notifiers[m_Current].m_Time > 0.0f)
        {
            m_Notifiers[m_Current].m_Time -= Time.deltaTime;
        }
        else
        {
            Closet();
        }
    }

    /// <summary>
    /// Hide the current notifier
    /// </summary>
    public void Closet()
    {
        mNotifier.HideNotifier();

        GameObject g = m_Notifiers[m_Current].gameObject;
        m_Notifiers.Remove(m_Notifiers[m_Current]);
        Destroy(g);
        StartCoroutine(GetAvaible());
    }

    //Options for new notifier
    public void NewNotifier(string title, string text)
    {
        NewNotifier(title, text, PlaceScreen.TopRight);
    }
    public void NewNotifier(string title, string text,GameObject target,string method)
    {
        NewNotifier(title, text, PlaceScreen.TopRight,4,0,target,method);
    }
    public void NewNotifier(string title, string text,int clip, GameObject target, string method)
    {
        NewNotifier(title, text, PlaceScreen.TopRight,10f,clip,target,method);
    }
    public void NewNotifier(string title, string text, PlaceScreen place, GameObject target, string method)
    {
        NewNotifier(title, text, place, 6f, 0, target, method);
    }
    public void NewNotifier(string title, string text,int clip)
    {
        NewNotifier(title, text, PlaceScreen.TopRight,10f,clip,null,"");
    }
    public void NewNotifier(string title, string text,PlaceScreen place)
    {
        NewNotifier(title, text, place,10f,0,null,"");
    }
    public void NewNotifier(string title, string text, PlaceScreen place,int clip)
    {
        NewNotifier(title, text, place, 10f, clip,null,"");
    }
    public void NewNotifier(string title, string text, float time)
    {
        NewNotifier(title, text,PlaceScreen.TopRight, time,0,null,"");
    }
    public void NewNotifier(string title, string text, float time,int clip)
    {
        NewNotifier(title, text, PlaceScreen.TopRight, time, clip,null,"");
    }

    /// <summary>
    /// Create a New Notifier
    /// </summary>
    /// <param name="title"></param>
    /// <param name="text"></param>
    /// <param name="place"></param>
    /// <param name="time"></param>
    public void NewNotifier(string title, string text, PlaceScreen place,float time,int clip,GameObject target,string method)
    {
        GameObject g = new GameObject();
        g.AddComponent<Notifier>();
        g.transform.parent = this.transform;
        Notifier n = g.GetComponent<Notifier>();
        //get and set values for the new notifier
       // n.m_Title = title;

        n.m_Text = text;
        n.m_Time = time;
        n.m_Place = place;
        n.clip = clip;
        n.m_Target = target;
        n.m_Method = method;
        //Add the new notifier to list
        m_Notifiers.Add(n);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator GetAvaible()
    {
        Avaible = false;
        yield return new WaitForSeconds(Delay);
        Avaible = true;
    }
}