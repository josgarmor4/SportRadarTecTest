# SportRadarTecTest
Tecnical test SportRadar

Modelate object match

	- Home team (string)
	- Away team (string)
	- Home score (string)
	- Away score (string)
	- ToString method return "HomeTeamName - AwayTeamName: HomeScore - AwayScore"

Modelate object WCScoreBoard

	- Structure to save in memory the list of matches (dictionary dictionary<id,match>)
	- id to identificate each match (int)

	-Funcionality
		- Start match (initial score 0 - 0)
		- Finish match (delte match from structure of WCScoreBoard)
		- Update match (Update the match score)
		- Sumary of matches (return a sumary of matches order by total score, if same total score, order by most recently added)

Assumptions

	- Matches data received are correct
	- Score for home or away team can't be negative (this case will be controlate for exception)
	- Name for home or away team can't be null or empty (this case will be controlate for exception)
