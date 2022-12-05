# Drilling Fluid Additives API

My API provides basic information about additives used in drilling fluids to perform one or more specific functions.

My database has two tables:
```
AdditipeType
Additive
```
![diagram](https://user-images.githubusercontent.com/73149523/205687464-f921cd05-1b8b-43ee-b0c1-913b0f603bf4.png)

## AdditiveType Endpoint
|API|Description|Request Body|
|---|---|---|
|`GET /api/additivetype`|Gets all the types of additives|None|

## Additive Endpoints
|API|Description|Request Body|
|---|---|---|
|`GET /api/additive`|Gets all the additives|None|
|`GET /api/additive/id`|Gets an additive by id|None|
|`POST /api/additive`|Add a new additive|Additive Object|
|`PUT /api/additive/id`|Updates a record|Additive Object|
|`DELETE /api/additive/id`|Deletes a record|None|

## Response body

### GET Method

 ```json
{
    "statusCode": 200,
    "statusDescription": "Additives in database",
    "resultData": [
        {
            "id": 1,
            "additiveName": "Barite",
            "waterBased": true,
            "oilBased": true,
            "info": "Increases the density of any drilling fluid system up to 20 lb/gal while still maintainng good rheological properties.",
            "additiveTypeId": 4
        },
        {
            "id": 2,
            "additiveName": "Caustic Soda",
            "waterBased": true,
            "oilBased": false,
            "info": "Strong base which is extremely soluble in water. Used to maintain or increase pH and precipitates magnesium and suppresses calcium in high hardness waters such as seawater, reduces corrosion and neutralizes acid gases such as carbon dioxide and hydrogen sulfide.",
            "additiveTypeId": 1
        }
    ]
 }
 ```


### POST Method

 ```json
{
    "statusCode": 201,
    "statusDescription": "Record created successfully",
    "resultData": {
        "id": 21,
        "additiveName": "Additive X",
        "waterBased": true,
        "oilBased": false,
        "info": "Increases pH.",
        "additiveTypeId": 1
    }
}
 ```
### PUT Method

 ```json
{
    "statusCode": 200,
    "statusDescription": "Record updated successfully",
    "resultData": {
        "id": 21,
        "additiveName": "Additive X",
        "waterBased": true,
        "oilBased": true,
        "info": "Increases pH.",
        "additiveTypeId": 1
    }
}
 ```
### DELETE Method

 ```json
{
    "statusCode": 200,
    "statusDescription": "The additive with id 21 was deleted",
    "resultData": null
}
 ```





