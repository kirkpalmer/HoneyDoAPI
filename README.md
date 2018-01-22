# HoneyDoAPI


Honey Do API is a sample currently using an In Memory Database:

It has the following API calls:
GET ALL Honey do Item: GET http://localhost:39929/api/honeydo
Get a particular Item: GET http://localhost:39929/api/honeydo/{id} (where {id} is the number you are requesting)

Create an new Item: POST http://localhost:39929/api/honeydo
available parameters: Name(string), Description(string), StartDate(datatime), ImportanceRank(int)
example json:
       {"name": "Get Food",
        "description": "Remember Coupon",
        "startDate": "2018-01-23",
        "importanceRank": 1}
Update an Item: PUT http://localhost:39929/api/honeydo/{id}
available parameters: Name(string), Description(string), Status(string){OPEN, COMPLETE, CANCELED, FUTURE}, ImportanceRank(int)
example json:
{"id": 2,
        "name": "Get Car Washed Again",
        "status": {
            "type": "COMPLETE"
        },
        "importanceRank": 1
    }
Delete an Item: DELETE http://localhost:39929/api/honeydo/{id}
Removes the item from Memory

Potential Changes:
1. Add Database so Items can be stored.
2. Change Importance Property to ValueObject with fixed rnage of numbers.
3. Convert Status to fixed list to choose from.
4. Change Services to Mediator Pattern. for cleaner code and testing.
5. more validation of data coming from json
6. Remove the Delete and instead archive records once they are canceled or completed.
