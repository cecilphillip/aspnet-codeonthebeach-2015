ASP .NET MVC 6 Samples
================================


The demos in this repo were created for my talk at [Code On The Beach](https://www.codeonthebeach.com) 2015 "ASP .NET MVC 6 and the new .NET Web Stack". Feel free to fork, submit an issue if you have questions, or even send a pull request :D.

Getting Setup
-------------

######ASP .NET
The [ASPNET Home](https://github.com/aspnet/home#getting-started-on-windows) repo on Github should have what you need to get the ASP .NET 5 runtime installed on your machine.

The samples were written with beta6 of the runtime. Running **dnvm install 1.0.0-beta6** in your command prompt should pull down the correct version.



######Javascript
Some of the samples use Ecmascript 6 syntax so the project is setup to be transpiled using Babel. To get these working, you'll need to have NodeJS and NPM installed on your path. Navigate to the Demos folder from the command line and enter the following:

* npm install -g jspm@beta
* jspm install


Now you should be all set. Happy Coding
