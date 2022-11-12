#You may need to run the following command before installing packages:

apt-get update
#If you’re running in a Dockerfile, then you have to follow the below command:
apt-get -y install curl

#Finally, to suppress the std o/p use -qq. Example
apt-get -qq -y install curl