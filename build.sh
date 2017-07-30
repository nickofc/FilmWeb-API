#!/usr/bin/env bash

#exit if any command fails
set -e

artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then  
  rm -R $artifactsFolder
fi

dotnet restore

# Ideally we would use the 'dotnet test' command to test netcoreapp and net451 so restrict for now 
# but this currently doesn't work due to https://github.com/dotnet/cli/issues/3073 so restrict to netcoreapp
# FilmWeb-API/FilmWebAPI/UnitTestProject1/UnitTestProject1.csproj
# FilmWeb-API/FilmWebAPI/FilmWebAPI/FilmWebAPI.csproj

dotnet test FilmWeb-API/FilmWebAPI/FilmWebAPI/FilmWebAPI -c Release -f netcoreapp1.0

# Instead, run directly with mono for the full .net version 
dotnet build FilmWeb-API/FilmWebAPI/FilmWebAPI/FilmWebAPI -c Release -f net451

mono \  
FilmWeb-API/FilmWebAPI/FilmWebAPI/FilmWebAPI/bin/Release/net451/*/dotnet-test-xunit.exe \
FilmWeb-API/FilmWebAPI/FilmWebAPI/FilmWebAPI/bin/Release/net451/*/TEST_PROJECT_NAME.dll

revision=${TRAVIS_JOB_ID:=1}  
revision=$(printf "%04d" $revision) 

dotnet pack FilmWeb-API/FilmWebAPI/FilmWebAPI/FilmWebAPI -c Release -o ./artifacts --version-suffix=$revision  
