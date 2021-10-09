# manifesto-examination

Poster- time taken: approx 3 hrs. 

# ATM 

Approach:

I initially thought to create class for each account and lot the ballance and transactions but I became 
doubtful about whether storing this information on the ATM was secure and why I needed to do it as the 
question doesnt suggest any foulplay and I am given the account pin/ ballance on each use of the ATM so 
I opted to initialise scoped variables instead and not create a class.
	// assume json input (an array representing each row)
	// deserialise json into an array
	// scan through line by line: 
	// make global variable for total cash in program.cs
	// global variable to track list index worked through
	// use for loop for list.count total number of rows. 
	// For each for per customer: scope variables: 
		// pin
		// user input password
		// ballance
		// (update row number) and use functions to verify each line has correct data. 
	// 4) method to authenticate pin number if true proceed, else return ACCOUNT_ERR
	// for each for each transaction (use boolean for "" row found)
	// switch case based on first element of each line (use functions to verify line)
	// if W check if withdrawal is acceptable if true proceed, else return FUNDS_ERR 
	// update ballance, return ballance (increment row counter)
	// if B return acc ballance (increment row counter)
	// if "" exit for loop