# Van's PC Builder API

Welcome to Van's PC Builder API! This web application provides a set of RESTful APIs to fetch data about computer parts, starting with CPUs. More components will be added soon.

## API Overview

The API allows users to retrieve information about different computer parts via HTTP requests. Currently, only CPU endpoints are available.

### Get All CPUs

Retrieve a list of all available CPUs in the database.

####  Endpoint:

GET https://vanpcbuilder.azurewebsites.net/api/CPU

#### Request Example:

GET /api/CPU 
Host: vanpcbuilder.azurewebsites.net

#### Response Example:

[
  {
    //TBD
  }
]

#### Response Codes:

200 OK

500 Internal Server Error: Something went wrong on the server.

#### Future Updates

GET All GPU

GET All RAM

GET All Internal Storage

More endpoints for detailed queries

#### How to Contribute

Fork the repository.

Create a new branch.

Make your changes.

Submit a pull request.

#### Contact

For any issues or feature requests, feel free to open an issue or contact me directly.

Stay tuned for updates and happy coding! 