@ECHO OFF 
:: This batch file runs sonarqube
TITLE SonarQube
ECHO Please wait... Runing sonarqube Commands.
ECHO ==========================
ECHO Sonar START
ECHO ============================
dotnet sonarscanner begin /k:"Investiment" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="sqp_ce1c576c15a3cf876a85a5e83389e53099e0bd26"
ECHO ============================
ECHO BUILD
ECHO ============================
dotnet build
ECHO ============================
ECHO TEST
ECHO ============================

ECHO ============================
ECHO END
ECHO ============================
dotnet sonarscanner end /d:sonar.login="sqp_ce1c576c15a3cf876a85a5e83389e53099e0bd26"
PAUSE