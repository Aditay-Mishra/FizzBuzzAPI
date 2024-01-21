# FizzBuzzAPI
Simple .net web api project.
Requirements to run the code locally : 
1. Visual Studio Code(Visual studio can also work)
2. .NET8.0 SDK(https://dotnet.microsoft.com/en-us/download)
   
Steps to build and run:
1. Clone the project
2. Open the root "FizzBuzz" folder with VSCode(Visual Studio Code) by right clicking the folder icon and open with VSCode
     alternatively open VSCode > File menu > Open Folder > Select "FizzBuzz" folder
3. Go to "Terminal" menu > New Terminal
4. In Bottom Terminal pane type the following command :
   dotnet run
5. If it asks to trust certificate, accept it.
6. You will get the localhost server url and port in Terminal pane. (For example : "Now listening on: http://localhost:5088")
7. While the server is running, you can send api requests on above url by any tool.
8. For example : In browser window, open http://localhost:5088/swagger
     It will show both the apis and you can send requests from here too.
   The two api are:
   a. /FizzBuzz/convertToFizzBuzz with request parameters(to be sent with url e.g. http://localhost:5088/FizzBuzz/convertToFizzBuzz?firstNumber=1&secondNumber=5&limit=10&stringToReplaceMultipleOfFirstNumber=a&stringToReplaceMultipleOfSecondNumber=b) :
     firstNumber
     secondNumber
     limit
     stringToReplaceMultipleOfFirstNumber
     stringToReplaceMultipleOfSecondNumber
        Return Type : output string formatted according to Fizz Buzz problem statement
  b. /FizzBuzz/mostFrequentRequest with no parameters
        Return Type : a string containing most frequent Request and its hitcount
        Request string including above parameters

9. To exit the server process : Press Ctrl+C in the same Terminal
