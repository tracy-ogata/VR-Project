using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activeROMgame : MonoBehaviour {
    //active game variables
    public AudioSource munchSound;
    public AudioSource backgroundSound;
    public int reset_Hit = 0;
    public int g_Hit = 0;
    //public int score = 0;
    //public Text scoreText;
    //public Text gameOverScore;
    public Transform popupLocation;

    public GameObject textPrefab;
    public GameObject textPrefab2;
    public GameObject textPrefab3;

    //public List<Vector3> LocationList = new List<Vector3>();
    //public int LocationIndex;
    public int foodIndex;
    public bool inHand;
    public bool inHand2;
    public bool inHand3;

    public GameObject foodSelected;

    public GameObject lineRenderer;
    public GameObject lineRenderer2;
    public GameObject lineRenderer3;
    private int numPoints = 2;
    private Vector3[] positions = new Vector3[25];
    private Vector3 centerPoint;
    private Vector3 startRelCenter;
    private Vector3 endRelCenter;
    public Vector3 endpointDragon;
    //public Transform startPos;
    //public Transform endPos;
    public Material sparkles;

    public SteamVR_TestThrow testThrow;
    public createEndpointLists endpointsScript;
    public dragonPooler dragonPooler;
    public foodPooler foodPooler;
    public Create_vMarkers cylinder;
    public dragonMovement dragonMovement;
    public int indexFar = 0;
    public int indexClose = 0;
    public int indexHead = 0;
    public int indexShoulder = 0;
    public int indexWaist = 0;
    public int indexUpper = 0;
    public int indexLower = 0;
    public int index;

    public int type;

    //easy = 0, med = 1, hard = 2
    public int difficulty;

    public int dragonNum;

    public void moveToNextRound(int dragNum)
    {
        if (dragNum == 1)
        {
            dragonPooler.obj2.SetActive(false);
            dragonPooler.obj3.SetActive(false);
        }
        else if (dragNum == 2)
        {
            dragonPooler.obj.SetActive(false);
            dragonPooler.obj3.SetActive(false);
        }
        else if (dragNum == 3)
        {
            dragonPooler.obj.SetActive(false);
            dragonPooler.obj2.SetActive(false);
        }

        dragonPooler.obj.SetActive(true);
        dragonPooler.obj2.SetActive(true);
        dragonPooler.obj3.SetActive(true);

        foodPooler.obj.SetActive(true);
        foodPooler.obj2.SetActive(true);
        foodPooler.obj3.SetActive(true);

        type += 1;
    }

    public void movementType(int type, out Vector3 endpointDragon, out Vector3 endpointFood)
    {
        switch (type)
        {
            // extension = 0
            case 0:
                endpointDragon = endpointsScript.endpointsFar[indexFar];
                indexFar++;
                if (indexFar = endpointsScript.endpointsFar.Count - 1)
                {
                    indexFar = 0;
                }
                endpointFood = endpointsScript.endpointsClose[indexClose];
                indexClose++;
                if (indexClose > endpointsScript.endpointsClose.Count - 1)
                {
                    indexClose = 0;
                }
                break;
            // flexion = 1
            case 1:
                endpointDragon = endpointsScript.endpointsClose[indexClose];
                indexClose++;
                if (indexClose = endpointsScript.endpointsClose.Count - 1)
                {
                    indexClose = 0;
                }
                endpointFood = endpointsScript.endpointsFar[indexFar];
                indexFar++;
                if (indexFar > endpointsScript.endpointsFar.Count - 1)
                {
                    indexFar = 0;
                }
                break;
            // horizontalHead = 2
            case 2:
                endpointDragon = endpointsScript.endpointsHead[indexHead];
                indexHead++;
                if (indexHead = endpointsScript.endpointsHead.Count - 1)
                {
                    indexHead = 0;
                }
                endpointFood = endpointsScript.endpointsHead[indexHead];
                indexHead++;
                if (indexHead > endpointsScript.endpointsHead.Count - 1)
                {
                    indexHead = 0;
                }
                break;
            // horizontalShoulder = 3
            case 3:
                endpointDragon = endpointsScript.endpointsShoulder[indexShoulder];
                indexShoulder++;
                if (indexShoulder = endpointsScript.endpointsShoulder.Count - 1)
                {
                    indexShoulder = 0;
                }
                endpointFood = endpointsScript.endpointsShoulder[indexShoulder];
                indexShoulder++;
                if (indexShoulder > endpointsScript.endpointsShoulder.Count - 1)
                {
                    indexShoulder = 0;
                }
                break;
            // horizontalWwaist = 4
            case 4:
                endpointDragon = endpointsScript.endpointsWaist[indexWaist];
                indexWaist++;
                if (indexWaist = endpointsScript.endpointsWaist.Count - 1)
                {
                    indexFar = 0;
                }
                endpointFood = endpointsScript.endpointsWaist[indexWaist];
                indexWaist++;
                if (indexWaist > endpointsScript.endpointsWaist.Count - 1)
                {
                    indexWaist = 0;
                }
                break;
            // up = 5
            case 5:
                endpointDragon = endpointsScript.endpoints[indexUpper];
                indexUpper++;
                if (indexUpper = endpointsScript.endpointsUpper.Count - 1)
                {
                    indexUpper = 0;
                }
                endpointFood = endpointsScript.endpointsLower[indexLower];
                indexLower++;
                if (indexLower > endpointsScript.endpointsLower.Count - 1)
                {
                    indexLower = 0;
                }
                break;
            // down = 6
            case 6:
                endpointDragon = endpointsScript.endpointsLower[indexLower];
                indexLower++;
                if (indexLower = endpointsScript.endpointsLower.Count - 1)
                {
                    indexLower = 0;
                }
                endpointFood = endpointsScript.endpointsUpper[indexUpper];
                indexUpper++;
                if (indexUpper > endpointsScript.endpointsUpper.Count - 1)
                {
                    indexUpper = 0;
                }
                break;
        }
    }

    public void getSlerp(Transform startPos, Transform endPos)  //need to add if statement for left hand. 
    {
        centerPoint = (startPos.position + endPos.position) * 0.5f - Vector3.right;
        startRelCenter = startPos.position - centerPoint;
        endRelCenter = endPos.position - centerPoint;
        for (int i = 0; i < 25; i++)
        {
            float fracComplete = (i / 25.0f);
            positions[i] = Vector3.Slerp(startRelCenter, endRelCenter, fracComplete) + centerPoint;
            lineRenderer3.GetComponent<LineRenderer>().SetPositions(positions);
        }
    }

    // Use this for initialization
    void Start () {
        //LocationList.Add(new Vector3(0f, 1f, 3f));
        //LocationList.Add(new Vector3(1f, 1f, 3f));
        //LocationList.Add(new Vector3(-1f, 1f, 3f));
        //LocationIndex = Random.Range(0, LocationList.Count);

        foodSelected.SetActive(false);
        munchSound = GameObject.FindGameObjectWithTag("munch").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //var device = SteamVR_Controller.Input((int)testThrow.trackedObj.index);
        //testThrow.shoulderjoint = GameObject.FindGameObjectWithTag("RACR");

        if (testThrow.start_game)
        {
            // old code
            /*
            if(dragonPooler.GetPooledObject() != null)
            {
                GameObject obj = dragonPooler.GetPooledObject();
                //LocationIndex = Random.Range(0, LocationList.Count);
                obj.transform.position += obj.transform.forward * -1.5f;    //this location needs to be based on subject rotation as well. also the canvas rotation will need to be rotated...? 
                //Debug.Log(obj.transform.position);  //to add active flexibility i think just make this based on the subject's cylinder or tracker rotation. (0,180,0)

                obj.SetActive(true);
            }

            //add food pooling capability
            if (foodPooler.GetPooledObject() != null)
            {
                GameObject food = foodPooler.GetPooledObject();
                foodIndex = Random.Range(0, endpointsScript.endpointsFood.Count);   //instantiate the food objects at random endpoints. 
                while (endpointsScript.endpointsFood[foodIndex] == endpointsScript.endpointsEasy[dragonMovement.indexE] || endpointsScript.endpointsFood[foodIndex] == endpointsScript.endpointsMed[dragonMovement.indexM] || endpointsScript.endpointsFood[foodIndex] == endpointsScript.endpointsHard[dragonMovement.indexH])
                {
                    foodIndex++;
                    if (foodIndex > endpointsScript.endpointsFood.Count - 1)
                    {
                        foodIndex = 0;
                    }
                }
                food.transform.position = endpointsScript.endpointsFood[foodIndex];
                food.transform.rotation = Quaternion.Euler(0, 180, 0);   //to add active flexibility i think just make this based on the subject's cylinder or tracker rotation. 
                food.SetActive(true);
            }
            */

            if (inHand || inHand2 || inHand3)  //we grabbed a chicken leg. create the line renders to the dragons. will need to edit and incorporate logic for the different curves?? is there a way to create a curve
                //one curve for items on the same horizontal plane, vertical plane, but what to do for cross planes? maybe straight line to get on same plane and then follow horizontal/vertical plane logic? 
                //do we want to measure this guided movement or measure how they actually reach for the items and move to another point? 
            {
                lineRenderer.SetActive(true);
                lineRenderer2.SetActive(true);
                lineRenderer3.SetActive(true);

                lineRenderer.GetComponent<Renderer>().material = sparkles;
                lineRenderer2.GetComponent<Renderer>().material = sparkles;
                lineRenderer3.GetComponent<Renderer>().material = sparkles;

                lineRenderer.GetComponent<LineRenderer>().positionCount = numPoints;
                lineRenderer2.GetComponent<LineRenderer>().positionCount = numPoints;
                lineRenderer3.GetComponent<LineRenderer>().positionCount = numPoints;

                lineRenderer.GetComponent<LineRenderer>().SetPosition(0, foodSelected.transform.position);
                lineRenderer.GetComponent<LineRenderer>().SetPosition(1, GameObject.Find("drag1").transform.position);

                lineRenderer2.GetComponent<LineRenderer>().SetPosition(0, foodSelected.transform.position);
                lineRenderer2.GetComponent<LineRenderer>().SetPosition(1, GameObject.Find("drag2").transform.position);

                if(GameObject.Find("drag3").transform.position.x < testThrow.RACR.transform.position.x)    //how to find if the object is behind? x position is < RACR.position.x
                {
                    getSlerp(foodSelected.transform, GameObject.Find("drag3").transform);   //slerp points to the behind points. 
                }
                else
                {
                    lineRenderer3.GetComponent<LineRenderer>().SetPosition(0, foodSelected.transform.position);
                    lineRenderer3.GetComponent<LineRenderer>().SetPosition(1, GameObject.Find("drag3").transform.position);
                }
            }

            if (reset_Hit >= 5)
            {
                for (int i = 0; i < dragonPooler.pooledObjs.Count; i++)
                {
                    dragonPooler.pooledObjs[i].SetActive(false); 
                }
                for (int i = 0; i < foodPooler.pooledObjs.Count; i++)
                {
                    foodPooler.pooledObjs[i].SetActive(false);
                }
                reset_Hit = 0;
            }

            if (g_Hit >= 7)
            {
                for (int i = 0; i < dragonPooler.pooledObjs.Count; i++)
                {
                    dragonPooler.pooledObjs[i].SetActive(false); 
                }
                for (int i = 0; i < foodPooler.pooledObjs.Count; i++)
                {
                    foodPooler.pooledObjs[i].SetActive(false);
                }
                g_Hit = 0;
                reset_Hit = 0;
                //gameOverScore.text = score.ToString();
                //testThrow.scoreDisp.SetActive(false);
                //this works? 
                /*Vector3 distanceVector = (testThrow.gameOverCanvas.transform.position - cylinder.cylinder2.transform.position).normalized;
                Vector3 targetPosition = distanceVector * -3f;
                testThrow.gameOverCanvas.transform.position = targetPosition;

                testThrow.gameOverCanvas.transform.eulerAngles = new Vector3(0f, cylinder.cylinder2.transform.eulerAngles.y - 180, 0f);*/
                testThrow.gameOverCanvas.SetActive(true);
                testThrow.restartMenu.SetActive(true);
                testThrow.controller.SetActive(true);
                testThrow.controllerCover.SetActive(true);
                testThrow.chicken.SetActive(false);
                testThrow.start_game = false;
            }

            if (testThrow.collidingObject)
            {
                if((testThrow.collidingObject.name == "food" || testThrow.collidingObject.name == "food2" || testThrow.collidingObject.name == "food3") && !(inHand || inHand2 || inHand3))
                {
                    testThrow.controller.SetActive(false);
                    testThrow.controllerCover.SetActive(false);
                    testThrow.chicken.SetActive(true);
                    if (testThrow.collidingObject.name == "food")
                    {
                        inHand = true;
                        foodPooler.obj2.SetActive(false);
                        foodPooler.obj3.SetActive(false);
                    }
                    else if (testThrow.collidingObject.name == "food2")
                    {
                        inHand2 = true;
                        foodPooler.obj.SetActive(false);
                        foodPooler.obj3.SetActive(false);
                    }
                    else if (testThrow.collidingObject.name == "food3")
                    {
                        inHand3 = true;
                        foodPooler.obj.SetActive(false);
                        foodPooler.obj2.SetActive(false);
                    }
                    foodSelected.transform.rotation = testThrow.collidingObject.transform.rotation;
                    foodSelected.transform.position = testThrow.collidingObject.transform.position;
                    foodSelected.SetActive(true);
                    testThrow.collidingObject.SetActive(false);
                    testThrow.collidingObject = null;
                }

                if (inHand && testThrow.collidingObject.name == "drag1")
                {
                    munchSound.Play();
                    //Instantiate(textPrefab, popupLocation.position, Quaternion.Euler(0, 180, 0));
                    g_Hit++;
                    reset_Hit++;
                    inHand = false;
                    testThrow.controller.SetActive(true);
                    testThrow.controllerCover.SetActive(true);
                    testThrow.chicken.SetActive(false);
                    lineRenderer.SetActive(false);
                    lineRenderer2.SetActive(false);
                    lineRenderer3.SetActive(false);
                    foodSelected.SetActive(false);
                    testThrow.collidingObject.SetActive(false);
                    testThrow.collidingObject = null;
                    //score = score + 10;
                    //scoreText.text = score.ToString();

                }

                else if (inHand2 && testThrow.collidingObject.name == "drag2")
                {
                    munchSound.Play();
                    //Instantiate(textPrefab, popupLocation.position, Quaternion.Euler(0, 180, 0));
                    g_Hit++;
                    reset_Hit++;
                    inHand2 = false;
                    testThrow.controller.SetActive(true);
                    testThrow.controllerCover.SetActive(true);
                    testThrow.chicken.SetActive(false);
                    lineRenderer.SetActive(false);
                    lineRenderer2.SetActive(false);
                    lineRenderer3.SetActive(false);
                    foodSelected.SetActive(false);
                    testThrow.collidingObject.SetActive(false);
                    testThrow.collidingObject = null;
                    //score = score + 20;
                    //scoreText.text = score.ToString();

                }

                else if (inHand3 && testThrow.collidingObject.name == "drag3")
                {
                    munchSound.Play();
                    //Instantiate(textPrefab, popupLocation.position, Quaternion.Euler(0, 180, 0));
                    g_Hit++;
                    reset_Hit++;
                    inHand3 = false;
                    testThrow.controller.SetActive(true);
                    testThrow.controllerCover.SetActive(true);
                    testThrow.chicken.SetActive(false);
                    lineRenderer.SetActive(false);
                    lineRenderer2.SetActive(false);
                    lineRenderer3.SetActive(false);
                    foodSelected.SetActive(false);
                    testThrow.collidingObject.SetActive(false);
                    testThrow.collidingObject = null;
                    //score = score + 30;
                    //scoreText.text = score.ToString();
                    moveToNextRound = true;
                }
            }

            /*else if (!testThrow.collidingObject)
            {
                Debug.Log("no collision");
            }*/
        }
    }
}
