# Simple Shape REST API


**NOTE:** My solution might look more complex than it should be because I want to show that I can do an architecture which follows Clean Architecture ideas. 

I can make this implementation simpler if I need to. To make it simpler, I could have used only one model being passed from the Controllers to the Services, to the Repositories. But an implementation like that will make things harder to manage in the long run. (please refer to ["Is Layering Worth the Mapping?"](https://blog.ploeh.dk/2012/02/09/IsLayeringWorththeMapping/) by Mark Seemann)


## Sample Use:

### Get All

```
GET "https://localhost:44304/Shapes"`
```

Response body:

``` json
[
  {
    "type": "circle",
    "radius": 4,
    "area": 50.26548245743669,
    "circumference": 25.132741228718345,
    "id": "b0231f0c-9ccf-4f20-8322-c8ff8c80929e"
  },
  {
    "type": "line",
    "length": 3,
    "area": 3,
    "perimeter": 3,
    "id": "3fd23d3d-5c65-470e-861e-d00e79d88517"
  },
  {
    "type": "rectangle",
    "length": 6,
    "width": 7,
    "area": 42,
    "perimeter": 26,
    "id": "20fa1895-b973-45bd-9b9a-a5c6fe90c1d3"
  },
  {
    "type": "square",
    "side": 5,
    "area": 25,
    "perimeter": 20,
    "id": "411e0500-2b3c-450d-baee-e1b2964ed912"
  }
]
```

### Get

```
GET "https://localhost:44304/Shapes/411e0500-2b3c-450d-baee-e1b2964ed912"
```
	
Response body:

``` json
{
  "type": "square",
  "side": 5,
  "area": 25,
  "perimeter": 20,
  "id": "411e0500-2b3c-450d-baee-e1b2964ed912"
}
```


### Create (POST)

```
POST "https://localhost:44304/Shapes"
{
    "type": "rectangle",
    "length": 123,
    "width": 456
}

```

Response body:

``` json
{
  "type": "rectangle",
  "length": 123,
  "width": 456,
  "area": 56088,
  "perimeter": 1158,
  "id": "0c553c2e-9e27-4395-a423-0eef6546df68"
}
```

Response headers:

```
 location: https://localhost:44304/Shapes/0c553c2e-9e27-4395-a423-0eef6546df68 
```


### Update (PUT)

```
PUT "https://localhost:44304/Shapes/0c553c2e-9e27-4395-a423-0eef6546df68"
```

Response body:

```
{
  "type": "rectangle",
  "length": 987,
  "width": 654,
  "area": 645498,
  "perimeter": 3282,
  "id": "0c553c2e-9e27-4395-a423-0eef6546df68"
}
```