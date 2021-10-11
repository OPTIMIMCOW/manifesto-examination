# manifesto-examination

# Poster
- Time taken: approx 3 hrs.
- Instructions: Drag Poster.html file into an internet browser window.
- Tested on Google Chrome 1920x1080 screen @ 100% 

# ATM 
- Time taken: approx 14hrs.
- Instructions: 
1) Clone repo to directory.
2) Open ATM.sln project file located here "\manifesto-examination\ATM\ATM\ATM.sln" from your ide. 
3) Build project - console will open with example cases outputs shown. 
4) Input example data is a TestFile.json found in "\manifesto-examination\ATM\ATM\TestFile.json"
and is read into the code in Program.cs line 12. Either alter TestFile.json or alter the path in Program.cs to an alternative json file. 

- Assumptions/ Approach: 
1) Data input is all rows of data in one go ie not line by line interaction with client side so I chose a json input as deserialising to an array is simple.
2) Assume less than 60k rows of data between atm money refill (100ppl per day x 10 rows of transactions x 30 days = 30k) so Int32 used for row counter. 
3) Assume structure of data may not always be valid so validation implemented.(Note I implemented this during refactor not initially). 
4) I Instantiate Atm class in Program.cs and create Accounts + handle transactions inside of the Atm object. I Created static utility and validation helper classes. 
5) On validation of incorrect data I terminate processing. This makes sense if we are working though all the data row by row but not if this was during
use with a user on the client side. I assumed the former initially so stayed consistent. 
5) Did not implement logger but appreciated that a logger would be useful to trace issues.