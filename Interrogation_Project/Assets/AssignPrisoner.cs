using UnityEngine;
using System.Collections;

public class AssignPrisoner : MonoBehaviour {

	public Prisoner [] prisoner;
	public int crim1;
	public int crim2;
	public int activ1;
	public int activ2;

	public AssignPrisoner()
	{
		
		//make sure the are differentiable 
		activ1 = -1;
		activ2 = -1;
		//Random.seed = (int)System.DateTime.Now.Ticks;
		//crim1 = Random.Range(0,4);
		//crim2 = Random.Range (0,4);

		crim1 = -1;
		crim2 = -1;
		//4 prisoners + initialization
		prisoner = new Prisoner[4];


		for(int i = 0; i < prisoner.Length; i++)
		{
			prisoner[i] = new Prisoner();
		}

		prisoner[0].setProfile("Lahti", 25,"App Startup CEO", "Independent", "They were acquitted from being charged with involvement in underground hacker activity",
		                       "They just bought a house under a false identity with gray market income.");
		prisoner[1].setProfile("Kaplan", 33,
		                       "Assistant professor of English literature", "Left Wing", "Unlawful association, parking tickets"
		                       , "Their gathering for leftist-minded academics has gained popularity recently");
		prisoner[2].setProfile("Crowe",28,"Specialized computer hardware store owner","Moderte left wing","They are under investivation for smuggling illegal computer hardware from China", "They are active in online forms with some anti-capitalist interests.");
		prisoner[3].setProfile("Oliveiro", 42,"Sales clerk at Best Buy", "Unknown", "They are connected to previous hacker attack","They have used a lot of bandwidth recently; they bought high-end computer parts");

		//getting random roles with corresponding predefined information.
		//assignRole(); this was original
	//	assignInformation(); //this was original

	}

	public void assignRole(int randNum1, int randNum2) //randomize role
	{
		crim1 = randNum1;
		crim2 = randNum2;
		do{
			crim2 = Random.Range(0,4);
		}while(crim1 == crim2);

		for(int i = 0; i < 4; i++)
		{
			prisoner[i].p.setRole("Activist");
		}

		prisoner[crim1].p.setRole("Hacker");
		prisoner[crim2].p.setRole("Hacker");

	}


	public void assignInformation(){
	
		setHackerFacts(crim1, crim2);
		setHackerRumors(crim1, crim2);


		for(int i = 0; i < 4; i++)
		{
			if( (i != crim1) && (i != crim2)){
				activ1 = i;
			}
		}

		for(int j = 0; j < 4; j++)
		{
			if( (j!=activ1)&&((j != crim1) && (j != crim2))){
				activ2 = j;
			}
		}

		setActivistFacts(activ1, activ2);
		setActivitstRumors(activ1, activ2);


	}

	void setHackerFacts(int i, int j)
	{
		prisoner[i].f.setHow("Planting false info");
		prisoner[i].f.setWho("Mei Yamoto");
		prisoner[i].f.setWhen("I don't know");
		prisoner[i].f.setWhere("Stock Exchange");
		
		prisoner[j].f.setHow("Planting false info");
		prisoner[j].f.setWho("I don't know");
		prisoner[j].f.setWhen("Wednesday 6PM");
		prisoner[j].f.setWhere("Stock Exchange");
	}

	void setHackerRumors(int i, int j)
	{
		prisoner[i].r.setHow("Cutting off communications");
		prisoner[i].r.setWho("Mist");
		prisoner[i].r.setWhen("Monday 1PM");
		prisoner[i].r.setWhere("Libery Bank HQ");
		
		prisoner[j].r.setHow("Cutting off communications");
		prisoner[j].r.setWho("Sarah Jackson");
		prisoner[j].r.setWhen("Friday 2PM");
		prisoner[j].r.setWhere("Libery Bank HQ");
	}

	void setActivistFacts(int i, int j)
	{
		prisoner[i].f.setHow("I don't know");
		prisoner[i].f.setWho("Mei Yamoto");
		prisoner[i].f.setWhen("I don't know");
		prisoner[i].f.setWhere("I don't know");
		
		prisoner[j].f.setHow("I don't know");
		prisoner[j].f.setWho("I don't know");
		prisoner[j].f.setWhen("Wednesday 6PM");
		prisoner[j].f.setWhere("Stock Exchange");
	}
	
	void setActivitstRumors(int i, int j)
	{
		prisoner[i].r.setHow("Cutting off the power");
		prisoner[i].r.setWho("Michael Deer");
		prisoner[i].r.setWhen("Wednesday 6PM");
		prisoner[i].r.setWhere("Libery Bank HQ");
		
		prisoner[j].r.setHow("Planting false info");
		prisoner[j].r.setWho("Mist");
		prisoner[j].r.setWhen("Wednesday 6PM");
		prisoner[j].r.setWhere("Libery Bank HQ");
	}
}
