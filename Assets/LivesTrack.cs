using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesTrack : MonoBehaviour
{
    static public LivesTrack Instance;
    public GameObject target;

    Text livesText;
    int lives = 3;

    void Awake()
    {
        Instance = this;
        livesText = GetComponent<Text>();
        livesText.text = "LIVES: " + lives.ToString();
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2);
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife(int value)
    {
        Ball_Controller playerScript = target.GetComponent<Ball_Controller>();

        lives -= value;
        livesText.text = "LIVES: " + lives.ToString();

        if (lives >= 0)
        {
            print("LivesTrack: player died, moving to last checkpoint");
            target.rigidbody.velocity = new Vector3(0, 0, 0);
            target.transform.position = playerScript.newCheckpoint;
        }
        else
        {
            print("LivesTrack: player ran out of lives, moving to first checkpoint");
            //target.rigidbody.velocity = new Vector3(0, 0, 0);
            //target.transform.position = playerScript.firstCheckpoint;
            //StartCoroutine(RestartLevel());
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
