using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour {
    //animation
    public GameObject animationCanvas;
    public bool animationStart = false;
    public int animClick = 0;
    public GameObject animOne;
    public GameObject animTwo;
    public GameObject animThree;

    public SteamVR_TestThrow testThrow;

	// Update is called once per frame
	void Update () {
        var device = SteamVR_Controller.Input((int)testThrow.trackedObj.index);

        if (animationStart && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            animClick++;
            Debug.Log("click");
        }

        if (animationStart && animClick == 0)
        {
            animationCanvas.SetActive(true);
            animOne.SetActive(false);
            animTwo.SetActive(false);
            animThree.SetActive(false);
        }

        else if (animationStart && animClick == 1)
        {
            animOne.SetActive(true);
        }

        else if (animationStart && animClick == 2)
        {
            Destroy(animOne);
            animTwo.SetActive(true);
        }

        else if (animationStart && animClick == 3)
        {
            Destroy(animTwo);
            animThree.SetActive(true);
        }
    }
}
