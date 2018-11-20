﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class StageManager : MonoBehaviour {
    public static bool[] myLevel = { true, false, false, false };

    // sql 인스턴스 변수
    IDbConnection dbc;
    IDbCommand dbcm;        //SQL문 작동 개체
    IDataReader dbr;        //반환된 값 읽어주는 객체

    // Use this for initialization
    void Start () {
        string constr = "URI=file:character.db";

        dbc = new SqliteConnection(constr);
        dbc.Open();
        dbcm = dbc.CreateCommand();

        dbcm.CommandText = "SELECT stage, clearCount from Stage";
        dbr = dbcm.ExecuteReader();

        while (dbr.Read())
        {
            int dbStage = dbr.GetInt16(0);
            int dbClear = dbr.GetInt16(1);
            Debug.Log("stage" + dbStage + " : " + dbClear);
            if (dbClear > 0)
                if (myLevel.Length > dbStage)
                {
                    myLevel[dbStage] = true;
                }
        }

        for (int i = 0; i < myLevel.Length; i++)
        {
            Debug.Log("Level" + i + " : " + myLevel[i]);
        }

        /* DB 연결 정보들을 초기화 합니다. */
        dbr.Close();
        dbr = null;
        dbcm.Dispose();
        dbcm = null;
        dbc.Close();
        dbc = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
