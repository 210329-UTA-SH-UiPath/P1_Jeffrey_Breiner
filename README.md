# P1_Jeffrey_Breiner
# PizzaBox
This project is a pizza ordering website that lets users place orders for pizzas, see their previous orders, and view various overviews of all the orders previously placed. 

Users may choose between several premade pizzas or create their own pizza to add to an order. Multiple pizzas may be added to an order, but each order may not contain more than 50 pizzas or $250 worth of pizzas. Each user is also limited to one order every 2 hours and 1 order from each store every 24 hours.

Users can enter their name to view all orders they have previously placed. There is also a page for viewing all pizzas placed by all users and a page for viewing a revenue report for each store, with both weekly and monthly filtering.

All orders are stored in a database hosted through Microsoft Azure.

# Technologies Used
* C#
* SQL Server
* ASP.NET Core Web API
* Entity Framework Core
* Asp.Net Core MVC
* .Net core
* Azure SQL Databases

# How to set up

## Hosting
1. Launch two instances of Visual Studio
1. In one instance, open and run PizzaBox.Api.sln. This must be run first
1. In the other instance, open and run PizzaBox.FrontEnd.sln

## Using
1. Once PizzaBox.FrontEnd.sln is run, a web page should open up in the browser set to https://localhost:44305
1. From here, the user can click on "Place An Order" to go through the order placement process, "See Your Orders" to view their previously placed orders, or "Manager's Seat" to view all previous orders and view the revenue report for each store.

# Contributors
Jeffrey Breiner

# MIT License

Copyright (c) 2021 Jeffrey Breiner

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
