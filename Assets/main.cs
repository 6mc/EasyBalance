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
	public Text down;
public double rate;
int Year = System.DateTime.Now.Year;
 int Month = System.DateTime.Now.Month;
 int Day = System.DateTime.Now.Day;
 int Hour = System.DateTime.Now.Hour;
int Min = System.DateTime.Now.Minute;




	// Use this for initialization
	void Start () {
//		Debug.Log(Year+"-"+"-"+sysHour+"-"+Day+"-"+hour+"-"+min);üü

if (!System.IO.File.Exists(Application.persistentDataPath+"lastlogin.txt"))
{
System.IO.File.WriteAllText(Application.persistentDataPath+"lastlogin.txt", "");

}
if (!System.IO.File.Exists(Application.persistentDataPath+"balance.txt"))
{
System.IO.File.WriteAllText(Application.persistentDataPath+"balance.txt", "0");

}


string check = System.IO.File.ReadAllText(Application.persistentDataPath+"lastlogin.txt");

string rbal = System.IO.File.ReadAllText(Application.persistentDataPath+"balance.txt");



if(check=="")
{



}
	else
{
int nowtime =( Month * 43200)+(Day*1440)+(Hour*60)+Min;
string[] lasttime = check.Split('-');
//Debug.Log(dates[2]);15-10-2017
double lbal=Convert.ToDouble(rbal);
int lmin=Convert.ToInt32(lasttime[4]);
int lhour=Convert.ToInt32(lasttime[3]);
int lday=Convert.ToInt32(lasttime[2]);
int lmonth=Convert.ToInt32(lasttime[1]);
int lyear=Convert.ToInt32(lasttime[0]);

int final=nowtime-((lmonth*43200)+(lday*1440)+(lhour*60)+lmin);

string realrate = System.IO.File.ReadAllText(Application.persistentDataPath+"Data.txt");

double fina = Convert.ToDouble(final);
double Rrate = Convert.ToDouble(realrate);

Debug.Log(final);

Result.text=((fina*Rrate)+lbal).ToString();


}

string lastlogin = Year+"-"+Month+"-"+Day+"-"+Hour+"-"+Min;



System.IO.File.WriteAllText(Application.persistentDataPath+"balance.txt", Result.text);

System.IO.File.WriteAllText(Application.persistentDataPath+"lastlogin.txt", lastlogin);





	}
	
	// Update is called once per frame
	void Update () {
		
	}

public void Spend()
{

double money = Convert.ToDouble(Result.text);
double pay  = Convert.ToDouble(down.text);

Result.text = (money-pay).ToString();

System.IO.File.WriteAllText(Application.persistentDataPath+"balance.txt", Result.text);


}



public void procs()
{
System.IO.File.WriteAllText(Application.persistentDataPath+"balance.txt", "0");


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
System.IO.File.WriteAllText(Application.persistentDataPath+"Data.txt", rate.ToString());
Result.text=val.ToString();




}

}
