using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;  
using System;
using UnityEngine.UI;
using System.Linq;
public class History : MonoBehaviour {

public Text None;
public Text None1;
public Text None2;
public Text None3;
public Text None4;
public Text None5;
public Text None6;

public Text Moneyleft;


	// Use this for initialization
	void Start () {
	

None.text=" ";
None1.text=" ";
None2.text=" ";
None3.text=" ";
None4.text=" ";
None5.text=" ";
None6.text=" ";

Text[] txt = new Text[10];

txt[0]=None;
txt[1]=None1;
txt[2]=None2;
txt[3]=None3;
txt[4]=None4;
txt[5]=None5;
txt[6]=None6;





string Receipts = System.IO.File.ReadAllText(Application.persistentDataPath+"History.txt");


string[] each = Receipts.Split(';');

for (int i = 0; i < each.Count(); i++)
        {
if(each[i]!=null)

{

txt[i].text=each[i];
	
}

        }



string Rbalance = System.IO.File.ReadAllText(Application.persistentDataPath+"RealBalance.txt");

Moneyleft.text ="Real Balance:"+Rbalance+" TL";





}
	
public void Back()
{

Application.LoadLevel("EasyBal");

}




public void Undo()
{
string Rcp = System.IO.File.ReadAllText(Application.persistentDataPath+"History.txt");

//string fixed;
string[] Ech = Rcp.Split(';');


//Debug.Log(Ech.Count().ToString());


//Debug.Log();


string balance = System.IO.File.ReadAllText(Application.persistentDataPath+"balance.txt");


string Rbalance = System.IO.File.ReadAllText(Application.persistentDataPath+"RealBalance.txt");


Text[] txt = new Text[10];

txt[0]=None;
txt[1]=None1;
txt[2]=None2;
txt[3]=None3;
txt[4]=None4;
txt[5]=None5;
txt[6]=None6;


int number = Ech.Count()-2;



//Debug.Log("sunual"+txt[number].text);

string[] Erlich = Ech[number].Split('T');

//string[] vrals = Ech[number].Split("TL");

double amount = Convert.ToDouble(Erlich[0]); 

double rebal = Convert.ToDouble(Rbalance)+amount;

double dbalance = Convert.ToDouble(balance);


System.IO.File.WriteAllText(Application.persistentDataPath+"balance.txt", (dbalance+amount).ToString());




System.IO.File.WriteAllText(Application.persistentDataPath+"RealBalance.txt", rebal.ToString());



Rcp="";

for (int i = 0; i < Ech.Count()-2; i++)
        {

Rcp = Rcp+Ech[i]+";";
       
        }


System.IO.File.WriteAllText(Application.persistentDataPath+"History.txt", Rcp);
Debug.Log("done");

Application.LoadLevel("history");

}



	// Update is called once per frame
	void Update () {
		
	}
}
