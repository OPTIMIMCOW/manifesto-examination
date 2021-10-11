# manifesto-examination

# Poster
- Time taken: approx 3 hrs.
- Instructions: Drag Poster.html file into an internet browser window.
- Tested on Google Chrome 1920x1080 screen @ 100% 

# ATM 
- Time taken: approx 12hrs.
- Instructions: 
1) Clone rep to directory.
2) Open ATM.sln file located here ("\manifesto-examination\manifesto-examination\ATM\ATM\ATM.sln") in ide. 
3) Build project - console will open with example cases outputs shown. 
4) Input example data is a TestFile.json found in "\manifesto-examination\manifesto-examination\ATM\ATM\TestFile.json"
and is read into the code in Program.cs line 12. Either alter TestFile.json or alter the path in Program.cs to an alternative json file. 

- Assumptions/ Approach: 
1) Data input is all rows of data ie not line by line interaction with client side so chose a json input as deserialise to an array is simple.
2) Assume less than 60k rows of data between atm money refill (100ppl per day x 10 rows of transactions x 30 days = 30k) so Int32 used for counter. 
3) Assume structure of data may not always be valid.
4) Instantiate atm class in program and create accounts/ handle transactions inside atm. Create static utility and validation classes. 
5) On validation of incorrect data I terminate processing. This makes sense if we are working though all the data row by row but not if this was during
use with a user. I assumed the former initially so stayed consistent. 
5) Did not implement logger but appreciated that a logger would be useful to trace issues.