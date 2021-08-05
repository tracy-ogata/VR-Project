//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Valve.VR;
using System.Collections.Generic;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class SteamVR_TestThrow : MonoBehaviour
{
    //virtual marker variables
    public GameObject prefab;
    public GameObject RACR;
    public GameObject C7;
    public GameObject T8;
    public GameObject STRN;
    public GameObject CHEST;
    public GameObject RMELB;
    public GameObject RLELB;
    public GameObject RFA;
    public GameObject RUS;
    public GameObject RRS;
    public GameObject marker;

    public Transform tracker;
    public Transform tracker2;
    public Transform tracker3;

    //button variables
    public bool racr_bool = false;
    public bool c7_bool = false;
    public bool t8_bool = false;
    public bool strn_bool = false;
    public bool chest_bool = false;
    public bool rmelb_bool = false;
    public bool rlelb_bool = false;
    public bool rfa_bool = false;
    public bool rus_bool = false;
    public bool rrs_bool = false;

    public bool racr_edit = false; 
    public bool c7_edit = false; 
    public bool t8_edit = false; 
    public bool strn_edit = false; 
    public bool chest_edit = false; 
    public bool rmelb_edit = false; 
    public bool rlelb_edit = false;
    public bool rfa_edit = false; 
    public bool rus_edit = false; 
    public bool rrs_edit = false;

    public bool calibrated = false; 

    public bool start_game = false;
    public bool start_passive = false;
    public bool restart_game = false;
    public bool restart_passive = false;

    public Material col_mat;
    public Material red;
    public Material orange;
    public Material blue;
    public Material yellow;

    //motion tracking controller
    public SteamVR_TrackedObject trackedObj;
    //public GameObject shoulderjoint;
    public GameObject chicken;
    public GameObject controllerCover;
    public GameObject controller;
    public GameObject markerSpawn;

    //controller UI
    public VRTK.VRTK_ControllerEvents controllerEvents;

    //canvas & button variables
    public GameObject collidingObject;
    public GameObject startAnimButton;
    public GameObject startPassiveButton;
    public GameObject setTrackerCanvas;
    //public GameObject scoreDisp;
    public GameObject gameOverCanvas;
    public GameObject calibrateCanvas;
    public GameObject restartMenu;
    public GameObject endpointsButton;
    public GameObject chunks;
    public GameObject scenery;
    public GameObject buttonCanvas; 

    public Dropdown handDrop;

    public animationScript animationScript;
    public createEndpointLists endpointsScript;
    public activeROMgame game;
    public Create_vMarkers vMarkers; 
    public SteamVR_Controller.Device device;
    public dragonPooler dragonPooler;
    public passiveROM passiveROM;
    public dotPool dotPool;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        //scoreDisp.SetActive(false);
        gameOverCanvas.SetActive(false);
        calibrateCanvas.SetActive(false);
        animationScript.animationCanvas.SetActive(false);
        restartMenu.SetActive(false);
        startAnimButton.SetActive(false);
        startPassiveButton.SetActive(false);
        chunks.SetActive(false);
        chicken.SetActive(false);
        controllerCover.SetActive(true);
        
        

        /*string torsoTracker = "LHR-24979233";


		uint index = 0;
		ETrackedPropertyError error = new ETrackedPropertyError();
		for (uint i = 0; i < 16; i++)
		{
			var result = new System.Text.StringBuilder((int)64);
			OpenVR.System.GetStringTrackedDeviceProperty(i, ETrackedDeviceProperty.Prop_SerialNumber_String, result, 64, ref error);
			//Debug.Log(result);
			string rr = result.ToString();
			Debug.Log (rr);

			if (rr==torsoTracker)
            {
				Debug.Log ("hello");
				Debug.Log(i); 
                cube_torso = GameObject.FindGameObjectWithTag("torso");
                cube_torso.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex(10);

            }
        }*/
    }

    public void racr_button()
    {
        racr_bool = true;
        racr_edit = false;
    }

    public void c7_button()
    {
        c7_bool = true;
        c7_edit = false;
    }

    public void t8_button()
    {
        t8_bool = true;
        t8_edit = false; 
    }

    public void strn_button()
    {
        strn_bool = true;
        strn_edit = false;
    }

    public void chest_button()
    {
        chest_bool = true;
        chest_edit = false; 
    }

    public void rmelb_button()
    {
        rmelb_bool = true;
        rmelb_edit = false;
    }

    public void rlelb_button()
    {
        rlelb_bool = true;
        rlelb_edit = false; 
    }

    public void rfa_button()
    {
        rfa_bool = true;
        rfa_edit = false;
    }

    public void rus_button()
    {
        rus_bool = true;
        rus_edit = false;
    }

    public void rrs_button()
    {
        rrs_bool = true;
        rrs_edit = false; 
    }

    public void start_passive_button()
    {
        start_passive = true;
        start_game = false;
        startAnimButton.SetActive(true);
        chunks.SetActive(true);
        startPassiveButton.SetActive(false);

    }

    public void animation_button()
    {
        for (int i = 0; i < dotPool.pooledObjs.Count; i++)
        {
            dotPool.pooledObjs[i].SetActive(false);
        }

        passiveROM.lineRenderer.SetActive(false);
        passiveROM.lineRenderer2.SetActive(false);
        passiveROM.lineRenderer3.SetActive(false);
        passiveROM.lineRenderer4.SetActive(false);

        buttonCanvas.SetActive(false);
        animationScript.animationStart = true;
        start_game = false;
        start_passive = false;
        animationScript.animClick = 0;
        //this works? 
        //animationScript.animationCanvas.transform.eulerAngles = new Vector3(0f, vMarkers.cylinder2.transform.eulerAngles.y - 180, 0f);
        /*Vector3 distanceVector = (-animationScript.animationCanvas.transform.position + vMarkers.cylinder2.transform.position).normalized;
        Vector3 targetPosition = distanceVector * 1f;
        animationScript.animationCanvas.transform.position -= targetPosition;*/
        
        animationScript.animationCanvas.SetActive(true);
        animationScript.animOne.SetActive(false);
        animationScript.animTwo.SetActive(false);
        animationScript.animThree.SetActive(false);
        startAnimButton.SetActive(false);
        chunks.SetActive(false);
        endpointsButton.SetActive(false);
        scenery.SetActive(true);
        game.backgroundSound.Play();
    }

    public void start_game_button() //*****changed the controller here ****/////////
    {
        start_game = true;
        start_passive = false;
        game.g_Hit = 0;
        game.reset_Hit = 0;
        animationScript.animationStart = false;
        //scoreDisp.SetActive(true);
        Destroy(animationScript.animThree);
        Destroy(animationScript.animationCanvas);

        //controller.SetActive(false);
        //controllerCover.SetActive(false);
        markerSpawn.SetActive(false);
        //chicken.SetActive(true);
        
    }

    public void restart_game_button()
    {
        for (int i = 0; i < dragonPooler.pooledObjs.Count; i++)
        {
            dragonPooler.pooledObjs[i].SetActive(false);
        }

        for (int i = 0; i < dotPool.pooledObjs.Count; i++)
        {
            dotPool.pooledObjs[i].SetActive(false);
        }

        passiveROM.lineRenderer.SetActive(false);
        passiveROM.lineRenderer2.SetActive(false);
        passiveROM.lineRenderer3.SetActive(false);
        passiveROM.lineRenderer4.SetActive(false);

        start_game = true;
        start_passive = false;
        //scoreDisp.SetActive(true);
        gameOverCanvas.SetActive(false);
        restartMenu.SetActive(false);
        chunks.SetActive(false);
        controller.SetActive(false);
        controllerCover.SetActive(false);
        markerSpawn.SetActive(false);
        chicken.SetActive(true);
        scenery.SetActive(true);
        //game.score = 0;
        game.g_Hit = 0;
        game.reset_Hit = 0;
        //game.scoreText.text = game.score.ToString();

        game.backgroundSound.Play();
    }

    public void restart_passive_button()
    {
        for (int i = 0; i < dragonPooler.pooledObjs.Count; i++)
        {
            dragonPooler.pooledObjs[i].SetActive(false);
        }

        for (int i = 0; i < dotPool.pooledObjs.Count; i++)
        {
            dotPool.pooledObjs[i].SetActive(false);
        }

        passiveROM.lineRenderer.SetActive(false);
        passiveROM.lineRenderer2.SetActive(false);
        passiveROM.lineRenderer3.SetActive(false);
        passiveROM.lineRenderer4.SetActive(false);

        start_passive = true;
        start_game = false;
        gameOverCanvas.SetActive(false);
        restartMenu.SetActive(true);
        chunks.SetActive(true);
        chicken.SetActive(false);
        controller.SetActive(true);
        controllerCover.SetActive(true);
        endpointsButton.SetActive(true);
        scenery.SetActive(false);
        game.backgroundSound.Stop();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (collidingObject || !other.GetComponent<Rigidbody>())
        {
            return;
        }

        else if (other.gameObject.name.Equals("food") || other.gameObject.name.Equals("drag1") || other.gameObject.name.Equals("drag2") || other.gameObject.name.Equals("drag3") || other.gameObject.tag.Equals("RACR") || other.gameObject.tag.Equals("C7") || other.gameObject.tag.Equals("T8") || other.gameObject.tag.Equals("STRN") || other.gameObject.tag.Equals("Chest") || other.gameObject.tag.Equals("RMELB") || other.gameObject.tag.Equals("RLELB") || other.gameObject.tag.Equals("RFA") || other.gameObject.tag.Equals("RUS") || other.gameObject.tag.Equals("RRS"))
        {
            collidingObject = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject != collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        

        if (calibrated)
        {
            RACR.SetActive(true);
            C7.SetActive(true);
            T8.SetActive(true);
            STRN.SetActive(true);
            CHEST.SetActive(true);
            RMELB.SetActive(true);
            RLELB.SetActive(true);
            RFA.SetActive(true);
            RUS.SetActive(true);
            RRS.SetActive(true);

            //shoulderjoint = GameObject.FindGameObjectWithTag("RACR");
        }
    }
}

