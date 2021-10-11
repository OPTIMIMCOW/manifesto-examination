# manifesto-examination

# Poster
- Time taken: approx 3 hrs.
- Instructions: Drag Poster.html file into an internet browser window.
- Tested on Google Chrome 1920x1080 screen @ 100% 

# ATM 
- Time taken: approx 12hrs.
- Instructions: 
- Assumptions/ Approach: 
1) Data input is all rows of data ie not line by line interaction with client side so chose a json input as deserialise to an array is simple.
2) Assume less than 60k rows of data between atm refil (100ppl per day x 10 rows of transactions x 30 days = 30k) so Int32 used for counter. 
3) Assume structure of data always valid eg the account details will always contain 3 pieces of information and a pin can only be 4 numbers only etc.
4) Use of classes for atm and account is basic and only really used to make code easier to read as I generally done need much persistant data. 