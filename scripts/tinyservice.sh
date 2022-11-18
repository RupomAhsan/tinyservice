#!/bin/bash
dotnet run --project src/TinyService

# To install docker Image
docker build -t tinyservice .

# kubectl alias command

Set-Alias -Name k -Value kubectl 

# install ngnix
docker pull nginx

# Install alpine
docker pull alpine
