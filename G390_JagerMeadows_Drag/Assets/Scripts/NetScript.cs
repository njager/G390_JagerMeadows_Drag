using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NetScript : MonoBehaviour
{
    //public variables
    public float speed;
    public float castDistance;
    public float interpolantValue;
    public float lerpFeel;
    public static int points;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI rareFish;
    public TextMeshProUGUI regFish;
    public TextMeshProUGUI trashFish;
    public int raf;
    public int rgf;
    public int trf;
    public AudioClip splash;
    public AudioClip tug;
    AudioSource audioSource;


    //private variables
    Rigidbody rB;
    BoxCollider netCollider;
    private bool casted;
    private bool lerping;
    [SerializeField] float timer;
    public bool firstCast = true;
    

    //variables for transition
    Vector3 startPos;
    Vector3 endPos;

    private void Start()
    {
        //get the rigidbody
        rB = GetComponent<Rigidbody>();
        netCollider = GetComponent<BoxCollider>();

        casted = false;
       
        audioSource = GetComponent<AudioSource>();

        if (firstCast == true)
        {
            SetCountText();
            firstCast = false;
        }
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        //if above the water, allow movement
        if(!casted == true)
        {
            //Get the horizontal and vertical axis
            float translationz = Input.GetAxis("Vertical") * speed;
            float translationx = Input.GetAxis("Horizontal") * speed;

            //make it move per second instead of per frame
            translationz *= Time.deltaTime;
            translationx *= Time.deltaTime;

            //set translation along the x and z axes
            transform.Translate(translationx, 0, translationz);
        }
        
        //check for space and position to cast net
        if (transform.position.y > 10 && Input.GetKeyDown(KeyCode.Space))
        {
            Cast();
        }

        //pull net after casted
        if (casted == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Pulled();
        }

        if(lerping == true)
        {
            Move();
        }
    }
    /// <summary>
    /// freezes x and y movement
    /// sends net down in y
    /// deactivates collider
    /// </summary>
    void Cast()
    {
        audioSource.PlayOneShot(splash, 0.3F);
        netCollider.enabled = !netCollider.enabled;
        endPos = rB.transform.position;
        rB.transform.Translate(0, -castDistance, 0);

        casted = true;
        rgf = 0;
        trf = 0;
        raf = 0;
        FishCount();
    }

    /// <summary>
    /// activates collider
    /// brings net up in y
    /// unfreezes movement
    /// </summary>
    void Pulled()
    {
        netCollider.enabled = !netCollider.enabled;
        startPos = rB.transform.position;

        casted = false;
        lerping = true;

        interpolantValue = 0f;
        audioSource.PlayOneShot(tug, 0.4F);

        

    }

    void Move()
    {

        //moves the net object smoothly
        interpolantValue = Mathf.MoveTowards(interpolantValue, 1f, Time.deltaTime * lerpFeel);
        transform.position = Vector3.Lerp(transform.position, endPos, interpolantValue);

        //when lerp is finished
        if(interpolantValue >= 1f)
        {
            lerping = false;
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        //all these ifs check for fish catches
        if (other.CompareTag("Fish"))
        {
            Destroy refScript = other.gameObject.GetComponent<Destroy>();

            if (refScript.isCaught == false)
            {
                //detects fish, adds relevant points
                Debug.Log("Caught a fish!");
                points += 1;
                //print("Points = " + points.ToString());

                rgf += 1;

                FishCount();
                SetCountText();

                //insert particle effect here
                //fishParticle.Play();

                //parents fish to net, fish is destroyed by separate script
                other.transform.parent = rB.transform;

                // paste UI code here
                refScript.isCaught = true;
            }
            
            
        }
        else if (other.CompareTag("Trash"))
        {

            Destroy refScript = other.gameObject.GetComponent<Destroy>();

            if (refScript.isCaught == false)
            {
                
                //detects fish, adds relevant points
                Debug.Log("Caught trash!");
                points -= 1;
                // print("Points = " + points.ToString());

                trf += 1;

                FishCount();
                SetCountText();

                //parents fish to net, then destroys
                other.transform.parent = rB.transform;

                //insert particle effect here
                //trashParticle.Play();

                // paste UI code here
                refScript.isCaught = true;
            }
        }
        else if (other.CompareTag("Rare"))
        {
            Destroy refScript = other.gameObject.GetComponent<Destroy>();

            if (refScript.isCaught == false)
            {

                //detects fish, adds relevant points
                Debug.Log("Caught a rare fish!");
                points += 3;
                // print("Points = " + points.ToString());

                raf += 1;

                FishCount();
                SetCountText();

                //parents fish to net, then destroys
                other.transform.parent = rB.transform;

                //insert particle effect here
                //rareParticle.Play();

                // paste UI code here
                refScript.isCaught = true;
            }
        }

    }

    void SetCountText()
    {
        countText.text = "Points: " + points.ToString();

    }

    void FishCount()
    {
        rareFish.text = "Rare Fish Caught: " + raf.ToString();
        trashFish.text = "Trash Caught: " + trf.ToString();
        regFish.text = "Regular Fish Caught: " + rgf.ToString();
        Debug.Log("this is active");
        
    }


    
}
