@ECHO OFF 
:: This batch file runs sonarqube
TITLE SonarQube
ECHO Please wait... Runing sonarqube Commands.
ECHO ==========================
ECHO Sonar START
ECHO ============================
dotnet sonarscanner begin /k:"Investiment" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="sqp_644c078dae726b65bb8ef47ae9620207c28414b0" /d:sonar.cs.opencover.reportsPaths=Library.Test\coverage.opencover.xml  
ECHO ============================
ECHO BUILD
ECHO ============================
dotnet build
ECHO ============================
ECHO TEST
ECHO ============================
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover 
ECHO ============================
ECHO END
ECHO ============================
dotnet sonarscanner end /d:sonar.login="sqp_644c078dae726b65bb8ef47ae9620207c28414b0"
PAUSE