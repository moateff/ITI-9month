# setup
# update docker
sudo apt update
sudo apt install --only-upgrade docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin

# check version
docker --version

# add user to docker group
sudo usermod -aG docker $USER

# check user added to docker group
group

# login to docker hub
docker login

# task1
# run the container nginx 
docker run -d --name my-nginx -p 80:80 nginx

# check the container status 
docker ps

# start the stopped container 
docker stop my-nginx
docker start my-nginx

# remove the container 
docker rm my-nginx

# remove the image 
docker rmi nginx

# task2
# run container ubuntu in an interactive mode 
docker run -it --name my-ubuntu ubuntu /bin/bash

# run the following command in the container “echo docker” 
echo docker

# open a bash shell in the container and touch a file named hello-docker 
touch hello-docker
ls

# stop the container and remove it. Write your comment about the file hello-docker 
docker stop my-ubuntu
docker rm my-ubuntu

# The file hello-docker is deleted when the container is removed because container filesystems are ephemeral. 
# Any data stored inside the container is lost unless it is saved in a Docker volume or bind mount.

# remove all stopped containers 
docker rm $(docker ps -aq)

# task3
# deploy a MySQL database called app-database. Use the mysql latest image, and use the 
# -e flag to set MYSQL_ROOT_PASSWORD to P4sSw0rd0!. The container should run in the 
# background. 
docker run -d \
  --name app-database \
  -e MYSQL_ROOT_PASSWORD='P4sSw0rd0!' \
  mysql:latest


# task4
# run the image Nginx ▪ Add html static files to the container and make sure they are accessible  
# commit the container with image name IMAGE_NAME 
docker run -d --name my-nginx -p 8080:80 nginx

cd /usr/share/nginx/html
echo "<h1>Hello from Nginx Container</h1>" > index.html

curl http://localhost:8080

docker commit my-nginx my-nginx

# task5
# create 2 nginx containers with 2 different network of type bridge, enter to one of them and  
# use curl command to view the content of the other container.
docker network create net1
docker network create net2

docker run -d --name nginx1 --network net1 nginx
docker run -d --name nginx2 --network net2 nginx

docker exec -it nginx1 bash

curl http://172.19.0.2