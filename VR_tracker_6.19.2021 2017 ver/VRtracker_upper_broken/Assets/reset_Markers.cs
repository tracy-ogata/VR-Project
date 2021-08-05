using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_Markers : MonoBehaviour {

    public SteamVR_TestThrow testThrow;


    // Use this for initialization
    public void reset_button () {
        testThrow.RACR.SetActive(false);
        testThrow.C7.SetActive(false);
        testThrow.T8.SetActive(false);
        testThrow.STRN.SetActive(false);
        testThrow.CHEST.SetActive(false);
        testThrow.RMELB.SetActive(false);
        testThrow.RLELB.SetActive(false);
        testThrow.RFA.SetActive(false);
        testThrow.RUS.SetActive(false);
        testThrow.RRS.SetActive(false);

        testThrow.racr_edit = false;
        testThrow.c7_edit = false;
        testThrow.chest_edit = false;
        testThrow.rfa_edit = false;
        testThrow.rrs_edit = false;
        testThrow.rus_edit = false;
        testThrow.rmelb_edit = false;
        testThrow.rlelb_edit = false;
        testThrow.strn_edit = false;
        testThrow.t8_edit = false;



    }
	

}
