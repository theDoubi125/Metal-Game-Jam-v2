using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class TelephoneBehaviour : MonoBehaviour
{

    static string savedTextMessage = "";
    static string savedDialogTextMessage = "";

    public static TelephoneBehaviour instance;

    private GameObject telephone;
    private GameObject telephoneText;

    private GameObject bulle;
    private GameObject bulleText;
    private GameObject bulleHero;

    bool telephoneMoving;
    bool telephoneVisible;


    bool dialogHeroVisible;

    float visiblePhonePos = 125f;
    float hiddenPhonePos = -125f;

    private float currentTime;
    private float timeReset;

    // Use this for initialization
    void Start()
    {
        instance = this;
        telephone = GameObject.Find("PhoneEcran");
        telephoneText = GameObject.Find("PhoneMessage");

        bulle = GameObject.Find("BulleDialog");
        bulleText = GameObject.Find("BulleMessage");
        bulleHero = GameObject.Find("Hero");

        telephoneMoving = false;
        telephoneVisible = false;

        dialogHeroVisible = true;
        toogleDialogVisibility();
    }

    // Update is called once per frame
    void Update()
    {

        if (telephoneMoving)
        {
            MovePhone();
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            InitMovePhone();
        }

        if(timeReset > 0) // cache dialogue après X temps
        {
            currentTime += Time.deltaTime;
            if (currentTime > timeReset)
            {
                setDialogVisibility(false);
                timeReset = 0;
                currentTime = 0;
            }
        }
        
        

    }


    public bool isTelephoneVisible()
    {
        return telephoneVisible;
    }

    private void MovePhone()
    {
        if (telephoneVisible)
        {
            if (telephone.transform.position.y < visiblePhonePos)
            {
                telephone.transform.Translate(new Vector3(0, Time.deltaTime * 125, 0));
                telephoneText.transform.Translate(new Vector3(0, Time.deltaTime * 125, 0));
            }

            if (telephone.transform.position.y >= visiblePhonePos)
            {
                EndMovePhone();
            }

        }
        else
        {
            if (telephone.transform.position.y > hiddenPhonePos)
            {
                telephone.transform.Translate(new Vector3(0, -Time.deltaTime * 125, 0));
                telephoneText.transform.Translate(new Vector3(0, -Time.deltaTime * 125, 0));
            }

            if (telephone.transform.position.y <= hiddenPhonePos)
            {
                EndMovePhone();
            }
        }

    }

    public void InitMovePhone()
    {
        telephoneMoving = true;

        telephoneVisible = !telephoneVisible;
        MovePhone();
    }

    private void EndMovePhone()
    {
        telephoneMoving = false;
    }

    public static void SetTelephoneText(string textToWrite)
    {
        SetTelephoneText(textToWrite, true);
    }

    public static void SetTelephoneText(string textToWrite, bool isInConcert)
    {
        savedTextMessage = textToWrite;

        GameObject textObject = GameObject.Find("Telephone/PhoneMessage");
        if (textObject != null)
        {
            if (isInConcert)
            {
                textObject.GetComponent<Text>().text = ObfuscateText(textToWrite);
            }
            else
            {
                textObject.GetComponent<Text>().text = textToWrite;
            }
        }
    }

    public static void SetMessageVisible(bool visible)
    {
        SetTelephoneText(savedTextMessage, !visible);
    }

    private static string ObfuscateText(string textToWrite)
    {
        StringBuilder textToChange = new StringBuilder(textToWrite);
        for (int i = 0; i < textToChange.Length; ++i)
        {
            char c = textToChange[i];
            if (c == '\n' || c == ' ')
            {
                continue;
            }
            if (Random.value * 5 > 1)
            {
                textToChange[i] = '*';
            }
        }
        return textToChange.ToString();
    }

    //@deprecated
    private static string FormatText(string textToWrite)
    {
        string textToReturn = "";

        for (int i = 0; i < 7; ++i) //phone has capacity of 7 lines
        {
            string currentSubstring = textToWrite;
            if (textToWrite.Length >= 19)
            {
                currentSubstring = textToWrite.Substring(0, 19);
            }
            int lastWhiteSpace = currentSubstring.LastIndexOf(" ");
            if (lastWhiteSpace == -1)
            {
                textToReturn = textToReturn + currentSubstring;
                break;
            }
            textToReturn = textToReturn + currentSubstring.Substring(0, lastWhiteSpace) + "\n";
            textToWrite = textToWrite.Substring(lastWhiteSpace + 1);
        }

        return textToReturn;
    }



    public static void SetDialogText(string textToWrite)
    {
        GameObject textObject = GameObject.Find("Telephone/BulleDialog/BulleMessage");
        if (textObject != null)
        {
            textObject.GetComponent<Text>().text = textToWrite;
        }
    }



    public void toogleDialogVisibility()
    {
        dialogHeroVisible = !dialogHeroVisible;
        if (!dialogHeroVisible)
        {
            bulle.transform.Translate(new Vector3(0, -200));
        }
        else
        {
            bulle.transform.Translate(new Vector3(0, 200));
        }
    }

    public void setDialogVisibility(bool value)
    {
        if (value != dialogHeroVisible)
        {
            if (value)
            {
                timeReset = 8;
                currentTime = 0;
            }
            toogleDialogVisibility();
        }
    }
}
