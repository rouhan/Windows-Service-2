1. Compile the code on VS 2015
2. Install the windows service using installutil

"C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe" "C:\Users\asad\Desktop\Task\Task4\WindowsService_HostAPI\WindowsService_HostAPI\bin\Debug\WindowsService_HostAPI.exe"

3. Go to start and type services.msc and find "WebAPISelfHosting" and start it.
4. It will create some logs in bin/debug/logs folder 
5. Open WebServiceCaller solution and Run for calling Self Host Service using Endpoint "http://localhost:8080/Values/GetString/"
6.The Result Ipaddress and HostName will fetch from Webservice and display.