# TestApps
## Getting Started

The project has been created in Visual Studio 2020.
### Folder Structure
DataBase folder contains script needed to create test database and all the stored procedures used.
ProductWebApp folder contains all the projects and whole solution.

### Prerequisites

1.IIS web server

2.SQL Management Studio



### Solution structure
Solution consist of three components : 1. Console Application for bulk upload of product
                                     : 2. Mvc Web Applicationm following repository pattern
									 : 2. Console Application for Word search

### Running the application
We need these files in the temp folder
1. Products.xlsx  (C:\Temp\Products.xlsx)
2. words.txt  (C:\Temp\words.txt

Web application need to be hosted on IIS( using port 802)
http://localhost:802/ProductWebApp/
API documentation can be view in swagger(http://localhost:802/ProductWebApp/swagger/ui/index#/Product)


