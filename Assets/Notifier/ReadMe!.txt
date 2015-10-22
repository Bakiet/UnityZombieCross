Thanks For Buying Notifier!

Requiered:
Unity 4.6++

Get Started-----------------------------------------------------------------------

- Import Notifier Package to your project.
- Open Scene Example in Notifier -> Example -> Scene.

Create Notifier in a new Scene-----------------------------------------------------

- In your new scene, create a Canvas in: GameObject -> UI -> Canvas.
- Into canvas drag the Notifier Prefabs From: Notifier -> Prefabs
- Drag in hierarchy the NotifierManager Prefabs from: Notifier -> Prefabs.
- in NotifierManager Var "MNotifier" Drag the Notifier from canvas.

Use Notifier------------------------------------------------------------------------
For Create / Show a new notifier in RunTime from any script, called like this:

bl_NotifierManager.Instance.NewNotifier("Title","Text"); //For only show text
or
bl_NotifierManager.Instance.NewNotifier("Title","Text",gameObject,"Message");//For Show Text and send a message to a GameObject.
or
bl_NotifierManager.Instance.NewNotifier("Title","Text",PlaceScreen.Top);//For Show Text and select place where show.
or
bl_NotifierManager.Instance.NewNotifier("Title","Text"PlaceScreen.Top,10f,1,gameObject,"Message");

Complete Values----------------------------------------------------------------------
 public void NewNotifier(string title, string text, PlaceScreen place,float time,int clip,GameObject target,string method)

    public string m_Title = "";
    public string m_Text = "";
    public float m_Time = 10f;
    public PlaceScreen m_Place = PlaceScreen.Middle;
    public int clip = 0;
    public GameObject m_Target = null;
    public string m_Method = "";

Where:


m_Title =  Title Show in Top.
m_Text =   Text to show in notifier.
m_Time =   Time for show the notifier.
m_Place =  Place where appear the notifier.
clip =     the id / position of clip from list.
m_Target = GameObject for send the message
m_Method = Name of function we need called.


Support:

Email: brinerjhonson.lc@gmail.com
Forum: LovattoStudio.com/Forum/Index.php






