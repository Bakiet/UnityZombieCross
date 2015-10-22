using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NotifierButtons : MonoBehaviour {

    public Animation FinishAnim;
    public GameObject Shadow;

    private Vector2 ShadowPos;
    private Vector2 NextShadowPos;

	// Use this for initialization
	void Start () {
		//bl_NotifierManager.Instance.NewNotifier("Notifier In Top Right", "Use your cell to move the bike from left to right.");
    //    bl_NotifierManager.Instance.NewNotifier("Notifier In Top Left", "Notifier is a simple way to create profecionals: tutorials, notifications,conversations, presentations,reports and much more ...", PlaceScreen.TopLeft);
      //  bl_NotifierManager.Instance.NewNotifier("Notifier In Top", "You can create / display a new notification with just one line of code.", PlaceScreen.Top);
		//bl_NotifierManager.Instance.NewNotifier("Notifier In Middle", "Use your cell to move the bike from left to right.", PlaceScreen.Middle);
       // bl_NotifierManager.Instance.NewNotifier("Notifier In Middle Left", "It is useful for any type of genre of games like FPS, RPG, MMO, etc ... all need something like this.", PlaceScreen.MiddleLeft);
		bl_NotifierManager.Instance.NewNotifier("Notifier In Middle Right", "Press the green button to speed.", PlaceScreen.MiddleRight, this.gameObject, "SeeTargetRight");
		bl_NotifierManager.Instance.NewNotifier("Notifier In Botton", "Press the red button to brake.", PlaceScreen.Botton,  this.gameObject, "SeeTargetLeft");
       // bl_NotifierManager.Instance.NewNotifier("Notifier In Botton Left", "Sounds for notificasion? ... Is also included :D", PlaceScreen.BottonLeft,1);
       // bl_NotifierManager.Instance.NewNotifier("Notifier In Botton Right", "<color=orange>Notifier</color>, what are you waiting for get!", PlaceScreen.BottonRight,this.gameObject,"Finished");
	}

    /// <summary>
    /// 
    /// </summary>
    public void SeeTargetRight()
    {
        NextShadowPos = new Vector2(330, -150);
        Shadow.SetActive(true);
    }
    /// <summary>
    /// 
    /// </summary>
    public void SeeTargetLeft()
    {
		NextShadowPos = new Vector2(-320, -150);
    }
    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (!Shadow.activeSelf)
            return;

        ShadowPos = Vector2.Lerp(ShadowPos, NextShadowPos, Time.deltaTime * 6);
        Shadow.GetComponent<RectTransform>().anchoredPosition = ShadowPos;
    }
    /// <summary>
    /// 
    /// </summary>
    public void Finished()
    {
        //Shadow.SetActive(false);
        NextShadowPos = new Vector2(-3, -20);
		FinishAnim.GetComponent<Animation>().Play("Finished");
    }

}