using UnityEngine;
using System.Collections;

public class Prisoner {

	public Fact f;
	public Rumor r;
	public Profile p;
	//public enum role;

	public Prisoner()
	{
		f = new Fact();
		r = new Rumor();
		p = new Profile();
	}

	public void setProfile(string lName, int age,
	                       string profession, string polAff, string crimHist, string rectAct){
		p.setLname(lName);
		p.setAge(age);
		p.setProfession(profession);
		p.setPolAff(polAff);
		p.setCrimHist(crimHist);
		p.setRecAct(rectAct);
	}

	public void setRumor(string who, string when, string how, string where){
		r.setHow(how);
		r.setWhen(when);
		r.setWhere(where);
		r.setWho(who);
	}

	public void setFact(string who, string when, string how, string where){
		r.setHow(how);
		r.setWhen(when);
		r.setWhere(where);
		r.setWho(who);
	}

	public string outPut()
	{
		string str = "****Personal Info*** \n" + "\n Role: "+p.role+"\n Last Name: "+p.lName +"\n Age: "+ p.age + "\n Profession: "+p.profession
			+"\n Political Affiliation: "+p.polAff+"\n Criminal History: "+ p.crimHist+"\n Recent Activity: "+p.recAct+
				"\n ****Facts****"+"\n How: "+f.how+"\n When: " + f.when + "\n Where: " +f.where +"\n Who: " + f.who + 
				"\n ****Rumors***:"+ "\n How: "+r.how+"\n When: " + r.when + "\n Where: " +r.where +"\n Who: " + r.who; 
		return str;
	}

}
