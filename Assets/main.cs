using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;  
using System;
using UnityEngine.UI;
using System.Linq;


public class main : MonoBehaviour {


	public Text payday;
	public Text balance;
	public Text Result;
public double rate;
int Year = System.DateTime.Now.Year;
 int Month = System.DateTime.Now.Month;
 int Day = System.DateTime.Now.Day;
 int Hour = System.DateTime.Now.Hour;
int Min = System.DateTime.Now.Minute;




	// Use this for initialization
	void Start () {
//		Debug.Log(Year+"-"+"-"+sysHour+"-"+Day+"-"+hour+"-"+min);



	}
	
	// Update is called once per frame
	void Update () {
		
	}

public void procs()
{
int pmin= 1;
int phour=0;

string[] dates = payday.text.Split('-');
//Debug.Log(dates[2]);15-10-2017

int pday=Convert.ToInt32(dates[0]);
int pmonth=Convert.ToInt32(dates[1]);
int pyear=Convert.ToInt32(dates[2]);

//Debug.Log(pyear);


timeleft(pday,pmonth,pyear);

}

int mleft;	

public void timeleft(int pday,int pmonth,int pyear)
{


mleft=((pyear-Year)*525600)+((pmonth-Month-1)*43200)+((24-Hour)*60)-Min;

if (pday-Day<0)
{

	mleft=mleft+((pday+(30-Day))*1440);
}
else
{

mleft=mleft+(pday-Day)*1440;

}


Debug.Log(mleft);
//Debug.Log(crease(mleft));

crease(mleft);

InvokeRepeating("increase", 1f, 60f);
}



public void crease(int mleft){

double blc=Convert.ToDouble(balance.text);
double left = Convert.ToDouble(mleft);

rate = blc/left;

//Debug.Log(blc);
Debug.Log("rate");
Debug.Log(rate);
//return rate;
}

double val =0;

public void increase()
{

val=val+rate;
Debug.Log(val);
Result.text=val.ToString();

}

}
