using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAns : MonoBehaviour
{
    public static CheckAns instance;
    string ans_str = "3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986" +
                     "2803482534211706798214808651328230664709384460955058223172535940812848111745028410270" +
                     "1938521105559644622948954930381964428810975665933446128475648233786783165271201909145" +
                     "6485669234603486104543266482133936072602491412737245870066063155881748815209209628292" +
                     "5409171536436789259036001133053054882046652138414695194151160943305727036575959195309" +
                     "2186117381932611793105118548074462379962749567351885752724891227938183011949129833673" +
                     "3624406566430860213949463952247371907021798609437027705392171762931767523846748184676" +
                     "6940513200056812714526356082778577134275778960917363717872146844090122495343014654958" +
                     "5371050792279689258923542019956112129021960864034418159813629774771309960518707211349" +
                     "9999983729780499510597317328160963185950244594553469083026425223082533446850352619311" +
                     "8817101000313783875288658753320838142061717766914730359825349042875546873115956286388" +
                     "235378759375195778185778053217122680661300192787661119590921642019893809525720106548586327886593615338182";

    [SerializeField]
    Text current_pi;
    int size;
    GameObject Score;
    GameObject HighScore;
    SoundManager soundManager;
    private void Awake()
    {
        instance = this;
        size = 4;
    }
    private void Start()
    {
        Score = GameObject.Find("Score");
        HighScore = GameObject.Find("HighScore");
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        Score.SetActive(false);
        HighScore.SetActive(false);
    }

    public void Check(char c)
    {
        if (c == ans_str[size])
        {
            size++;
            current_pi.text = current_pi.text + c;
            GameObject choiceManager = GameObject.Find("ChoiceManager");
            choiceManager.GetComponent<Answer>().SetNumber();
            soundManager.PlayCorrect();
        }
        else
        {
            Fail();
            soundManager.PlayWrong();
        }
    }

    public int GetSize()
    {
        return size;
    }

    public string GetAnswer()
    {
        return ans_str;
    }

    public void Fail()
    {
        GameObject heart3 = GameObject.Find("heart1");
        GameObject heart2 = GameObject.Find("heart2");
        GameObject heart1 = GameObject.Find("heart3");
        if (heart1 != null)
        {
            heart1.SetActive(false);
        }
        else if (heart2 != null)
        {
            heart2.SetActive(false);
        }
        else if (heart3 != null)
        {
            heart3.SetActive(false);
            GameObject Choice1 = GameObject.Find("Choice1");
            GameObject Choice2 = GameObject.Find("Choice2");
            GameObject Choice3 = GameObject.Find("Choice3");
            Choice1.SetActive(false);
            Choice2.SetActive(false);
            Choice3.SetActive(false);
            Score.SetActive(true);
            Score.GetComponent<Text>().text = "Score : " + (size - 2);
            int highscore = PlayerPrefs.GetInt("highscore", 0);
            if (size - 2 > highscore)
            {
                PlayerPrefs.SetInt("highscore", size - 2);
                HighScore.GetComponent<Text>().text = "High Score : " + (size - 2);
            }
            else
            {
                HighScore.GetComponent<Text>().text = "High Score : " + highscore;
            }
        }
    }
}
