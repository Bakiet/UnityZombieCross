using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class bl_Notifier : MonoBehaviour {

    public Text m_Title = null;
    public Text m_Text = null;
    [Space(5)]
    public AudioClip[] Clips;
    public AudioSource WritterSource = null;
    public AudioClip WritterSounds;
    [Space(5)]
    public Animation m_Anim = null;
    public GameObject NextButton = null;
    //Privates
    private string CurrentAnim = "";
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ps"></param>
    public void DoNotifier(string title,string text)
    {
        DoNotifier(title, text, PlaceScreen.TopRight,0,null,"");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="text"></param>
    /// <param name="target"></param>
    /// <param name="method"></param>
    public void DoNotifier(string title, string text,GameObject target,string method)
    {
        DoNotifier(title, text, PlaceScreen.TopRight, 0,target,method);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="text"></param>
    /// <param name="clip"></param>
    public void DoNotifier(string title, string text, int clip)
    {
        DoNotifier(title, text, PlaceScreen.TopRight,clip,null,"");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="text"></param>
    /// <param name="clip"></param>
    public void DoNotifier(string title, string text, int clip,GameObject target,string method)
    {
        DoNotifier(title, text, PlaceScreen.TopRight, clip, target, method);
    }
    /// <summary>
    /// Create a new Notifier with information receive.
    /// </summary>
    /// <param name="ps"></param>
    public void DoNotifier(string title,string text,PlaceScreen ps,int clip,GameObject target,string method)
    {
        m_Title.text = title;
        m_Text.text = text;
        StartCoroutine(TypeText());
        switch (ps)
        {
            case PlaceScreen.Top:
                m_Anim["Top"].speed = 1.0f;
                m_Anim.Play("Top");
                CurrentAnim = "Top";
                break;
            case PlaceScreen.TopLeft:
                m_Anim["TopLeft"].speed = 1.0f;
                m_Anim.Play("TopLeft");
                CurrentAnim = "TopLeft";
                break;
            case PlaceScreen.TopRight:
                m_Anim["TopRight"].speed = 1.0f;
                m_Anim.Play("TopRight");
                CurrentAnim = "TopRight";
                break;
            case PlaceScreen.Middle:
                m_Anim["Middle"].speed = 1.0f;
                m_Anim.Play("Middle");
                CurrentAnim = "Middle";
                break;
            case PlaceScreen.MiddleLeft:
                m_Anim["MiddleLeft"].speed = 1.0f;
                m_Anim.Play("MiddleLeft");
                CurrentAnim = "MiddleLeft";
                break;
            case PlaceScreen.MiddleRight:
                m_Anim["MiddleRight"].speed = 1.0f;
                m_Anim.Play("MiddleRight");
                CurrentAnim = "MiddleRight";
                break;
            case PlaceScreen.Botton:
                m_Anim["Botton"].speed = 1.0f;
                m_Anim.Play("Botton");
                CurrentAnim = "Botton";
                break;
            case PlaceScreen.BottonLeft:
                m_Anim["BottonLeft"].speed = 1.0f;
                m_Anim.Play("BottonLeft");
                CurrentAnim = "BottonLeft";
                break;
            case PlaceScreen.BottonRight:
                m_Anim["BottonRight"].speed = 1.0f;
                m_Anim.Play("BottonRight");
                CurrentAnim = "BottonRight";
                break;
        }
        if (Clips[clip] != null)
        {
            GetComponent<AudioSource>().clip = Clips[clip];
            GetComponent<AudioSource>().Play();
        }
        if (target != null && method != string.Empty)
        {
            target.SendMessage(method, SendMessageOptions.DontRequireReceiver);
        }
    }
    /// <summary>
    /// Play Current animation in reverse.
    /// </summary>
    public void HideNotifier()
    {
        StopAllCoroutines();
        StopCoroutine("TypeText");
        m_Anim[CurrentAnim].time = m_Anim[CurrentAnim].length;
        m_Anim[CurrentAnim].speed = -1.0f;
        m_Anim.Play(CurrentAnim);
    }
    /// <summary>
    /// TypeWritter
    /// </summary>
    /// <returns></returns>
    IEnumerator TypeText()
    {
        if (NextButton != null)
        {
            NextButton.SetActive(false);
        }
        //cache text
        string t = m_Text.text;
        m_Text.text = "";
        foreach (char letter in t.ToCharArray())
        {
            //guiText.text += letter;
            m_Text.text += letter;
            if (WritterSource != null && WritterSounds != null)
            {
                WritterSource.clip = WritterSounds;
                WritterSource.Play();
            }
            yield return null;
            yield return new WaitForSeconds(0.002f);//one letter per 0.002f 
        }
        DoInFinishWritter();
    }
    /// <summary>
    /// Called when typewritter is finished
    /// </summary>
    void DoInFinishWritter()
    {
        if (NextButton != null)
        {
            NextButton.SetActive(true);
        }
    }
}