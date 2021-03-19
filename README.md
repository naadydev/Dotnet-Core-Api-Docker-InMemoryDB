# CrowdLending POC API

## Requirements
1- List of Funds with investment required
2- Click on a Fund and submit an amount (between 100€ and 10.000€) for a funding;
3- Can only submit an amount once per funding.
4- Should be prepared for horizontal scaling.

## Tech Stack
- .Net Core 3.1
**InMemoryDB Used For purpose of the POC**

## Endpoints
| URL | For | HTTP|
| ------ | ------ |------
| api/funds | Get All Funds |GET
| api/investments | Get All Users Investments |GET
| api/investments/{id} | Get User Investments by UserId |GET
| api/funds | add user investment |POST

## How To RUn
- ##### You can simply run using Visual studio 2019 and .net 3.1 installed
- ##### Add The Frontend URL in the CORS appsettings.js

- #### This Project support Docker so you can follow the following steps to run the api
```sh
    $> docker build -t crowdlendingpocapi .
    $> docker run -d -p 8080:80 --name clpocapi crowdlendingpocapi
```

