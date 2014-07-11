using UnityEngine;
using System.Collections;

public class Profile : MonoBehaviour {
	public string role;//good or bad guy?
	public string lName;
	public int age;
	public string profession;
	
	public string polAff;
	public string crimHist;
	public string recAct;

	public Profile(){
		role = "none";
		lName = "";
		age = 0;
		profession = "";

		polAff = "";
		crimHist = "";
		recAct = "";
	}

	public void setProfile(string ln, int a, string p, string pa, string ch, string ra){
		setLname(ln);
		setAge(a);
		setPolAff(pa);
		setCrimHist(ch);
		setRecAct(ra);
		setProfession(p);
	}

	public void setRole(string r){
		role = r;
	}

	public void setLname(string ln){
		lName = ln;
	}

	public void setAge(int a){
		age = a;
	}

	public void setPolAff(string pa){
		polAff = pa;
	}

	public void setCrimHist(string ch){
		crimHist = ch;
	}

	public void setRecAct(string ra){
		recAct = ra;
	}

	public void setProfession(string p){
		profession = p;
	}

	public string getRole(){
		return role;
	}
}
