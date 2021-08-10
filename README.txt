1. Start RDIChallengeAPI
2. user postman to call API on http://localhost:6000
3. To add a customer:
	Use POST
	Url: http://localhost:6000/api/Customers
	JSON Body Sample
	{
		"CustomerId": 123,
		"CardNumber": 4916898414075509,
		"CVV": 12345
	}	

	Sample return:
	{
		"registrationDate": "2021-08-10T01:53:57.9227681Z",
		"token": 23660975059021,
		"cardId": 1
	}

4. To validate a customer
	Use POST
	Url: http://localhost:6000/api/Validate
	JSON Body Sample
	{
		"CustomerId": 123,
		"CardId" : 2,
		"Token": 14843407196030,
		"CVV": 1234
	}

	It will return, true or false.